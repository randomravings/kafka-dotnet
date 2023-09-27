using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    public interface IStreamReaderAssigned<TKey, TValue> :
        IStreamReader<TKey, TValue>
    {
        ValueTask<ImmutableArray<TopicPartitionOffset>> SeekToBeginning(
            CancellationToken cancellationToken
        );
        ValueTask<ImmutableArray<TopicPartitionOffset>> SeekToEnd(
            CancellationToken cancellationToken
        );
        ValueTask<ImmutableArray<TopicPartitionOffset>> Seek(
            IReadOnlyDictionary<TopicPartition, Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        );
        ValueTask<ImmutableArray<TopicPartitionOffset>> Seek(
            IReadOnlyDictionary<TopicPartition, Timestamp> topicPartitionTimestamp,
            CancellationToken cancellationToken
        );
    }
}
