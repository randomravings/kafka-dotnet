using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record TopicPartitionDescription(
        int PartitionIndex,
        int LeaderId,
        int LeaderEpoch,
        Error Errors,
        ImmutableArray<int> ReplicaNodes,
        ImmutableArray<int> IsrNodes,
        ImmutableArray<int> OfflineReplicas
    );
}
