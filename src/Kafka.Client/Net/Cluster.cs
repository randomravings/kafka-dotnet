using Kafka.Client.Config;
using Kafka.Client.Messages;
using Kafka.Client.Model.Internal;
using Kafka.Common.Model;
using Kafka.Common.Net;
using Kafka.Common.Net.Transport;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Net;
using System.Security.Cryptography;

namespace Kafka.Client.Net
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposable ownership transfer ignored.")]
    internal sealed class Cluster(
        ImmutableArray<BootstrapServer> bootstrapServers,
        KafkaClientConfig config,
        ILogger logger
    ) :
        ICluster<INodeLink>,
        IDisposable
    {
        private readonly ImmutableArray<BootstrapServer> _bootstrapServers = bootstrapServers;
        private readonly ConcurrentDictionary<NodeId, NodeLink> _connections = [];
        private readonly KafkaClientConfig _config = config;
        private readonly ILogger _logger = logger;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        private NodeId _controllerNodeId = NodeId.Empty;
        private bool _closed;

        public async Task<INodeLink> Connection(
            NodeId nodeId,
            CancellationToken cancellationToken
        )
        {
            if (_connections.TryGetValue(nodeId, out var connection))
                return connection;
            await _semaphore.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                if (_closed)
                    throw new InvalidOperationException("Connection pool closed");
                if (_connections.TryGetValue(nodeId, out connection))
                    return connection;
                return await GetConnection(
                    nodeId,
                    cancellationToken
                ).ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<INodeLink> Controller(
            CancellationToken cancellationToken
        )
        {
            if (_controllerNodeId != NodeId.Empty && _connections.TryGetValue(_controllerNodeId, out var connection))
                return connection;
            await _semaphore.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                if (_closed)
                    throw new InvalidOperationException("Connection pool closed");
                if (_connections.TryGetValue(_controllerNodeId, out connection))
                    return connection;
                return await GetController(
                    cancellationToken
                ).ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task CloseAll(
            CancellationToken cancellationToken
        )
        {
            await _semaphore.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                if (_closed)
                    return;
                _closed = true;
                foreach (var connection in _connections)
                    await connection.Value.Close(
                        cancellationToken
                    ).ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public void Dispose()
        {
            foreach (var connection in _connections)
                connection.Value.Dispose();
            _semaphore.Dispose();
        }

        private async Task<NodeLink> GetConnection(
            NodeId nodeId,
            CancellationToken cancellationToken
        )
        {
            if (_connections.TryGetValue(nodeId, out var connection))
                return connection;
            return await InitConnection(
                nodeId,
                cancellationToken
            ).ConfigureAwait(false);
        }

        private async Task<NodeLink> GetController(
            CancellationToken cancellationToken
        )
        {
            if (_connections.TryGetValue(_controllerNodeId, out var connection))
                return connection;
            return await InitController(
                cancellationToken
            ).ConfigureAwait(false);
        }

        private async Task<NodeLink> InitConnection(
            NodeId clusterNodeId,
            CancellationToken cancellationToken
        )
        {
            if (_connections.TryGetValue(clusterNodeId, out var connection))
                return connection;

            connection = await GetController(cancellationToken)
                .ConfigureAwait(false)
            ;

            var metadataResponse = await connection.Metadata(cancellationToken)
                .ConfigureAwait(false)
            ;

            var node = metadataResponse
                .BrokersField
                .FirstOrDefault(
                    r => r.NodeIdField == clusterNodeId.Value,
                    MetadataResponseData.MetadataResponseBroker.Empty
                )
            ;
            if (node.NodeIdField == NodeId.Empty)
                throw new KeyNotFoundException($"Unknown node Id: {clusterNodeId.Value}");

            var transport = CreateTransport(
                node.HostField,
                node.PortField
            );
            connection = new NodeLink(
                transport,
                _config,
                _logger
            );
            await connection.Open(
                cancellationToken
            ).ConfigureAwait(false);
            _connections.TryAdd(clusterNodeId, connection);
            return connection;
        }

        private async Task<NodeLink> InitController(
            CancellationToken cancellationToken
        )
        {
            // Sample a connection from existing links for bootstraps
            var connection = _connections.Count switch
            {
                0 => await RandomizeBootstrapConnection(cancellationToken).ConfigureAwait(false),
                _ => RandomizeExistingConnection(),
            };

            // Determine controller node.
            var metadataResponse = await connection
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
            controller = new NodeLink(
                transport,
                _config,
                _logger
            );
            await connection.Open(
                cancellationToken
            ).ConfigureAwait(false);
            _connections.TryAdd(_controllerNodeId, controller);
            return controller;
        }

        private NodeLink RandomizeExistingConnection()
        {
            var randomIndex = RandomNumberGenerator.GetInt32(0, _connections.Count - 1);
            return _connections.ElementAt(randomIndex).Value;
        }

        private async Task<NodeLink> RandomizeBootstrapConnection(
            CancellationToken cancellationToken
        )
        {
            var randomIndex = _bootstrapServers.Length switch
            {
                0 => -1,
                1 => 0,
                var l => RandomNumberGenerator.GetInt32(0, l - 1)
            };
            (var host, var port) = _bootstrapServers[randomIndex];

            var transport = CreateTransport(
                host,
                port
            );

            var connection = new NodeLink(
                transport,
                _config,
                _logger
            );
            await connection.Open(
                cancellationToken
            ).ConfigureAwait(false);
            // Determine controller node.
            var metadataResponse = await connection
                .Metadata(cancellationToken)
                .ConfigureAwait(false)
            ;

            var node = metadataResponse
                .BrokersField
                .FirstOrDefault(
                    r => string.CompareOrdinal(r.HostField, host) == 0 && r.PortField == port
                ) ?? throw new KeyNotFoundException($"Unable to find host for {host}:{port}");
            ;

            var nodeId = new NodeId(node.NodeIdField);

            // If existing node then close and replace.
            if (_connections.TryGetValue(nodeId, out var existing))
            {
                await existing.Close(
                    cancellationToken
                ).ConfigureAwait(false);
                existing.Dispose();
                _connections.Remove(nodeId, out _);
            }

            _connections.TryAdd(nodeId, connection);
            return connection;
        }

        private TcpTransport CreateTransport(
            string host,
            int port
        )
        {
            var useSsl =
                _config.Client.SecurityProtocol == SecurityProtocol.Ssl ||
                _config.Client.SecurityProtocol == SecurityProtocol.SaslSsl
            ;

            var entry = Dns.GetHostEntry(host);
            var ipAddres = entry.AddressList[0];
            var ipEndPoint = new IPEndPoint(ipAddres, port);

            return new TcpTransport(
                ipEndPoint,
                useSsl,
                _logger
            );
        }
    }
}
