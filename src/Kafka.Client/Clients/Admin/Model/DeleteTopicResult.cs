using Kafka.Common.Model;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record DeleteTopicResult(
        TopicId Id,
        TopicName Name
    );
}
