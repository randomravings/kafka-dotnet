using Kafka.Common.Model;

namespace Kafka.Common.Net
{
    public interface IConnectionManager<TConnection> :
        IDisposable
        where TConnection : IConnection
    {
        ValueTask<TConnection> Controller(
            CancellationToken cancellationToken
        );

        ValueTask<TConnection> Connection(
            ClusterNodeId nodeId,
            CancellationToken cancellationToken
        );

        ValueTask CloseAll(
            CancellationToken cancellationToken
        );
    }
}
