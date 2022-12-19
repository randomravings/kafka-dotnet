using Kafka.Common.Types;
using System.Collections.Immutable;
using static Kafka.Client.Clients.Admin.Model.CreateTopicsResult;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record CreateTopicsResult(
        ImmutableArray<CreateTopicResult> CreatedTopics,
        ImmutableArray<CreateTopicError> ErrorTopics
    )
    {
        public static Model.CreateTopicsResult Empty { get; } = new(
            ImmutableArray<CreateTopicResult>.Empty,
            ImmutableArray<CreateTopicError>.Empty
        );

        public sealed record CreateTopicResult(
            TopicId Id,
            TopicName Name,
            int NumPartitions,
            int ReplicationFactor,
            ImmutableSortedDictionary<string, string?> Config
        );

        public sealed record CreateTopicError(
            TopicName Name,
            Error Error
        );
    };
}
