using System.Collections.Immutable;
using Kafka.Client.Model;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record DeleteTopicsOptions(
        int TimeoutMs,
        ImmutableArray<Guid> TopicIds,
        ImmutableArray<string> TopicNames
    ) : ClientOptions(TimeoutMs)
    {
        public static DeleteTopicsOptions Empty { get; } = new(
            -1,
            ImmutableArray<Guid>.Empty,
            ImmutableArray<string>.Empty
        );
    };
}
