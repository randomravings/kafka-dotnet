namespace Kafka.Common.Network
{
    public interface ITransport :
        IDisposable
    {
        bool IsConnected { get; }
        public ValueTask Connect(CancellationToken token = default);
        ValueTask Disconnect(CancellationToken token = default);
        public ValueTask Handshake(CancellationToken token = default);
        public ValueTask<long> Read(Memory<byte> buffer, CancellationToken token = default);
        public ValueTask<long> Write(ReadOnlyMemory<byte> buffer, CancellationToken token = default);
    }
}
