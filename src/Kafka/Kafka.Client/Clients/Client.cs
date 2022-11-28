using Kafka.Client.Messages;
using Kafka.Client.Server;
using Kafka.Common.Encoding;
using Kafka.Common.Network;
using Kafka.Common.Network.Tcp;
using Kafka.Common.Protocol;
using Kafka.Common.Types;
using Kafka.Common.Types.Comparison;
using System.Collections.Immutable;

namespace Kafka.Client.Clients
{
    public abstract class Client<TConfig> :
        IClient
        where TConfig : notnull, ClientConfig
    {
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
            (var host, var port) = ParseBoostrap(config.BootstrapServers).First();
            _transport = new PlaintextTransport(host, port);
        }

        protected async ValueTask EnsureConnection(CancellationToken cancellationToken)
        {
            if (_transport.IsConnected)
                return;
            await _transport.Connect(cancellationToken);
            await _transport.Handshake(cancellationToken);
            _apiVersions = await GetApiVersions(cancellationToken);
            _cluster = await GetCluster(_apiVersions[Api.Metadata].Version.Max, cancellationToken);
        }

        protected async ValueTask<TResponse> HandleRequest<TRequest, TResponse>(
            TRequest request,
            EncodeVersionDelegate<TRequest> requestWriter,
            DecodeVersionDelegate<TResponse> responseReader,
            short? versionOverride,
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
                REQUEST_HEADER_VERSION,
                RESPONSE_HEADER_VERSION,
                versionOverride,
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
            short headerRequestVersion,
            short headerResponseVersion,
            short? apiVersion,
            CancellationToken cancellationToken
        )
            where TRequest : notnull, Request
            where TResponse : notnull, Response
        {
            var correlationId = Interlocked.Increment(ref _coorelationIds);
            var version = apiVersion.HasValue ?
                apiVersion.Value :
                _apiVersions[request.Api].Version.Max
            ;
            var requestHeader = new RequestHeader(
                request.Api,
                version,
                correlationId,
                _config.ClientId
            );
            var requestBuffer = new byte[1024 * 1024].AsMemory();
            var requestSlice = requestBuffer;
            requestSlice = RequestHeaderSerde.Write(requestSlice, headerRequestVersion, requestHeader);
            requestSlice = requestWriter(requestSlice, version, request);
            var len = requestBuffer.Length - requestSlice.Length;
            var responseBuffer = await _transport.HandleRequest(requestBuffer[0..len], cancellationToken);
            var responseHeader = ResponseHeaderSerde.Read(ref responseBuffer, headerResponseVersion);
            if (responseHeader.CorrelationIdField != requestHeader.CorrelationIdField)
                throw new Exception($"Correlation Id mismath - Request: {requestHeader.CorrelationIdField} - Response: {responseHeader.CorrelationIdField}");
            var response = responseReader(ref responseBuffer, version);
            return response;
        }

        private async ValueTask<ImmutableSortedDictionary<short, ApiVersion>> GetApiVersions(
            CancellationToken cancellationToken
        )
        {
            var request = new ApiVersionsRequest(
                ".Net Client",
                "1.0.0"
            );
            var response = await ExecuteRequest(
                request,
                (s, v, r) => ApiVersionsRequestSerde.Write(s, v, r),
                (ref ReadOnlyMemory<byte> s, short v) => ApiVersionsResponseSerde.Read(ref s, v),
                1,
                0,
                1,
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
                (s, v, r) => MetadataRequestSerde.Write(s, v, r),
                (ref ReadOnlyMemory<byte> s, short v) => MetadataResponseSerde.Read(ref s, v),
                REQUEST_HEADER_VERSION,
                RESPONSE_HEADER_VERSION,
                null,
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
                response.ClusterIdField ?? "",
                nodes[new(response.ControllerIdField)],
                nodes,
                ImmutableSortedSet<Topic>.Empty,
                ImmutableSortedSet<Topic>.Empty,
                ImmutableSortedSet<Topic>.Empty,
                ImmutableSortedDictionary<Topic, ImmutableArray<PartitionMetadata>>.Empty,
                ImmutableSortedDictionary<string, Guid>.Empty
            );
        }

        private static IEnumerable<(string Host, int Port)> ParseBoostrap(string bootstrapServers) =>
            bootstrapServers.Split(',').Select(r => r.Split(':')).Select(r => (r[0], int.Parse(r[1])))
        ;
    }
}
