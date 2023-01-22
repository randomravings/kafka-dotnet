using Kafka.Common.Types;

namespace Kafka.Client.Clients.Consumer.Models
{
    public record TopicNames(
        params TopicName[] List
    )
    {
        public static implicit operator TopicNames(string[] topicNames) =>
            new(topicNames.Select(r => new TopicName(r)).ToArray())
        ;
        public static implicit operator TopicNames(string topicName) =>
            new(new TopicName(topicName))
        ;
    }
}
