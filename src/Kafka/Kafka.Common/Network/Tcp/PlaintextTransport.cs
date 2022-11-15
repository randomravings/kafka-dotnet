using System.Net.Sockets;

namespace Kafka.Common.Network.Tcp
{
    public sealed class PlaintextTransport :
        ITransport
    {
        private readonly int _receiveBufferSize = 1024 * 1024;
        private readonly string _host;
        private readonly int _port;
        private readonly TcpClient _tcpClient;

        public PlaintextTransport(string host, int port)
        {
            _host = host;
            _port = port;
            _tcpClient = new TcpClient();
        }
        bool ITransport.IsConnected =>
            _tcpClient.Connected
        ;

        async ValueTask ITransport.Connect(CancellationToken cancellationToken) =>
            await _tcpClient.ConnectAsync(_host, _port, cancellationToken)
        ;

        async ValueTask ITransport.Disconnect(CancellationToken cancellationToken)
        {
            _tcpClient.Close();
            await ValueTask.CompletedTask;
        }

        async ValueTask ITransport.Handshake(CancellationToken cancellationToken) =>
            await ValueTask.CompletedTask
        ;

        async ValueTask<MemoryStream> ITransport.HandleRequest(MemoryStream buffer, CancellationToken cancellationToken)
        {
            var len = (int)buffer.Length;
            var bytes = buffer.GetBuffer().AsMemory(0, len);
            var networkStream = _tcpClient.GetStream();
            await networkStream.WriteAsync(bytes, cancellationToken);
            await networkStream.FlushAsync(cancellationToken);
            var receiveBytes = new byte[_receiveBufferSize];
            await networkStream.ReadAsync(receiveBytes, cancellationToken);
            return new(receiveBytes);
        }

        void IDisposable.Dispose()
        {
            if (_tcpClient == null)
                return;
            if(_tcpClient.Connected)
                _tcpClient.Close();
            _tcpClient.Dispose();
        }
    }
}
