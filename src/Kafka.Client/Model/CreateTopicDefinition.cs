using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record CreateTopicDefinition(
        string Name,
        int NumPartitions,
        short ReplicationFactor,
        IReadOnlyDictionary<Partition, IReadOnlySet<ClusterNodeId>> ReplicasAssignments,
        IReadOnlyDictionary<string, string?> Configs
    )
    {
        public static CreateTopicDefinition Empty { get; } = new(
            "",
            -1,
            -1,
            ImmutableSortedDictionary<Partition, IReadOnlySet<ClusterNodeId>>.Empty,
            ImmutableSortedDictionary<string, string?>.Empty
        );
    };
}
