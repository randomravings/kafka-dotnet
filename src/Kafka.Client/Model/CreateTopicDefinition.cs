using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record CreateTopicDefinition(
        string Name,
        int NumPartitions,
        short ReplicationFactor,
        IReadOnlyDictionary<int, IReadOnlyList<int>> ReplicasAssignments,
        IReadOnlyDictionary<string, string?> Configs
    )
    {
        public static CreateTopicDefinition Empty { get; } = new(
            "",
            -1,
            -1,
            ImmutableSortedDictionary<int, IReadOnlyList<int>>.Empty,
            ImmutableSortedDictionary<string, string?>.Empty
        );
    };
}
