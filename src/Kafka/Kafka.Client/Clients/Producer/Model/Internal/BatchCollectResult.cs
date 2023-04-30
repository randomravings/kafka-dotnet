using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer.Model.Internal
{
    internal sealed record BatchCollectResult<TKey, TValue>(
        BatchCollectReason Reason,
        ImmutableArray<ProduceCommand> Batch,
        ProduceCommand? Overflow = default
    );
}
