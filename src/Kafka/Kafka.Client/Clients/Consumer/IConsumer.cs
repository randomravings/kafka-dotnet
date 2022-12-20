using Kafka.Common;
using Kafka.Common.Types;

namespace Kafka.Client.Clients.Consumer
{
    public interface IConsumer<TKey, TValue> :
        IClient
    {
        ValueTask<ConsumeResult<TKey, TValue>> Poll(CancellationToken cancellationToken = default);
        ValueTask Subscribe(TopicName topic, CancellationToken cancellationToken = default);
        ValueTask Unsubscribe(TopicName topic, CancellationToken cancellationToken = default);
        ValueTask Assign(TopicPartitionOffset topicPartitionOffset, CancellationToken cancellationToken = default);
        ValueTask Assign(TopicPartitionOffsets topicPartitionOffsets, CancellationToken cancellationToken = default);
        ValueTask UnAssign(TopicPartitionOffset topicPartitionOffset, CancellationToken cancellationToken = default);
        ValueTask UnAssign(TopicPartitionOffsets topicPartitionOffsets, CancellationToken cancellationToken = default);
    }
}
