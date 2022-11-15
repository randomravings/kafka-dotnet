using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Server
{
    public sealed record Cluster(
        ClusterId ClusterId,
        ClusterNode Controller,
        ImmutableSortedDictionary<ClusterNodeId, ClusterNode> Nodes,
        ImmutableSortedSet<Topic> UnauthorizedTopics,
        ImmutableSortedSet<Topic> InvalidTopics,
        ImmutableSortedSet<Topic> InternalTopics,
        ImmutableSortedDictionary<Topic, ImmutableArray<PartitionMetadata>> TopicMetadata,
        ImmutableSortedDictionary<string, Guid> TopicIds
    )
    {
        public static Cluster Empty { get; } = new(
            ClusterId.Empty,
            ClusterNode.Empty,
            ImmutableSortedDictionary<ClusterNodeId, ClusterNode>.Empty,
            ImmutableSortedSet<Topic>.Empty,
            ImmutableSortedSet<Topic>.Empty,
            ImmutableSortedSet<Topic>.Empty,
            ImmutableSortedDictionary<Topic, ImmutableArray<PartitionMetadata>>.Empty,
            ImmutableSortedDictionary<string, Guid>.Empty
        );
    }
}
