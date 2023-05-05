using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Messages;
using Kafka.Common.Model;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    internal sealed class BrokerChannelSingle :
        BrokerChannel
    {
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private readonly Func<SendCommand, CancellationToken, Task> _sendDelegate;

        public BrokerChannelSingle(
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
            _sendDelegate = _acks switch
            {
                0 => SendWithoutAck,
                _ => SendWithAck
            };
        }

        public override async Task Send(SendCommand sendCommand, CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                await _sendDelegate(sendCommand, cancellationToken);
            }
            finally { _semaphore.Release(); }
        }

        private async Task SendWithAck(
            SendCommand sendCommand,
            CancellationToken cancellationToken
        )
        {
            var partitionStates = new Dictionary<TopicPartition, int>();
            var request = CreateProduceRequest(
                sendCommand,
                partitionStates
            );
            var response = await ProducerProtocol.Produce(
                _connection,
                request,
                _config,
                _logger,
                cancellationToken
            );
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

        private async Task SendWithoutAck(
            SendCommand sendCommand,
            CancellationToken cancellationToken
        )
        {
            var partitionStates = new Dictionary<TopicPartition, int>();
            var request = CreateProduceRequest(
                sendCommand,
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
                sendCommand,
                Offset.Unset,
                Errors.Known.NONE,
                ""
            );
            // TODO: This needs revisit, just hacked in.
            foreach (var state in partitionStates)
                _topicPartitionStates[state.Key] = state.Value;
        }

        private ProduceRequest CreateProduceRequest(
            SendCommand sendCommand,
            IDictionary<TopicPartition, int> partitionStates
        )
        {
            _topicPartitionStates.TryGetValue(sendCommand.TopicPartition, out int baseSequence);
            var records = BuildRecords(baseSequence, Attributes.None, sendCommand);
            baseSequence += records.Count;
            partitionStates[sendCommand.TopicPartition] = baseSequence;
            var partitionData = new ProduceRequest.TopicProduceData.PartitionProduceData(
                sendCommand.TopicPartition.Partition,
                ImmutableArray.Create(records)
            );
            var topicData = new ProduceRequest.TopicProduceData(
                sendCommand.TopicPartition.Topic,
                ImmutableArray.Create(partitionData)
            );
            return new ProduceRequest(
                _transactionalId,
                _acks,
                _requestTimeoutMs,
                ImmutableArray.Create(topicData)
            );
        }

        protected override Task Closing(CancellationToken cancellationToken) =>
            Task.CompletedTask
        ;

        protected override Task Flushing(CancellationToken cancellationToken) =>
            Task.CompletedTask
        ;
    }
}
