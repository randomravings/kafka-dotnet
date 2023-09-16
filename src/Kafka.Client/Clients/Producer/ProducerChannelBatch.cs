using Kafka.Client.Clients.Logging;
using Kafka.Client.Clients.Producer.Logging;
using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Clients.Producer.Model.Internal;
using Kafka.Client.Commands;
using Kafka.Client.Exceptions;
using Kafka.Client.Messages;
using Kafka.Common.Model;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    internal sealed class ProducerChannelBatch :
        ProducerChannel
    {
        private readonly int _maxInFlightRequestsPerConnection;
        private readonly int _maxRequestSize;
        private readonly TimeSpan _lingerTime;
        private readonly Task _recordsBuilderTask;
        private readonly Task _recordsAccumulatorTask;
        private readonly CancellationTokenSource _internalCts = new();
        private readonly BlockingCollection<ICommand> _commandQueue = new();
        private readonly BlockingCollection<ProduceBatch> _sendQueue = new();
        private readonly Func<ProduceBatch, CancellationToken, ValueTask> _sendDelegate;

        public ProducerChannelBatch(
            long producerId,
            short producerEpoch,
            short acks,
            string? transactionalId,
            int requestTimeoutMs,
            IProducerConnection protocol,
            ProducerConfig config,
            ILogger logger
        ) : base(
                producerId,
                producerEpoch,
                acks,
                transactionalId,
                requestTimeoutMs,
                protocol,
                config,
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

        protected override ValueTask Sending(SendCommand pendCommand, CancellationToken cancellationToken)
        {
            _commandQueue.Add(pendCommand, cancellationToken);
            return ValueTask.CompletedTask;
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
                var carryOver = default(ICommand);
                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        switch (carryOver)
                        {
                            case SendCommand sendCommand:
                                (var batch, var reason, carryOver) = Collect(
                                    _commandQueue,
                                    sendCommand,
                                    _maxInFlightRequestsPerConnection,
                                    _maxRequestSize,
                                    _lingerTime,
                                    cancellationToken
                                );
                                // Send batch for delivery.
                                if(batch.Count > 0)
                                    _sendQueue.Add(batch, cancellationToken);
                                ProducerLog.BatchCollected(_logger, reason, batch.Count);
                                break;
                            case null:
                                carryOver = _commandQueue.Take(cancellationToken);
                                break;
                            case FlushCommand flushCommand:
                                SpinWait.SpinUntil(() => _sendQueue.Count == 0);
                                flushCommand.TaskCompletionSource.SetResult(true);
                                carryOver = _commandQueue.Take(cancellationToken);
                                break;
                        }
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
        private static (ProduceBatch Batch, BatchCollectReason Reason, ICommand? Overflow) Collect(
            BlockingCollection<ICommand> commandQueue,
            SendCommand carryOver,
            int maxInFlightRequestsPerConnection,
            int maxRequestSize,
            TimeSpan lingerMs,
            CancellationToken cancellationToken
        )
        {
            // Create linger time CTS.
            using var localCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            localCts.CancelAfter(lingerMs);

            var batch = new ProduceBatch(Attributes.None);
            var estimatedSize = EstimateRecordSize(carryOver);
            var attributes = carryOver.Attributes;
            batch.Add(carryOver);
            try
            {
                while (true)
                {
                    if (batch.Count >= maxInFlightRequestsPerConnection)
                        return (batch, BatchCollectReason.MaxInFlightReached, null);
                    var item = commandQueue.Take(localCts.Token);
                    switch (item)
                    {
                        case SendCommand sendCommand:
                            estimatedSize += EstimateRecordSize(sendCommand);
                            if (estimatedSize >= maxRequestSize)
                                return (batch, BatchCollectReason.MaxSizeExceeded, sendCommand);
                            if (sendCommand.Attributes != attributes)
                                return (batch, BatchCollectReason.AttributesChanged, null);
                            batch.Add(sendCommand);
                            break;
                        case FlushCommand flushCommand:
                            return (batch, BatchCollectReason.Flush, flushCommand);
                    }
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
                        ProducerLog.ProduceCommandDequeue(_logger, batch.Count);
                        await _sendDelegate(
                            batch,
                            cancellationToken
                        ).ConfigureAwait(false);
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
            FinalizeSend(
                batch
            );
            // TODO: This needs revisit, just hacked in.
            foreach (var state in partitionStates)
                _topicPartitionStates[state.Key] = state.Value;
        }

        private ProduceRequestData CreateProduceRequest(
            ProduceBatch batch,
            IDictionary<TopicPartition, int> partitionStates
        )
        {
            var topicProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequestData.TopicProduceData>();
            foreach ((var topic, var partitions) in batch)
            {
                var partitionProduceDataBuilder = ImmutableArray.CreateBuilder<ProduceRequestData.TopicProduceData.PartitionProduceData>();
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
                            ImmutableArray.Create(records),
                            ImmutableArray<TaggedField>.Empty
                        )
                    );
                }
                topicProduceDataBuilder.Add(
                    new(
                        topic,
                        partitionProduceDataBuilder.ToImmutable(),
                        ImmutableArray<TaggedField>.Empty
                    )
                );
            }
            return new ProduceRequestData(
                _transactionalId,
                _acks,
                _requestTimeoutMs,
                topicProduceDataBuilder.ToImmutable(),
                ImmutableArray<TaggedField>.Empty
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
            ProduceResponseData response
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
            IReadOnlyList<SendCommand> commands,
            ProduceResponseData.TopicProduceResponse.PartitionProduceResponse response
        )
        {
            for (int i = 0; i < commands.Count; i++)
                FinalizeSend(commands[i], response.BaseOffsetField + i, Errors.Known.NONE, "");
        }

        private static void FinalizeSendWithErrors(
            IReadOnlyList<SendCommand> commands,
            ProduceResponseData.TopicProduceResponse.PartitionProduceResponse response
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

        protected override async ValueTask Closing(CancellationToken cancellationToken)
        {
            _internalCts.Cancel();
            await Task.WhenAll(_recordsAccumulatorTask, _recordsBuilderTask).ConfigureAwait(false);
        }

        protected override async ValueTask Flushing(CancellationToken cancellationToken)
        {
            var flushCommand = new FlushCommand();
            _commandQueue.Add(flushCommand, cancellationToken);
            await flushCommand.TaskCompletionSource.Task.ConfigureAwait(false);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _internalCts.Dispose();
            _commandQueue.Dispose();
            _sendQueue.Dispose();
    }
    }
}
