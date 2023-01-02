using Kafka.Client.Clients.Producer.Model;

namespace Kafka.Client.Clients.Producer
{
    public interface ITransaction
    {
        string? TransactionId { get; }
        TxnState TxnState { get; }
        Task Commit(CancellationToken cancellationToken);
        Task Rollback(CancellationToken cancellationToken);
    }
}
