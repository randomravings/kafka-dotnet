using Kafka.Common.Types;

namespace Kafka.Client.Clients.Consumer
{
    public sealed record ConsumeResult<TKey, TValue>(
        TopicPartition TopicPartition,
        Offset Offset,
        Offset LastStableOffset,
        Offset LogStartOffset,
        Offset HighWatermark,
        Error Error,
        ConsumerRecord<TKey, TValue> Record
    );
}
