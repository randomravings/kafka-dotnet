using Kafka.Common.Model;

namespace Kafka.Client.Clients.Consumer
{
    public interface IStreamReaderApplication<TKey, TValue> :
        IStreamReader<TKey, TValue>
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
