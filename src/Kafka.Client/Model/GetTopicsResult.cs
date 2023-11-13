using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record GetTopicsResult(
        IReadOnlyList<TopicDescription> Topics
    )
    {
        public static GetTopicsResult Empty { get; } = new(
            ImmutableArray<TopicDescription>.Empty
        );
    };
}
