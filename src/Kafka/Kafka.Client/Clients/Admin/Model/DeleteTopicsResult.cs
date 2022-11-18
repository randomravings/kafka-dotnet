using Kafka.Common.Exceptions;
using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record DeleteTopicsResult(
        ImmutableArray<Topic> DeletedTopics,
        ImmutableSortedDictionary<Topic, ApiException> ErrorTopics
    )
    {
        public static DeleteTopicsResult Empty { get; } = new(
            ImmutableArray<Topic>.Empty,
            ImmutableSortedDictionary<Topic, ApiException>.Empty
        );
    };
}
