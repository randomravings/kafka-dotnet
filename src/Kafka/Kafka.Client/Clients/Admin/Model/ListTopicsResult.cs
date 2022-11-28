using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record ListTopicsResult(
        ImmutableSortedSet<TopicListing> Topics
    )
    {
        public static ListTopicsResult Empty { get; } = new(
            ImmutableSortedSet<TopicListing>.Empty
        );
    };
}
