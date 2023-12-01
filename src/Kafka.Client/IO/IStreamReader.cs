using Kafka.Client.Model;

namespace Kafka.Client.IO
{
    public interface IStreamReader
    {
        ValueTask<InputRecord> Read(
            CancellationToken cancellationToken
        );
        ValueTask<InputRecord> Read(
            TimeSpan timeout,
            CancellationToken cancellationToken
        );
        Task Close(
            CancellationToken cancellationToken
        );
    }

    public interface IStreamReader<TKey, TValue>
    {
        ValueTask<ReadRecord<TKey, TValue>> Read(
            CancellationToken cancellationToken
        );
        ValueTask<ReadRecord<TKey, TValue>> Read(
            TimeSpan timeout,
            CancellationToken cancellationToken
        );
        Task Close(
            CancellationToken cancellationToken
        );
    }
}
