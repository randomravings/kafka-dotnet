using Kafka.Common.Model;

namespace Kafka.Common.Net
{
    public interface IConnection :
        IDisposable
    {
        ClusterNodeId NodeId { get; }
        ITransport Transport { get; }
        ValueTask Open(CancellationToken cancellationToken);
        ValueTask Close(CancellationToken cancellationToken);
    }
}
