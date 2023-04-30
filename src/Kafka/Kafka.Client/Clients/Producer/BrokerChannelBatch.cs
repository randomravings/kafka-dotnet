using Kafka.Client.Clients.Producer.Logging;
using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Clients.Producer.Model.Internal;
using Kafka.Client.Messages;
using Kafka.Common.Model;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    internal sealed class BrokerChannelBatch :
        BrokerChannel
    {
        private readonly int _maxInFlightRequestsPerConnection;
        private readonly int _maxRequestSize;
        private readonly TimeSpan _lingerTime;
        private readonly Task _recordsBuilderTask;
        private readonly Task _recordsAccumulatorTask;
        private readonly CancellationTokenSource _internalCts = new();
        private readonly BlockingCollection<ProduceCommand> _commandQueue = new();
        private readonly BlockingCollection<ProduceBatch> _executeQueue = new();
        private readonly Func<ProduceBatch, CancellationToken, Task> _sendDelegate;

        public BrokerChannelBatch(
            long producerId,
            short producerEpoch,
            short acks,
            string transactionalId,
            int requestTimeoutMs,
            ProducerConfig config,
            IConnection connection,
            ILogger logger
        ) : base(
                producerId,
                producerEpoch,
                acks,
                transactionalId,
                requestTimeoutMs,
                config,
                connection,
                logger
            )
        {
            _maxInFlightRequestsPerConnection = config.MaxInFlightRequestsPerConnection;
            _maxRequestSize = config.MaxRequestSize;
            _lingerTime = TimeSpan.FromMilliseconds(config.LingerMs);
            _sendDelegate = _acks switch
            {
                0 => SendBatchOneWay,
                _ => SendBatch
            };
            _recordsBuilderTask = RunDispatch(_internalCts.Token);
            _recordsAccumulatorTask = RunCollector(_internalCts.Token);
        }

        public override Task<ProduceResult> Send(ProduceCommand produceCommand, CancellationToken cancellationToken)
        {
            _commandQueue.Add(produceCommand, cancellationToken);
            return produceCommand.TaskCompletionSource.Task;
        }

        public Task<ProduceResult> Queue(ProduceCommand produceCommand, CancellationToken cancellationToken)
        {
            _commandQueue.Add(produceCommand, cancellationToken);
            return produceCommand.TaskCompletionSource.Task;
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
                var overflow = default(ProduceCommand);
                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        // Process overflow or await next item.
                        var item = overflow ?? _commandQueue.Take(cancellationToken);

                        // Create linger time CTS.
                        using var localCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                        localCts.CancelAfter(_lingerTime);

                        // Collect until either:
                        // - Max in flight reached.
                        // - Max size overflowed.
                        // - Linger time reached.
                        (var batch, var reason, overflow) = Collect(
                            _commandQueue,
                            item,
                            _maxInFlightRequestsPerConnection,
                            _maxRequestSize,
                            localCts.Token
                        );

                        // Send batch for delivery.
                        _executeQueue.Add(batch, cancellationToken);
                        ProducerLog.BatchCollected(_logger, reason, batch.Count);
                    }
                }
                catch (OperationCanceledException) { }
            }, CancellationToken.None);
        }

        /// <summary>
        /// Collects items into an existing batch from queue.
        /// If an item would overflow the buffer size then it is returned.
        /// </summary>
        /// <param name="commandQueue">Queue to consume.</param>
        /// <param name="batchBuilder">Batch to fill.</param>
        /// <param name="maxInFlightRequestsPerConnection">Max number of messages for batch.</param>
        /// <param name="maxRequestSize">Max size in bytes for batch.</param>
        /// <param name="cancellationToken">Cancellation token for linger time.</param>
        /// <returns></returns>
        private static (ProduceBatch Batch, BatchCollectReason Reason, ProduceCommand? Overflow) Collect(
            BlockingCollection<ProduceCommand> commandQueue,
            ProduceCommand firstItem,
            int maxInFlightRequestsPerConnection,
            int maxRequestSize,
            CancellationToken cancellationToken
        )
        {
            var batch = new ProduceBatch(Attributes.None);
            var fetchedSize = EstimateRecordSize(firstItem);
            var attributes = firstItem.Attributes;
            batch.Add(firstItem);
            try
            {
                while (true)
                {
                    if (batch.Count >= maxInFlightRequestsPerConnection)
                        return (batch, BatchCollectReason.MaxInFlightReached, null);

                    var item = commandQueue.Take(cancellationToken);

                    if (item.Attributes != attributes)
                        return (batch, BatchCollectReason.AttributesChanged, null);

                    fetchedSize += EstimateRecordSize(item);
                    if (fetchedSize >= maxRequestSize)
                        return (batch, BatchCollectReason.MaxSizeExceeded, item);

                    batch.Add(item);
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
                        var batch = _executeQueue.Take(cancellationToken);
                        ProducerLog.ProduceCommandDequeue(_logger, batch.Count);
                        await _sendDelegate(
                            batch,
                            cancellationToken
                        );
                    }
                }
                catch (OperationCanceledException) { }
                catch (Exception ex)
                {
                    _logger.LogCritical("{ex}", ex);
                }

            }, CancellationToken.None);
        }

        private async Task SendBatch(
            ProduceBatch batch,
            CancellationToken cancellationToken
        )
        {
            var partitionStates = new Dictionary<TopicPartition, int>();
            var request = CreateProduceRequest(
                batch,
                partitionStates
            );
            var response = await ProducerProtocol.Produce(
                _connection,
                request,
                _config,
                _logger,
                cancellationToken
            );
            FinalizeSend(
                batch,
                response
            );
            // TODO: This needs revisit, just hacked in.
            foreach (var state in partitionStates)
                _topicPartitionStates[state.Key] = state.Value;
        }

        private async Task SendBatchOneWay(
            ProduceBatch batch,
            CancellationToken cancellationToken
        )
        {
            var partitionStates = new Dictionary<TopicPartition, int>();
            var request = CreateProduceRequest(
                batch,
                partitionStates
            );
            await ProducerProtocol.ProduceNoAck(
                _connection,
                request,
                _config,
                _logger,
                cancellationToken
            );
            FinalizeSend(
                batch
            );
            // TODO: This needs revisit, just hacked in.
            foreach (var state in partitionStates)
                _topicPartitionStates[state.Key] = state.Value;
        }

        private ProduceRequest CreateProduceRequest(
            ProduceBatch batch,
            IDictionary<TopicPartition, int> partitionStates
        )
        {
            var topicProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequest.TopicProduceData>();
            foreach ((var topic, var partitions) in batch)
            {
                var partitionProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequest.TopicProduceData.PartitionProduceData>();
                foreach ((var partition, var commands) in partitions)
                {
                    var topicPartition = new TopicPartition(topic, partition);
                    _topicPartitionStates.TryGetValue(topicPartition, out int baseSequence);
                    var records = BuildRecords(
                        baseSequence,
                        Attributes.None,
                        commands
                    );
                    baseSequence += records.Count;
                    partitionStates[topicPartition] = baseSequence;
                    partitionProduceDataBuilder.Add(
                        new(
                            partition,
                            ImmutableArray.Create(records)
                        )
                    );
                }
                topicProduceDataBuilder.Add(
                    new(
                        topic,
                        partitionProduceDataBuilder.ToImmutable()
                    )
                );
            }
            return new ProduceRequest(
                _transactionalId,
                _acks,
                _requestTimeoutMs,
                topicProduceDataBuilder.ToImmutable()
            );
        }

        private static void FinalizeSend(
            ProduceBatch batch
        )
        {
            foreach ((var topic, var partitions) in batch)
                foreach ((var partition, var commands) in partitions)
                    foreach (var command in commands)
                        FinalizeSend(command, Offset.Unset, Errors.Known.NONE, "");
        }

        private static void FinalizeSend(
            ProduceBatch batch,
            ProduceResponse response
        )
        {
            foreach (var topic in response.ResponsesField)
            {
                foreach (var partition in topic.PartitionResponsesField)
                {
                    var commands = batch[topic.NameField, partition.IndexField];
                    if (partition.ErrorCodeField == 0)
                        FinalizeSend(commands, partition);
                    else
                        FinalizeSendWithErrors(commands, partition);
                }
            }
        }

        private static void FinalizeSend(
            IReadOnlyList<ProduceCommand> commands,
            ProduceResponse.TopicProduceResponse.PartitionProduceResponse response
        )
        {
            for (int i = 0; i < commands.Count; i++)
                FinalizeSend(commands[i], response.BaseOffsetField + i, Errors.Known.NONE, "");
        }

        private static void FinalizeSendWithErrors(
            IReadOnlyList<ProduceCommand> commands,
            ProduceResponse.TopicProduceResponse.PartitionProduceResponse response
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
            for (int i = 0; i < commands.Count; i++)
            {
                if (!recordErrors.TryGetValue(i, out var recordError))
                    recordError = "";
                FinalizeSend(commands[i], response.BaseOffsetField + i, error, recordError);
            }
        }

        protected override async Task Closing(CancellationToken cancellationToken)
        {
            _internalCts.Cancel();
            await Task.WhenAll(_recordsAccumulatorTask, _recordsBuilderTask);
        }
    }
}
