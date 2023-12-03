using Kafka.Common.Model;

namespace Kafka.Common.Net
{
    public interface ICluster<TConnection>
        where TConnection : INode
    {
        Task<TConnection> Controller(
            CancellationToken cancellationToken
        );

        Task<TConnection> Connection(
            NodeId nodeId,
            CancellationToken cancellationToken
        );

        Task CloseAll(
            CancellationToken cancellationToken
        );
    }
}
