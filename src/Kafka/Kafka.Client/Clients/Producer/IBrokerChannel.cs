using Kafka.Client.Clients.Producer.Model;

namespace Kafka.Client.Clients.Producer
{
    internal interface IBrokerChannel
    {
        Task Send(SendCommand sendCommand, CancellationToken cancellationToken);
        Task Close(CancellationToken cancellationToken);
        Task Flush(CancellationToken cancellationToken);
    }
}
