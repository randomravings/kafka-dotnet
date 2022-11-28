using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record DescribeTopicsOptions(
        int TimeoutMs,
        short? ApiVersion,
        string ClientId,
        ImmutableArray<Guid> TopicIds,
        ImmutableArray<string> TopicNames,
        bool IncludeTopicAuthorizedOperations
    ) : ClientOptions(TimeoutMs, ApiVersion, ClientId)
    {
        public static DescribeTopicsOptions Empty { get; } = new(
            -1,
            0,
            "",
            ImmutableArray<Guid>.Empty,
            ImmutableArray<string>.Empty,
            false
        );
    };
}
