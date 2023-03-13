using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Common.Network
{
    public interface IConnectionPool
    {
        Task<IConnection> AquireConnection(CancellationToken cancellationToken);
        Task<IConnection> AquireConnection(string host, int port, CancellationToken cancellationToken);
        Task<IConnection> AquireCoordinatorConnection(CancellationToken cancellationToken);
        Task<IConnection> AquireSharedConnection(CancellationToken cancellationToken);
        Task<IConnection> AquireSharedConnection(string host, int port, CancellationToken cancellationToken);
        Task<IConnection> AquireSharedControllerConnection(CancellationToken cancellationToken);
        Task<ImmutableSortedDictionary<ClusterNodeId, IConnection>> AquireBrokerConnections(CancellationToken cancellationToken);
    }
}
