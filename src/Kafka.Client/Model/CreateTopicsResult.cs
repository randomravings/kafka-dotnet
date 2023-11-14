using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record CreateTopicsResult(
        ImmutableArray<CreateTopicResult> CreatedTopics
    )
    {
        public static Model.CreateTopicsResult Empty { get; } = new(
            ImmutableArray<CreateTopicResult>.Empty
        );
    };
}
