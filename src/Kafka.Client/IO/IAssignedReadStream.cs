using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IAssignedReadStream :
        IReadStream
    {
        IAssignedReaderBuilder CreateReader();

        ValueTask Seek(
            IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets
        );

        ValueTask Assign(IReadOnlyList<TopicPartition> topicPartitions);

        ValueTask Unassign(IReadOnlyList<TopicPartition> topicPartitions);
    }
}
