using Kafka.Common.Model;

namespace Kafka.Client.Model
{
    public sealed record DeleteTopicResult(
        TopicId Id,
        TopicName Name
    );
}
