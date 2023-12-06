using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IManualReader :
        IReader
    {
        ValueTask Assign(
            TopicPartition topicPartition
        );
        ValueTask Assign(
            IReadOnlyList<TopicPartition> topicPartitions
        );
        ValueTask Assign(
            TopicPartitionOffset topicPartitionOffset
        );
        ValueTask Assign(
            IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets
        );
        ValueTask Unassign(
            TopicPartition topicPartitionOffset
        );
        ValueTask Unassign(
            IReadOnlyList<TopicPartition> topicPartitions
        );
        ValueTask Seek(
            TopicPartitionOffset topicPartitionOffset
        );
        ValueTask Seek(
            IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets
        );
        ValueTask Seek(
            TopicPartition topicPartition
        );
        ValueTask Seek(
            IReadOnlyList<TopicPartition> topicPartitions,
            Timestamp timestamp
        );
        ValueTask SeekBeginning();
        ValueTask SeekBeginning(
            TopicPartition topicPartition
        );
        ValueTask SeekBeginning(
            IReadOnlyList<TopicPartition> topicPartitions
        );
        ValueTask SeekEnd();
        ValueTask SeekEnd(
            TopicPartition topicPartition
        );
        ValueTask SeekEnd(
            IReadOnlyList<TopicPartition> topicPartitions
        );
    }

    public interface IManualReader<TKey, TValue> :
        IReader<TKey, TValue>
    {
    }
}
