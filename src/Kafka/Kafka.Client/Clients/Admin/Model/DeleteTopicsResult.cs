using Kafka.Common.Types;
using System.Collections.Immutable;
using static Kafka.Client.Clients.Admin.Model.DeleteTopicsResult;

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

        public sealed record DeleteTopicResult(
            TopicId Id,
            TopicName Name
        );

        public sealed record DeleteTopicError(
            TopicName Name,
            Error Error
        );
    };
}
