using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record PartitionDescription(
        Partition PartitionIndex,
        ClusterNodeId LeaderId,
        Epoch LeaderEpoch,
        ImmutableArray<ClusterNodeId> ReplicaNodes,
        ImmutableArray<ClusterNodeId> IsrNodes,
        ImmutableArray<ClusterNodeId> OfflineReplicas,
        Error Error
    );
}
