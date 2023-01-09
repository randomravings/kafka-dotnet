namespace Kafka.Client.Clients.Producer.Model.Internal
{
    internal record BeginTransactionCommand(
        TaskCompletionSource<ITransaction> TaskCompletionSource
    ) : IProducerCommand;
}
