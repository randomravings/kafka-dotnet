using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IGroupReadStream :
        IReadStream
    {
        IGroupReaderBuilder CreateReader();

        Task Commit(
            CancellationToken cancellationToken
        );

        Task Commit(
            TopicPartitionOffset topicPartitionOffset,
            CancellationToken cancellationToken
        );

        Task Commit(
            IEnumerable<TopicPartitionOffset> topicPartitionOffsets,
            CancellationToken cancellationToken
        );
        Task AddReader(
            IReadOnlySet<TopicName> topics,
            CancellationToken cancellationToken
        );
    }
}
