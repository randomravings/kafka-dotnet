using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Sockets;

namespace Kafka.Common.Net.Transport
{
    public abstract class TcpTransport :
        ITransport
    {
        private readonly DnsEndPoint _endPoint;
        private readonly Socket _socket;
        private readonly ILogger _logger;

        protected TcpTransport(
            string host,
            int port,
            ILogger logger
        )
        {
            _endPoint = new DnsEndPoint(host, port, AddressFamily.InterNetwork);
            _socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                ExclusiveAddressUse = true,
            };
            _logger = logger;
        }

        string ITransport.Host => _endPoint.Host;

        int ITransport.Port => _endPoint.Port;

        bool ITransport.IsConnected => _socket.Connected;

        async ValueTask ITransport.Open(
            CancellationToken cancellationToken
        )
        {
            try
            {
                await _socket.ConnectAsync(_endPoint.Host, _endPoint.Port, cancellationToken).ConfigureAwait(false);
                await Task.Yield();
            }
            catch (Exception ex)
            {
                throw new OpenConnectionException("Error during connect", ex);
            }
        }

        async ValueTask ITransport.Close(
            CancellationToken cancellationToken
        )
        {
            try
            {
                if (_socket.Connected)
                    _socket.Close();
                await Task.Yield();
            }
            catch (Exception ex)
            {
                throw new OpenConnectionException("Error during close", ex);
            }
        }

        async ValueTask ITransport.Send(
            ReadOnlyMemory<byte> requestBytes,
            CancellationToken cancellationToken
        )
        {
            var lenBytes = new byte[4];
            _ = BinaryEncoder.WriteInt32(lenBytes, 0, requestBytes.Length);
            await _socket.SendAsync(
                lenBytes,
                cancellationToken
            ).ConfigureAwait(false);
            await _socket.SendAsync(
                requestBytes,
                cancellationToken
            ).ConfigureAwait(false);
        }

        void IDisposable.Dispose()
        {
            _socket.Dispose();
            GC.SuppressFinalize(this);
        }

        async ValueTask<byte[]> ITransport.Receive(
            CancellationToken cancellationToken
        )
        {
            var sizeBytes = new byte[4];
            if (!await ReadBytesFromNetwork(_socket, sizeBytes, cancellationToken).ConfigureAwait(false))
                return Array.Empty<byte>();
            (_, var messageLen) = BinaryDecoder.ReadInt32(sizeBytes, 0);
            var responseBytes = new byte[messageLen];
            if (!await ReadBytesFromNetwork(_socket, responseBytes, cancellationToken).ConfigureAwait(false))
                return Array.Empty<byte>();
            return responseBytes;
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
                var bytesReceived = await socket.ReceiveAsync(
                    bytes.AsMemory(offset, bytes.Length - offset),
                    cancellationToken
                ).ConfigureAwait(false);
                if (bytesReceived == 0)
                    return false;
                offset += bytesReceived;
            }
            return true;
        }
    }
}
