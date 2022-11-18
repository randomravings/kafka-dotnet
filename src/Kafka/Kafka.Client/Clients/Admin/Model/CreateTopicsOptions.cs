using System.Collections.Immutable;
using static Kafka.Client.Clients.Admin.Model.CreateTopicsOptions;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record CreateTopicsOptions(
        int TimeoutMs,
        short? ApiVersion,
        string ClientId,
        bool ValidateOnly,
        bool RetryOnQuotaViolation,
        ImmutableArray<NewTopic> Topics
    ) : ClientOptions(TimeoutMs, ApiVersion, ClientId)
    {
        public static CreateTopicsOptions Empty { get; } = new(
            -1,
            0,
            "",
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
