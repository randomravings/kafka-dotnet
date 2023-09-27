namespace Kafka.Client.Clients.Producer
{
    public interface ITransaction :
        IDisposable
    {
        ValueTask Commit(CancellationToken cancellationToken);
        ValueTask Rollback(CancellationToken cancellationToken);
    }
}
