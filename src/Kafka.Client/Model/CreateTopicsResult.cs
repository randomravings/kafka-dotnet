using System.Collections.Immutable;

namespace Kafka.Client.Model
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
    };
}
