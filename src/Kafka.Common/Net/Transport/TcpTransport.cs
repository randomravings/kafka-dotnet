using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Sockets;

namespace Kafka.Common.Net.Transport
{
    public abstract class TcpTransport :
        ITransport,
        IDisposable
    {
        private readonly DnsEndPoint _endPoint;
        private readonly Socket _socket;
        private readonly ILogger _logger;
        private bool _disposed;

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

        public string Host => _endPoint.Host;

        public int Port => _endPoint.Port;

        public bool IsConnected => _socket.Connected;

        public async ValueTask Open(
            CancellationToken cancellationToken
        )
        {
            try
            {
                await _socket.ConnectAsync(_endPoint.Host, _endPoint.Port, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new OpenConnectionException("Error during connect", ex);
            }
        }

        public ValueTask Close(
            CancellationToken cancellationToken
        )
        {
            try
            {
                if (_socket.Connected)
                    _socket.Close();
                return ValueTask.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new OpenConnectionException("Error during close", ex);
            }
        }

        public async ValueTask Send(
            ReadOnlyMemory<byte> data,
            CancellationToken cancellationToken
        )
        {
            var lenBytes = new byte[4];
            _ = BinaryEncoder.WriteInt32(lenBytes, 0, data.Length);
            await _socket.SendAsync(
                lenBytes,
                cancellationToken
            ).ConfigureAwait(false);
            await _socket.SendAsync(
                data,
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async ValueTask<byte[]> Receive(
            CancellationToken cancellationToken
        )
        {
            var sizeBytes = new byte[4];
            if (!await ReadBytesFromNetwork(_socket, sizeBytes, cancellationToken).ConfigureAwait(false))
                return [];
            (_, var messageLen) = BinaryDecoder.ReadInt32(sizeBytes, 0);
            var responseBytes = new byte[messageLen];
            if (!await ReadBytesFromNetwork(_socket, responseBytes, cancellationToken).ConfigureAwait(false))
                return [];
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

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _socket.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
