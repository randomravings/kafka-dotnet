namespace Kafka.Client.Clients.Consumer
{
    public interface IInputStream<TKey, TValue>
    {
        Task<IFetchResult<TKey, TValue>> Fetch(CancellationToken cancellationToken);
        Task Close(CancellationToken cancellationToken);
    }
}
