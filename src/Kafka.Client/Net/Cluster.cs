using Kafka.Client.Collections;
using Kafka.Client.Config;
using Kafka.Client.Messages;
using Kafka.Client.Model.Internal;
using Kafka.Common.Model;
using Kafka.Common.Net;
using Kafka.Common.Net.Transport;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.Security.Cryptography;

namespace Kafka.Client.Net
{
    internal sealed class Cluster(
        ImmutableArray<BootstrapServer> bootstrapServers,
        KafkaClientConfig config,
        ILogger logger
    ) :
        ICluster<IClientConnection>,
        IDisposable
    {
        private readonly ImmutableArray<BootstrapServer> _bootstrapServers = bootstrapServers;
        private readonly ClusterNodeDictionary<IClientConnection> _connections = [];
        private readonly KafkaClientConfig _config = config;
        private readonly ILogger _logger = logger;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        private ClusterNodeId _controllerNodeId = ClusterNodeId.Empty;
        private bool _closed;

        public async Task<IClientConnection> Connection(
            ClusterNodeId nodeId,
            CancellationToken cancellationToken
        )
        {
            if (_connections.Get(nodeId, out var connection))
                return connection;
            await _semaphore.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                if (_closed)
                    throw new InvalidOperationException("Connection pool closed");
                if (_connections.Get(nodeId, out connection))
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

        public async Task<IClientConnection> Controller(
            CancellationToken cancellationToken
        )
        {
            if (_controllerNodeId != ClusterNodeId.Empty && _connections.Get(_controllerNodeId, out var connection))
                return connection;
            await _semaphore.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                if (_closed)
                    throw new InvalidOperationException("Connection pool closed");
                if (_connections.Get(_controllerNodeId, out connection))
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
                foreach (var connection in _connections.CopyItems())
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
            foreach (var connection in _connections.CopyItems())
                connection.Value.Dispose();
            _semaphore.Dispose();
        }

        private async Task<IClientConnection> GetConnection(
            ClusterNodeId nodeId,
            CancellationToken cancellationToken
        )
        {
            if (_connections.Get(nodeId, out var connection))
                return connection;
            return await InitConnection(
                nodeId,
                cancellationToken
            ).ConfigureAwait(false);
        }

        private async Task<IClientConnection> GetController(
            CancellationToken cancellationToken
        )
        {
            if (_connections.Get(_controllerNodeId, out var connection))
                return connection;
            return await InitController(
                cancellationToken
            ).ConfigureAwait(false);
        }

        private async Task<IClientConnection> InitConnection(
            ClusterNodeId clusterNodeId,
            CancellationToken cancellationToken
        )
        {
            if (_connections.Get(clusterNodeId, out var connection))
                return connection;

            connection = await Controller(cancellationToken)
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
            if (node.NodeIdField == ClusterNodeId.Empty)
                throw new KeyNotFoundException($"Unknown node Id: {clusterNodeId.Value}");

            var transport = CreateTransport(
                node.HostField,
                node.PortField
            );
            connection = new ClientConnection(
                transport,
                _config,
                _logger
            );
            await connection.Open(
                cancellationToken
            ).ConfigureAwait(false);
            _connections.Add(clusterNodeId, connection);
            return connection;
        }

        private async Task<IClientConnection> InitController(
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
            if (_connections.Get(_controllerNodeId, out var controller))
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
            controller = new ClientConnection(
                transport,
                _config,
                _logger
            );
            await connection.Open(
                cancellationToken
            ).ConfigureAwait(false);
            _connections.Add(_controllerNodeId, controller);
            return controller;
        }

        private IClientConnection RandomizeExistingConnection()
        {
            var randomIndex = RandomNumberGenerator.GetInt32(0, _connections.Count - 1);
            return _connections.ElementAt(randomIndex).Value;
        }

        private async Task<IClientConnection> RandomizeBootstrapConnection(
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

            var connection = (IClientConnection)new ClientConnection(
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

            var nodeId = new ClusterNodeId(node.NodeIdField);

            // If existing node then close and replace.
            if (_connections.Get(nodeId, out var existing))
            {
                await existing.Close(
                    cancellationToken
                ).ConfigureAwait(false);
                existing.Dispose();
                _connections.Remove(nodeId);
            }

            _connections.Add(nodeId, connection);
            return connection;
        }

        private ITransport CreateTransport(
            string host,
            int port
        ) =>
            _config.Client.SecurityProtocol switch
            {
                SecurityProtocol.Plaintext => new SaslPlaintextTransport(
                    host,
                    port,
                    _logger
                ),
                _ => throw new NotImplementedException(
                    $"Implementation does not support security protocol: {_config.Client.SecurityProtocol}"
                )
            }

        ;
    }
}
