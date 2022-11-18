using System.Collections.Immutable;
using static Kafka.Client.Messages.DeleteTopicsRequest;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record DeleteTopicsOptions(
        int TimeoutMs,
        short? ApiVersion,
        string ClientId,
        ImmutableArray<DeleteTopicState> TopicsField,
        ImmutableArray<string> TopicNamesField
    ) : ClientOptions(TimeoutMs, ApiVersion, ClientId)
    {
        public static DeleteTopicsOptions Empty { get; } = new(
            -1,
            0,
            "",
            ImmutableArray<DeleteTopicState>.Empty,
            ImmutableArray<string>.Empty
        );

        public record DeleteTopic(
            string? Name,
            Guid TopicId
        )
        {
            public static DeleteTopic Empty { get; } = new(
                null,
                Guid.Empty
            );
        }
    };
}
