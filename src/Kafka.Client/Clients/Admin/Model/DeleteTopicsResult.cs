using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record DeleteTopicsResult(
        ImmutableArray<DeleteTopicResult> DeletedTopics,
        ImmutableArray<DeleteTopicError> ErrorTopics
    )
    {
        public static DeleteTopicsResult Empty { get; } = new(
            ImmutableArray<DeleteTopicResult>.Empty,
            ImmutableArray<DeleteTopicError>.Empty
        );
    };
}
