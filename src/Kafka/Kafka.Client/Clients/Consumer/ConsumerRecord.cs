using Kafka.Common;
using Kafka.Common.Records;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    public sealed record ConsumerRecord<TKey, TValue>(
        TopicPartitionOffset TopicPartitionOffset,
        Timestamp Timestamp,
        ImmutableArray<RecordHeader> Headers,
        TKey Key,
        TValue Value,
        ClusterInfo ClusterInfo
    )
        where TKey : notnull
        where TValue : notnull
    ;
}
