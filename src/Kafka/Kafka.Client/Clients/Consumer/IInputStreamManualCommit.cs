using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Types;

namespace Kafka.Client.Clients.Consumer
{
    public interface IInputStreamManualCommit<TKey, TValue> :
        IInputStream<TKey, TValue>
    {
        ValueTask<CommitResult> Commit(
            ConsumeResult<TKey, TValue> consumeResult,
            CancellationToken cancellationToken
        );
        ValueTask<CommitResult> Commit(
            TopicPartition topicPartition,
            Offset offset,
            CancellationToken cancellationToken
        );
        ValueTask<CommitResult> Commit(
            IDictionary<TopicPartition, Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        );
    }
}
