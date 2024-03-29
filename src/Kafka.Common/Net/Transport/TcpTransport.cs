﻿using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Sockets;

namespace Kafka.Common.Net.Transport
{
    public sealed class TcpTransport :
        ITransport,
        IDisposable
    {
        private readonly IPEndPoint _endPoint;
        private readonly Socket _socket;
        private readonly ILogger _logger;
        private Stream _stream;

        public TcpTransport(
            IPEndPoint dnsEndPoint,
            ILogger logger
        )
        {
            _endPoint = dnsEndPoint;
            _socket = new(_endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            {
                ExclusiveAddressUse = true,
            };
            _logger = logger;
            _stream = new MemoryStream([]);
        }

        public string Host => _endPoint.Address.ToString();

        public int Port => _endPoint.Port;

        public bool IsConnected => _socket.Connected;

        public async ValueTask Open(
            CancellationToken cancellationToken
        )
        {
            try
            {
                await _socket.ConnectAsync(
                    _endPoint,
                    cancellationToken
                ).ConfigureAwait(false);
                _stream = new NetworkStream(_socket, FileAccess.ReadWrite, false);
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
                _stream.Close();
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
            await _stream.WriteAsync(
                lenBytes,
                cancellationToken
            ).ConfigureAwait(false);
            await _stream.WriteAsync(
                data,
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async ValueTask<byte[]> Receive(
            CancellationToken cancellationToken
        )
        {
            var sizeBytes = new byte[4];
            await _stream.ReadAtLeastAsync(sizeBytes, 4, true, cancellationToken).ConfigureAwait(false);
            (_, var messageLen) = BinaryDecoder.ReadInt32(sizeBytes, 0);
            var responseBytes = new byte[messageLen];
            await _stream.ReadAtLeastAsync(responseBytes, messageLen, true, cancellationToken).ConfigureAwait(false);
            return responseBytes;
        }

        public void Dispose()
        {
            _stream.Dispose();
            _socket.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
