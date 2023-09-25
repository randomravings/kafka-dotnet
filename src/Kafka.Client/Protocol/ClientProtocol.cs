using Kafka.Client.Clients;
using Kafka.Client.Clients.Consumer.Logging;
using Kafka.Client.Clients.Logging;
using Kafka.Client.Exceptions;
using Kafka.Client.Messages;
using Kafka.Client.Messages.Serdes;
using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Net.Sockets;

namespace Kafka.Client.Protocol
{
    internal abstract class ClientProtocol :
        IClientProtocol
    {
        private const string CLIENT_NAME = "kafka-dotnet";
        private const string CLIENT_VERSION = "0.1.0";

        private readonly ConcurrentDictionary<int, TaskCompletionSource<byte[]>> _pendingRequests = new();
        private readonly BlockingCollection<SendThing> _sendQueue = new();

        private CancellationTokenSource _internalCts = new();
        private Task _senderThread = Task.CompletedTask;
        private Task _receiverThread = Task.CompletedTask;
        private readonly SemaphoreSlim _connectionSemaphore = new(1, 1);

        private static readonly ApiVersionsRequestData API_VERSION_REQUEST = new(
            CLIENT_NAME,
            CLIENT_VERSION,
            ImmutableArray<TaggedField>.Empty
        );

        private static readonly MetadataRequestData CLUSTER_METADATA_REQUEST = new(
            ImmutableArray<MetadataRequestData.MetadataRequestTopic>.Empty,
            false,
            false,
            false,
            ImmutableArray<TaggedField>.Empty
        );

        private readonly IRequestEncoder<RequestHeaderData, ApiVersionsRequestData> _apiVersionRequestHandler = new ApiVersionsRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, ApiVersionsResponseData> _apiVersionResponseHandler = new ApiVersionsResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, MetadataRequestData> _metadataRequestHandler = new MetadataRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, MetadataResponseData> _metadataResponseHandler = new MetadataResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, FindCoordinatorRequestData> _findCoordinatorRequestHandler = new FindCoordinatorRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, FindCoordinatorResponseData> _findCoordinatorResponseHandler = new FindCoordinatorResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, OffsetFetchRequestData> _offsetFetchRequestHandler = new OffsetFetchRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, OffsetFetchResponseData> _offsetFetchResponseHandler = new OffsetFetchResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, ListOffsetsRequestData> _listOffsetsRequestHandler = new ListOffsetsRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, ListOffsetsResponseData> _listOffsetsResponseHandler = new ListOffsetsResponseDecoder();

        private readonly string _clientId;
        private readonly int _retries;
        private readonly TimeSpan _retryBackOffMs;
        private readonly ILogger _logger;
        private readonly ITransport _connection;
        private int _coorelationIds;
        private ClusterNodeId _nodeId = 0;

        private readonly SortedList<ApiKey, ApiVersion> _apiVersions = new();

        private bool disposedValue;

        protected ClientProtocol(
            ITransport connection,
            ClientConfig config,
            ILogger logger
        )
        {
            _connection = connection;
            _clientId = config.ClientId;
            _retries = config.Retries;
            _retryBackOffMs = TimeSpan.FromMilliseconds(config.RetryBackoffMs);
            _logger = logger;
        }

        private async ValueTask ReadinessCheck(CancellationToken cancellationToken)
        {
            if (_connection.IsConnected)
                return;
            await _connectionSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

            // Reentry catch
            if (_connection.IsConnected)
                return;

            try
            {
                _internalCts.Cancel();
                await Task.WhenAll(_senderThread, _receiverThread).ConfigureAwait(false);
                foreach (var penndingRequest in _pendingRequests)
                    penndingRequest.Value.SetCanceled(CancellationToken.None);
                _pendingRequests.Clear();
                _apiVersionRequestHandler.SetApiVersion(0);
                _apiVersionResponseHandler.SetApiVersion(0);

                await OpenTransport(cancellationToken).ConfigureAwait(false);
                _internalCts = new();
                _senderThread = Task.Run(async () =>
                    await SendLoop(_internalCts.Token).ConfigureAwait(false),
                    CancellationToken.None
                );
                _receiverThread = Task.Run(async () =>
                    await ReceiveLoop(_internalCts.Token).ConfigureAwait(false),
                    CancellationToken.None
                );

                var apiVersionsResponse = await ApiKeyBootstrap(
                    cancellationToken
                ).ConfigureAwait(false);

                UpdateApiVersions(apiVersionsResponse);

                var metadataResponse = await Execute(
                    CLUSTER_METADATA_REQUEST,
                    _metadataRequestHandler,
                    _metadataResponseHandler,
                    MetadataError,
                    cancellationToken
                ).ConfigureAwait(false);

                _nodeId = metadataResponse
                    .BrokersField
                    .Where(r => r.HostField == _connection.Host && r.PortField == _connection.Port)
                    .Select(r => r.NodeIdField)
                    .FirstOrDefault()
                ;
            }
            finally
            {
                _connectionSemaphore.Release();
            }
        }

        private async Task SendLoop(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var sendThing = _sendQueue.Take(cancellationToken);
                    await _connection.Send(
                        sendThing.Data,
                        cancellationToken
                    ).ConfigureAwait(false);
                    if (!sendThing.OneWay)
                        _pendingRequests[sendThing.CorrelationId] = sendThing.TaskCompletionSource;
                }
                catch (OperationCanceledException) { }
                catch (SocketException ex)
                {
                    _logger.SndSocketException(ex);
                }
            }
        }

        private async Task ReceiveLoop(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var data = await _connection.Receive(cancellationToken).ConfigureAwait(false);
                    (_, var correlationId) = BinaryDecoder.ReadInt32(data, 0);
                    if (_pendingRequests.Remove(correlationId, out var taskCompletionSource))
                        taskCompletionSource.SetResult(data);
                    else
                        _logger.UnexpectedCorrellationId(correlationId);
                }
                catch (OperationCanceledException) { }
                catch (SocketException ex)
                {
                    _logger.RcvSocketException(ex);
                }
            }
        }

        ITransport IProtocol.Connection => _connection;

        ClusterNodeId IClientProtocol.NodeId => _nodeId;

        async ValueTask<ApiVersionsResponseData> IClientProtocol.ApiVersions(
            CancellationToken cancellationToken
        ) =>
            await ApiVersions(
                API_VERSION_REQUEST,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<ApiVersionsResponseData> ApiVersions(
            ApiVersionsRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _apiVersionRequestHandler,
                _apiVersionResponseHandler,
                ApiVersionsError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> ApiVersionsError(ApiVersionsResponseData response)
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<MetadataResponseData> IClientProtocol.Metadata(
            CancellationToken cancellationToken
        ) =>
            await Metadata(
                CLUSTER_METADATA_REQUEST,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<MetadataResponseData> IClientProtocol.Metadata(
            MetadataRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Metadata(
                request,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<MetadataResponseData> Metadata(
            MetadataRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _metadataRequestHandler,
                _metadataResponseHandler,
                MetadataError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> MetadataError(MetadataResponseData response) =>
            response
                .TopicsField
                .Where(t => t.ErrorCodeField != 0)
                .Select(t => Errors.Translate(t.ErrorCodeField))
                .Concat(response
                    .TopicsField
                    .SelectMany(t => t.PartitionsField
                        .Where(p => p.ErrorCodeField != 0)
                        .Select(p => Errors.Translate(p.ErrorCodeField))
                    )
                )
                .ToImmutableArray()
        ;

        async ValueTask<FindCoordinatorResponseData> IClientProtocol.FindCoordinator(
            FindCoordinatorRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _findCoordinatorRequestHandler,
                _findCoordinatorResponseHandler,
                FindCoordinatorError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> FindCoordinatorError(FindCoordinatorResponseData response)
        {
            if (response.ErrorCodeField != 0)
                ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
            return response
                .CoordinatorsField
                .Where(r => r.ErrorCodeField != 0)
                .Select(r => Errors.Translate(r.ErrorCodeField))
                .ToImmutableArray()
            ;
        }

        async ValueTask<OffsetFetchResponseData> IClientProtocol.OffsetFetch(
            OffsetFetchRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _offsetFetchRequestHandler,
                _offsetFetchResponseHandler,
                OffsetFetchError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> OffsetFetchError(
            OffsetFetchResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<ListOffsetsResponseData> IClientProtocol.ListOffsets(
            ListOffsetsRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _listOffsetsRequestHandler,
                _listOffsetsResponseHandler,
                ListOffsetsError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> ListOffsetsError(
            ListOffsetsResponseData response
        ) =>
            response
                .TopicsField
                .SelectMany(t => t.PartitionsField
                    .Where(p => p.ErrorCodeField != 0)
                    .Select(p => Errors.Translate(p.ErrorCodeField))
                )
                .ToImmutableArray()
        ;

        protected async ValueTask<TResponse> Execute<TRequest, TResponse>(
            TRequest requestMessage,
            IRequestEncoder<RequestHeaderData, TRequest> requestEncoder,
            IResponseDecoder<ResponseHeaderData, TResponse> responseDecoder,
            Func<TResponse, ImmutableArray<Error>> errorDelegate,
            CancellationToken cancellationToken
        )
            where TRequest : notnull, RequestMessage
            where TResponse : notnull, ResponseMessage
        {
            var tries = 0;
            var requestBytes = new byte[1024 * 1024];
            while (true)
            {
                await ReadinessCheck(cancellationToken).ConfigureAwait(false);
                var offset = 0;
                var correlationId = Interlocked.Increment(ref _coorelationIds);
                var requestHeader = CreateRequestHeader(requestEncoder, correlationId, _clientId, ImmutableArray<TaggedField>.Empty);
                offset = requestEncoder.WriteHeader(requestBytes, offset, requestHeader);
                offset = requestEncoder.WriteMessage(requestBytes, offset, requestMessage);
                var taskCompletionSource = new TaskCompletionSource<byte[]>();
                var sendThing = new SendThing(
                    requestHeader.CorrelationId,
                    requestBytes.AsMemory(0, offset),
                    false,
                    taskCompletionSource
                );
                _sendQueue.Add(sendThing, cancellationToken);
                var responseBytes = await taskCompletionSource.Task.ConfigureAwait(false);
                (offset, var _) = responseDecoder.ReadHeader(responseBytes, 0);
                (_, var response) = responseDecoder.ReadMessage(responseBytes, offset);
                var errors = errorDelegate(response);
                if (errors.Length == 0)
                    return response;
                LogError(_logger, requestHeader, errors);
                if (tries < _retries && IsTransient(errors))
                    cancellationToken.WaitHandle.WaitOne(_retryBackOffMs);
                else
                    return response;
            }
        }

        private readonly record struct SendThing(
            int CorrelationId,
            ReadOnlyMemory<byte> Data,
            bool OneWay,
            TaskCompletionSource<byte[]> TaskCompletionSource
        );

        protected async ValueTask ExecuteOneWay<TRequest>(
            TRequest requestMessage,
            IRequestEncoder<RequestHeaderData, TRequest> requestEncoder,
            CancellationToken cancellationToken
        )
            where TRequest : notnull, RequestMessage
        {
            var tries = 0;
            var requestBytes = new byte[1024 * 1024];
            while (true)
            {
                await ReadinessCheck(cancellationToken).ConfigureAwait(false);
                var offset = 0;
                var correlationId = Interlocked.Increment(ref _coorelationIds);
                var requestHeader = CreateRequestHeader(requestEncoder, correlationId, _clientId, ImmutableArray<TaggedField>.Empty);
                offset = requestEncoder.WriteHeader(requestBytes, offset, requestHeader);
                offset = requestEncoder.WriteMessage(requestBytes, offset, requestMessage);
                var taskCompletionSource = new TaskCompletionSource<byte[]>();
                var sendThing = new SendThing(
                    requestHeader.CorrelationId,
                    requestBytes.AsMemory(0, offset),
                    false,
                    taskCompletionSource
                );
                _sendQueue.Add(sendThing, cancellationToken);
                _ = await taskCompletionSource.Task.ConfigureAwait(false);
                if (tries < _retries)
                    cancellationToken.WaitHandle.WaitOne(_retryBackOffMs);
                else
                    return;
            }
        }

        private async ValueTask<ApiVersionsResponseData> ApiKeyBootstrap(
            CancellationToken cancellationToken
        )
        {
            var tries = 0;
            var requestBytes = new byte[1024 * 1024];
            while (true)
            {
                var offset = 0;
                var correlationId = Interlocked.Increment(ref _coorelationIds);
                var requestHeader = CreateRequestHeader(_apiVersionRequestHandler, correlationId, _clientId, ImmutableArray<TaggedField>.Empty);
                offset = _apiVersionRequestHandler.WriteHeader(requestBytes, offset, requestHeader);
                offset = _apiVersionRequestHandler.WriteMessage(requestBytes, offset, API_VERSION_REQUEST);
                var taskCompletionSource = new TaskCompletionSource<byte[]>();
                var sendThing = new SendThing(
                    requestHeader.CorrelationId,
                    requestBytes.AsMemory(0, offset),
                    false,
                    taskCompletionSource
                );
                _sendQueue.Add(sendThing, cancellationToken);
                var responseBytes = await taskCompletionSource.Task.ConfigureAwait(false);
                (offset, var _) = _apiVersionResponseHandler.ReadHeader(responseBytes, 0);
                (_, var response) = _apiVersionResponseHandler.ReadMessage(responseBytes, offset);
                var errors = ApiVersionsError(response);
                if (errors.Length == 0)
                    return response;
                LogError(_logger, requestHeader, errors);
                if (tries < _retries && IsTransient(errors))
                    cancellationToken.WaitHandle.WaitOne(_retryBackOffMs);
                return response;
            }
        }


        private async ValueTask OpenTransport(
            CancellationToken cancellationToken
        )
        {
            int retires = 0;
            while (!_connection.IsConnected)
            {
                retires++;
                try
                {
                    await _connection.Open(cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException) { }
                catch (OpenConnectionException ex)
                {
                    ClientLog.ConnectError(_logger, ex);
                    if (retires < 10)
                        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken).ConfigureAwait(false);
                    else
                        throw;
                }
            }
        }

        private static void LogError(ILogger logger, RequestHeaderData header, ImmutableArray<Error> errors)
        {
            foreach (var error in errors)
                if (error.Retriable)
                    ClientLog.LogErrorAsWaring(logger, header, error);
                else
                    ClientLog.LogApiError(logger, header, error);
        }

        private static bool IsTransient(ImmutableArray<Error> errors)
        {
            foreach (var error in errors)
                if (!error.Retriable)
                    return false;
            return true;
        }

        protected RequestHeaderData CreateRequestHeader(
            ApiKey apiKey,
            Common.Model.ApiVersion version
        )
        {
            var correlationId = Interlocked.Increment(ref _coorelationIds);
            return new RequestHeaderData(
                (short)apiKey,
                version,
                correlationId,
                _clientId,
                ImmutableArray<TaggedField>.Empty
            );
        }

        private void UpdateApiVersions(ApiVersionsResponseData apiVersionsResponse)
        {
            _apiVersions.Clear();
            foreach (var apiKey in apiVersionsResponse.ApiKeysField)
                _apiVersions.Add((ApiKey)apiKey.ApiKeyField, apiKey.MaxVersionField);

            SetCodecVersion(_apiVersionRequestHandler, _apiVersions);
            SetCodecVersion(_apiVersionResponseHandler, _apiVersions);

            SetCodecVersion(_metadataRequestHandler, _apiVersions);
            SetCodecVersion(_metadataResponseHandler, _apiVersions);

            SetCodecVersion(_findCoordinatorRequestHandler, _apiVersions);
            SetCodecVersion(_findCoordinatorResponseHandler, _apiVersions);

            SetCodecVersion(_offsetFetchRequestHandler, _apiVersions);
            SetCodecVersion(_offsetFetchResponseHandler, _apiVersions);

            SetCodecVersion(_listOffsetsRequestHandler, _apiVersions);
            SetCodecVersion(_listOffsetsResponseHandler, _apiVersions);

            UpdateApiVersions(_apiVersions);
        }

        protected abstract void UpdateApiVersions(IReadOnlyDictionary<ApiKey, ApiVersion> versions);

        async ValueTask IProtocol.Close(CancellationToken cancellationToken) =>
            await _connection.Close(cancellationToken).ConfigureAwait(false)
        ;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    var pendingRequests = _pendingRequests.Select(r => r.Value).ToImmutableArray();
                    foreach (var pendingRequest in pendingRequests)
                        pendingRequest.SetCanceled();
                    _internalCts.Cancel();
                    Task.WaitAll(_senderThread, _receiverThread);
                    _internalCts.Dispose();
                    _sendQueue.Dispose();
                    _connectionSemaphore.Dispose();
                }
                disposedValue = true;
            }
        }

        protected static RequestHeaderData CreateRequestHeader(
            IMessageCodec messageCodec,
            int correlationId,
            string clientId,
            ImmutableArray<TaggedField> taggedFields
        ) =>
            new (
                (short)messageCodec.ApiKey,
                (short)messageCodec.ApiVersion,
                correlationId,
                clientId,
                taggedFields
            )
        ;

        protected static void SetCodecVersion(IMessageCodec messageCodec, IReadOnlyDictionary<ApiKey, ApiVersion> apiVersions)
        {
            var apiVersion = apiVersions[messageCodec.ApiKey];
            messageCodec.SetApiVersion(apiVersion);
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
