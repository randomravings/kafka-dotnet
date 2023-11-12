using Kafka.Client.Model;

namespace Kafka.Client.IO
{
    public interface IStreamReader<TKey, TValue> :
        IDisposable
    {
        ValueTask<ConsumerRecord<TKey, TValue>> Read(
            CancellationToken cancellationToken
        );
        ValueTask<ConsumerRecord<TKey, TValue>> Read(
            TimeSpan timeout,
            CancellationToken cancellationToken
        );
        Task Close(
            CancellationToken cancellationToken
        );
    }
}
