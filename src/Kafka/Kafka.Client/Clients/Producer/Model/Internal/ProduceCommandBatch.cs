using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer.Model.Internal
{
    internal record ProduceCommandBatch(
        ImmutableArray<ProduceCommand> ProduceCommands
    ) : IProducerCommand;
}
