using Kafka.Common.Model;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record DeleteTopicError(
        TopicName Name,
        Error Error
    );
}
