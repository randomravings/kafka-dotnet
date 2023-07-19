namespace Kafka.Common.Network
{
    public interface IConnection
    {
        bool IsConnected { get; }
        ValueTask Open(CancellationToken cancellationToken);
        ValueTask Close(CancellationToken cancellationToken);
        string Host { get; }
        int Port { get; }
        ValueTask Send(
            byte[] requestBytes,
            int offset,
            int length,
            CancellationToken cancellationToken
        );
        ValueTask<byte[]> Receive(
            CancellationToken cancellationToken
        );
    }
}
