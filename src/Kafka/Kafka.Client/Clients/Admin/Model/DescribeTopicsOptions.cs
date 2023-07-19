using System.Collections.Immutable;
using Kafka.Client.Model;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record DescribeTopicsOptions(
        int TimeoutMs,
        ImmutableArray<Guid> TopicIds,
        ImmutableArray<string> TopicNames,
        bool IncludeTopicAuthorizedOperations
    ) : ClientOptions(TimeoutMs)
    {
        public static DescribeTopicsOptions Empty { get; } = new(
            -1,
            ImmutableArray<Guid>.Empty,
            ImmutableArray<string>.Empty,
            false
        );
    };
}
