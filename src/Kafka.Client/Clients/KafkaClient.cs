using Kafka.Client.Protocol;
using Kafka.Common.Network;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.Globalization;
using System.Net;
using System.Net.Sockets;

namespace Kafka.Client.Clients
{
    internal abstract class KafkaClient<TClient, TConfig> :
        IClient
        where TClient : notnull, IClient
        where TConfig : notnull, ClientConfig
    {
        private readonly TConfig _config;
        private readonly ILogger<TClient> _logger;

        private bool _disposed;
        protected KafkaClient(
            TConfig config,
            ILogger<TClient> logger
        )
        {
            _config = config;
            _logger = logger;
        }

        protected TConfig Config => _config;
        protected ILogger<TClient> Logger => _logger;

        protected async ValueTask<TProtocol> GetControllerProtocol<TProtocol>(            
            Func<ITransport, TConfig, ILogger<TClient>, TProtocol> builder,
            CancellationToken cancellationToken
        )
            where TProtocol : IClientProtocol
        {
            var connection = RandomizeConnection();
            var protocol = builder(connection, _config, _logger);
            var metadataResponse = await protocol.Metadata(cancellationToken).ConfigureAwait(false);
            var controller = metadataResponse.BrokersField.First(r => r.NodeIdField == metadataResponse.ControllerIdField);
            if (connection.Host != controller.HostField || connection.Port != controller.PortField)
            {
                await connection.Close(cancellationToken).ConfigureAwait(false);
                connection = KafkaClient<TClient, TConfig>.CreateConnection(controller.HostField, controller.PortField);
                protocol = builder(connection, _config, _logger);
            }
            return protocol;
        }

        protected ITransport RandomizeConnection()
        {
            var bootstrapServers = Parse(_config.BootstrapServers);
#pragma warning disable CA5394 // Do not use insecure randomness
            var randomIndex = Random.Shared.Next(0, bootstrapServers.Length - 1);
#pragma warning restore CA5394 // Do not use insecure randomness
            var host = bootstrapServers[randomIndex];
            return KafkaClient<TClient, TConfig>.CreateConnection(host.Host, host.Port);
        }

        public async ValueTask Close(CancellationToken cancellationToken) =>
            await OnClose(cancellationToken).ConfigureAwait(false)
        ;

        protected abstract ValueTask OnClose(CancellationToken cancellationToken);

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected static ImmutableArray<DnsEndPoint> Parse(string bootStrapServer) =>
            bootStrapServer
                .Split(',')
                .Select(r => r.Split(':'))
                .Select(r => new DnsEndPoint(
                    r[0],
                    int.Parse(r[1],
                        NumberStyles.None,
                        CultureInfo.InvariantCulture
                    ),
                    AddressFamily.InterNetwork
                ))
                .ToImmutableArray()
        ;

        protected static ITransport CreateConnection(string host, int port) =>
            new SaslPlaintextTransport(host, port)
        ;
    }
}
