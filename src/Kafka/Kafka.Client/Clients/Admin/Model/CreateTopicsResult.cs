using Kafka.Common.Exceptions;
using Kafka.Common.Types;
using System.Collections.Immutable;
using static Kafka.Client.Clients.Admin.Model.CreateTopicsResult;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record CreateTopicsResult(
        ImmutableSortedDictionary<Topic, CreatedTopicResult> CreatedTopics,
        ImmutableSortedDictionary<Topic, Error> ErrorTopics
    )
    {
        public static Model.CreateTopicsResult Empty { get; } = new(
            ImmutableSortedDictionary<Topic, CreatedTopicResult>.Empty,
            ImmutableSortedDictionary<Topic, Error>.Empty
        );

        public sealed record CreatedTopicResult(
            Topic Topic,
            int NumPartitions,
            int ReplicationFactor,
            ImmutableSortedDictionary<string, string?> Config
        );
    };
}
