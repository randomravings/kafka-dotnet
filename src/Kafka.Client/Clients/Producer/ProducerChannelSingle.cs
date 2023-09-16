using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Messages;
using Kafka.Common.Model;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    internal sealed class ProducerChannelSingle :
        ProducerChannel
    {
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private readonly Func<SendCommand, CancellationToken, ValueTask> _sendDelegate;

        public ProducerChannelSingle(
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
            _sendDelegate = _acks switch
            {
                0 => SendWithoutAck,
                _ => SendWithAck
            };
        }

        protected override async ValueTask Sending(SendCommand sendCommand, CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await _sendDelegate(sendCommand, cancellationToken).ConfigureAwait(false);
            }
            finally { _semaphore.Release(); }
        }

        private async ValueTask SendWithAck(
            SendCommand sendCommand,
            CancellationToken cancellationToken
        )
        {
            var partitionStates = new Dictionary<TopicPartition, int>();
            var request = CreateProduceRequest(
                sendCommand,
                partitionStates
            );
            var response = await _protocol.Produce(request, cancellationToken).ConfigureAwait(false);
            var partitionData = response.ResponsesField[0].PartitionResponsesField[0];
            if (partitionData.ErrorCodeField == 0)
            {
                FinalizeSend(
                    sendCommand,
                    partitionData.BaseOffsetField,
                    Errors.Known.NONE,
                    ""
                );
            }
            else
            {
                var error = Errors.Translate(partitionData.ErrorCodeField);
                var recordErrors = partitionData.RecordErrorsField.FirstOrDefault();
                FinalizeSend(
                    sendCommand,
                    partitionData.BaseOffsetField,
                    error,
                    recordErrors?.BatchIndexErrorMessageField ?? ""
                );
            
            }
            // TODO: This needs revisit, just hacked in.
            foreach (var state in partitionStates)
                _topicPartitionStates[state.Key] = state.Value;
        }

        private async ValueTask SendWithoutAck(
            SendCommand sendCommand,
            CancellationToken cancellationToken
        )
        {
            var partitionStates = new Dictionary<TopicPartition, int>();
            var request = CreateProduceRequest(
                sendCommand,
                partitionStates
            );
            await _protocol.ProduceNoAck(request, cancellationToken).ConfigureAwait(false);
            FinalizeSend(
                sendCommand,
                Offset.Unset,
                Errors.Known.NONE,
                ""
            );
            // TODO: This needs revisit, just hacked in.
            foreach (var state in partitionStates)
                _topicPartitionStates[state.Key] = state.Value;
        }

        private ProduceRequestData CreateProduceRequest(
            SendCommand sendCommand,
            IDictionary<TopicPartition, int> partitionStates
        )
        {
            _topicPartitionStates.TryGetValue(sendCommand.TopicPartition, out int baseSequence);
            var records = BuildRecords(baseSequence, Attributes.None, sendCommand);
            baseSequence += records.Count;
            partitionStates[sendCommand.TopicPartition] = baseSequence;
            var partitionData = new ProduceRequestData.TopicProduceData.PartitionProduceData(
                sendCommand.TopicPartition.Partition,
                ImmutableArray.Create(records),
                ImmutableArray<TaggedField>.Empty
            );
            var topicData = new ProduceRequestData.TopicProduceData(
                sendCommand.TopicPartition.Topic.TopicName,
                ImmutableArray.Create(partitionData),
                ImmutableArray<TaggedField>.Empty
            );
            return new ProduceRequestData(
                _transactionalId,
                _acks,
                _requestTimeoutMs,
                ImmutableArray.Create(topicData),
                ImmutableArray<TaggedField>.Empty
            );
        }

        protected override async ValueTask Closing(CancellationToken cancellationToken)
        {
            await _protocol.Close(cancellationToken).ConfigureAwait(false);
            _semaphore.Dispose();
        }

        protected override ValueTask Flushing(CancellationToken cancellationToken) =>
            ValueTask.CompletedTask
        ;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _semaphore.Dispose();
        }
    }
}
