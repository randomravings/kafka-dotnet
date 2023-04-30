using Kafka.Client.Clients.Producer.Model;
using Kafka.Client.Clients.Producer.Model.Internal;

namespace Kafka.Client.Clients.Producer
{
    internal interface IBrokerChannel
    {
        Task<ProduceResult> Send(ProduceCommand produceCommand, CancellationToken cancellationToken);
        Task Close(CancellationToken cancellationToken);
    }
}
