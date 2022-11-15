using Kafka.Common;
using Kafka.Common.Types;

namespace Kafka.Client.Clients.Consumer
{
    internal interface IConsumer<TKey, TValue> :
        IClient
        where TKey : notnull
        where TValue : notnull
    {
        ValueTask<ConsumeResult<TKey, TValue>> Poll(CancellationToken token = default);
        ValueTask Subscribe(string topic, CancellationToken token = default);
        ValueTask Assign(TopicPartitionOffset topicPartitionOffset, CancellationToken token = default);
        ValueTask Assign(TopicPartitionOffsets topicPartitionOffsets, CancellationToken token = default);
        ValueTask UnAssign(TopicPartitionOffset topicPartitionOffset, CancellationToken token = default);
        ValueTask UnAssign(TopicPartitionOffsets topicPartitionOffsets, CancellationToken token = default);
    }
}
