using Kafka.Common.Encoding;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;

namespace Kafka.Common.Network.Tcp
{
    public sealed class PlaintextTransport :
        ITransport
    {
        private readonly DnsEndPoint _endPoint;
        private readonly TcpClient _tcpClient;

        public PlaintextTransport(DnsEndPoint endPoint)
        {
            _endPoint = endPoint;
            _tcpClient = new TcpClient();
        }
        bool ITransport.IsConnected =>
            _tcpClient.Connected
        ;

        async ValueTask ITransport.Connect(CancellationToken cancellationToken) =>
            await _tcpClient.ConnectAsync(_endPoint.Host, _endPoint.Port, cancellationToken)
        ;

        async ValueTask ITransport.Disconnect(CancellationToken cancellationToken)
        {
            _tcpClient.Close();
            await ValueTask.CompletedTask;
        }

        async ValueTask ITransport.Handshake(CancellationToken cancellationToken) =>
            await ValueTask.CompletedTask
        ;

        async ValueTask<byte[]> ITransport.HandleRequest(
            byte[] requestBytes,
            int offset,
            int length,
            CancellationToken cancellationToken
        )
        {
            var networkStream = _tcpClient.GetStream();
            await networkStream.WriteAsync(requestBytes.AsMemory(offset, length), cancellationToken);
            await networkStream.FlushAsync(cancellationToken);
            var sizeBytes = new byte[4];
            await ReadBytesFromNetwork(networkStream, sizeBytes, cancellationToken);
            var index = 0;
            var messageLen = Decoder.ReadInt32(sizeBytes, ref index);
            var responseBytes = new byte[messageLen];
            await ReadBytesFromNetwork(networkStream, responseBytes, cancellationToken);
            return responseBytes;
        }

        private static async ValueTask ReadBytesFromNetwork(
            NetworkStream stream,
            byte[] bytes,
            CancellationToken cancellationToken
        )
        {
            var offset = 0;
            while (offset < bytes.Length)
            {
                var bytesReceived = await stream.ReadAsync(bytes.AsMemory(offset, bytes.Length - offset), cancellationToken);
                if (bytesReceived == 0)
                    throw new IOException("No bytes received");
                offset += bytesReceived;
            }
        }

        void IDisposable.Dispose()
        {
            if (_tcpClient == null)
                return;
            if (_tcpClient.Connected)
                _tcpClient.Close();
            _tcpClient.Dispose();
        }
    }
}
