using Kafka.Common.Model;

namespace Kafka.Client
{
    public interface IGroupReadStream :
        IReadStream
    {
        /// <summary>
        /// Gets all Topic Partitions in the current stream.
        /// </summary>
        /// <returns></returns>
        IReadOnlySet<TopicPartition> Assignments { get; }

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
            IReadOnlySet<Topic> topics,
            CancellationToken cancellationToken
        );
    }
}
