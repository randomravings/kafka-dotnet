using Kafka.Client.Messages;
using Kafka.Client.Server;
using Kafka.Common.Encoding;
using Kafka.Common.Network;
using Kafka.Common.Network.Tcp;
using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients
{
    public abstract class Client<TConfig> :
        IClient
        where TConfig : notnull, ClientConfig
    {
        private const short MAJOR_KAFKA_VERSION = 3;
        private const short REQUEST_HEADER_VERSION = 2;
        private const short RESPONSE_HEADER_VERSION = 1;
        private int _coorelationIds = 0;
        private bool _disposed;
        private readonly ITransport _transport;
        protected Cluster _cluster = Cluster.Empty;
        protected readonly TConfig _config;
        private ImmutableSortedDictionary<short, ApiVersion> _apiVersions = ImmutableSortedDictionary<short, ApiVersion>.Empty;

        protected Client(
            TConfig config
        )
        {
            _config = config;
            (var host, var port) = ParseBoostrap(config.BootstrapServers).First();
            _transport = new PlaintextTransport(host, port);
        }

        protected async ValueTask RefreshMetadata(CancellationToken cancellationToken)
        {
            _cluster = await GetCluster(cancellationToken);
        }

        protected async ValueTask<ImmutableSortedDictionary<short, ApiVersion>> GetApiVersions(
            short version,
            CancellationToken cancellationToken
        )
        {
            if (!_transport.IsConnected)
            {
                await _transport.Connect(cancellationToken);
                await _transport.Handshake(cancellationToken);
            }
            var request = new ApiVersionsRequest(
                ".Net Client",
                "1.0.0"
            );
            var correlationId = Interlocked.Increment(ref _coorelationIds);
            var requestHeader = new RequestHeader(
                Api.ApiVersions,
                version,
                correlationId,
                "me.org"
            );
            var requestBuffer = new MemoryStream
            {
                Position = 4
            };
            RequestHeaderSerde.Write(requestBuffer, 1, requestHeader);
            ApiVersionsRequestSerde.Write(requestBuffer, version, request);
            requestBuffer.Position = 0;
            Encoder.WriteInt32(requestBuffer, (int)(requestBuffer.Length - 4));
            var responseBuffer = await _transport.HandleRequest(requestBuffer, cancellationToken);
            responseBuffer.Position = 0;
            var responseLength = Decoder.ReadInt32(responseBuffer);
            responseBuffer.SetLength(responseLength + 4);
            var responseHeader = ResponseHeaderSerde.Read(responseBuffer, 0);
            if (responseHeader.CorrelationIdField != requestHeader.CorrelationIdField)
                throw new Exception($"Correlation Id mismath - Request: {requestHeader.CorrelationIdField} - Response: {responseHeader.CorrelationIdField}");
            var response = ApiVersionsResponseSerde.Read(responseBuffer, version);
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

        protected async ValueTask<TResponse> HandleRequest<TRequest, TResponse>(
            short apiKey,
            TRequest request,
            Action<MemoryStream, short, TRequest> requestWriter,
            Func<MemoryStream, short, TResponse> responseReader,
            short? versionOverride,
            CancellationToken cancellationToken
        )
        {
            if(!_transport.IsConnected)
            {
                await _transport.Connect(cancellationToken);
                await _transport.Handshake(cancellationToken);
            }
            if (_apiVersions.Count == 0)
                _apiVersions = await GetApiVersions(1, cancellationToken);
            var correlationId = Interlocked.Increment(ref _coorelationIds);
            var apiVersions = _apiVersions[apiKey];
            var version = apiVersions.Version.Max;
            if(versionOverride.HasValue)
            {
                if (versionOverride.Value < apiVersions.Version.Min || versionOverride.Value > apiVersions.Version.Max)
                    throw new Exception("Value override out of range.");
                version = versionOverride.Value;
            }
            var requestHeader = new RequestHeader(
                apiKey,
                version,
                correlationId,
                "me.org"
            );
            var requestBuffer = new MemoryStream
            {
                Position = 4
            };
            RequestHeaderSerde.Write(requestBuffer, REQUEST_HEADER_VERSION, requestHeader);
            requestWriter(requestBuffer, version, request);
            requestBuffer.Position = 0;
            Encoder.WriteInt32(requestBuffer, (int)(requestBuffer.Length - 4));
            var responseBuffer = await _transport.HandleRequest(requestBuffer, cancellationToken);
            responseBuffer.Position = 0;
            var responseLength = Decoder.ReadInt32(responseBuffer);
            responseBuffer.SetLength(responseLength + 4);
            var responseHeader = ResponseHeaderSerde.Read(responseBuffer, RESPONSE_HEADER_VERSION);
            if (responseHeader.CorrelationIdField != requestHeader.CorrelationIdField)
                throw new Exception($"Correlation Id mismath - Request: {requestHeader.CorrelationIdField} - Response: {responseHeader.CorrelationIdField}");
            var response = responseReader(responseBuffer, version);
            return response;
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

        private async ValueTask<Cluster> GetCluster(CancellationToken cancellationToken)
        {
            return await new ValueTask<Cluster>(Cluster.Empty);
        }

        private static IEnumerable<(string Host, int Port)> ParseBoostrap(string bootstrapServers) =>
            bootstrapServers.Split(',').Select(r => r.Split(':')).Select(r => (r[0], int.Parse(r[1])))
        ;
    }
}
