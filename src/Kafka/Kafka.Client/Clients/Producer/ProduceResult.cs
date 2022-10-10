using Kafka.Common;

namespace Kafka.Client.Clients.Producer
{
    public sealed record ProduceResult<TKey, TValue>(
        TopicPartitionOffset TopicPartitionOffset,
        ProducerRecord<TKey, TValue> Record
    );
}
