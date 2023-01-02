using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer.Model
{
    public record ProduceCommandBatch<TKey, TValue>(
        ImmutableArray<ProduceCommand<TKey, TValue>> ProduceCommands
    ) : IProducerCommand;
}
