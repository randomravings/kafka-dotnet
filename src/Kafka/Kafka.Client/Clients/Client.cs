using Kafka.Client.Messages;
using Kafka.Client.Server;
using Kafka.Common.Encoding;
using Kafka.Common.Network;
using Kafka.Common.Network.Tcp;
using Kafka.Common.Protocol;
using Kafka.Common.Types;
using Kafka.Common.Types.Comparison;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
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
        private readonly ITransport _transport;

        private readonly BlockingCollection<RequestData> _requestQueue = new();
        private readonly ConcurrentDictionary<int, TaskCompletionSource<byte[]>> _pendingRequests = new();

        private readonly CancellationTokenSource _clientCts = new();
        private readonly Task _sender;
        protected readonly TConfig _config;
        protected readonly ILogger _logger;

        private int _coorelationIds = 0;
        private bool _metadataInitialized = false;
        private bool _disposed;

        protected ImmutableSortedDictionary<short, ApiVersion> _apiVersions = ImmutableSortedDictionary<short, ApiVersion>.Empty;
        protected Cluster _cluster = Cluster.Empty;

        private sealed record SendCallback(
            RequestHeader RequestHeader,
            bool Flexible,
            bool IgnoreHeaderTaggedFields,
            byte[] Request,
            int Offset,
            int Length,
            TaskCompletionSource<byte[]> Response
        );

        private readonly record struct RequestData(
            int CorrelationId,
            byte[] Data,
            int Offset,
            int Length
        );

        protected Client(
            TConfig config,
            ILogger logger
        )
        {
            _config = config;
            _logger = logger;
            var endpoint = ParseBoostrap(config.BootstrapServers).First();
            _transport = new PlaintextTransport(endpoint);
            _sender = Task.Run(async () => await SendLoop(_clientCts.Token), CancellationToken.None);
        }

        protected async ValueTask EnsureMetadata(CancellationToken cancellationToken)
        {
            if (_metadataInitialized)
                return;
            _apiVersions = await GetApiVersions(cancellationToken);
            _cluster = await GetCluster(_apiVersions[ApiKey.Metadata].Version.Max, cancellationToken);
            _metadataInitialized = true;
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
            await EnsureMetadata(cancellationToken);
            return await ExecuteRequest(
                request,
                requestWriter,
                responseReader,
                cancellationToken
            );
        }

        public async ValueTask Close(CancellationToken cancellationToken)
        {
            await OnClose(cancellationToken);
            _clientCts.Cancel();
            await _sender;
            await _transport.Close(cancellationToken);
        }

        protected abstract ValueTask OnClose(CancellationToken cancellationToken);

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                _sender.Dispose();
                _transport.Dispose();
            }
            _disposed = true;
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
            if (_apiVersions.TryGetValue(request.Api, out var storedVersion))
                version = Math.Min(request.MaxVersion, storedVersion.Version.Max);
            var flexible = version >= request.FlexibleVersion;
            var requestHeader = new RequestHeader(
                request.Api,
                version,
                correlationId,
                _config.ClientId
            );
            var requestBytes = new byte[1024 * 1024];
            var offset = 0;
            offset = RequestHeaderSerde.Write(requestBytes, offset, requestHeader, REQUEST_HEADER_VERSION, flexible);
            offset = requestWriter(requestBytes, offset, request, requestHeader.RequestApiVersionField);

            var completionSource = new TaskCompletionSource<byte[]>();
            _pendingRequests.TryAdd(correlationId, completionSource);
            _requestQueue.Add(new(correlationId, requestBytes, 0, offset), cancellationToken);
            _logger.LogTrace("Adding request id: {correlationId}, apiKey: {apiKey}, version: {version} type: {request}/{response}", correlationId, request.Api, version, typeof(TRequest).Name, typeof(TResponse).Name);
            var responseBytes = await completionSource.Task;
            if (responseBytes.Length == 0)
                throw new EndOfStreamException("No bytes received from server");
            _pendingRequests.TryRemove(correlationId, out _);

            offset = 0;
            var responeHeader = ResponseHeaderSerde.Read(responseBytes, ref offset, RESPONSE_HEADER_VERSION, flexible && !ignoreHeaderTaggedFields);
            if (responeHeader.CorrelationIdField != requestHeader.CorrelationIdField)
                throw new Exception($"Correlation Id mismath - Request: {requestHeader.CorrelationIdField} - Response: {responeHeader.CorrelationIdField}");
            var response = responseReader(responseBytes, ref offset, version);
            return response;
        }

        private async Task SendLoop(
            CancellationToken cancellationToken
        )
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await EnsureConnection(cancellationToken);
                    (var correlationId, var requestBytes, int offset, int length) = _requestQueue.Take(cancellationToken);
                    var responseBytes = await _transport.HandleRequest(requestBytes, offset, length, cancellationToken);
                    if (_pendingRequests.TryGetValue(correlationId, out var taskCompletionSource))
                        taskCompletionSource.SetResult(responseBytes);
                }
                catch (OperationCanceledException) { }
            }
        }

        private async ValueTask EnsureConnection(CancellationToken cancellationToken)
        {
            while (!_transport.IsConnected)
            {
                try
                {
                    await _transport.Connect(cancellationToken);
                    await _transport.Handshake(cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
                }
            }
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
