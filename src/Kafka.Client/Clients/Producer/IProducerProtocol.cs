using Kafka.Client.Clients.Producer.Model;

namespace Kafka.Client.Clients.Producer
{
    internal interface IProducerProtocol :
        IDisposable
    {
        ValueTask Send(SendCommand sendCommand, CancellationToken cancellationToken);
        ValueTask Close(CancellationToken cancellationToken);
        ValueTask Flush(CancellationToken cancellationToken);
    }
}
