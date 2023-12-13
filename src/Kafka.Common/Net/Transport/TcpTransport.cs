using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Kafka.Common.Net.Transport
{
    public sealed class TcpTransport :
        ITransport,
        IDisposable
    {
        private readonly IPEndPoint _endPoint;
        private readonly Socket _socket;
        private readonly ILogger _logger;
        private readonly bool _useSsl;
        private Stream _readStream;
        private Stream _writeStream;

        public TcpTransport(
            IPEndPoint dnsEndPoint,
            bool useSsl,
            ILogger logger
        )
        {
            _endPoint = dnsEndPoint;
            _socket = new(_endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            {
                ExclusiveAddressUse = true,
            };
            _useSsl = useSsl;
            _logger = logger;
            _readStream = new MemoryStream([]);
            _writeStream = new MemoryStream([]);
        }

        public string Host => _endPoint.Address.ToString();

        public int Port => _endPoint.Port;

        public bool IsConnected => _socket.Connected;

        private void CreateStream(Socket socket)
        {
            var readStream = new NetworkStream(_socket, FileAccess.Read, false);
            var writeStream = new NetworkStream(_socket, FileAccess.Write, false);

            if (!_useSsl)
            {
                _readStream = readStream;
                _writeStream = writeStream;
            }

            string certPath = "E:\\docker_environments\\cp-single-sasl_ssl\\client-creds\\kafka.client.pfx";
            string certPass = "secret";
            var collection = new X509Certificate2Collection();
            collection.Import(certPath, certPass, X509KeyStorageFlags.PersistKeySet);

            var cert = collection[0];

            var rsaPublicKey = cert.GetRSAPublicKey();

            var aes = Aes.Create();
            aes.KeySize = 256;
            aes.Mode = CipherMode.CBC;

            var keyFormatter = new RSAPKCS1KeyExchangeFormatter(rsaPublicKey);
            var keyEncrypted = keyFormatter.CreateKeyExchange(aes.Key, aes.GetType());

            _readStream = new CryptoStream(readStream, aes.CreateDecryptor(), CryptoStreamMode.Read, true);
            _writeStream = new CryptoStream(writeStream, aes.CreateEncryptor(), CryptoStreamMode.Write, true);
        }

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
                CreateStream(_socket);
            }
            catch (Exception ex)
            {
                throw new OpenConnectionException("Error during connect", ex);
            }
        }

        public static bool RemoteCertificateValidationCallback(
            object sender,
            X509Certificate? certificate,
            X509Chain? chain,
            SslPolicyErrors sslPolicyErrors
        )
        {
            //sslPolicyErrors returns RemoteCertificateNameMismatch
            return true; //Code shortened
        }


        public ValueTask Close(
            CancellationToken cancellationToken
        )
        {
            try
            {

                _writeStream.Close();
                _readStream.Close();
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
            await _writeStream.WriteAsync(
                lenBytes,
                cancellationToken
            ).ConfigureAwait(false);
            await _writeStream.WriteAsync(
                data,
                cancellationToken
            ).ConfigureAwait(false);
        }

        public async ValueTask<byte[]> Receive(
            CancellationToken cancellationToken
        )
        {
            var sizeBytes = new byte[4];
            await _readStream.ReadAtLeastAsync(sizeBytes, 4, true, cancellationToken).ConfigureAwait(false);
            (_, var messageLen) = BinaryDecoder.ReadInt32(sizeBytes, 0);
            var responseBytes = new byte[messageLen];
            await _readStream.ReadAtLeastAsync(responseBytes, messageLen, true, cancellationToken).ConfigureAwait(false);
            return responseBytes;
        }

        public void Dispose()
        {
            _writeStream.Dispose();
            _readStream.Dispose();
            _socket.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
