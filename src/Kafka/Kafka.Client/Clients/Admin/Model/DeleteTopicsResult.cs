using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record DeleteTopicsResult(
        ImmutableArray<Topic> DeletedTopics,
        ImmutableSortedDictionary<Topic, Error> ErrorTopics
    )
    {
        public static DeleteTopicsResult Empty { get; } = new(
            ImmutableArray<Topic>.Empty,
            ImmutableSortedDictionary<Topic, Error>.Empty
        );
    };
}
