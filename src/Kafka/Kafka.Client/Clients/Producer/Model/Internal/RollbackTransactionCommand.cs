namespace Kafka.Client.Clients.Producer.Model.Internal
{
    internal record RollbackTransactionCommand(
        string TransactionId,
        TaskCompletionSource<ITransaction> TaskCompletionSource
    ) : IProducerCommand;
}
