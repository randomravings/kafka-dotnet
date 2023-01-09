using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer.Model.Internal
{
    internal record ProduceCommandBatch<TKey, TValue>(
        ImmutableArray<ProduceCommand<TKey, TValue>> ProduceCommands
    ) : IProducerCommand;
}
