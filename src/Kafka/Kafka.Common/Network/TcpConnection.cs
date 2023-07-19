using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using System.Net;
using System.Net.Sockets;

namespace Kafka.Common.Network
{
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    public sealed class TcpConnection :
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
        IConnection
    {
        private readonly DnsEndPoint _endPoint;
        private readonly Socket _socket;

        public TcpConnection(
            string host,
            int port
        )
        {
            _endPoint = new DnsEndPoint(host, port, AddressFamily.InterNetwork);
            _socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                ExclusiveAddressUse = true,
            };
        }

        string IConnection.Host => _endPoint.Host;

        int IConnection.Port => _endPoint.Port;

        bool IConnection.IsConnected => _socket.Connected;

        async ValueTask IConnection.Open(CancellationToken cancellationToken)
        {
            try
            {
                await _socket.ConnectAsync(_endPoint.Host, _endPoint.Port, cancellationToken).ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                throw new OpenConnectionException("Error during connect", ex);
            }
        }

        ValueTask IConnection.Close(CancellationToken cancellationToken)
        {
            if (_socket.Connected)
                _socket.Close();
            _socket.Dispose();
            return ValueTask.CompletedTask;
        }

        async ValueTask IConnection.Send(byte[] requestBytes, int offset, int length, CancellationToken cancellationToken) =>
            await Send(new byte[4], requestBytes, offset, length, cancellationToken).ConfigureAwait(false)
        ;

        async ValueTask<byte[]> IConnection.Receive(CancellationToken cancellationToken) =>
            await Receive(new byte[4], cancellationToken).ConfigureAwait(false)
        ;

        private static async ValueTask<bool> ReadBytesFromNetwork(
            Socket socket,
            byte[] bytes,
            CancellationToken cancellationToken
        )
        {
            var offset = 0;
            while (offset < bytes.Length)
            {
                var bytesReceived = await socket.ReceiveAsync(
                    bytes.AsMemory(offset, bytes.Length - offset),
                    SocketFlags.None,
                    cancellationToken
                ).ConfigureAwait(false);
                if (bytesReceived == 0)
                    return false;
                offset += bytesReceived;
            }
            return true;
        }

        private async ValueTask Send(byte[] sizeBytes, byte[] requestBytes, int offset, int length, CancellationToken cancellationToken)
        {
            BinaryEncoder.WriteInt32(sizeBytes, 0, length);
            await _socket.SendAsync(
                sizeBytes.AsMemory(0, 4),
                SocketFlags.Partial,
                cancellationToken
            ).ConfigureAwait(false);
            await _socket.SendAsync(
                requestBytes.AsMemory(offset, length),
                SocketFlags.None,
                cancellationToken
            ).ConfigureAwait(false);
        }

        private async ValueTask<byte[]> Receive(byte[] sizeBytes, CancellationToken cancellationToken)
        {
            if (!await ReadBytesFromNetwork(_socket, sizeBytes, cancellationToken).ConfigureAwait(false))
                return Array.Empty<byte>();
            (_, var messageLen) = BinaryDecoder.ReadInt32(sizeBytes, 0);
            var responseBytes = new byte[messageLen];
            if (!await ReadBytesFromNetwork(_socket, responseBytes, cancellationToken).ConfigureAwait(false))
                return Array.Empty<byte>();
            return responseBytes;
        }

        public void Dispose() =>
            _socket.Dispose()
        ;
    }
}