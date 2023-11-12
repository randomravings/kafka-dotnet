using Kafka.Client.Config;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Net;
using Kafka.Common.Net.Transport;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Kafka.Client.Net
{
    internal sealed class ConnectionManager :
        IConnectionManager<IClientConnection>
    {
        private readonly ImmutableArray<string> _bootstrapUrls;
        private readonly SortedList<ClusterNodeId, IClientConnection> _connections = new(ClusterNodeIdCompare.Instance);
        private readonly ClientConfig _config;
        private readonly ILogger _logger;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        private ClusterNodeId _controllerNodeId = ClusterNodeId.Empty;
        private bool _closed;

        public ConnectionManager(
            ClientConfig config,
            ILogger logger
        )
        {
            _bootstrapUrls = config.BootstrapServers.Split(',', StringSplitOptions.RemoveEmptyEntries).ToImmutableArray();
            _config = config;
            _logger = logger;
        }

        async ValueTask<IClientConnection> IConnectionManager<IClientConnection>.Connection(
            ClusterNodeId nodeId,
            CancellationToken cancellationToken
        ) =>
            await Connection(
                nodeId,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<IClientConnection> IConnectionManager<IClientConnection>.Controller(
            CancellationToken cancellationToken
        ) =>
            await Controller(
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask IConnectionManager<IClientConnection>.CloseAll(
            CancellationToken cancellationToken
        )
        {
            await _semaphore.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                _closed = true;
                foreach (var connection in _connections.Values)
                    await connection.Close(
                        cancellationToken
                    ).ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        void IDisposable.Dispose()
        {
            foreach (var connection in _connections.Values)
                connection.Dispose();
            _semaphore.Dispose();
        }

        private async ValueTask<IClientConnection> Connection(
            ClusterNodeId nodeId,
            CancellationToken cancellationToken
        )
        {
            if (_connections.TryGetValue(nodeId, out var protocol))
                return protocol;

            await _semaphore.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                if (_closed)
                    throw new InvalidOperationException("Connection pool closed");
                return await InitConnection(
                    nodeId,
                    cancellationToken
                ).ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async ValueTask<IClientConnection> Controller(
            CancellationToken cancellationToken
        )
        {
            if (_connections.TryGetValue(_controllerNodeId, out var protocol))
                return protocol;

            await _semaphore.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                if (_closed)
                    throw new InvalidOperationException("Connection pool closed");
                return await InitController(
                    cancellationToken
                ).ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async ValueTask<IClientConnection> InitConnection(
            ClusterNodeId clusterNodeId,
            CancellationToken cancellationToken
        )
        {
            if (_connections.TryGetValue(clusterNodeId, out var protocol))
                return protocol;

            protocol = await Controller(cancellationToken)
                .ConfigureAwait(false)
            ;

            var metadataResponse = await protocol.Metadata(cancellationToken)
                .ConfigureAwait(false)
            ;

            var node = metadataResponse
                .BrokersField
                .FirstOrDefault(
                    r => r.NodeIdField == clusterNodeId.Value
                ) ??
                throw new KeyNotFoundException($"Unknown node Id: {clusterNodeId.Value}")
            ;

            var transport = CreateTransport(
                node.HostField,
                node.PortField
            );
            protocol = CreateProtocol(
                transport
            );
            _connections.Add(clusterNodeId, protocol);
            return protocol;
        }

        private async ValueTask<IClientConnection> InitController(
            CancellationToken cancellationToken
        )
        {
            // Sample a connection from existing links for bootstraps
            var protocol = _connections.Count switch
            {
                0 => await RandomizeBootstrapConnection(cancellationToken).ConfigureAwait(false),
                _ => RandomizeExistingConnection(),
            };

            // Determine controller node.
            var metadataResponse = await protocol
                .Metadata(cancellationToken)
                .ConfigureAwait(false)
            ;

            _controllerNodeId = metadataResponse.ControllerIdField;

            // Controller is already present.
            if (_connections.TryGetValue(_controllerNodeId, out var controller))
                return controller;

            var controllerNode = metadataResponse
                .BrokersField
                .FirstOrDefault(
                    r => r.NodeIdField == metadataResponse.ControllerIdField
                ) ?? throw new KeyNotFoundException("Unable to determine controller node.")
            ;

            // Unused connection and we missed our guess.
            var transport = CreateTransport(
                controllerNode.HostField,
                controllerNode.PortField
            );
            controller = CreateProtocol(
                transport
            );
            _connections.Add(_controllerNodeId, controller);
            return controller;
        }

        private IClientConnection RandomizeExistingConnection()
        {
            var randomIndex = RandomNumberGenerator.GetInt32(0, _connections.Count - 1);
            return _connections.ElementAt(randomIndex).Value;
        }

        private async ValueTask<IClientConnection> RandomizeBootstrapConnection(
            CancellationToken cancellationToken
        )
        {
            var randomIndex = _bootstrapUrls.Length switch
            {
                0 => -1,
                1 => 0,
                var l => RandomNumberGenerator.GetInt32(0, l - 1)
            };
            var randomUrl = _bootstrapUrls[randomIndex].Split(':', StringSplitOptions.RemoveEmptyEntries);
            var host = randomUrl[0];
            var port = int.Parse(randomUrl[1], CultureInfo.InvariantCulture);

            // Do we have connection defined by host:port?
            var protocol = _connections.Values.FirstOrDefault(p =>
                p.Transport.Host == host &&
                p.Transport.Port == port
            );
            if (protocol != null)
                return protocol;

            var randomTransport = CreateTransport(
                host,
                port
            );

            protocol = CreateProtocol(
                randomTransport
            );

            // Determine controller node.
            var metadataResponse = await protocol
                .Metadata(cancellationToken)
                .ConfigureAwait(false)
            ;

            var node = metadataResponse
                .BrokersField
                .FirstOrDefault(
                    r => string.CompareOrdinal(r.HostField, host) == 0 && r.PortField == port
                ) ?? throw new KeyNotFoundException($"Unable to find host for {host}:{port}");
            ;

            var nodeId = new ClusterNodeId(node.NodeIdField);

            // If existing node then close and replace.
            if (_connections.TryGetValue(nodeId, out var existing))
            {
                await existing.Close(
                    cancellationToken
                ).ConfigureAwait(false);
                existing.Dispose();
                _connections.Remove(nodeId);
            }

            _connections.Add(nodeId, protocol);
            return protocol;
        }

        private IClientConnection CreateProtocol(
            ITransport transport
        ) =>
            new ClientConnection(
                transport,
                _config,
                _logger
            )
        ;

        private static ImmutableArray<DnsEndPoint> Parse(string bootStrapServer) =>
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

        private ITransport CreateTransport(
            string host,
            int port
        ) =>
            new SaslPlaintextTransport(
                host,
                port,
                _logger
            )
        ;
    }
}
