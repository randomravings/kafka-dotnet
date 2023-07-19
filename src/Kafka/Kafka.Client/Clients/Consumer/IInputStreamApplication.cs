using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    public interface IInputStreamApplication<TKey, TValue> :
        IConsumerInstance<TKey, TValue>,
        IDisposable
    {
        ValueTask Commit(
            CancellationToken cancellationToken
        );
        ValueTask Commit(
            TopicPartitionOffset topicPartitionOffset,
            CancellationToken cancellationToken
        );
        ValueTask<ImmutableArray<TopicPartitionOffset>> Commit(
            ImmutableSortedDictionary<TopicPartition, Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        );
    }
}
