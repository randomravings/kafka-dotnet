using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record CreateTopicOptions(
        string Name,
        int NumPartitions,
        short ReplicationFactor,
        ImmutableSortedDictionary<int, ImmutableArray<int>> ReplicasAssignments,
        ImmutableSortedDictionary<string, string?> Configs
    )
    {
        public static CreateTopicOptions Empty { get; } = new(
            "",
            -1,
            -1,
            ImmutableSortedDictionary<int, ImmutableArray<int>>.Empty,
            ImmutableSortedDictionary<string, string?>.Empty
        );
    };
}
