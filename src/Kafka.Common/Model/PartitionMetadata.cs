using System.Collections.Immutable;

namespace Kafka.Common.Model
{
    public sealed record PartitionMetadata(
        TopicPartition TopicPartition,
        Error Error,
        ClusterNodeId? LeaderId,
        Timestamp? LeaderEpoch,
        ImmutableArray<ClusterNodeId> ReplicaIds,
        ImmutableArray<ClusterNodeId> InSyncReplicaIds,
        ImmutableArray<ClusterNodeId> OfflineReplicaIds
    );
}
