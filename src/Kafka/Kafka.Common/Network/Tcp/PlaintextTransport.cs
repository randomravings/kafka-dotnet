using Kafka.Common.Encoding;
using System.Net;
using System.Net.Sockets;

namespace Kafka.Common.Network.Tcp
{
    public sealed class PlaintextTransport :
        ITransport
    {
        private readonly DnsEndPoint _endPoint;
        private readonly Socket _socket;
        private static readonly EndPoint NO_ENDPOINT = new IPEndPoint(0, 0);

        public PlaintextTransport(
            DnsEndPoint endPoint
        )
        {
            _endPoint = endPoint;
            _socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                ExclusiveAddressUse = true,
            };
        }
        bool ITransport.IsConnected =>
            _socket.Connected
        ;

        DnsEndPoint ITransport.RemoteEndPoint => _endPoint;
        EndPoint ITransport.LocalEndPoint => _socket?.LocalEndPoint ?? NO_ENDPOINT;

        async Task ITransport.Connect(CancellationToken cancellationToken) =>
            await _socket.ConnectAsync(_endPoint.Host, _endPoint.Port, cancellationToken)
        ;

        async Task ITransport.Disconnect(CancellationToken cancellationToken)
        {
            _socket.Close();
            await ValueTask.CompletedTask;
        }

        async Task ITransport.Handshake(CancellationToken cancellationToken) =>
            await ValueTask.CompletedTask
        ;

        async Task ITransport.Send(byte[] requestBytes, int offset, int length, CancellationToken cancellationToken) =>
            await Send(new byte[4], requestBytes, offset, length, cancellationToken)
        ;

        async Task<byte[]> ITransport.Receive(CancellationToken cancellationToken) =>
            await Receive(new byte[4], cancellationToken)
        ;

        async Task<byte[]> ITransport.HandleRequest(
            byte[] requestBytes,
            int offset,
            int length,
            CancellationToken cancellationToken
        )
        {
            var sizeBytes = new byte[4];
            await Send(sizeBytes, requestBytes, offset, length, cancellationToken);
            return await Receive(sizeBytes, cancellationToken);
        }

        async Task ITransport.Close(CancellationToken cancellationToken)
        {
            if (_socket.Connected)
                _socket.Close();
            await ValueTask.CompletedTask;
        }

        void IDisposable.Dispose()
        {
            if (_socket.Connected)
                _socket.Close();
            _socket.Dispose();
        }

        private static async ValueTask<bool> ReadBytesFromNetwork(
            Socket socket,
            byte[] bytes,
            CancellationToken cancellationToken
        )
        {
            var offset = 0;
            while (offset < bytes.Length)
            {
                var bytesReceived = await socket.ReceiveAsync(bytes.AsMemory(offset, bytes.Length - offset), SocketFlags.None, cancellationToken);
                if (bytesReceived == 0)
                    return false;
                offset += bytesReceived;
            }
            return true;
        }

        private async Task Send(byte[] sizeBytes, byte[] requestBytes, int offset, int length, CancellationToken cancellationToken)
        {
            Encoder.WriteInt32(sizeBytes, 0, length);
            await _socket.SendAsync(sizeBytes.AsMemory(0, 4), SocketFlags.Partial, cancellationToken);
            await _socket.SendAsync(requestBytes.AsMemory(offset, length), SocketFlags.None, cancellationToken);
        }

        private async Task<byte[]> Receive(byte[] sizeBytes, CancellationToken cancellationToken)
        {
            if (!await ReadBytesFromNetwork(_socket, sizeBytes, cancellationToken))
                return Array.Empty<byte>();
            (_, var messageLen) = Decoder.ReadInt32(sizeBytes, 0);
            var responseBytes = new byte[messageLen];
            if (!await ReadBytesFromNetwork(_socket, responseBytes, cancellationToken))
                return Array.Empty<byte>();
            return responseBytes;
        }
    }
}
