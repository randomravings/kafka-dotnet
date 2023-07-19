using Kafka.Common.Model;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record CreateTopicError(
        TopicName Name,
        Error Error
    );
}
