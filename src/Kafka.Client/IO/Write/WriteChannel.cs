using Kafka.Client.Collections;
using Kafka.Client.Config;
using Kafka.Client.Logging;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Model.Internal;
using Kafka.Client.Net;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Kafka.Client.IO.Write
{
    internal sealed class WriteChannel :
        IDisposable
    {
        private readonly NodeId _nodeId;
        private readonly int _maxRequestSize;
        private readonly long _lingerMs;
        private readonly Task _recordsBuilderTask;
        private readonly Task _recordsAccumulatorTask;
        private readonly CancellationTokenSource _internalCts = new();
        private readonly BlockingCollection<ProduceCommand> _commandQueue = [];
        private readonly BlockingCollection<WriteBatch> _sendQueue = [];
        private readonly ManualResetEventSlim _sendBlocker = new(true);
        private readonly long _producerId;
        private readonly short _producerEpoch;
        private readonly short _acks;
        private readonly string? _transactionalId;
        private readonly ILogger _logger;
        private readonly INodeLink _protocol;
        private readonly TopicPartitionMap<int> _topicPartitionStates = [];
        private readonly Func<WriteBatch, CancellationToken, Task> _sendDelegate;

        public WriteChannel(
            NodeId nodeId,
            long producerId,
            short producerEpoch,
            INodeLink protocol,
            WriteStreamConfig producerConfig,
            ILogger logger
        )
        {
            _nodeId = nodeId;
            _producerId = producerId;
            _producerEpoch = producerEpoch;
            _transactionalId = producerConfig.TransactionalId;
            _acks = ParseAcks(producerConfig, logger);
            _sendDelegate = _acks switch
            {
                0 => SendBatchOneWay,
                _ => SendBatch
            };
            _protocol = protocol;
            _logger = logger;
            _maxRequestSize = producerConfig.MaxRequestSize;
            _lingerMs = producerConfig.LingerMs;
            _recordsBuilderTask = RunDispatch(_internalCts.Token);
            _recordsAccumulatorTask = RunCollector(_internalCts.Token);
        }

        public void Send(
            in ProduceCommand produceCommand,
            in CancellationToken cancellationToken
        )
        {
            _sendBlocker.Wait(cancellationToken);
            _commandQueue.Add(produceCommand, cancellationToken);
        }

        /// <summary>
        /// Collector loop.
        /// </summary>
        /// <param name="cancellationToken"></param>
        private Task RunCollector(
            CancellationToken cancellationToken
        )
        {
            Task.Yield();
            return Task.Run(() =>
            {
                _logger.LogInformation($"Node {_nodeId.Value} - Batch collector started.");
                try
                {
                    var carryOver = default(ProduceCommand?);
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        (var batch, var reason, carryOver) = Collect(
                            stopwatch,
                            carryOver,
                            cancellationToken
                        );
                        _logger.BatchCollected(batch.Count, reason);
                        if (batch.Count > 0)
                            _sendQueue.Add(batch, cancellationToken);
                    }
                }
                catch (OperationCanceledException) { }
                _logger.LogInformation($"Node {_nodeId.Value} - Batch collector stoppped.");
            }, CancellationToken.None);
        }

        /// <summary>
        /// Collects items into an existing batch from queue.
        /// If an item would overflow the buffer size then it is returned.
        /// </summary>
        /// <param name="carryOver">Possible carry over from previous fill.</param>
        /// <param name="cancellationToken">Cancellation token for linger time.</param>
        /// <returns></returns>
        private (WriteBatch Batch, BatchCollectReason Reason, ProduceCommand? Overflow) Collect(
            in Stopwatch stopwatch,
            in ProduceCommand? carryOver,
            in CancellationToken cancellationToken
        )
        {
            var produceCommand = carryOver ?? _commandQueue.Take(cancellationToken);
            var attributes = produceCommand.Record.Attributes;
            var batch = new WriteBatch(
                _maxRequestSize,
                0,
                attributes,
                _producerId,
                _producerEpoch
            )
            {
                produceCommand
            };
            stopwatch.Reset();
            while (true)
            {
                var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                if (elapsedMilliseconds >= _lingerMs)
                    return (batch, BatchCollectReason.MaxLingerMsReached, null);

                var millisecondTimeout = unchecked((int)(_lingerMs - elapsedMilliseconds));
                if (!_commandQueue.TryTake(out produceCommand, millisecondTimeout, cancellationToken))
                    return (batch, BatchCollectReason.MaxLingerMsReached, null);

                if (produceCommand.Record.Attributes != attributes)
                    return (batch, BatchCollectReason.AttributesChanged, produceCommand);

                var (added, _) = batch.Add(produceCommand);
                if (!added)
                    return (batch, BatchCollectReason.MaxSizeExceeded, produceCommand);
            }
        }

        public Task RunDispatch(
            CancellationToken cancellationToken
        )
        {
            Task.Yield();
            return Task.Run(async () =>
            {
                _logger.LogInformation($"Node {_nodeId.Value} - Dispatcher started.");
                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var batch = _sendQueue.Take(cancellationToken);
                        _logger.ProduceCommandDequeue(batch.Count);
                        await Task.Yield();
                        await _sendDelegate(
                            batch,
                            cancellationToken
                        ).ConfigureAwait(false);
                    }
                }
                catch (OperationCanceledException) { }
                catch (CorrelationIdException ex)
                {
                    _logger.CorrelationMismatch(ex);
                }
                _logger.LogInformation($"Node {_nodeId.Value} - Dispatcher stopped.");

            }, CancellationToken.None);
        }

        private async Task SendBatch(
            WriteBatch batch,
            CancellationToken cancellationToken
        )
        {
            var partitionStates = new Dictionary<TopicPartition, int>();
            var request = CreateProduceRequest(
                batch,
                partitionStates
            );
            var response = await _protocol.Produce(
                request,
                cancellationToken
            ).ConfigureAwait(false);
            FinalizeSend(
                batch,
                response
            );
            // TODO: This needs revisit, just hacked in.
            foreach (var state in partitionStates)
                _topicPartitionStates.Upsert(state.Key, state.Value);
        }

        private async Task SendBatchOneWay(
            WriteBatch batch,
            CancellationToken cancellationToken
        )
        {
            var partitionStates = new Dictionary<TopicPartition, int>();
            var request = CreateProduceRequest(
                batch,
                partitionStates
            );
            await _protocol.ProduceNoAck(
                request,
                cancellationToken
            ).ConfigureAwait(false);
            FinalizeSend(
                batch
            );
            // TODO: This needs revisit, just hacked in.
            foreach (var state in partitionStates)
                _topicPartitionStates.Upsert(state.Key, state.Value);
        }

        private ProduceRequestData CreateProduceRequest(
            in WriteBatch batch,
            in IDictionary<TopicPartition, int> partitionStates
        )
        {
            var topic = TopicName.Empty;
            var topicProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequestData.TopicProduceData>();
            foreach (var (topicPartition, produceRecords) in batch)
            {
                if (topic != topicPartition.Topic.TopicName)
                {
                    topicProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequestData.TopicProduceData>();
                    topic = topicPartition.Topic.TopicName;
                }
                var partitionProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequestData.TopicProduceData.PartitionProduceData>();

                _topicPartitionStates.Get(topicPartition, out int baseSequence);
                produceRecords.SetBaseSequence(baseSequence);
                var records = BuildRecords(
                    baseSequence,
                    produceRecords
                );
                baseSequence += records.Records.Count;
                partitionStates[topicPartition] = baseSequence;
                partitionProduceDataBuilder.Add(
                    new(
                        topicPartition.Partition,
                        ImmutableArray.Create(records),
                        []
                    )
                );
                topicProduceDataBuilder.Add(
                    new(
                        topicPartition.Topic.TopicName,
                        partitionProduceDataBuilder.ToImmutable(),
                        []
                    )
                );
            }
            // TODO: Compute actual timeout
            var requestTimeoutMs = 5000;
            return new ProduceRequestData(
                _transactionalId,
                _acks,
                requestTimeoutMs,
                topicProduceDataBuilder.ToImmutable(),
                []
            );
        }

        private static void FinalizeSend(
            in WriteBatch batch
        )
        {
            foreach (var (topicPartition, produceRecords) in batch)
                foreach (var command in produceRecords)
                    FinalizeSend(command, Offset.Unset, ApiError.None, "");
        }

        private static void FinalizeSend(
            in WriteBatch batch,
            in ProduceResponseData response
        )
        {
            foreach (var topic in response.ResponsesField)
            {
                foreach (var partition in topic.PartitionResponsesField)
                {
                    var topicPartition = new TopicPartition(topic.NameField, partition.IndexField);
                    var commands = batch[topicPartition];
                    if (partition.ErrorCodeField == 0)
                        FinalizeSend(commands, partition);
                    else
                        FinalizeSendWithErrors(commands, partition);
                }
            }
        }

        private static void FinalizeSend(
            in WriteRecords produceRecords,
            in ProduceResponseData.TopicProduceResponse.PartitionProduceResponse response
        )
        {
            var delta = 0;
            foreach (var produceRecord in produceRecords)
            {
                FinalizeSend(produceRecord, response.BaseOffsetField + delta, ApiError.None, "");
                delta++;
            }

        }

        private static void FinalizeSendWithErrors(
            in WriteRecords produceRecords,
            in ProduceResponseData.TopicProduceResponse.PartitionProduceResponse response
        )
        {
            var error = ApiErrors.Translate(response.ErrorCodeField);
            var recordErrors = response
                .RecordErrorsField
                .ToImmutableSortedDictionary(
                    k => k.BatchIndexField,
                    v => v.BatchIndexErrorMessageField ?? ""
                )
            ;
            var delta = 0;
            foreach (var produceRecord in produceRecords)
            {
                if (!recordErrors.TryGetValue(delta, out var recordError))
                    recordError = "";
                FinalizeSend(produceRecord, response.BaseOffsetField + delta, error, recordError);
                delta++;
            }
        }

        private static void FinalizeSend(
            in ProduceCommand produceCommand,
            in Offset offset,
            in ApiError error,
            in string recordError
        )
        {
            var (record, callback) = produceCommand;
            callback.SetResult(
                new ProduceResult(
                    new TopicPartitionOffset(
                        record.TopicPartition,
                        offset
                    ),
                    record.Timestamp,
                    error,
                    recordError
                )
            );
        }

        private static IRecords BuildRecords(
            in int baseSequence,
            in WriteRecords records
        )
        {
            records.SetBaseSequence(baseSequence);
            return records;
        }

        public async Task Close(
            CancellationToken cancellationToken
        )
        {
            await _internalCts.CancelAsync().ConfigureAwait(false);
            await Task.WhenAll(_recordsAccumulatorTask, _recordsBuilderTask).ConfigureAwait(false);
            await _protocol.Close(cancellationToken).ConfigureAwait(false);
        }

        public async Task Flush(
            CancellationToken cancellationToken
        )
        {
            _sendBlocker.Reset();
            try
            {
                while (_commandQueue.Count > 0 && !cancellationToken.IsCancellationRequested)
                    await Task.Delay(
                        10,
                        cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                // Noop
            }
            finally
            {
                _sendBlocker.Set();
            }
        }

        private static short ParseAcks(
            WriteStreamConfig producerConfig,
            ILogger logger
        )
        {
            if (producerConfig.Acks == "all")
                return -1;
            if (short.TryParse(producerConfig.Acks, out var acks) && acks >= 0)
                return acks;
            logger.DefaultAcks(producerConfig.Acks);
            return -1;
        }

        public void Dispose()
        {
            _internalCts.Dispose();
            _sendQueue.Dispose();
            _commandQueue.Dispose();
            _sendBlocker.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
