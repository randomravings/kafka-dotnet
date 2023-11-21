using Kafka.Common.Model;

namespace Kafka.Common.Net
{
    public interface IConnection :
        IDisposable
    {
        ClusterNodeId NodeId { get; }
        ITransport Transport { get; }
        Task Open(CancellationToken cancellationToken);
        Task Close(CancellationToken cancellationToken);
    }
}
