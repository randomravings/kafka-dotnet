using Kafka.Client.Config;
using Kafka.Client.Logging;
using Kafka.Client.Messages;
using Kafka.Client.Model;
using Kafka.Client.Net;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Kafka.Client.IO.Stream
{
    internal sealed class ProducerChannel :
        IDisposable
    {
        private readonly int _maxRequestSize;
        private readonly TimeSpan _lingerTime;
        private readonly Task _recordsBuilderTask;
        private readonly Task _recordsAccumulatorTask;
        private readonly CancellationTokenSource _internalCts = new();
        private readonly BlockingCollection<ProduceCommand> _commandQueue = new();
        private readonly BlockingCollection<ProduceBatch> _sendQueue = new();
        private readonly ManualResetEventSlim _sendBlocker = new(true);
        private readonly long _producerId;
        private readonly short _producerEpoch;
        private readonly short _acks;
        private readonly string? _transactionalId;
        private readonly ILogger _logger;
        private readonly IClientConnection _protocol;
        private readonly SortedList<TopicPartition, int> _topicPartitionStates = new(TopicPartitionCompare.Instance);
        private readonly Func<ProduceBatch, CancellationToken, ValueTask> _sendDelegate;

        public ProducerChannel(
            long producerId,
            short producerEpoch,
            IClientConnection protocol,
            OutputStreamConfig producerConfig,
            ILogger logger
        )
        {
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
            _lingerTime = TimeSpan.FromMilliseconds(producerConfig.LingerMs);
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
            return Task.Run(() =>
            {
                try
                {
                    var carryOver = default(ProduceCommand?);
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        (var batch, var reason, carryOver) = Collect(
                            carryOver,
                            cancellationToken
                        );
                        _logger.BatchCollected(reason, batch.Count);
                        if (batch.Count > 0)
                            _sendQueue.Add(batch, cancellationToken);
                    }
                }
                catch (OperationCanceledException) { }
            }, CancellationToken.None);
        }

        /// <summary>
        /// Collects items into an existing batch from queue.
        /// If an item would overflow the buffer size then it is returned.
        /// </summary>
        /// <param name="carryOver">Possible carry over from previous fill.</param>
        /// <param name="cancellationToken">Cancellation token for linger time.</param>
        /// <returns></returns>
        private (ProduceBatch Batch, BatchCollectReason Reason, ProduceCommand? Overflow) Collect(
            in ProduceCommand? carryOver,
            in CancellationToken cancellationToken
        )
        {
            var produceCommand = carryOver ?? _commandQueue.Take(cancellationToken);
            var attributes = produceCommand.Record.Attributes;
            var batch = new ProduceBatch(
                _maxRequestSize,
                0,
                attributes,
                _producerId,
                _producerEpoch
            )
            {
                produceCommand
            };

            // Create linger time CTS.
            using var localCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            localCts.CancelAfter(_lingerTime);

            try
            {
                while (true)
                {
                    produceCommand = _commandQueue.Take(localCts.Token);
                    if (produceCommand.Record.Attributes != attributes)
                        return (batch, BatchCollectReason.AttributesChanged, produceCommand);
                    var (added, _) = batch.Add(produceCommand);
                    if (!added)
                        return (batch, BatchCollectReason.MaxSizeExceeded, produceCommand);
                }
            }
            catch (OperationCanceledException)
            {
                return (batch, BatchCollectReason.MaxLingerMsReached, null);
            }
        }

        public Task RunDispatch(
            CancellationToken cancellationToken
        )
        {
            return Task.Run(async () =>
            {
                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var batch = _sendQueue.Take(cancellationToken);
                        _logger.ProduceCommandDequeue(batch.Count);
                        await _sendDelegate(
                            batch,
                            cancellationToken
                        ).ConfigureAwait(false);
                        await Task.Yield();
                    }
                }
                catch (OperationCanceledException) { }
                catch (CorrelationIdException ex)
                {
                    ClientLog.CorrelationMismatch(_logger, ex);
                }

            }, CancellationToken.None);
        }

        private async ValueTask SendBatch(
            ProduceBatch batch,
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
            await Task.Yield();
            FinalizeSend(
                batch,
                response
            );
            // TODO: This needs revisit, just hacked in.
            foreach (var state in partitionStates)
                _topicPartitionStates[state.Key] = state.Value;
        }

        private async ValueTask SendBatchOneWay(
            ProduceBatch batch,
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
            await Task.Yield();
            FinalizeSend(
                batch
            );
            // TODO: This needs revisit, just hacked in.
            foreach (var state in partitionStates)
                _topicPartitionStates[state.Key] = state.Value;
        }

        private ProduceRequestData CreateProduceRequest(
            in ProduceBatch batch,
            in IDictionary<TopicPartition, int> partitionStates
        )
        {
            var lastTopic = TopicName.Empty;
            var topicProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequestData.TopicProduceData>();
            foreach (var (topicPartition, produceRecords) in batch)
            {
                if (lastTopic != topicPartition.Topic.TopicName)
                    topicProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequestData.TopicProduceData>();
                var partitionProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequestData.TopicProduceData.PartitionProduceData>();

                _topicPartitionStates.TryGetValue(topicPartition, out int baseSequence);
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
                        ImmutableArray<TaggedField>.Empty
                    )
                );
                topicProduceDataBuilder.Add(
                    new(
                        topicPartition.Topic.TopicName,
                        partitionProduceDataBuilder.ToImmutable(),
                        ImmutableArray<TaggedField>.Empty
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
                ImmutableArray<TaggedField>.Empty
            );
        }

        private static void FinalizeSend(
            in ProduceBatch batch
        )
        {
            foreach (var (topicPartition, produceRecords) in batch)
                foreach (var command in produceRecords)
                    FinalizeSend(command, Offset.Unset, Errors.Known.NONE, "");
        }

        private static void FinalizeSend(
            in ProduceBatch batch,
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
            in ProduceRecords produceRecords,
            in ProduceResponseData.TopicProduceResponse.PartitionProduceResponse response
        )
        {
            var delta = 0;
            foreach (var produceRecord in produceRecords)
            {
                FinalizeSend(produceRecord, response.BaseOffsetField + delta, Errors.Known.NONE, "");
                delta++;
            }

        }

        private static void FinalizeSendWithErrors(
            in ProduceRecords produceRecords,
            in ProduceResponseData.TopicProduceResponse.PartitionProduceResponse response
        )
        {
            var error = Errors.Translate(response.ErrorCodeField);
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
            in Error error,
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
            int baseSequence,
            ProduceRecords records
        )
        {
            records.SetBaseSequence(baseSequence);
            return records;
        }

        public async ValueTask Close(
            CancellationToken cancellationToken
        )
        {
            _internalCts.Cancel();
            await Task.WhenAll(_recordsAccumulatorTask, _recordsBuilderTask).ConfigureAwait(false);
            await _protocol.Close(cancellationToken).ConfigureAwait(false);
            await Task.Yield();
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
            catch(TaskCanceledException)
            {
                // Noop
            }
            finally
            {
                _sendBlocker.Set();
            }
        }

        private static short ParseAcks(
            OutputStreamConfig producerConfig,
            ILogger logger
        )
        {
            if (producerConfig.Acks == "all")
                return -1;
            if (short.TryParse(producerConfig.Acks, out var acks) && acks >= 0)
                return acks;
            ProducerLog.DefaultAcks(logger, producerConfig.Acks);
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
