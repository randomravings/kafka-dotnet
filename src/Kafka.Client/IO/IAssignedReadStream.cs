using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IAssignedReadStream :
        IReadStream
    {
        IAssignedReaderBuilder CreateReader();

        ValueTask Seek(
            IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets,
            CancellationToken cancellationToken
        );

        ValueTask Assign(
            IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets,
            CancellationToken cancellationToken
        );

        ValueTask Unassign(
            IReadOnlyList<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        );
    }
}
