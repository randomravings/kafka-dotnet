using Kafka.Common.Exceptions;
using Kafka.Common.Types;
using System.Collections.Immutable;
using static Kafka.Client.Clients.Admin.Model.CreateTopicsResult;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record CreateTopicsResult(
        ImmutableSortedDictionary<Topic, CreateTopicResult> CreatedTopics,
        ImmutableSortedDictionary<Topic, ApiException> ErrorTopics
    )
    {
        public static CreateTopicsResult Empty { get; } = new(
            ImmutableSortedDictionary<Topic, CreateTopicResult>.Empty,
            ImmutableSortedDictionary<Topic, ApiException>.Empty
        );

        public sealed record CreateTopicResult(
            Guid TopicId,
            int NumPartitions,
            int ReplicationFactor,
            ImmutableSortedDictionary<string, string?> Config
        );
    };
}
