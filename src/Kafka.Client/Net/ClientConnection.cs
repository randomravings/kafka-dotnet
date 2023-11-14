using Kafka.Client.Config;
using Kafka.Client.Logging;
using Kafka.Client.Messages;
using Kafka.Client.Messages.Encoding;
using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Net;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Net.Sockets;

namespace Kafka.Client.Net
{
    internal sealed class ClientConnection :
        IClientConnection
    {
        private const string CLIENT_NAME = "kafka-dotnet";
        private const string CLIENT_VERSION = "0.1.0";

        private readonly ConcurrentDictionary<int, TaskCompletionSource<byte[]>> _pendingRequests = new();
        private readonly BlockingCollection<SendThing> _sendQueue = new();

        private CancellationTokenSource _internalCts = new();
        private Task _senderThread = Task.CompletedTask;
        private Task _receiverThread = Task.CompletedTask;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

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

        private readonly IRequestEncoder<RequestHeaderData, CreateTopicsRequestData> _createTopicsRequestHandler = new CreateTopicsRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, CreateTopicsResponseData> _createTopicsResponseHandler = new CreateTopicsResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, DeleteTopicsRequestData> _deleteTopicsRequestHandler = new DeleteTopicsRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, DeleteTopicsResponseData> _deleteTopicsResponseHandler = new DeleteTopicsResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, FindCoordinatorRequestData> _findCoordinatorRequestHandler = new FindCoordinatorRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, FindCoordinatorResponseData> _findCoordinatorResponseHandler = new FindCoordinatorResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, OffsetFetchRequestData> _offsetFetchRequestHandler = new OffsetFetchRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, OffsetFetchResponseData> _offsetFetchResponseHandler = new OffsetFetchResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, ListOffsetsRequestData> _listOffsetsRequestHandler = new ListOffsetsRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, ListOffsetsResponseData> _listOffsetsResponseHandler = new ListOffsetsResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, InitProducerIdRequestData> _initProducerIdRequestHandler = new InitProducerIdRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, InitProducerIdResponseData> _initProducerIdResponseHandler = new InitProducerIdResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, ProduceRequestData> _produceRequestHandler = new ProduceRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, ProduceResponseData> _produceResponseHandler = new ProduceResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, AddPartitionsToTxnRequestData> _addPartitionsToTxnRequestHandler = new AddPartitionsToTxnRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, AddPartitionsToTxnResponseData> _addPartitionsToTxnResponseHandler = new AddPartitionsToTxnResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, EndTxnRequestData> _endTxnRequestHandler = new EndTxnRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, EndTxnResponseData> _endTxnResponseHandler = new EndTxnResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, HeartbeatRequestData> _heartbeatRequestHandler = new HeartbeatRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, HeartbeatResponseData> _heartbeatResponseHandler = new HeartbeatResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, JoinGroupRequestData> _joinGroupRequestHandler = new JoinGroupRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, JoinGroupResponseData> _joinGroupResponseHandler = new JoinGroupResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, SyncGroupRequestData> _syncGroupRequestHandler = new SyncGroupRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, SyncGroupResponseData> _syncGroupResponseHandler = new SyncGroupResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, LeaveGroupRequestData> _leaveGroupRequestHandler = new LeaveGroupRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, LeaveGroupResponseData> _leaveGroupResponseHandler = new LeaveGroupResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, OffsetCommitRequestData> _offsetCommitRequestHandler = new OffsetCommitRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, OffsetCommitResponseData> _offsetCommitResponseHandler = new OffsetCommitResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, FetchRequestData> _fetchRequestHandler = new FetchRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, FetchResponseData> _fetchResponseHandler = new FetchResponseDecoder();

        private readonly string _clientId;
        private readonly int _retries;
        private readonly TimeSpan _retryBackOffMs;
        private readonly ILogger _logger;
        private readonly ITransport _connection;
        private int _coorelationIds;
        private ClusterNodeId _nodeId = -1;

        private readonly SortedList<ApiKey, ApiVersion> _apiVersions = new();

        public ClientConnection(
            ITransport connection,
            KafkaClientConfig config,
            ILogger logger
        )
        {
            _connection = connection;
            _clientId = config.ClientId;
            _retries = config.Retries;
            _retryBackOffMs = TimeSpan.FromMilliseconds(config.RetryBackoffMs);
            _logger = logger;
        }

        ITransport IConnection.Transport => _connection;

        ClusterNodeId IConnection.NodeId => _nodeId;

        async ValueTask IConnection.Open(CancellationToken cancellationToken) =>
            await EnsureConnection(
                cancellationToken
            )
            .ConfigureAwait(false)
        ;

        async ValueTask IConnection.Close(CancellationToken cancellationToken)
        {
            if (!_connection.IsConnected)
                return;
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (!_connection.IsConnected)
                    return;
                await NetworkLoopStop(cancellationToken).ConfigureAwait(false);
                await _connection.Close(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        async ValueTask<ApiVersionsResponseData> IClientConnection.ApiVersions(
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

        private static (bool, ImmutableArray<Error>) ApiVersionsError(ApiVersionsResponseData response)
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<Error>.Empty);
            var errors = ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async ValueTask<MetadataResponseData> IClientConnection.Metadata(
            CancellationToken cancellationToken
        ) =>
            await Metadata(
                CLUSTER_METADATA_REQUEST,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<MetadataResponseData> IClientConnection.Metadata(
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

        private static (bool, ImmutableArray<Error>) MetadataError(MetadataResponseData response)
        {
            var errors = response
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

            if (errors.Length == 0)
                return (false, errors);
            if (errors.Any(r => r.Code == Errors.Known.UNKNOWN_TOPIC_OR_PARTITION.Code))
                return (false, errors);
            return (IsTransient(errors), errors);
        }

        async ValueTask<CreateTopicsResponseData> IClientConnection.CreateTopics(
            CreateTopicsRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _createTopicsRequestHandler,
                _createTopicsResponseHandler,
                CreateTopicsError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<Error>) CreateTopicsError(
            CreateTopicsResponseData response
        )
        {
            var errors = response
                .TopicsField
                .Where(r => r.ErrorCodeField != 0)
                .Select(r => Errors.Translate(r.ErrorCodeField))
                .ToImmutableArray()
            ;
            return (IsTransient(errors), errors);
        }

        async ValueTask<DeleteTopicsResponseData> IClientConnection.DeleteTopics(
            DeleteTopicsRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _deleteTopicsRequestHandler,
                _deleteTopicsResponseHandler,
                DeleteTopicsError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<Error>) DeleteTopicsError(
            DeleteTopicsResponseData response
        )
        {
            var errors = response.ResponsesField
                .Where(r => r.ErrorCodeField != 0)
                .Select(r => Errors.Translate(r.ErrorCodeField))
                .ToImmutableArray()
            ;
            if(errors.Length > 0 && errors.Any(r => r.Code == Errors.Known.UNKNOWN_TOPIC_OR_PARTITION.Code))
                return (false, errors);
            return (IsTransient(errors), errors);
        }

        async ValueTask<FindCoordinatorResponseData> IClientConnection.FindCoordinator(
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

        private static (bool, ImmutableArray<Error>) FindCoordinatorError(FindCoordinatorResponseData response)
        {
            var errors = response.ErrorCodeField switch
            {
                0 => response
                        .CoordinatorsField
                        .Where(r => r.ErrorCodeField != 0)
                        .Select(r => Errors.Translate(r.ErrorCodeField))
                        .ToImmutableArray(),
                _ => ImmutableArray.Create(Errors.Translate(response.ErrorCodeField))
            };
            return (IsTransient(errors), errors);
        }

        async ValueTask<OffsetFetchResponseData> IClientConnection.OffsetFetch(
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

        private static (bool, ImmutableArray<Error>) OffsetFetchError(
            OffsetFetchResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<Error>.Empty);
            var errors = ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async ValueTask<ListOffsetsResponseData> IClientConnection.ListOffsets(
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

        private static (bool, ImmutableArray<Error>) ListOffsetsError(
            ListOffsetsResponseData response
        )
        {
            var errors = response
                .TopicsField
                .SelectMany(t => t.PartitionsField
                    .Where(p => p.ErrorCodeField != 0)
                    .Select(p => Errors.Translate(p.ErrorCodeField))
                )
                .ToImmutableArray()
            ;
            return (IsTransient(errors), errors);
        }

        async ValueTask<InitProducerIdResponseData> IClientConnection.InitProducerId(
            InitProducerIdRequestData request,
            CancellationToken cancellationToken
        ) => await Execute(
                request,
                _initProducerIdRequestHandler,
                _initProducerIdResponseHandler,
                InitProducerIdError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<Error>) InitProducerIdError(InitProducerIdResponseData response)
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<Error>.Empty);
            var errors = ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async ValueTask<ProduceResponseData> IClientConnection.Produce(
            ProduceRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _produceRequestHandler,
                _produceResponseHandler,
                ProduceError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<Error>) ProduceError(ProduceResponseData response)
        {
            var errors = response
                .ResponsesField
                .SelectMany(t => t.PartitionResponsesField
                    .Where(r => r.ErrorCodeField != 0)
                    .Select(r => Errors.Translate(r.ErrorCodeField))
                )
                .ToImmutableArray()
            ;
            return (IsTransient(errors), errors);
        }

        async ValueTask IClientConnection.ProduceNoAck(
            ProduceRequestData request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteOneWay(
                request,
                _produceRequestHandler,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<AddPartitionsToTxnResponseData> IClientConnection.AddPartitionsToTxn(
            AddPartitionsToTxnRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _addPartitionsToTxnRequestHandler,
                _addPartitionsToTxnResponseHandler,
                AddPartitionsToTxnError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<Error>) AddPartitionsToTxnError(
            AddPartitionsToTxnResponseData response
        )
        {
            var errors = response
                .ResultsByTopicV3AndBelowField
                .SelectMany(t => t.ResultsByPartitionField
                    .Where(p => p.PartitionErrorCodeField != 0)
                    .Select(p => Errors.Translate(p.PartitionErrorCodeField))
                )
                .ToImmutableArray()
            ;
            return (IsTransient(errors), errors);
        }

        async ValueTask<EndTxnResponseData> IClientConnection.EndTxn(
            EndTxnRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _endTxnRequestHandler,
                _endTxnResponseHandler,
                EndTxnError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<Error>) EndTxnError(
            EndTxnResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<Error>.Empty);
            var errors = ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async ValueTask<HeartbeatResponseData> IClientConnection.Heartbeat(
            HeartbeatRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _heartbeatRequestHandler,
                _heartbeatResponseHandler,
                HeartbeatError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<Error>) HeartbeatError(
            HeartbeatResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<Error>.Empty);
            var errors = ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async ValueTask<JoinGroupResponseData> IClientConnection.JoinGroup(
            JoinGroupRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _joinGroupRequestHandler,
                _joinGroupResponseHandler,
                JoinGroupError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<Error>) JoinGroupError(
            JoinGroupResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<Error>.Empty);
            var errors = ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async ValueTask<SyncGroupResponseData> IClientConnection.SyncGroup(
            SyncGroupRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _syncGroupRequestHandler,
                _syncGroupResponseHandler,
                SyncGroupError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<Error>) SyncGroupError(
            SyncGroupResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<Error>.Empty);
            var errors = ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async ValueTask<LeaveGroupResponseData> IClientConnection.LeaveGroup(
            LeaveGroupRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _leaveGroupRequestHandler,
                _leaveGroupResponseHandler,
                LeaveGroupError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<Error>) LeaveGroupError(
            LeaveGroupResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<Error>.Empty);
            var errors = ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async ValueTask<OffsetCommitResponseData> IClientConnection.OffsetCommit(
            OffsetCommitRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _offsetCommitRequestHandler,
                _offsetCommitResponseHandler,
                OffsetCommitError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<Error>) OffsetCommitError(
            OffsetCommitResponseData response
        )
        {
            var errors = response
                .TopicsField
                .SelectMany(t => t.PartitionsField
                    .Where(p => p.ErrorCodeField != 0)
                    .Select(p => Errors.Translate(p.ErrorCodeField))
                )
                .ToImmutableArray()
            ;
            return (IsTransient(errors), errors);
        }

        async ValueTask<FetchResponseData> IClientConnection.Fetch(
            FetchRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _fetchRequestHandler,
                _fetchResponseHandler,
                FetchError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<Error>) FetchError(
            FetchResponseData response
        )
        {
            var errors = response.ErrorCodeField switch
            {
                0 => response
                        .ResponsesField
                        .SelectMany(t => t.PartitionsField
                            .Where(p => p.ErrorCodeField != 0)
                            .Select(p => Errors.Translate(p.ErrorCodeField))
                        )
                        .ToImmutableArray(),
                _ => ImmutableArray.Create(Errors.Translate(response.ErrorCodeField))
            };
            return (IsTransient(errors), errors);
        }

        void IDisposable.Dispose()
        {
            _internalCts.Dispose();
            _sendQueue.Dispose();
            _semaphore.Dispose();
            GC.SuppressFinalize(this);
        }

        private async ValueTask<TResponse> Execute<TRequest, TResponse>(
            TRequest requestMessage,
            IRequestEncoder<RequestHeaderData, TRequest> requestEncoder,
            IResponseDecoder<ResponseHeaderData, TResponse> responseDecoder,
            Func<TResponse, (bool, ImmutableArray<Error>)> errorDelegate,
            CancellationToken cancellationToken
        )
            where TRequest : notnull, RequestMessage
            where TResponse : notnull, ResponseMessage
        {
            var tries = 0;
            var requestBytes = new byte[1024 * 1024];
            while (true)
            {
                await EnsureConnection(cancellationToken).ConfigureAwait(false);
                var offset = 0;
                var requestHeader = CreateRequestHeader(requestEncoder, ImmutableArray<TaggedField>.Empty);
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
                var (retriable, errors) = errorDelegate(response);
                if (errors.Length == 0)
                    return response;
                LogError(_logger, requestHeader, errors);
                if (!retriable)
                    return response;
                if (tries++ <= _retries)
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

        private async ValueTask ExecuteOneWay<TRequest>(
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
                await EnsureConnection(cancellationToken).ConfigureAwait(false);
                var offset = 0;
                var requestHeader = CreateRequestHeader(requestEncoder, ImmutableArray<TaggedField>.Empty);
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
                if (tries++ <= _retries)
                    cancellationToken.WaitHandle.WaitOne(_retryBackOffMs);
                else
                    return;
            }
        }

        private async ValueTask ApiKeyBootstrap(
            CancellationToken cancellationToken
        )
        {
            _apiVersionRequestHandler.SetApiVersion(0);
            _apiVersionResponseHandler.SetApiVersion(0);
            var tries = 0;
            var requestBytes = new byte[1024 * 1024];
            while (true)
            {
                var offset = 0;
                var requestHeader = CreateRequestHeader(_apiVersionRequestHandler, ImmutableArray<TaggedField>.Empty);
                offset = _apiVersionRequestHandler.WriteHeader(requestBytes, offset, requestHeader);
                offset = _apiVersionRequestHandler.WriteMessage(requestBytes, offset, API_VERSION_REQUEST);

                await _connection.Send(requestBytes.AsMemory(0, offset), cancellationToken).ConfigureAwait(false);
                var responseBytes = await _connection.Receive(cancellationToken).ConfigureAwait(false);

                (offset, var _) = _apiVersionResponseHandler.ReadHeader(responseBytes, 0);
                (_, var apiVersionsResponse) = _apiVersionResponseHandler.ReadMessage(responseBytes, offset);

                var (_, errors) = ApiVersionsError(apiVersionsResponse);
                if (errors.Length == 0)
                {
                    UpdateApiVersions(apiVersionsResponse);
                    return;
                }

                LogError(_logger, requestHeader, errors);
                if (tries++ <= _retries && IsTransient(errors))
                    cancellationToken.WaitHandle.WaitOne(_retryBackOffMs);
                else
                    ApiExceptions(errors);
            }
        }

        private async ValueTask MetadataBootstrap(
            CancellationToken cancellationToken
        )
        {
            var tries = 0;
            var requestBytes = new byte[1024 * 1024];
            while (true)
            {
                var offset = 0;
                var requestHeader = CreateRequestHeader(_metadataRequestHandler, ImmutableArray<TaggedField>.Empty);
                offset = _metadataRequestHandler.WriteHeader(requestBytes, offset, requestHeader);
                offset = _metadataRequestHandler.WriteMessage(requestBytes, offset, CLUSTER_METADATA_REQUEST);

                await _connection.Send(requestBytes.AsMemory(0, offset), cancellationToken).ConfigureAwait(false);
                var responseBytes = await _connection.Receive(cancellationToken).ConfigureAwait(false);

                (offset, var _) = _metadataResponseHandler.ReadHeader(responseBytes, 0);
                (_, var metadataResponse) = _metadataResponseHandler.ReadMessage(responseBytes, offset);

                var (_, errors) = MetadataError(metadataResponse);
                if (errors.Length == 0)
                {
                    UpdateMetadata(metadataResponse);
                    return;
                }

                LogError(_logger, requestHeader, errors);
                if (tries++ <= _retries && IsTransient(errors))
                    cancellationToken.WaitHandle.WaitOne(_retryBackOffMs);
                else
                    ApiExceptions(errors);
            }
        }

        private static void ApiExceptions(ImmutableArray<Error> errors) =>
            throw new AggregateException(
                errors.Select(e => new ApiException(e))
            )
        ;

        private async ValueTask OpenTransport(
            CancellationToken cancellationToken
        )
        {
            int retires = 0;
            while (!_connection.IsConnected)
            {
                try
                {
                    await _connection.Open(cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException) { }
                catch (OpenConnectionException ex)
                {
                    _logger.ConnectError(ex);
                    if (retires++ <= 10)
                        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken).ConfigureAwait(false);
                    else
                        throw;
                }
            }
        }

        private async ValueTask EnsureConnection(CancellationToken cancellationToken)
        {
            if (_connection.IsConnected)
                return;
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (_connection.IsConnected)
                    return;
                await NetworkLoopStop(cancellationToken).ConfigureAwait(false);
                await OpenTransport(cancellationToken).ConfigureAwait(false);
                await ApiKeyBootstrap(cancellationToken).ConfigureAwait(false);
                await MetadataBootstrap(cancellationToken).ConfigureAwait(false);
                await NetworkLoopStart(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release();
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

        private static void LogError(ILogger logger, RequestHeaderData header, ImmutableArray<Error> errors)
        {
            foreach (var error in errors)
                logger.LogApiError(header, error);
        }

        private static bool IsTransient(ImmutableArray<Error> errors)
        {
            foreach (var error in errors)
                if (!error.Retriable)
                    return false;
            return true;
        }

        private RequestHeaderData CreateRequestHeader(
            IMessageCodec messageCodec,
            ImmutableArray<TaggedField> taggedFields
        )
        {
            var correlationId = Interlocked.Increment(ref _coorelationIds);
            return new RequestHeaderData(
                (short)messageCodec.ApiKey,
                messageCodec.ApiVersion,
                correlationId,
                _clientId,
                taggedFields
            );
        }

        private void UpdateMetadata(MetadataResponseData metadataResponse)
        {
            _nodeId = metadataResponse
                .BrokersField
                .Where(r => r.HostField == _connection.Host && r.PortField == _connection.Port)
                .Select(r => r.NodeIdField)
                .FirstOrDefault()
            ;
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

            SetCodecVersion(_createTopicsRequestHandler, _apiVersions);
            SetCodecVersion(_createTopicsResponseHandler, _apiVersions);

            SetCodecVersion(_deleteTopicsRequestHandler, _apiVersions);
            SetCodecVersion(_deleteTopicsResponseHandler, _apiVersions);

            SetCodecVersion(_findCoordinatorRequestHandler, _apiVersions);
            SetCodecVersion(_findCoordinatorResponseHandler, _apiVersions);

            SetCodecVersion(_offsetFetchRequestHandler, _apiVersions);
            SetCodecVersion(_offsetFetchResponseHandler, _apiVersions);

            SetCodecVersion(_listOffsetsRequestHandler, _apiVersions);
            SetCodecVersion(_listOffsetsResponseHandler, _apiVersions);

            SetCodecVersion(_initProducerIdRequestHandler, _apiVersions);
            SetCodecVersion(_initProducerIdResponseHandler, _apiVersions);

            SetCodecVersion(_produceRequestHandler, _apiVersions);
            SetCodecVersion(_produceResponseHandler, _apiVersions);

            SetCodecVersion(_addPartitionsToTxnRequestHandler, _apiVersions);
            SetCodecVersion(_addPartitionsToTxnResponseHandler, _apiVersions);

            SetCodecVersion(_endTxnRequestHandler, _apiVersions);
            SetCodecVersion(_endTxnResponseHandler, _apiVersions);

            SetCodecVersion(_heartbeatRequestHandler, _apiVersions);
            SetCodecVersion(_heartbeatResponseHandler, _apiVersions);

            SetCodecVersion(_joinGroupRequestHandler, _apiVersions);
            SetCodecVersion(_joinGroupResponseHandler, _apiVersions);

            SetCodecVersion(_syncGroupRequestHandler, _apiVersions);
            SetCodecVersion(_syncGroupResponseHandler, _apiVersions);

            SetCodecVersion(_leaveGroupRequestHandler, _apiVersions);
            SetCodecVersion(_leaveGroupResponseHandler, _apiVersions);

            SetCodecVersion(_offsetCommitRequestHandler, _apiVersions);
            SetCodecVersion(_offsetCommitResponseHandler, _apiVersions);

            SetCodecVersion(_fetchRequestHandler, _apiVersions);
            SetCodecVersion(_fetchResponseHandler, _apiVersions);
        }

        private async ValueTask NetworkLoopStop(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _internalCts.Cancel();
            await Task.WhenAll(_senderThread, _receiverThread).ConfigureAwait(false);
            await Task.Yield();
            var pendingRequests = _pendingRequests.Select(r => r.Value).ToImmutableArray();
            foreach (var pendingRequest in pendingRequests)
                pendingRequest.SetCanceled(CancellationToken.None);
        }

        private async ValueTask NetworkLoopStart(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _internalCts = new();
            _senderThread = Task.Run(async () =>
                await SendLoop(_internalCts.Token).ConfigureAwait(false),
                CancellationToken.None
            );
            await Task.Yield();
            _receiverThread = Task.Run(async () =>
                await ReceiveLoop(_internalCts.Token).ConfigureAwait(false),
                CancellationToken.None
            );
            await Task.Yield();
        }

        private static void SetCodecVersion(
            IMessageCodec messageCodec,
            IReadOnlyDictionary<ApiKey, ApiVersion> apiVersions
        )
        {
            var apiVersion = apiVersions[messageCodec.ApiKey];
            messageCodec.SetApiVersion(apiVersion);
        }
    }
}
