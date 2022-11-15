namespace Kafka.Common.Network
{
    public interface ITransport :
        IDisposable
    {
        bool IsConnected { get; }
        ValueTask Connect(CancellationToken cancellationToken = default);
        ValueTask Disconnect(CancellationToken cancellationToken = default);
        ValueTask Handshake(CancellationToken cancellationToken = default);
        ValueTask<MemoryStream> HandleRequest(MemoryStream buffer, CancellationToken cancellationToken = default);
    }
}
