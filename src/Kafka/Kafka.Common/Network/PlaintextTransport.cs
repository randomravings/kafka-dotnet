using System.Net.Sockets;

namespace Kafka.Common.Network
{
    internal sealed class PlaintextTransport :
        ITransport
    {
        private readonly ValueTask NOOP = new();
        private readonly string _host;
        private readonly int _port;
        public readonly TcpClient _tcpClient;

        bool ITransport.IsConnected => throw new NotImplementedException();

        public PlaintextTransport(string host, int port)
        {
            _host = host;
            _port = port;
            _tcpClient = new();
        }

        async ValueTask ITransport.Connect(CancellationToken token) =>
            await _tcpClient.ConnectAsync(_host, _port, token);

        async ValueTask ITransport.Handshake(CancellationToken token) =>
            await NOOP
        ;

        async ValueTask<long> ITransport.Read(Memory<byte> buffer, CancellationToken token) =>
            await _tcpClient.GetStream().ReadAsync(buffer, token)
        ;

        async ValueTask<long> ITransport.Write(ReadOnlyMemory<byte> buffer, CancellationToken token)
        {
            await _tcpClient.GetStream().WriteAsync(buffer, token);
            return buffer.Length;
        }

        async ValueTask ITransport.Disconnect(CancellationToken token) =>
            await _tcpClient.Client.DisconnectAsync(true, token)
        ;

        void IDisposable.Dispose()
        {
            if (_tcpClient.Client.Connected)
                _tcpClient.Client.Disconnect(true);
            _tcpClient.Dispose();
        }
    }
}
