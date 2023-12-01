using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IApplicationInputStream :
        IInputStream
    {
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
    }
}
