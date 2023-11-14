using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record DeleteTopicResult(
        TopicId TopicId,
        TopicName TopicName,
        Error Error
    );
}
