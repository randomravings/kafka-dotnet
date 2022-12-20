using Kafka.Client.Messages;
using Kafka.Client.Server;
using Kafka.Common.Encoding;
using Kafka.Common.Network;
using Kafka.Common.Network.Tcp;
using Kafka.Common.Protocol;
using Kafka.Common.Types;
using Kafka.Common.Types.Comparison;
using System.Collections.Immutable;
using System.Net;

namespace Kafka.Client.Clients
{
    public abstract class Client<TConfig> :
        IClient
        where TConfig : notnull, ClientConfig
    {
        private const string CLIENT_NAME = "confluent-kafka-dotnet";
        private const string CLIENT_VERSION = "1.9.2";
        private const short REQUEST_HEADER_VERSION = 2;
        private const short RESPONSE_HEADER_VERSION = 1;
        private int _coorelationIds = 0;
        private bool _disposed;
        private readonly ITransport _transport;
        protected readonly TConfig _config;
        protected ImmutableSortedDictionary<short, ApiVersion> _apiVersions = ImmutableSortedDictionary<short, ApiVersion>.Empty;
        protected Cluster _cluster = Cluster.Empty;

        protected Client(
            TConfig config
        )
        {
            _config = config;
            var endpoint = ParseBoostrap(config.BootstrapServers).First();
            _transport = new PlaintextTransport(endpoint);
        }

        protected async ValueTask EnsureConnection(CancellationToken cancellationToken)
        {
            if (_transport.IsConnected)
                return;
            await _transport.Connect(cancellationToken);
            await _transport.Handshake(cancellationToken);
            _apiVersions = await GetApiVersions(cancellationToken);
            _cluster = await GetCluster(_apiVersions[ApiKey.Metadata].Version.Max, cancellationToken);
        }

        protected async ValueTask<TResponse> HandleRequest<TRequest, TResponse>(
            TRequest request,
            EncodeVersionDelegate<TRequest> requestWriter,
            DecodeVersionDelegate<TResponse> responseReader,
            CancellationToken cancellationToken
        )
            where TRequest : notnull, Request
            where TResponse : notnull, Response
        {
            await EnsureConnection(cancellationToken);
            return await ExecuteRequest(
                request,
                requestWriter,
                responseReader,
                cancellationToken
            );
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transport.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private async ValueTask<TResponse> ExecuteRequest<TRequest, TResponse>(
            TRequest request,
            EncodeVersionDelegate<TRequest> requestWriter,
            DecodeVersionDelegate<TResponse> responseReader,
            CancellationToken cancellationToken
        )
            where TRequest : notnull, Request
            where TResponse : notnull, Response
            => await ExecuteRequest(
                request,
                requestWriter,
                responseReader,
                false,
                cancellationToken
            )
        ;

        private async ValueTask<TResponse> ExecuteRequest<TRequest, TResponse>(
            TRequest request,
            EncodeVersionDelegate<TRequest> requestWriter,
            DecodeVersionDelegate<TResponse> responseReader,
            bool ignoreHeaderTaggedFields,
            CancellationToken cancellationToken
        )
            where TRequest : notnull, Request
            where TResponse : notnull, Response
        {
            var correlationId = Interlocked.Increment(ref _coorelationIds);
            var version = request.MaxVersion;
            if(_apiVersions.TryGetValue(request.Api, out var storedVersion))
                version = Math.Min(request.MaxVersion, storedVersion.Version.Max);
            var flexible = version >= request.FlexibleVersion;
            var requestHeader = new RequestHeader(
                request.Api,
                version,
                correlationId,
                _config.ClientId
            );
            var requestBuffer = new byte[1024 * 1024];
            var requestIndex = 4;
            requestIndex = RequestHeaderSerde.Write(requestBuffer, requestIndex, requestHeader, REQUEST_HEADER_VERSION, flexible);
            requestIndex = requestWriter(requestBuffer, requestIndex, request, version);
            Encoder.WriteInt32(requestBuffer, 0, requestIndex - 4);
            var responseBuffer = await _transport.HandleRequest(requestBuffer, 0, requestIndex, cancellationToken);
            var responseIndex = 0;
            var responseHeader = ResponseHeaderSerde.Read(responseBuffer, ref responseIndex, RESPONSE_HEADER_VERSION, flexible && !ignoreHeaderTaggedFields);
            if (responseHeader.CorrelationIdField != requestHeader.CorrelationIdField)
                throw new Exception($"Correlation Id mismath - Request: {requestHeader.CorrelationIdField} - Response: {responseHeader.CorrelationIdField}");
            var response = responseReader(responseBuffer, ref responseIndex, version);
            return response;
        }

        private async ValueTask<ImmutableSortedDictionary<short, ApiVersion>> GetApiVersions(
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
                true,
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

        private async ValueTask<Cluster> GetCluster(
            short version,
            CancellationToken cancellationToken
        )
        {
            var request = new MetadataRequest(
                (version == 0 ? null : ImmutableArray<MetadataRequest.MetadataRequestTopic>.Empty),
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

        private static IEnumerable<DnsEndPoint> ParseBoostrap(string bootstrapServers) =>
            bootstrapServers.Split(',').Select(r => r.Split(':')).Select(r => new DnsEndPoint(r[0], int.Parse(r[1])))
        ;
    }
}
