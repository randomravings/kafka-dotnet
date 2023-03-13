using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    public interface IInputStreamAssigned<TKey, TValue> :
        IInputStream<TKey, TValue>
    {
        ValueTask<ImmutableArray<TopicPartitionOffset>> SeekToBeginning(
            CancellationToken cancellationToken
        );
        ValueTask<ImmutableArray<TopicPartitionOffset>> SeekToEnd(
            CancellationToken cancellationToken
        );
        ValueTask<ImmutableArray<TopicPartitionOffset>> Seek(
            ImmutableArray<TopicPartitionOffset> topicPartitionOffsets,
            CancellationToken cancellationToken
        );
        ValueTask<ImmutableArray<TopicPartitionOffset>> Seek(
            ImmutableArray<TopicPartition> topicPartitionOffsets,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        );
    }
}
