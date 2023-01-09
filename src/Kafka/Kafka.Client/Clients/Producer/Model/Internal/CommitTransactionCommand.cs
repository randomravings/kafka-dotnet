namespace Kafka.Client.Clients.Producer.Model.Internal
{
    internal record CommitTransactionCommand(
        string TransactionId,
        TaskCompletionSource<ITransaction> TaskCompletionSource
    ) : IProducerCommand;
}
