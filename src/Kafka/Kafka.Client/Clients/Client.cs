﻿using Kafka.Client.Messages;
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
        private readonly BlockingCollection<SendCallback> _pendingRequests = new();
        private readonly CancellationTokenSource _clientCts = new();
        private readonly Task _requestHandler;
        protected readonly TConfig _config;
        protected readonly ILogger _logger;

        private int _coorelationIds = 0;
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
            TaskCompletionSource<ReceivePackage> Response
        );

        private sealed record ReceivePackage(
            ResponseHeader ResponseHeader,
            byte[] Response,
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
            _transport = new PlaintextTransport(endpoint, logger);
            _requestHandler = Task.Run(async () => await Do(_clientCts.Token), CancellationToken.None);
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

        public async ValueTask Close(CancellationToken cancellationToken)
        {
            await OnClose(cancellationToken);
            _clientCts.Cancel();
            await _requestHandler;
            await _transport.Close(cancellationToken);
        }

        protected abstract ValueTask OnClose(CancellationToken cancellationToken);

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                _requestHandler.Dispose();
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

            var callback = new SendCallback(
                requestHeader,
                flexible,
                ignoreHeaderTaggedFields,
                requestBytes,
                0,
                offset,
                new TaskCompletionSource<ReceivePackage>()
            );
            _pendingRequests.Add(callback, cancellationToken);
            var response = await callback.Response.Task.ContinueWith(
                r =>
                {
                    offset = r.Result.Offset;
                    if (r.Result.ResponseHeader.CorrelationIdField != callback.RequestHeader.CorrelationIdField)
                        throw new Exception($"Correlation Id mismath - Request: {callback.RequestHeader.CorrelationIdField} - Response: {callback.RequestHeader.CorrelationIdField}");
                    var response = responseReader(r.Result.Response, ref offset, version);
                    return response;
                },
                CancellationToken.None
            );
            return response;
        }

        private async Task Do(
            CancellationToken cancellationToken
        )
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var sendCallback = _pendingRequests.Take(cancellationToken);
                    var responseBytes = await _transport.HandleRequest(sendCallback.Request, sendCallback.Offset, sendCallback.Length, cancellationToken);
                    var offset = 0;
                    var responseHeader = ResponseHeaderSerde.Read(responseBytes, ref offset, RESPONSE_HEADER_VERSION, sendCallback.Flexible && !sendCallback.IgnoreHeaderTaggedFields);
                    var receivePackage = new ReceivePackage(responseHeader, responseBytes, offset, responseBytes.Length - offset);
                    sendCallback.Response.SetResult(receivePackage);
                }
                catch (OperationCanceledException) { }
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
