using Kafka.Common;
using Kafka.Common.Types;

namespace Kafka.Client.Clients.Consumer
{
    public interface IConsumer<TKey, TValue> :
        IClient
    {
        ValueTask<ConsumeResult<TKey, TValue>> Poll(CancellationToken token = default);
        ValueTask Subscribe(string topic, CancellationToken token = default);
        ValueTask Assign(TopicPartitionOffset topicPartitionOffset, CancellationToken token = default);
        ValueTask Assign(TopicPartitionOffsets topicPartitionOffsets, CancellationToken token = default);
        ValueTask UnAssign(TopicPartitionOffset topicPartitionOffset, CancellationToken token = default);
        ValueTask UnAssign(TopicPartitionOffsets topicPartitionOffsets, CancellationToken token = default);
    }

    public interface IConsumer<TValue> :
        IConsumer<Ignore, TValue>
    { }
}
