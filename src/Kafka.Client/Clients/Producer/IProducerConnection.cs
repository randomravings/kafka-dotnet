using Kafka.Client.Messages;
using Kafka.Client.Protocol;

namespace Kafka.Client.Clients.Producer
{
    public interface IProducerConnection :
        IClientProtocol
    {
        ValueTask<ProduceResponseData> Produce(
            ProduceRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask ProduceNoAck(
            ProduceRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<InitProducerIdResponseData> InitProducerId(
            InitProducerIdRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<AddPartitionsToTxnResponseData> AddPartitionsToTxn(
            AddPartitionsToTxnRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<EndTxnResponseData> EndTxn(
            EndTxnRequestData request,
            CancellationToken cancellationToken
        );
    }
}
