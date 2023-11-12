using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record CreateTopicError(
        TopicName Name,
        Error Error
    );
}
