using System.Collections.Immutable;

namespace Kafka.Common.Model
{
    public sealed record ClusterMetadata(
        DateTimeOffset LastUpdated,
        ClusterId ClusterId,
        ImmutableSortedDictionary<NodeId, NodeMetadata> Nodes,
        NodeMetadata Controller
    )
    {
        public static ClusterMetadata Empty { get; } = new(
            DateTimeOffset.UnixEpoch,
            ClusterId.Empty,
            ImmutableSortedDictionary<NodeId, NodeMetadata>.Empty,
            NodeMetadata.Empty
        );
    }
}
