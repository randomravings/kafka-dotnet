using Kafka.Common.Model;

namespace Kafka.Common.Net
{
    public interface IConnectionManager<TConnection> :
        IDisposable
        where TConnection : IConnection
    {
        Task<TConnection> Controller(
            CancellationToken cancellationToken
        );

        Task<TConnection> Connection(
            ClusterNodeId nodeId,
            CancellationToken cancellationToken
        );

        Task CloseAll(
            CancellationToken cancellationToken
        );
    }
}
