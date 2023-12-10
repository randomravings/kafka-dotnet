namespace Kafka.Client.IO
{
    public interface ITransaction :
        IDisposable
    {
        Task Commit(CancellationToken cancellationToken);
        Task Rollback(CancellationToken cancellationToken);
    }
}
