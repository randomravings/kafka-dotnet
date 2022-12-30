namespace Kafka.Common.Network
{
    public interface ITransport :
        IDisposable
    {
        bool IsConnected { get; }
        ValueTask Connect(CancellationToken cancellationToken = default);
        ValueTask Disconnect(CancellationToken cancellationToken = default);
        ValueTask Handshake(CancellationToken cancellationToken = default);
        ValueTask<byte[]> HandleRequest(
            byte[] requestBytes,
            int offset,
            int length,
            CancellationToken cancellationToken
        );
        ValueTask Close(CancellationToken cancellationToken = default);
    }
}
