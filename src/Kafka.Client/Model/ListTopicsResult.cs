using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record ListTopicsResult(
        IReadOnlyList<TopicDescription> Topics
    )
    {
        public static ListTopicsResult Empty { get; } = new(
            ImmutableArray<TopicDescription>.Empty
        );
    };
}
