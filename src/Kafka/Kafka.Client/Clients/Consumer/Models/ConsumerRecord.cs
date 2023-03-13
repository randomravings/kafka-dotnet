using Kafka.Common.Records;
using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer.Models
{
    public sealed record ConsumerRecord<TKey, TValue>(
        TopicPartition TopicPartition,
        Offset Offset,
        Timestamp Timestamp,
        TKey Key,
        TValue Value,
        ImmutableArray<RecordHeader> Headers
    );
}
