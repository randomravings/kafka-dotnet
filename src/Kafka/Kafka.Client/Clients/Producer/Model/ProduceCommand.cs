using Kafka.Common.Records;
using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer.Model
{
    public record ProduceCommand<TKey, TValue>(
        TopicName Topic,
        Partition Partition,
        Timestamp Timestamp,
        ReadOnlyMemory<byte>? Key,
        ReadOnlyMemory<byte>? Value,
        ImmutableArray<RecordHeader> Headers,
        TaskCompletionSource<ProduceResult<TKey, TValue>> TaskCompletionSource
    ) : IProducerCommand;
}
