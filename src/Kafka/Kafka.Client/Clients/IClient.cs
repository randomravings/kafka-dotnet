namespace Kafka.Client.Clients
{
    public interface IClient :
        IDisposable
    {
        /// <summary>
        /// Perform gracefult shut down of client and free up resources.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask Close(CancellationToken cancellationToken = default);
    }
}
