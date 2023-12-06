using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record DeleteTopicError(
        TopicName Name,
        ApiError Error
    );
}
