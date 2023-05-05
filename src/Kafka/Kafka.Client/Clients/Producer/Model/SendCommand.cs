using Kafka.Client.Commands;
using Kafka.Common.Model;
using Kafka.Common.Records;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer.Model
{
    internal sealed record SendCommand(
        TopicPartition TopicPartition,
        Timestamp Timestamp,
        ReadOnlyMemory<byte>? Key,
        ReadOnlyMemory<byte>? Value,
        ImmutableArray<RecordHeader> Headers,
        Attributes Attributes
    ) : Command<ProduceResult>(
        new TaskCompletionSource<ProduceResult>(
            TaskCreationOptions.RunContinuationsAsynchronously
        )
    );
}
