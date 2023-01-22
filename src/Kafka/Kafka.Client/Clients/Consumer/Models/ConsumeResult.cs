using Kafka.Common.Types;

namespace Kafka.Client.Clients.Consumer.Models
{
    public abstract record ConsumeResult(
        TopicPartition TopicPartition,
        Offset Offset,
        Offset LastStableOffset,
        Offset LogStartOffset,
        Offset HighWatermark,
        Error Error
    );
    public sealed record ConsumeResult<TKey, TValue>(
        TopicPartition TopicPartition,
        Offset Offset,
        Offset LastStableOffset,
        Offset LogStartOffset,
        Offset HighWatermark,
        Error Error,
        ConsumerRecord<TKey, TValue> Record
    ) : ConsumeResult(
        TopicPartition,
        Offset,
        LastStableOffset,
        LogStartOffset,
        HighWatermark,
        Error
    );
    internal sealed record ControlResult(
        TopicPartition TopicPartition,
        Offset Offset,
        Offset LastStableOffset,
        Offset LogStartOffset,
        Offset HighWatermark,
        Error Error,
        ControlRecord Record
    ) : ConsumeResult(
        TopicPartition,
        Offset,
        LastStableOffset,
        LogStartOffset,
        HighWatermark,
        Error
    );
}
