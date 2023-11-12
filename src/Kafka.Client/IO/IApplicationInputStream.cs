using Kafka.Client.Model;
using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IApplicationInputStream :
        IInputStream
    {
        ValueTask Commit(
            CancellationToken cancellationToken
        );

        ValueTask Commit(
            TopicPartitionOffset topicPartitionOffset,
            CancellationToken cancellationToken
        );

        ValueTask Commit(
            IEnumerable<TopicPartitionOffset> topicPartitionOffsets,
            CancellationToken cancellationToken
        );
    }
}
