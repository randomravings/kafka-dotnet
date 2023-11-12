namespace Kafka.Client.IO
{
    public interface ITransaction :
        IDisposable
    {
        ValueTask Commit(CancellationToken cancellationToken);
        ValueTask Rollback(CancellationToken cancellationToken);
    }
}
