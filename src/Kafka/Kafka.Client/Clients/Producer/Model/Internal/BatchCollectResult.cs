using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer.Model.Internal
{
    internal sealed record BatchCollectResult<TKey, TValue>(
        BatchCollectReason BatchAccumulatedReason,
        ImmutableArray<ProduceCommand<TKey, TValue>> ProduceCommands,
        ProduceCommand<TKey, TValue>? CarryOver,
        IProducerCommand? ControlCommand
    );
}
