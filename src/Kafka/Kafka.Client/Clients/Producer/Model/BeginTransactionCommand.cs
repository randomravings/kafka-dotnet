namespace Kafka.Client.Clients.Producer.Model
{
    public record BeginTransactionCommand(
        TaskCompletionSource<ITransaction> TaskCompletionSource
    ) : IProducerCommand;
}
