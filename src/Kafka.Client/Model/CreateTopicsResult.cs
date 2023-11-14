using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record CreateTopicsResult(
        ImmutableArray<CreateTopicResult> Topics
    )
    {
        public static CreateTopicsResult Empty { get; } = new(
            ImmutableArray<CreateTopicResult>.Empty
        );
    };
}
