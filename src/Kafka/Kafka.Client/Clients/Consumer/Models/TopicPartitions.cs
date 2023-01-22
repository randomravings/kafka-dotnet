using Kafka.Common.Types;

namespace Kafka.Client.Clients.Consumer.Models
{
    public record TopicPartitions(
        params TopicPartition[] List
    )
    {
        public static implicit operator TopicPartitions(TopicPartition[] topicPartitionOffsets) =>
            new(topicPartitionOffsets)
        ;
        public static implicit operator TopicPartitions(TopicPartition topicPartitionOffset) =>
            new(topicPartitionOffset)
        ;
        public static implicit operator TopicPartitions((string, int) topicPartitionOffset) =>
            new(topicPartitionOffset)
        ;
        public static implicit operator TopicPartitions((string, int)[] topicPartitionOffset) =>
            new(topicPartitionOffset)
        ;
    }
}
