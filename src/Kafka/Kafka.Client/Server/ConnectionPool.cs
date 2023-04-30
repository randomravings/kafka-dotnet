using Kafka.Client.Clients;
using Kafka.Client.Messages;
using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Network;
using Kafka.Common.Network.Tcp;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.Net;

namespace Kafka.Client.Server
{
    public sealed class ConnectionPool :
        IConnectionPool
    {
        private const string CLIENT_NAME = "confluent-kafka-dotnet";
        private const string CLIENT_VERSION = "1.9.2";
        private const short REQUEST_HEADER_VERSION = 2;
        private const short RESPONSE_HEADER_VERSION = 1;

        private readonly ILogger _logger;
        private readonly string _clientId;
        private readonly DnsEndPoint[] _endPoints;

        public ConnectionPool(
            ClientConfig config,
            ILogger logger
        )
        {
            _clientId = config.ClientId;
            _endPoints = config
                .BootstrapServers
                .Split(',')
                .Select(
                    r =>
                    {
                        var hostAndPort = r.Split(':', StringSplitOptions.RemoveEmptyEntries);
                        var host = hostAndPort[0];
                        var port = 0;
                        if (hostAndPort.Length > 1)
                            _ = int.TryParse(hostAndPort[1], out port);
                        return new DnsEndPoint(host, port);
                    }
                )
                .ToArray()
            ;
            _logger = logger;
        }

        async Task<IConnection> IConnectionPool.AquireConnection(
            CancellationToken cancellationToken
        )
        {
            return await AquireConnection(
                _clientId,
                false,
                _logger,
                cancellationToken
            );
        }

        async Task<IConnection> IConnectionPool.AquireConnection(
            string host,
            int port,
            CancellationToken cancellationToken
        ) =>
            await AquireConnection(
                _clientId,
                new DnsEndPoint(host, port),
                false,
                _logger,
                cancellationToken
            )
        ;

        async Task<IConnection> IConnectionPool.AquireSharedConnection(
            CancellationToken cancellationToken
        )
        {
            return await AquireConnection(
                _clientId,
                true,
                _logger,
                cancellationToken
            );
        }

        async Task<IConnection> IConnectionPool.AquireSharedConnection(
            string host,
            int port,
            CancellationToken cancellationToken
        ) =>
            await AquireConnection(
                _clientId,
                new DnsEndPoint(host, port),
                true,
                _logger,
                cancellationToken
            )
        ;

        private async Task<IConnection> AquireConnection(
            string clientId,
            bool shared,
            ILogger logger,
            CancellationToken cancellationToken
        )
        {

            var connection = CreateConnection(clientId, _endPoints, shared, logger);
            await connection.Init(cancellationToken);
            return connection;
        }

        private static async Task<IConnection> AquireConnection(
            string clientId,
            DnsEndPoint endPoint,
            bool shared,
            ILogger logger,
            CancellationToken cancellationToken
        )
        {
            var connection = CreateConnection(clientId, endPoint, shared, logger);
            await connection.Init(cancellationToken);
            return connection;
        }

        private static IConnection CreateConnection(
            string clientId,
            DnsEndPoint[] endPoints,
            bool shared,
            ILogger logger
        )
        {
            var index = Random.Shared.Next(endPoints.Length);
            var endPoint = endPoints[index];
            return CreateConnection(clientId, endPoint, shared, logger);
        }

        private static IConnection CreateConnection(
            string clientId,
            DnsEndPoint endPoint,
            bool shared,
            ILogger logger
        )
        {
            var transport = CreateTransport(endPoint);
            return new Connection(clientId, transport, logger);
        }

        private static ITransport CreateTransport(DnsEndPoint endPoint) =>
            new PlaintextTransport(endPoint)
        ;

        public class Connection :
            IConnection
        {
            protected readonly string _clientId;
            protected readonly ITransport _transport;
            protected readonly ILogger _logger;

            private long _lastMetadataRefresh = 0L;
            private int _coorelationIds = 0;
            private ImmutableSortedDictionary<short, ApiVersion> _apiVersions = ImmutableSortedDictionary<short, ApiVersion>.Empty;
            private Cluster _clusterInfo = Cluster.Empty;
            private ClusterNode _clusterNodeInfo = ClusterNode.Empty;

            public Connection(
                string clientId,
                ITransport transport,
                ILogger logger
            )
            {
                _clientId = clientId;
                _transport = transport;
                _logger = logger;
            }

            ClusterNodeId IConnection.NodeId => _clusterNodeInfo.Id;

            string IConnection.Host => _transport.RemoteEndPoint.Host;

            int IConnection.Port => _transport.RemoteEndPoint.Port;

            async Task<Cluster> IConnection.GetClusterInfo(CancellationToken cancellationToken) =>
                await GetClusterInfo(cancellationToken)
            ;

            async Task<IEnumerable<ApiVersion>> IConnection.GetApiKeys(CancellationToken cancellationToken) =>
                await GetApiKeys(cancellationToken)
            ;

            private async Task<Cluster> GetClusterInfo(CancellationToken cancellationToken)
            {
                await EnsureMetadata(cancellationToken);
                return _clusterInfo;
            }

            private async Task<IEnumerable<ApiVersion>> GetApiKeys(CancellationToken cancellationToken)
            {
                await EnsureMetadata(cancellationToken);
                return _apiVersions.Values;
            }

            async Task IConnection.Init(CancellationToken cancellationToken) =>
                await Init(cancellationToken)
            ;

            async Task<TResponse> IConnection.ExecuteRequest<TRequest, TResponse>(
                TRequest request,
                EncodeVersionDelegate<TRequest> requestWriter,
                DecodeVersionDelegate<TResponse> responseReader,
                CancellationToken cancellationToken
            ) => await ExecuteRequest(
                    request,
                    requestWriter,
                    responseReader,
                    cancellationToken
                )
            ;

            async Task IConnection.Close(CancellationToken cancellationToken)
            {
                await _transport.Close(cancellationToken);
            }

            void IDisposable.Dispose()
            {
                _transport.Dispose();
            }

            protected RequestHeader CreateRequestHeader<TRequest>(
                TRequest request
            )
                where TRequest : notnull, Request
            {
                var correlationId = Interlocked.Increment(ref _coorelationIds);
                var version = request.MaxVersion;
                if (_apiVersions.TryGetValue(request.Api, out var storedVersion))
                    version = Math.Min(request.MaxVersion, storedVersion.Version.Max);
                return new RequestHeader(
                    request.Api,
                    version,
                    correlationId,
                    _clientId
                );
            }

            protected virtual async Task<TResponse> ExecuteRequest<TRequest, TResponse>(
                TRequest request,
                EncodeVersionDelegate<TRequest> requestWriter,
                DecodeVersionDelegate<TResponse> responseReader,
                CancellationToken cancellationToken
            )
                where TRequest : notnull, Request
                where TResponse : notnull, Response
            {
                await EnsureConnection(cancellationToken);
                var requestHeader = CreateRequestHeader(request);
                var flexibleHeader = requestHeader.RequestApiVersionField >= request.FlexibleVersion;
                var requestBytes = new byte[1024 * 1024];
                var offset = 0;
                offset = RequestHeaderSerde.Write(requestBytes, offset, requestHeader, REQUEST_HEADER_VERSION, flexibleHeader);
                offset = requestWriter(requestBytes, offset, request, requestHeader.RequestApiVersionField);

                var responseBytes = await _transport.HandleRequest(requestBytes, 0, offset, cancellationToken);
                if (responseBytes.Length == 0)
                    throw new EndOfStreamException("No bytes received from server");

                offset = 0;
                flexibleHeader &= request.Api != ApiKey.ApiVersions.Value;
                (offset, var responeHeader) = ResponseHeaderSerde.Read(responseBytes, offset, RESPONSE_HEADER_VERSION, flexibleHeader);
                if (responeHeader.CorrelationIdField != requestHeader.CorrelationIdField)
                    throw new Exception($"Correlation Id mismath - Request: {requestHeader.CorrelationIdField} - Response: {responeHeader.CorrelationIdField}");
                (_, var response) = responseReader(responseBytes, offset, requestHeader.RequestApiVersionField);
                return response;
            }

            async Task IConnection.Send<TRequest>(
                TRequest request,
                EncodeVersionDelegate<TRequest> requestWriter,
                CancellationToken cancellationToken
            )
            {
                await EnsureConnection(cancellationToken);
                var requestHeader = CreateRequestHeader(request);
                var flexibleHeader = requestHeader.RequestApiVersionField >= request.FlexibleVersion;
                var requestBytes = new byte[1024 * 1024];
                var offset = 0;
                offset = RequestHeaderSerde.Write(requestBytes, offset, requestHeader, REQUEST_HEADER_VERSION, flexibleHeader);
                offset = requestWriter(requestBytes, offset, request, requestHeader.RequestApiVersionField);
                await _transport.Send(requestBytes, 0, offset, cancellationToken);
            }

            protected async Task EnsureConnection(
                CancellationToken cancellationToken
            )
            {
                while (!_transport.IsConnected)
                {
                    try
                    {
                        await Init(cancellationToken); ;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message);
                        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
                    }
                }
            }

            private async ValueTask Init(CancellationToken cancellationToken)
            {
                await _transport.Connect(cancellationToken);
                _logger.LogTrace($"Connected to: {_transport.RemoteEndPoint} from: {_transport.LocalEndPoint}");
                await _transport.Handshake(cancellationToken);
                await EnsureMetadata(cancellationToken);
            }

            private async ValueTask EnsureMetadata(CancellationToken cancellationToken)
            {
                var nowMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                if (nowMs - _lastMetadataRefresh < 30000)
                    return;
                var apiVersions = await GetApiVersions(cancellationToken);
                Interlocked.Exchange(ref _apiVersions, apiVersions);
                var clusterInfo = await GetClusterInfo(_apiVersions[ApiKey.Metadata].Version.Max, cancellationToken);
                Interlocked.Exchange(ref _clusterInfo, clusterInfo);
                var clusterNodeInfo = _clusterInfo
                    .Nodes
                    .Values
                    .FirstOrDefault(r =>
                        string.Compare(r.Host, _transport.RemoteEndPoint.Host, true) == 0 && r.Port == _transport.RemoteEndPoint.Port,
                        ClusterNode.Empty
                    )
                ;
                Interlocked.Exchange(ref _clusterNodeInfo, clusterNodeInfo);
                var lastMetadataRefresh = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                Interlocked.Exchange(ref _lastMetadataRefresh, lastMetadataRefresh);
            }

            async Task<ImmutableSortedDictionary<short, ApiVersion>> GetApiVersions(
                CancellationToken cancellationToken
            )
            {
                var request = new ApiVersionsRequest(
                    CLIENT_NAME,
                    CLIENT_VERSION
                );
                var response = await ExecuteRequest(
                    request,
                    ApiVersionsRequestSerde.Write,
                    ApiVersionsResponseSerde.Read,
                    cancellationToken
                );
                return response
                    .ApiKeysField
                    .Select(r => new ApiVersion(
                        r.ApiKeyField,
                        new(
                            r.MinVersionField,
                            r.MaxVersionField
                        )
                    ))
                    .ToImmutableSortedDictionary(
                        k => (short)k.Api,
                        v => v
                    )
                ;
            }

            async Task<Cluster> GetClusterInfo(
                short version,
                CancellationToken cancellationToken
            )
            {
                var request = new MetadataRequest(
                    version == 0 ? null : ImmutableArray<MetadataRequest.MetadataRequestTopic>.Empty,
                    false,
                    true,
                    false
                );
                var response = await ExecuteRequest(
                    request,
                    MetadataRequestSerde.Write,
                    MetadataResponseSerde.Read,
                    cancellationToken
                );
                var nodes = response.BrokersField.Select(
                        r => new ClusterNode(
                            new(r.NodeIdField),
                            $"{r.NodeIdField}",
                            r.HostField,
                            r.PortField,
                            $"{r.RackField}"
                        )
                    )
                    .ToImmutableSortedDictionary(
                        k => k.Id,
                        v => v,
                        ClusterNodeIdCompare.Instance
                    )
                ;
                return new(
                    DateTimeOffset.UtcNow,
                    response.ClusterIdField ?? "",
                    nodes,
                    nodes[new(response.ControllerIdField)]
                );
            }
        }
    }
}
