using Kafka.Common.Model;

namespace Kafka.Client.Clients.Consumer.Models
{
    public record TopicIds(
        params TopicId[] List
    )
    {
        public static implicit operator TopicIds(TopicId[] topicNames) =>
            new(topicNames)
        ;
        public static implicit operator TopicIds(TopicId topicName) =>
            new(topicName)
        ;
    }
}
