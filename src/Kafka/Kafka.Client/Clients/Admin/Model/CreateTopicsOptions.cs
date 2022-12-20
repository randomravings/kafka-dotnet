using System.Collections.Immutable;
using static Kafka.Client.Clients.Admin.Model.CreateTopicsOptions;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record CreateTopicsOptions(
        int TimeoutMs,
        bool ValidateOnly,
        bool RetryOnQuotaViolation,
        ImmutableArray<NewTopic> Topics
    ) : ClientOptions(TimeoutMs)
    {
        public static CreateTopicsOptions Empty { get; } = new(
            -1,
            false,
            false,
            ImmutableArray<NewTopic>.Empty
        );

        public record NewTopic(
            string Name,
            int? NumPartitions,
            short? ReplicationFactor,
            ImmutableSortedDictionary<int, ImmutableArray<int>> ReplicasAssignments,
            ImmutableSortedDictionary<string, string?> Configs
        )
        {
            public static NewTopic Empty { get; } = new(
                "",
                null,
                null,
                ImmutableSortedDictionary<int, ImmutableArray<int>>.Empty,
                ImmutableSortedDictionary<string, string?>.Empty
            );
        }
    };
}
