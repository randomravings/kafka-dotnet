using Kafka.Common.Records;
using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer.Model
{
    public sealed record ProduceResult<TKey, TValue>(
        TopicPartitionOffset TopicPartitionOffset,
        Timestamp Timestamp,
        ImmutableArray<RecordHeader> Headers,
        TKey Key,
        TValue Value,
        Error Error,
        string RecordError
    );
}
