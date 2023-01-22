using Kafka.Client.Messages;
using Kafka.Client.Server;
using Kafka.Common;
using Kafka.Common.Exceptions;
using Kafka.Common.Types;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients
{
    public abstract class Client<TCLient, TConfig> :
        IClient
        where TCLient : notnull, IClient
        where TConfig : notnull, ClientConfig
    {
        protected readonly TConfig _config;
        protected readonly ILogger<TCLient> _logger;

        private bool _disposed;

        protected readonly IConnectionPool _connectionPool;

        protected Client(
            TConfig config,
            ILogger<TCLient> logger
        )
        {
            _config = config;
            _logger = logger;
            _connectionPool = new ConnectionPool(config, logger);
        }

        public async ValueTask Close(CancellationToken cancellationToken)
        {
            await OnClose(cancellationToken);
        }

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

        protected async ValueTask<(IConnection Connection, Error error)> GetCoordinator(
            ImmutableSortedDictionary<ClusterNodeId, IConnection> brokerConnections,
            string key,
            CoordinatorType keyType,
            CancellationToken cancellationToken
        )
        {
            var randomConnectionIndex = Random.Shared.Next(brokerConnections.Count);
            var randomConnection = brokerConnections.Values.ElementAt(randomConnectionIndex);
            (var nodeId, _, _, var error) = await GetCoordinator(randomConnection, key, keyType, cancellationToken);
            return (brokerConnections[nodeId], error);
        }

        protected async ValueTask<(IConnection Connection, Error error)> GetCoordinator(
            string key,
            CoordinatorType keyType,
            CancellationToken cancellationToken
        )
        {
            var randomConnection = await _connectionPool.AquireConnection(cancellationToken);
            (var nodeId, var host, var port, var error) = await GetCoordinator(randomConnection, key, keyType, cancellationToken);
            if (nodeId == randomConnection.NodeId)
                return (randomConnection, error);
            var coordinatorConnection = await _connectionPool.AquireConnection(host, port, cancellationToken);
            await randomConnection.Close(cancellationToken);
            return (coordinatorConnection, Errors.Known.NONE);
        }

        protected async ValueTask<(ClusterNodeId NodeId, string Host, int port, Error error)> GetCoordinator(
            IConnection connection,
            string key,
            CoordinatorType keyType,
            CancellationToken cancellationToken
        )
        {
            var lastError = Errors.Known.COORDINATOR_NOT_AVAILABLE;
            var count = -1;
            while (count < 10 && lastError.Retriable)
            {
                count++;
                var findCoordinatorRequest = new FindCoordinatorRequest(
                    key,
                    (sbyte)keyType,
                    new[] { key }.ToImmutableArray()
                );
                var findCoordinatorResponse = await connection.ExecuteRequest(
                    findCoordinatorRequest,
                    FindCoordinatorRequestSerde.Write,
                    FindCoordinatorResponseSerde.Read,
                    cancellationToken
                );
                var nodeId = findCoordinatorResponse.NodeIdField;
                var host = findCoordinatorResponse.HostField;
                var port = findCoordinatorResponse.PortField;
                var errorCode = findCoordinatorResponse.ErrorCodeField;
                if (findCoordinatorResponse.CoordinatorsField.Any())
                {
                    nodeId = findCoordinatorResponse.CoordinatorsField[0].NodeIdField;
                    host = findCoordinatorResponse.CoordinatorsField[0].HostField;
                    port = findCoordinatorResponse.CoordinatorsField[0].PortField;
                    errorCode = findCoordinatorResponse.CoordinatorsField[0].ErrorCodeField;
                }
                if (errorCode == 0)
                    return (nodeId, host, port, Errors.Known.NONE);
                else
                    lastError = Errors.Translate(findCoordinatorResponse.ErrorCodeField);
                _logger.LogDebug("Find Coordinator: {error}", lastError);
                cancellationToken.WaitHandle.WaitOne(500);
            }
            throw new ApiException(lastError);
        }

        protected async ValueTask<(ClusterNodeId CoordinatorNodeId, Error Error)> GetGroupCoordinator(
            ImmutableSortedDictionary<ClusterNodeId, IConnection> connections,
            string groupId,
            CancellationToken cancellationToken
        )
        {
            var randomConnection = connections.Values.ElementAt(Random.Shared.Next(0, connections.Count - 1));
            var findCoordinatorRequest = new FindCoordinatorRequest(
                groupId,
                (sbyte)CoordinatorType.GROUP,
                new[] { groupId }.ToImmutableArray()
            );
            var findCoordinatorResponse = await randomConnection.ExecuteRequest(
                findCoordinatorRequest,
                FindCoordinatorRequestSerde.Write,
                FindCoordinatorResponseSerde.Read,
                cancellationToken
            );
            if(findCoordinatorResponse.ErrorCodeField != 0)
            {
                var error = Errors.Translate(findCoordinatorResponse.ErrorCodeField);
                return (ClusterNodeId.Empty, error);
            }
            var nodeId = findCoordinatorResponse.NodeIdField;
            if (findCoordinatorResponse.CoordinatorsField.Any())
                nodeId = findCoordinatorResponse.CoordinatorsField[0].NodeIdField;
            return (nodeId, Errors.Known.NONE);
        }
    }
}
