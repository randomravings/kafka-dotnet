using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Types;

namespace Kafka.Client.Clients.Consumer.Models
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
