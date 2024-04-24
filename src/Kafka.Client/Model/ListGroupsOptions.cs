using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record ListGroupsOptions(
        IReadOnlyList<ConsumerGroupState> States,
        IReadOnlyList<string> Types
    )
    {
        public static ListGroupsOptions Empty { get; } = new(
            ImmutableArray<ConsumerGroupState>.Empty,
            ImmutableArray<string>.Empty
        );
    };
}
