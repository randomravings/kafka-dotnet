using Kafka.Common.Records;
using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer.Model.Internal
{
    internal record ProduceCommand(
        TopicPartition TopicPartition,
        Timestamp Timestamp,
        ReadOnlyMemory<byte>? Key,
        ReadOnlyMemory<byte>? Value,
        ImmutableArray<RecordHeader> Headers,
        Attributes Attributes,
        TaskCompletionSource<ProduceResult> TaskCompletionSource
    ) : IProducerCommand;
}
