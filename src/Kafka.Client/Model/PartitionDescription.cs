using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record PartitionDescription(
        Partition PartitionIndex,
        NodeId LeaderId,
        Epoch LeaderEpoch,
        ImmutableArray<NodeId> ReplicaNodes,
        ImmutableArray<NodeId> IsrNodes,
        ImmutableArray<NodeId> OfflineReplicas,
        Error Error
    );
}
