using System.Collections.Immutable;

namespace Kafka.Common.Types
{
    public sealed record PartitionMetadata(
        TopicPartition TopicPartition,
        ErrorCode Error,
        ClusterNodeId? LeaderId,
        Timestamp? LeaderEpoch,
        ImmutableArray<ClusterNodeId> ReplicaIds,
        ImmutableArray<ClusterNodeId> InSyncReplicaIds,
        ImmutableArray<ClusterNodeId> OfflineReplicaIds
    );
}
