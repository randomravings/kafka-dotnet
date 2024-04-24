namespace Kafka.Client
{
    public interface ITransaction :
        IDisposable
    {
        Task Commit(CancellationToken cancellationToken);
        Task Rollback(CancellationToken cancellationToken);
    }
}
