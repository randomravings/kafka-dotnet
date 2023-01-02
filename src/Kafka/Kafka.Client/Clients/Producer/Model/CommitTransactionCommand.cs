namespace Kafka.Client.Clients.Producer.Model
{
    public record CommitTransactionCommand(
        string TransactionId,
        TaskCompletionSource<ITransaction> TaskCompletionSource
    ) : IProducerCommand;
}
