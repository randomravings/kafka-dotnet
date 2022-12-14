using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Server
{
    public sealed record Cluster(
        DateTimeOffset LastUpdated,
        ClusterId ClusterId,
        ImmutableSortedDictionary<ClusterNodeId, ClusterNode> Nodes,
        ClusterNode Controller
    )
    {
        public static Cluster Empty { get; } = new(
            DateTimeOffset.UnixEpoch,
            ClusterId.Empty,
            ImmutableSortedDictionary<ClusterNodeId, ClusterNode>.Empty,
            ClusterNode.Empty
        );
    }
}
