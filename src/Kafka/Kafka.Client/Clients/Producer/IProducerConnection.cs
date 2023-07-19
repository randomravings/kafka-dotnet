using Kafka.Client.Messages;
using Kafka.Client.Protocol;

namespace Kafka.Client.Clients.Producer
{
    public interface IProducerConnection :
        IClientProtocol
    {
        ValueTask<ProduceResponse> Produce(
            ProduceRequest request,
            CancellationToken cancellationToken
        );

        ValueTask ProduceNoAck(
            ProduceRequest request,
            CancellationToken cancellationToken
        );

        ValueTask<InitProducerIdResponse> InitProducerId(
            InitProducerIdRequest request,
            CancellationToken cancellationToken
        );

        ValueTask<AddPartitionsToTxnResponse> AddPartitionsToTxn(
            AddPartitionsToTxnRequest request,
            CancellationToken cancellationToken
        );

        ValueTask<EndTxnResponse> EndTxn(
            EndTxnRequest request,
            CancellationToken cancellationToken
        );
    }
}
