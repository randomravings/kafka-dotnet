using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    public interface IInputStreamApplication<TKey, TValue> :
        IInputStream<TKey, TValue>
    {
        ValueTask<CommitResult> Commit(
            CancellationToken cancellationToken
        );
        ValueTask<CommitResult> Commit(
            TopicPartitionOffset topicPartitionOffset,
            CancellationToken cancellationToken
        );
        ValueTask<ImmutableArray<TopicPartitionOffset>> Commit(
            ImmutableSortedDictionary<TopicPartition, Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        );
    }
}
