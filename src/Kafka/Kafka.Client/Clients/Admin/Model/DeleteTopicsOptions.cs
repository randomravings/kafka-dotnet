using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record DeleteTopicsOptions(
        int TimeoutMs,
        short? ApiVersion,
        string ClientId,
        ImmutableArray<Guid> TopicIds,
        ImmutableArray<string> TopicNames
    ) : ClientOptions(TimeoutMs, ApiVersion, ClientId)
    {
        public static DeleteTopicsOptions Empty { get; } = new(
            -1,
            0,
            "",
            ImmutableArray<Guid>.Empty,
            ImmutableArray<string>.Empty
        );
    };
}
