using Kafka.Common.Encoding;
using System.Net.Sockets;

namespace Kafka.Common.Network.Tcp
{
    public sealed class PlaintextTransport :
        ITransport
    {
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

        async ValueTask<ReadOnlyMemory<byte>> ITransport.HandleRequest(
            ReadOnlyMemory<byte> requestBytes,
            CancellationToken cancellationToken
        )
        {
            var networkStream = _tcpClient.GetStream();
            Encoder.WriteInt32(networkStream, requestBytes.Length);
            await networkStream.WriteAsync(requestBytes, cancellationToken);
            await networkStream.FlushAsync(cancellationToken);
            var sizeBytes = new byte[4].AsMemory();
            await ReadBytesFromNetwork(networkStream, sizeBytes, cancellationToken);
            var sizeBytesRef = (ReadOnlyMemory<byte>)sizeBytes;
            var messageLen = Decoder.ReadInt32(ref sizeBytesRef);
            var responseBytes = new byte[messageLen].AsMemory();
            await ReadBytesFromNetwork(networkStream, responseBytes, cancellationToken);
            return responseBytes;
        }

        private static async ValueTask ReadBytesFromNetwork(
            NetworkStream stream,
            Memory<byte> bytes,
            CancellationToken cancellationToken
        )
        {
            var offset = 0;
            while (offset < bytes.Length)
            {
                var len = await stream.ReadAsync(bytes[offset..], cancellationToken);
                if (len == 0)
                    throw new IOException("No bytes received");
                offset += len;
            }
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
