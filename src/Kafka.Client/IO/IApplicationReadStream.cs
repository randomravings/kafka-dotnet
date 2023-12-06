using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IApplicationReadStream :
        IReadStream
    {
        IApplicationReaderBuilder CreateReader();

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
