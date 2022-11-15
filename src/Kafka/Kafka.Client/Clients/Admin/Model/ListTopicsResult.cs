using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record ListTopicsResult(
        ImmutableSortedDictionary<Topic, TopicListing> Topics
    )
    {
        public static ListTopicsResult Empty { get; } = new(
            ImmutableSortedDictionary<Topic, TopicListing>.Empty
        );
    };
}
