using Kafka.Common.Records;
using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    public sealed record ConsumerRecord<TKey, TValue>(
        Timestamp Timestamp,
        ImmutableArray<RecordHeader> Headers,
        TKey Key,
        TValue Value
    );
}
