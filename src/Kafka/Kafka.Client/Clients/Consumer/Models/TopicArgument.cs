using Kafka.Common.Types;

namespace Kafka.Client.Clients.Consumer.Models
{
    public record TopicList(
        params TopicName[] Names
    );
}
