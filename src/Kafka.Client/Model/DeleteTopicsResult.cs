using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record DeleteTopicsResult(
        IReadOnlyList<DeleteTopicResult> Topics
    )
    {
        public static DeleteTopicsResult Empty { get; } = new(
            ImmutableArray<DeleteTopicResult>.Empty
        );
    };
}
