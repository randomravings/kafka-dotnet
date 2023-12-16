using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Model
{
    public sealed record ListGroupsOptions(
        IReadOnlyList<ConsumerGroupState> States
    )
    {
        public static ListGroupsOptions Empty { get; } = new(
            ImmutableArray<ConsumerGroupState>.Empty
        );
    };
}
