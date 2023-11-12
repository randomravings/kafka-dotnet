namespace Kafka.Common.Net
{
    public interface ITransport :
        IDisposable
    {
        bool IsConnected { get; }
        string Host { get; }
        int Port { get; }
        ValueTask Open(
            CancellationToken cancellationToken
        );
        ValueTask Close(
            CancellationToken cancellationToken
        );
        ValueTask Send(
            ReadOnlyMemory<byte> data,
            CancellationToken cancellationToken
        );
        ValueTask<byte[]> Receive(
            CancellationToken cancellationToken
        );
    }
}
