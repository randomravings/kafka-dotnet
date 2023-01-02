namespace Kafka.Client.Clients.Producer.Model
{
    public record RollbackTransactionCommand(
        string TransactionId,
        TaskCompletionSource<ITransaction> TaskCompletionSource
    ) : IProducerCommand;
}
