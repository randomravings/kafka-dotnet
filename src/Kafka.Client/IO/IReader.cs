using Kafka.Client.Model;

namespace Kafka.Client.IO
{
    public interface IReader
    {
        ValueTask<ReadRecord> Read(
            CancellationToken cancellationToken
        );
        ValueTask<ReadRecord> Read(
            TimeSpan timeout,
            CancellationToken cancellationToken
        );
        Task Close(
            CancellationToken cancellationToken
        );
    }

    public interface IReader<TKey, TValue>
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
