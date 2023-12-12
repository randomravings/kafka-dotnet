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
using System.Net.Sockets;
using System.Runtime.Serialization;

namespace Kafka.Client.Net
{
    internal sealed class NodeLink(
        ITransport connection,
        KafkaClientConfig config,
        ILogger logger
    ) :
        INodeLink,
        IDisposable
    {
        private const string CLIENT_NAME = "kafka-dotnet";
        private const string CLIENT_VERSION = "0.1.0";

        private static readonly ApiVersionsRequestData API_VERSION_REQUEST = new(
            CLIENT_NAME,
            CLIENT_VERSION,
            []
        );

        private static readonly MetadataRequestData CLUSTER_METADATA_REQUEST = new(
            [],
            false,
            false,
            false,
            []
        );

        private readonly string _clientId = config.Client.ClientId;
        private readonly int _retries = config.Client.Retries;
        private readonly TimeSpan _retryBackOffMs = TimeSpan.FromMilliseconds(config.Client.RetryBackoffMs);
        private readonly ILogger _logger = logger;
        private readonly ITransport _transport = connection;
        private readonly SecurityProtocol _securityProtocol = config.Client.SecurityProtocol;
        private readonly SaslMechanism _saslMechanism = config.Client.SaslMechanism;
        private readonly string _saslUsername =
            string.IsNullOrEmpty(config.Client.SaslUsername) ?
            Environment.GetEnvironmentVariable(config.Client.SaslUsernameVariable, EnvironmentVariableTarget.Process) ??
            Environment.GetEnvironmentVariable(config.Client.SaslUsernameVariable, EnvironmentVariableTarget.User) ??
            Environment.GetEnvironmentVariable(config.Client.SaslUsernameVariable, EnvironmentVariableTarget.Machine) ??
            "" :
            config.Client.SaslUsername
        ;
        private readonly string _saslPassword =
            string.IsNullOrEmpty(config.Client.SaslPassword) ?
            Environment.GetEnvironmentVariable(config.Client.SaslPasswordVariable, EnvironmentVariableTarget.Process) ??
            Environment.GetEnvironmentVariable(config.Client.SaslPasswordVariable, EnvironmentVariableTarget.User) ??
            Environment.GetEnvironmentVariable(config.Client.SaslPasswordVariable, EnvironmentVariableTarget.Machine) ??
            "" :
            config.Client.SaslPassword
        ;

        private readonly ConcurrentDictionary<int, TaskCompletionSource<byte[]>> _pendingRequests = [];
        private readonly ConcurrentDictionary<ApiKey, ApiVersion> _apiVersions = [];
        private readonly BlockingCollection<SendThing> _sendQueue = [];
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        private readonly ApiVersionsRequestEncoder _apiVersionRequestEncoder = new();
        private readonly ApiVersionsResponseDecoder _apiVersionResponseDecoder = new();

        private readonly MetadataRequestEncoder _metadataRequestEncoder = new();
        private readonly MetadataResponseDecoder _metadataResponseDecoder = new();

        private readonly SaslHandshakeRequestEncoder _saslHandshakeRequestEncoder = new();
        private readonly SaslHandshakeResponseDecoder _saslHandshakeResponseDecoder = new();

        private readonly SaslAuthenticateRequestEncoder _saslAuthenticateRequestEncoder = new();
        private readonly SaslAuthenticateResponseDecoder _saslAuthenticateResponseDecoder = new();

        private readonly CreateTopicsRequestEncoder _createTopicsRequestEncoder = new();
        private readonly CreateTopicsResponseDecoder _createTopicsResponseDecoder = new();

        private readonly DeleteTopicsRequestEncoder _deleteTopicsRequestEncoder = new();
        private readonly DeleteTopicsResponseDecoder _deleteTopicsResponseDecoder = new();

        private readonly FindCoordinatorRequestEncoder _findCoordinatorRequestEncoder = new();
        private readonly FindCoordinatorResponseDecoder _findCoordinatorResponseDecoder = new();

        private readonly OffsetFetchRequestEncoder _offsetFetchRequestEncoder = new();
        private readonly OffsetFetchResponseDecoder _offsetFetchResponseDecoder = new();

        private readonly ListOffsetsRequestEncoder _listOffsetsRequestEncoder = new();
        private readonly ListOffsetsResponseDecoder _listOffsetsResponseDecoder = new();

        private readonly InitProducerIdRequestEncoder _initProducerIdRequestEncoder = new();
        private readonly InitProducerIdResponseDecoder _initProducerIdResponseDecoder = new();

        private readonly ProduceRequestEncoder _produceRequestEncoder = new();
        private readonly ProduceResponseDecoder _produceResponseDecoder = new();

        private readonly AddPartitionsToTxnRequestEncoder _addPartitionsToTxnRequestEncoder = new();
        private readonly AddPartitionsToTxnResponseDecoder _addPartitionsToTxnResponseDecoder = new();

        private readonly EndTxnRequestEncoder _endTxnRequestEncoder = new();
        private readonly EndTxnResponseDecoder _endTxnResponseDecoder = new();

        private readonly HeartbeatRequestEncoder _heartbeatRequestEncoder = new();
        private readonly HeartbeatResponseDecoder _heartbeatResponseDecoder = new();

        private readonly JoinGroupRequestEncoder _joinGroupRequestEncoder = new();
        private readonly JoinGroupResponseDecoder _joinGroupResponseDecoder = new();

        private readonly SyncGroupRequestEncoder _syncGroupRequestEncoder = new();
        private readonly SyncGroupResponseDecoder _syncGroupResponseDecoder = new();

        private readonly LeaveGroupRequestEncoder _leaveGroupRequestEncoder = new();
        private readonly LeaveGroupResponseDecoder _leaveGroupResponseDecoder = new();

        private readonly OffsetCommitRequestEncoder _offsetCommitRequestEncoder = new();
        private readonly OffsetCommitResponseDecoder _offsetCommitResponseDecoder = new();

        private readonly FetchRequestEncoder _fetchRequestEncoder = new();
        private readonly FetchResponseDecoder _fetchResponseDecoder = new();

        private CancellationTokenSource _internalCts = new();
        private Task _senderThread = Task.CompletedTask;
        private Task _receiverThread = Task.CompletedTask;
        private NodeId _nodeId = -1;
        private int _coorelationIds;

        NodeId INode.NodeId => _nodeId;

        public IReadOnlyDictionary<ApiKey, ApiVersion> Apis =>
            _apiVersions
        ;

        public async Task Open(CancellationToken cancellationToken) =>
            await EnsureConnection(
                cancellationToken
            )
            .ConfigureAwait(false)
        ;

        public async Task Close(CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (!_transport.IsConnected)
                    return;
                await NetworkLoopStop(cancellationToken).ConfigureAwait(false);
                await _transport.Close(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<ApiVersionsResponseData> ApiVersions(
            CancellationToken cancellationToken
        ) =>
            await ApiVersions(
                API_VERSION_REQUEST,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async Task<ApiVersionsResponseData> ApiVersions(
            ApiVersionsRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _apiVersionRequestEncoder,
                _apiVersionResponseDecoder,
                ApiVersionsError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) ApiVersionsError(ApiVersionsResponseData response)
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<ApiError>.Empty);
            var errors = ImmutableArray.Create(ApiErrors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        public async Task<MetadataResponseData> Metadata(
            CancellationToken cancellationToken
        ) =>
            await Metadata(
                CLUSTER_METADATA_REQUEST,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async Task<MetadataResponseData> INodeLink.Metadata(
            MetadataRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Metadata(
                request,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async Task<MetadataResponseData> Metadata(
            MetadataRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _metadataRequestEncoder,
                _metadataResponseDecoder,
                MetadataError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) MetadataError(MetadataResponseData response)
        {
            var errors = response
                .TopicsField
                .Where(t => t.ErrorCodeField != 0)
                .Select(t => ApiErrors.Translate(t.ErrorCodeField))
                .Concat(response
                    .TopicsField
                    .SelectMany(t => t.PartitionsField
                        .Where(p => p.ErrorCodeField != 0)
                        .Select(p => ApiErrors.Translate(p.ErrorCodeField))
                    )
                )
                .ToImmutableArray()
            ;

            if (errors.Length == 0)
                return (false, errors);
            if (errors.Any(r => r.Code == ApiError.UnknownTopicOrPartition.Code))
                return (false, errors);
            return (IsTransient(errors), errors);
        }

        async Task<CreateTopicsResponseData> INodeLink.CreateTopics(
            CreateTopicsRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _createTopicsRequestEncoder,
                _createTopicsResponseDecoder,
                CreateTopicsError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) CreateTopicsError(
            CreateTopicsResponseData response
        )
        {
            var errors = response
                .TopicsField
                .Where(r => r.ErrorCodeField != 0)
                .Select(r => ApiErrors.Translate(r.ErrorCodeField))
                .ToImmutableArray()
            ;
            return (IsTransient(errors), errors);
        }

        async Task<DeleteTopicsResponseData> INodeLink.DeleteTopics(
            DeleteTopicsRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _deleteTopicsRequestEncoder,
                _deleteTopicsResponseDecoder,
                DeleteTopicsError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) DeleteTopicsError(
            DeleteTopicsResponseData response
        )
        {
            var errors = response.ResponsesField
                .Where(r => r.ErrorCodeField != 0)
                .Select(r => ApiErrors.Translate(r.ErrorCodeField))
                .ToImmutableArray()
            ;
            if (errors.Length > 0 && errors.Any(r => r.Code == ApiError.UnknownTopicOrPartition.Code))
                return (false, errors);
            return (IsTransient(errors), errors);
        }

        async Task<FindCoordinatorResponseData> INodeLink.FindCoordinator(
            FindCoordinatorRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _findCoordinatorRequestEncoder,
                _findCoordinatorResponseDecoder,
                FindCoordinatorError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) FindCoordinatorError(FindCoordinatorResponseData response)
        {
            var errors = response.ErrorCodeField switch
            {
                0 => response
                        .CoordinatorsField
                        .Where(r => r.ErrorCodeField != 0)
                        .Select(r => ApiErrors.Translate(r.ErrorCodeField))
                        .ToImmutableArray(),
                _ => [ApiErrors.Translate(response.ErrorCodeField)]
            };
            return (IsTransient(errors), errors);
        }

        async Task<OffsetFetchResponseData> INodeLink.OffsetFetch(
            OffsetFetchRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _offsetFetchRequestEncoder,
                _offsetFetchResponseDecoder,
                OffsetFetchError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) OffsetFetchError(
            OffsetFetchResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<ApiError>.Empty);
            var errors = ImmutableArray.Create(ApiErrors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async Task<ListOffsetsResponseData> INodeLink.ListOffsets(
            ListOffsetsRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _listOffsetsRequestEncoder,
                _listOffsetsResponseDecoder,
                ListOffsetsError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) ListOffsetsError(
            ListOffsetsResponseData response
        )
        {
            var errors = response
                .TopicsField
                .SelectMany(t => t.PartitionsField
                    .Where(p => p.ErrorCodeField != 0)
                    .Select(p => ApiErrors.Translate(p.ErrorCodeField))
                )
                .ToImmutableArray()
            ;
            return (IsTransient(errors), errors);
        }

        async Task<InitProducerIdResponseData> INodeLink.InitProducerId(
            InitProducerIdRequestData request,
            CancellationToken cancellationToken
        ) => await Execute(
                request,
                _initProducerIdRequestEncoder,
                _initProducerIdResponseDecoder,
                InitProducerIdError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) InitProducerIdError(InitProducerIdResponseData response)
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<ApiError>.Empty);
            var errors = ImmutableArray.Create(ApiErrors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async Task<ProduceResponseData> INodeLink.Produce(
            ProduceRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _produceRequestEncoder,
                _produceResponseDecoder,
                ProduceError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) ProduceError(ProduceResponseData response)
        {
            var errors = response
                .ResponsesField
                .SelectMany(t => t.PartitionResponsesField
                    .Where(r => r.ErrorCodeField != 0)
                    .Select(r => ApiErrors.Translate(r.ErrorCodeField))
                )
                .ToImmutableArray()
            ;
            return (IsTransient(errors), errors);
        }

        async Task INodeLink.ProduceNoAck(
            ProduceRequestData request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteOneWay(
                request,
                _produceRequestEncoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async Task<AddPartitionsToTxnResponseData> INodeLink.AddPartitionsToTxn(
            AddPartitionsToTxnRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _addPartitionsToTxnRequestEncoder,
                _addPartitionsToTxnResponseDecoder,
                AddPartitionsToTxnError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) AddPartitionsToTxnError(
            AddPartitionsToTxnResponseData response
        )
        {
            var errors = response
                .ResultsByTopicV3AndBelowField
                .SelectMany(t => t.ResultsByPartitionField
                    .Where(p => p.PartitionErrorCodeField != 0)
                    .Select(p => ApiErrors.Translate(p.PartitionErrorCodeField))
                )
                .ToImmutableArray()
            ;
            return (IsTransient(errors), errors);
        }

        async Task<EndTxnResponseData> INodeLink.EndTxn(
            EndTxnRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _endTxnRequestEncoder,
                _endTxnResponseDecoder,
                EndTxnError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) EndTxnError(
            EndTxnResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<ApiError>.Empty);
            var errors = ImmutableArray.Create(ApiErrors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async Task<HeartbeatResponseData> INodeLink.Heartbeat(
            HeartbeatRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _heartbeatRequestEncoder,
                _heartbeatResponseDecoder,
                HeartbeatError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) HeartbeatError(
            HeartbeatResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<ApiError>.Empty);
            var errors = ImmutableArray.Create(ApiErrors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async Task<JoinGroupResponseData> INodeLink.JoinGroup(
            JoinGroupRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _joinGroupRequestEncoder,
                _joinGroupResponseDecoder,
                JoinGroupError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) JoinGroupError(
            JoinGroupResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<ApiError>.Empty);
            var errors = ImmutableArray.Create(ApiErrors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async Task<SyncGroupResponseData> INodeLink.SyncGroup(
            SyncGroupRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _syncGroupRequestEncoder,
                _syncGroupResponseDecoder,
                SyncGroupError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) SyncGroupError(
            SyncGroupResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<ApiError>.Empty);
            var errors = ImmutableArray.Create(ApiErrors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async Task<LeaveGroupResponseData> INodeLink.LeaveGroup(
            LeaveGroupRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _leaveGroupRequestEncoder,
                _leaveGroupResponseDecoder,
                LeaveGroupError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) LeaveGroupError(
            LeaveGroupResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<ApiError>.Empty);
            var errors = ImmutableArray.Create(ApiErrors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        async Task<OffsetCommitResponseData> INodeLink.OffsetCommit(
            OffsetCommitRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _offsetCommitRequestEncoder,
                _offsetCommitResponseDecoder,
                OffsetCommitError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) OffsetCommitError(
            OffsetCommitResponseData response
        )
        {
            var errors = response
                .TopicsField
                .SelectMany(t => t.PartitionsField
                    .Where(p => p.ErrorCodeField != 0)
                    .Select(p => ApiErrors.Translate(p.ErrorCodeField))
                )
                .ToImmutableArray()
            ;
            return (IsTransient(errors), errors);
        }

        async Task<FetchResponseData> INodeLink.Fetch(
            FetchRequestData request,
            CancellationToken cancellationToken
        ) =>
            await Execute(
                request,
                _fetchRequestEncoder,
                _fetchResponseDecoder,
                FetchError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static (bool, ImmutableArray<ApiError>) FetchError(
            FetchResponseData response
        )
        {
            var errors = response.ErrorCodeField switch
            {
                0 => response
                        .ResponsesField
                        .SelectMany(t => t.PartitionsField
                            .Where(p => p.ErrorCodeField != 0)
                            .Select(p => ApiErrors.Translate(p.ErrorCodeField))
                        )
                        .ToImmutableArray(),
                _ => [ApiErrors.Translate(response.ErrorCodeField)]
            };
            return (IsTransient(errors), errors);
        }

        public void Dispose()
        {
            _internalCts.Dispose();
            _sendQueue.Dispose();
            _semaphore.Dispose();
            _transport.Dispose();
            GC.SuppressFinalize(this);
        }

        private async Task<TResponse> Execute<TRequest, TResponse>(
            TRequest requestMessage,
            IRequestEncoder<RequestHeaderData, TRequest> requestEncoder,
            IResponseDecoder<ResponseHeaderData, TResponse> responseDecoder,
            Func<TResponse, (bool, ImmutableArray<ApiError>)> errorDelegate,
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
                var requestHeader = CreateRequestHeader(requestEncoder, []);
                offset = requestEncoder.WriteHeader(requestBytes, offset, requestHeader);
                offset = requestEncoder.WriteMessage(requestBytes, offset, requestMessage);
                var taskCompletionSource = new TaskCompletionSource<byte[]>(
                    TaskCreationOptions.RunContinuationsAsynchronously
                );
                var sendThing = new SendThing(
                    requestHeader.CorrelationId,
                    requestBytes.AsMemory(0, offset),
                    false,
                    taskCompletionSource
                );
                _sendQueue.Add(sendThing, cancellationToken);
                var responseBytes = await taskCompletionSource
                    .Task
                    .WaitAsync(cancellationToken)
                    .ConfigureAwait(false)
                ;
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

        private async Task ExecuteOneWay(
            ProduceRequestData requestMessage,
            ProduceRequestEncoder requestEncoder,
            CancellationToken cancellationToken
        )
        {
            var tries = 0;
            var requestBytes = new byte[1024 * 1024];
            while (true)
            {
                await EnsureConnection(cancellationToken).ConfigureAwait(false);
                var offset = 0;
                var requestHeader = CreateRequestHeader(requestEncoder, []);
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
                _ = await taskCompletionSource
                    .Task
                    .WaitAsync(cancellationToken)
                    .ConfigureAwait(false)
                ;
                if (tries++ <= _retries)
                    cancellationToken.WaitHandle.WaitOne(_retryBackOffMs);
                else
                    return;
            }
        }

        private async Task ApiKeyBootstrap(
            CancellationToken cancellationToken
        )
        {
            _apiVersionRequestEncoder.SetApiVersion(0);
            _apiVersionResponseDecoder.SetApiVersion(0);
            var tries = 0;
            var requestBytes = new byte[1024 * 1024];
            while (true)
            {
                var offset = 0;
                var requestHeader = CreateRequestHeader(_apiVersionRequestEncoder, []);
                offset = _apiVersionRequestEncoder.WriteHeader(requestBytes, offset, requestHeader);
                offset = _apiVersionRequestEncoder.WriteMessage(requestBytes, offset, API_VERSION_REQUEST);

                await _transport.Send(requestBytes.AsMemory(0, offset), cancellationToken).ConfigureAwait(false);
                var responseBytes = await _transport.Receive(cancellationToken).ConfigureAwait(false);

                (offset, var _) = _apiVersionResponseDecoder.ReadHeader(responseBytes, 0);
                (_, var apiVersionsResponse) = _apiVersionResponseDecoder.ReadMessage(responseBytes, offset);

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

        private async Task SaslHandshake(
            CancellationToken cancellationToken
        )
        {
            var saslHandshakeRequest = new SaslHandshakeRequestData(
                GetEnumAttributeValue(_saslMechanism),
                []
            );

            var tries = 0;
            var requestBytes = new byte[1024 * 1024];
            while (true)
            {
                var offset = 0;
                var requestHeader = CreateRequestHeader(_saslHandshakeRequestEncoder, []);
                offset = _saslHandshakeRequestEncoder.WriteHeader(requestBytes, offset, requestHeader);
                offset = _saslHandshakeRequestEncoder.WriteMessage(requestBytes, offset, saslHandshakeRequest);

                await _transport.Send(requestBytes.AsMemory(0, offset), cancellationToken).ConfigureAwait(false);
                var responseBytes = await _transport.Receive(cancellationToken).ConfigureAwait(false);

                (offset, var _) = _saslHandshakeResponseDecoder.ReadHeader(responseBytes, 0);
                (_, var saslHandshakeResponse) = _saslHandshakeResponseDecoder.ReadMessage(responseBytes, offset);

                var (_, errors) = SaslHandshakeError(saslHandshakeResponse);
                if (errors.Length == 0)
                    return;
                LogError(_logger, requestHeader, errors);
                if (tries++ <= _retries && IsTransient(errors))
                    cancellationToken.WaitHandle.WaitOne(_retryBackOffMs);
                else
                    ApiExceptions(errors);
            }
        }

        private static (bool, ImmutableArray<ApiError>) SaslHandshakeError(SaslHandshakeResponseData response)
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<ApiError>.Empty);
            var errors = ImmutableArray.Create(ApiErrors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        private async Task SaslAuthenticate(
            CancellationToken cancellationToken
        )
        {
            var bytes = new byte[_saslUsername.Length + _saslPassword.Length + 2];
            Array.Copy(System.Text.Encoding.UTF8.GetBytes(_saslUsername),0 , bytes, 1, _saslUsername.Length);
            Array.Copy(System.Text.Encoding.UTF8.GetBytes(_saslPassword),0, bytes, _saslUsername.Length + 2, _saslPassword.Length);
            var saslAuthenticateRequestData = new SaslAuthenticateRequestData(
                bytes,
                []
            );

            var tries = 0;
            var requestBytes = new byte[1024 * 1024];
            while (true)
            {
                var offset = 0;
                var requestHeader = CreateRequestHeader(_saslAuthenticateRequestEncoder, []);
                offset = _saslAuthenticateRequestEncoder.WriteHeader(requestBytes, offset, requestHeader);
                offset = _saslAuthenticateRequestEncoder.WriteMessage(requestBytes, offset, saslAuthenticateRequestData);

                await _transport.Send(requestBytes.AsMemory(0, offset), cancellationToken).ConfigureAwait(false);
                var responseBytes = await _transport.Receive(cancellationToken).ConfigureAwait(false);

                (offset, var _) = _saslAuthenticateResponseDecoder.ReadHeader(responseBytes, 0);
                (_, var saslHandshakeResponse) = _saslAuthenticateResponseDecoder.ReadMessage(responseBytes, offset);

                var (_, errors) = SaslAuthenticateError(saslHandshakeResponse);
                if (errors.Length == 0)
                    return;
                LogError(_logger, requestHeader, errors);
                if (tries++ <= _retries && IsTransient(errors))
                    cancellationToken.WaitHandle.WaitOne(_retryBackOffMs);
                else
                    ApiExceptions(errors);
            }
        }

        private static (bool, ImmutableArray<ApiError>) SaslAuthenticateError(SaslAuthenticateResponseData response)
        {
            if (response.ErrorCodeField == 0)
                return (false, ImmutableArray<ApiError>.Empty);
            var errors = ImmutableArray.Create(ApiErrors.Translate(response.ErrorCodeField));
            return (IsTransient(errors), errors);
        }

        private static string GetEnumAttributeValue<TEnum>(TEnum value)
            where TEnum : Enum
        {
            var enumType = typeof(TEnum);
            var stringValue = value.ToString();
            var memberInfos = enumType.GetMember(stringValue);
            var enumValueMemberInfo = memberInfos
                .FirstOrDefault(m =>
                    m.DeclaringType == enumType
                )
            ;
            if (enumValueMemberInfo == null)
                return "";

            var valueAttributes = enumValueMemberInfo
                .GetCustomAttributes(
                    typeof(EnumMemberAttribute),
                    false
                )
            ;

            if (valueAttributes == null || valueAttributes.Length != 1)
                return "";
            else
                return((EnumMemberAttribute)valueAttributes[0]).Value ?? "";
        }

        private async Task MetadataBootstrap(
            CancellationToken cancellationToken
        )
        {
            var tries = 0;
            var requestBytes = new byte[1024 * 1024];
            while (true)
            {
                var offset = 0;
                var requestHeader = CreateRequestHeader(_metadataRequestEncoder, []);
                offset = _metadataRequestEncoder.WriteHeader(requestBytes, offset, requestHeader);
                offset = _metadataRequestEncoder.WriteMessage(requestBytes, offset, CLUSTER_METADATA_REQUEST);

                await _transport.Send(requestBytes.AsMemory(0, offset), cancellationToken).ConfigureAwait(false);
                var responseBytes = await _transport.Receive(cancellationToken).ConfigureAwait(false);

                (offset, var _) = _metadataResponseDecoder.ReadHeader(responseBytes, 0);
                (_, var metadataResponse) = _metadataResponseDecoder.ReadMessage(responseBytes, offset);

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

        private static void ApiExceptions(ImmutableArray<ApiError> errors) =>
            throw new AggregateException(
                errors.Select(e => new ApiException(e))
            )
        ;

        private async Task OpenTransport(
            CancellationToken cancellationToken
        )
        {
            int retires = 0;
            while (!_transport.IsConnected)
            {
                try
                {
                    await _transport.Open(cancellationToken).ConfigureAwait(false);
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

        private async Task EnsureConnection(CancellationToken cancellationToken)
        {
            if (_transport.IsConnected)
                return;
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (_transport.IsConnected)
                    return;
                await NetworkLoopStop(cancellationToken).ConfigureAwait(false);
                await OpenTransport(cancellationToken).ConfigureAwait(false);
                await ApiKeyBootstrap(cancellationToken).ConfigureAwait(false);
                switch(_securityProtocol)
                {
                    case SecurityProtocol.SaslPlaintext:
                        await SaslHandshake(cancellationToken).ConfigureAwait(false);
                        await SaslAuthenticate(cancellationToken).ConfigureAwait(false);
                        break;
                }
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
            await Task.Yield();
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var sendThing = _sendQueue.Take(cancellationToken);
                    await _transport.Send(
                        sendThing.Data,
                        cancellationToken
                    ).ConfigureAwait(false);
                    if (!sendThing.OneWay)
                        _pendingRequests.TryAdd(sendThing.CorrelationId, sendThing.TaskCompletionSource);
                    else
                        sendThing.TaskCompletionSource.SetResult([]);
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
            await Task.Yield();
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var data = await _transport.Receive(cancellationToken).ConfigureAwait(false);
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

        private static void LogError(ILogger logger, RequestHeaderData header, ImmutableArray<ApiError> errors)
        {
            foreach (var error in errors)
                logger.LogApiError(header, error);
        }

        private static bool IsTransient(ImmutableArray<ApiError> errors)
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
                .Where(r => r.HostField == _transport.Host && r.PortField == _transport.Port)
                .Select(r => r.NodeIdField)
                .FirstOrDefault()
            ;
        }

        private void UpdateApiVersions(ApiVersionsResponseData apiVersionsResponse)
        {
            _apiVersions.Clear();
            foreach (var apiKey in apiVersionsResponse.ApiKeysField)
                _apiVersions[(ApiKey)apiKey.ApiKeyField] = apiKey.MaxVersionField;

            SetCodecVersion(_apiVersionRequestEncoder, _apiVersions);
            SetCodecVersion(_apiVersionResponseDecoder, _apiVersions);

            SetCodecVersion(_metadataRequestEncoder, _apiVersions);
            SetCodecVersion(_metadataResponseDecoder, _apiVersions);

            SetCodecVersion(_saslHandshakeRequestEncoder, _apiVersions);
            SetCodecVersion(_saslHandshakeResponseDecoder, _apiVersions);

            SetCodecVersion(_saslAuthenticateRequestEncoder, _apiVersions);
            SetCodecVersion(_saslAuthenticateResponseDecoder, _apiVersions);

            SetCodecVersion(_createTopicsRequestEncoder, _apiVersions);
            SetCodecVersion(_createTopicsResponseDecoder, _apiVersions);

            SetCodecVersion(_deleteTopicsRequestEncoder, _apiVersions);
            SetCodecVersion(_deleteTopicsResponseDecoder, _apiVersions);

            SetCodecVersion(_findCoordinatorRequestEncoder, _apiVersions);
            SetCodecVersion(_findCoordinatorResponseDecoder, _apiVersions);

            SetCodecVersion(_offsetFetchRequestEncoder, _apiVersions);
            SetCodecVersion(_offsetFetchResponseDecoder, _apiVersions);

            SetCodecVersion(_listOffsetsRequestEncoder, _apiVersions);
            SetCodecVersion(_listOffsetsResponseDecoder, _apiVersions);

            SetCodecVersion(_initProducerIdRequestEncoder, _apiVersions);
            SetCodecVersion(_initProducerIdResponseDecoder, _apiVersions);

            SetCodecVersion(_produceRequestEncoder, _apiVersions);
            SetCodecVersion(_produceResponseDecoder, _apiVersions);

            SetCodecVersion(_addPartitionsToTxnRequestEncoder, _apiVersions);
            SetCodecVersion(_addPartitionsToTxnResponseDecoder, _apiVersions);

            SetCodecVersion(_endTxnRequestEncoder, _apiVersions);
            SetCodecVersion(_endTxnResponseDecoder, _apiVersions);

            SetCodecVersion(_heartbeatRequestEncoder, _apiVersions);
            SetCodecVersion(_heartbeatResponseDecoder, _apiVersions);

            SetCodecVersion(_joinGroupRequestEncoder, _apiVersions);
            SetCodecVersion(_joinGroupResponseDecoder, _apiVersions);

            SetCodecVersion(_syncGroupRequestEncoder, _apiVersions);
            SetCodecVersion(_syncGroupResponseDecoder, _apiVersions);

            SetCodecVersion(_leaveGroupRequestEncoder, _apiVersions);
            SetCodecVersion(_leaveGroupResponseDecoder, _apiVersions);

            SetCodecVersion(_offsetCommitRequestEncoder, _apiVersions);
            SetCodecVersion(_offsetCommitResponseDecoder, _apiVersions);

            SetCodecVersion(_fetchRequestEncoder, _apiVersions);
            SetCodecVersion(_fetchResponseDecoder, _apiVersions);
        }

        private async Task NetworkLoopStop(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _internalCts.CancelAsync().ConfigureAwait(false);
            await Task.WhenAll(_senderThread, _receiverThread).ConfigureAwait(false);
            var pendingRequests = _pendingRequests.Select(r => r.Value).ToImmutableArray();
            foreach (var pendingRequest in pendingRequests)
                pendingRequest.SetCanceled(CancellationToken.None);
        }

        private async Task NetworkLoopStart(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _internalCts = new();
            await Task.Yield();
            _senderThread = Task.Run(async () =>
                await SendLoop(_internalCts.Token).ConfigureAwait(false),
                CancellationToken.None
            );
            await Task.Yield();
            _receiverThread = Task.Run(async () =>
                await ReceiveLoop(_internalCts.Token).ConfigureAwait(false),
                CancellationToken.None
            );
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
