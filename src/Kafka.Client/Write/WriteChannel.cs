using Kafka.Client.Config;
using Kafka.Client.Logging;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Model.Internal;
using Kafka.Client.Net;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Kafka.Client.Write
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
        private readonly BlockingCollection<WriteCommand> _commandQueue = [];
        private readonly BlockingCollection<WriteBatch> _sendQueue = [];
        private readonly ManualResetEventSlim _sendBlocker = new(true);
        private readonly long _producerId;
        private readonly short _producerEpoch;
        private readonly short _acks;
        private readonly string? _transactionalId;
        private readonly ILogger _logger;
        private readonly INodeLink _protocol;
        private readonly ConcurrentDictionary<TopicPartition, int> _topicPartitionStates = new(TopicPartitionCompare.Equality);
        private readonly Func<WriteBatch, CancellationToken, Task> _sendDelegate;

        public WriteChannel(
            NodeId nodeId,
            long producerId,
            short producerEpoch,
            INodeLink protocol,
            WriteStreamConfig writeStreamConfig,
            ILogger logger
        )
        {
            _nodeId = nodeId;
            _producerId = producerId;
            _producerEpoch = producerEpoch;
            _transactionalId = writeStreamConfig.TransactionalId;
            _acks = ParseAcks(nodeId, writeStreamConfig, logger);
            _sendDelegate = _acks switch
            {
                0 => SendBatchOneWay,
                _ => SendBatch
            };
            _protocol = protocol;
            _logger = logger;
            _maxRequestSize = writeStreamConfig.MaxRequestSize;
            _lingerMs = writeStreamConfig.LingerMs;
            _recordsBuilderTask = RunDispatch(_internalCts.Token);
            _recordsAccumulatorTask = RunCollector(_internalCts.Token);
        }

        public void Send(
            in WriteCommand writeCommand,
            in CancellationToken cancellationToken
        )
        {
            _sendBlocker.Wait(cancellationToken);
            _commandQueue.Add(writeCommand, cancellationToken);
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
                _logger.BatchCollectorStarted(_nodeId);
                try
                {
                    var carryOver = default(WriteCommand?);
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        (var batch, var reason, carryOver) = Collect(
                            stopwatch,
                            carryOver,
                            cancellationToken
                        );
                        _logger.BatchCollected(_nodeId, batch.Count, reason);
                        if (batch.Count > 0)
                            _sendQueue.Add(batch, cancellationToken);
                    }
                }
                catch (OperationCanceledException) { }
                finally
                {
                    _logger.BatchCollectorStopped(_nodeId);
                }
            }, CancellationToken.None);
        }

        /// <summary>
        /// Collects items into an existing batch from queue.
        /// If an item would overflow the buffer size then it is returned.
        /// </summary>
        /// <param name="carryOver">Possible carry over from previous fill.</param>
        /// <param name="cancellationToken">Cancellation token for linger time.</param>
        /// <returns></returns>
        private (WriteBatch Batch, BatchCollectReason Reason, WriteCommand? Overflow) Collect(
            in Stopwatch stopwatch,
            in WriteCommand? carryOver,
            in CancellationToken cancellationToken
        )
        {
            var writeCommand = carryOver ?? _commandQueue.Take(cancellationToken);
            var attributes = writeCommand.Attributes;
            var batch = new WriteBatch(
                _maxRequestSize,
                0,
                attributes,
                _producerId,
                _producerEpoch
            )
            {
                writeCommand
            };
            stopwatch.Reset();
            while (true)
            {
                var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                if (elapsedMilliseconds >= _lingerMs)
                    return (batch, BatchCollectReason.MaxLingerMsReached, null);

                var millisecondTimeout = unchecked((int)(_lingerMs - elapsedMilliseconds));
                if (!_commandQueue.TryTake(out writeCommand, millisecondTimeout, cancellationToken))
                    return (batch, BatchCollectReason.MaxLingerMsReached, null);

                if (writeCommand.Attributes != attributes)
                    return (batch, BatchCollectReason.AttributesChanged, writeCommand);

                var (added, _) = batch.Add(writeCommand);
                if (!added)
                    return (batch, BatchCollectReason.MaxSizeExceeded, writeCommand);
            }
        }

        public Task RunDispatch(
            CancellationToken cancellationToken
        )
        {
            Task.Yield();
            return Task.Run(async () =>
            {
                _logger.DispatcherStarted(_nodeId);
                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var batch = _sendQueue.Take(cancellationToken);
                        _logger.DispatcherDequeue(_nodeId, batch.Count);
                        await Task.Yield();
                        await _sendDelegate(
                            batch,
                            cancellationToken
                        ).ConfigureAwait(false);
                    }
                }
                catch (OperationCanceledException) { }
                finally
                {
                    _logger.DispatcherStarted(_nodeId);
                }

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
                _topicPartitionStates[state.Key] = state.Value;
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
                _topicPartitionStates[state.Key] = state.Value;
        }

        private ProduceRequestData CreateProduceRequest(
            in WriteBatch batch,
            in IDictionary<TopicPartition, int> partitionStates
        )
        {
            var topic = TopicName.Empty;
            var topicProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequestData.TopicProduceData>();
            foreach (var (topicPartition, writeRecords) in batch)
            {
                if (topic != topicPartition.Topic.TopicName)
                {
                    topicProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequestData.TopicProduceData>();
                    topic = topicPartition.Topic.TopicName;
                }
                var partitionProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequestData.TopicProduceData.PartitionProduceData>();

                _topicPartitionStates.TryGetValue(topicPartition, out int baseSequence);
                writeRecords.SetBaseSequence(baseSequence);
                baseSequence += writeRecords.Records.Count;
                partitionStates[topicPartition] = baseSequence;
                partitionProduceDataBuilder.Add(
                    new(
                        topicPartition.Partition,
                        [(IRecords)writeRecords],
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
            foreach (var (topicPartition, writeRecords) in batch)
                foreach (var command in writeRecords)
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
            in WriteRecords writeRecords,
            in ProduceResponseData.TopicProduceResponse.PartitionProduceResponse response
        )
        {
            var delta = 0;
            foreach (var writeRecord in writeRecords)
            {
                FinalizeSend(writeRecord, response.BaseOffsetField + delta, ApiError.None, "");
                delta++;
            }

        }

        private static void FinalizeSendWithErrors(
            in WriteRecords writeRecords,
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
            foreach (var writeRecord in writeRecords)
            {
                if (!recordErrors.TryGetValue(delta, out var recordError))
                    recordError = "";
                FinalizeSend(writeRecord, response.BaseOffsetField + delta, error, recordError);
                delta++;
            }
        }

        private static void FinalizeSend(
            in WriteCommand writeCommand,
            in Offset offset,
            in ApiError error,
            in string recordError
        )
        {
            var (record, _, callback) = writeCommand;
            callback.SetResult(
                new WriteResult(
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
            in NodeId nodeId,
            in WriteStreamConfig writeStreamConfig,
            in ILogger logger
        )
        {
            if (writeStreamConfig.Acks == "all")
                return -1;
            if (short.TryParse(writeStreamConfig.Acks, out var acks) && acks >= 0)
                return acks;
            logger.DefaultAcks(nodeId, writeStreamConfig.Acks);
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
