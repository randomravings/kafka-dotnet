namespace Kafka.Common.Network
{
    public interface ITransport :
        IDisposable
    {
        bool IsConnected { get; }
        ValueTask Connect(CancellationToken cancellationToken = default);
        ValueTask Disconnect(CancellationToken cancellationToken = default);
        ValueTask Handshake(CancellationToken cancellationToken = default);
        ValueTask<ReadOnlyMemory<byte>> HandleRequest(ReadOnlyMemory<byte> requestBytes, CancellationToken cancellationToken = default);
    }
}
