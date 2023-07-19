using Kafka.Client.Clients;
using Kafka.Client.Clients.Admin.Model;
using Kafka.Client.Clients.Producer.Logging;
using Kafka.Client.Exceptions;
using Kafka.Client.Messages;
using Kafka.Client.Messages.Serdes;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Protocol
{
    internal abstract class ClientProtocol :
        IClientProtocol
    {
        private const string CLIENT_NAME = "kafka-dotnet";
        private const string CLIENT_VERSION = "0.1.0";

        private static readonly ApiVersionsRequest API_VERSION_REQUEST = new(
            CLIENT_NAME,
            CLIENT_VERSION,
            ImmutableArray<TaggedField>.Empty
        );

        private static readonly MetadataRequest CLUSTER_METADATA_REQUEST = new(
            ImmutableArray<MetadataRequest.MetadataRequestTopic>.Empty,
            false,
            false,
            false,
            ImmutableArray<TaggedField>.Empty
        );

        private readonly string _clientId;
        private readonly int _retries;
        private readonly TimeSpan _retryBackOffMs;
        private readonly ILogger _logger;
        private readonly IConnection _connection;
        private readonly SortedList<ApiKey, Api> _apiVersions = new(ApiKeyCompare.Instance);
        private int _coorelationIds;
        private ClusterNodeId _nodeId = 0;

        private IEncoder<RequestHeader, ApiVersionsRequest> _apiVersionRequestEncoder = ApiVersionsRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, ApiVersionsResponse> _apiVersionResponseDecoder = ApiVersionsResponseSerde.CreateDecoder(0);

        private IEncoder<RequestHeader, MetadataRequest> _metadataRequestEncoder = MetadataRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, MetadataResponse> _metadataResponseDecoder = MetadataResponseSerde.CreateDecoder(0);

        private IEncoder<RequestHeader, FindCoordinatorRequest> _findCoordinatorRequestEncoder = FindCoordinatorRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, FindCoordinatorResponse> _findCoordinatorResponseDecoder = FindCoordinatorResponseSerde.CreateDecoder(0);

        private IEncoder<RequestHeader, OffsetFetchRequest> _offsetFetchRequestEncoder = OffsetFetchRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, OffsetFetchResponse> _offsetFetchResponseDecoder = OffsetFetchResponseSerde.CreateDecoder(0);

        private IEncoder<RequestHeader, ListOffsetsRequest> _listOffsetsRequestEncoder = ListOffsetsRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, ListOffsetsResponse> _listOffsetsResponseDecoder = ListOffsetsResponseSerde.CreateDecoder(0);

        protected ClientProtocol(
            IConnection connection,
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

        IConnection IProtocol.Connection => _connection;

        ClusterNodeId IClientProtocol.NodeId => _nodeId;

        async ValueTask<ApiVersionsResponse> IClientProtocol.ApiVersions(
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                API_VERSION_REQUEST,
                ApiVersions,
                ApiVersionsError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<ApiVersionsRequest, ApiVersionsResponse>> ApiVersions(
            ApiVersionsRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _apiVersionRequestEncoder,
                _apiVersionResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> ApiVersionsError(ApiVersionsResponse response)
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<MetadataResponse> IClientProtocol.Metadata(
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                CLUSTER_METADATA_REQUEST,
                Metadata,
                MetadataError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<MetadataResponse> IClientProtocol.Metadata(
            MetadataRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                Metadata,
                MetadataError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<MetadataRequest, MetadataResponse>> Metadata(
            MetadataRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _metadataRequestEncoder,
                _metadataResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> MetadataError(MetadataResponse response) =>
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

        async ValueTask<FindCoordinatorResponse> IClientProtocol.FindCoordinator(
            FindCoordinatorRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                FindCoordinator,
                FindCoordinatorError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<FindCoordinatorRequest, FindCoordinatorResponse>> FindCoordinator(
            FindCoordinatorRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _findCoordinatorRequestEncoder,
                _findCoordinatorResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> FindCoordinatorError(FindCoordinatorResponse response)
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

        async ValueTask<OffsetFetchResponse> IClientProtocol.OffsetFetch(
            OffsetFetchRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                OffsetFetch,
                OffsetFetchError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<OffsetFetchRequest, OffsetFetchResponse>> OffsetFetch(
            OffsetFetchRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _offsetFetchRequestEncoder,
                _offsetFetchResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> OffsetFetchError(
            OffsetFetchResponse response
        )
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<ListOffsetsResponse> IClientProtocol.ListOffsets(
            ListOffsetsRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                ListOffsets,
                ListOffsetsError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<ListOffsetsRequest, ListOffsetsResponse>> ListOffsets(
            ListOffsetsRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _listOffsetsRequestEncoder,
                _listOffsetsResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> ListOffsetsError(
            ListOffsetsResponse response
        ) =>
            response
                .TopicsField
                .SelectMany(t => t.PartitionsField
                    .Where(p => p.ErrorCodeField != 0)
                    .Select(p => Errors.Translate(p.ErrorCodeField))
                )
                .ToImmutableArray()
        ;

        protected async ValueTask<TResponse> ExecuteRequest<TRequest, TResponse>(
            TRequest request,
            Func<TRequest, CancellationToken, ValueTask<SendRequestResult<TRequest, TResponse>>> requestDelegate,
            Func<TResponse, ImmutableArray<Error>> errorDelegate,
            CancellationToken cancellationToken
        )
            where TRequest : notnull, IRequest
            where TResponse : notnull, IResponse
        {
            var tries = 0;
            await EnsureConnection(
                cancellationToken
            ).ConfigureAwait(false);
            (var requestHeader, _, _, var response) = await requestDelegate(
                request,
                cancellationToken
            ).ConfigureAwait(false);
            var errors = errorDelegate(response);
            if (errors.Length == 0)
                return response;

            while (errors.Length > 0 && tries < _retries)
            {
                LogError(_logger, requestHeader, errors);
                if (IsTransient(errors))
                    cancellationToken.WaitHandle.WaitOne(_retryBackOffMs);
                else
                    break;
                tries++;
                await EnsureConnection(
                    cancellationToken
                ).ConfigureAwait(false);
                (requestHeader, _, _, response) = await requestDelegate(
                    request,
                    cancellationToken
                ).ConfigureAwait(false);
                errors = errorDelegate(response);
            }
            return response;
        }

        protected async ValueTask ExecuteRequestNoAck<TRequest>(
            TRequest request,
            Func<TRequest, CancellationToken, ValueTask> requestDelegate,
            CancellationToken cancellationToken
        )
            where TRequest : notnull
        {
            await EnsureConnection(
                cancellationToken
            ).ConfigureAwait(false);
            await requestDelegate(
                request,
                cancellationToken
            ).ConfigureAwait(false);
        }

        private async ValueTask EnsureConnection(
            CancellationToken cancellationToken
        )
        {
            if (_connection.IsConnected)
                return;

            while (!_connection.IsConnected)
            {
                try
                {
                    await _connection.Open(cancellationToken).ConfigureAwait(false);
                }
                catch (OpenConnectionException ex)
                {
                    ProducerLog.ConnectError(_logger, ex);
                    await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken).ConfigureAwait(false);
                }
            }

            (_, _, _, var apiVersionsResponse) = await ApiVersions(
                API_VERSION_REQUEST,
                cancellationToken
            ).ConfigureAwait(false);

            UpdateApiVersions(apiVersionsResponse);

            (_, _, _, var metadataResponse) = await Metadata(
                CLUSTER_METADATA_REQUEST,
                cancellationToken
            ).ConfigureAwait(false);

            _nodeId = metadataResponse
                .BrokersField.Where(r => r.HostField == _connection.Host && r.PortField == _connection.Port)
                .Select(r => r.NodeIdField)
                .FirstOrDefault()
            ;
        }

        private static void LogError(ILogger logger, RequestHeader header, ImmutableArray<Error> errors)
        {
            foreach (var error in errors)
                if (error.Retriable)
                    ProducerLog.LogErrorAsWaring(logger, header, error);
                else
                    ProducerLog.LogApiError(logger, header, error);
        }

        private static bool IsTransient(ImmutableArray<Error> errors)
        {
            foreach (var error in errors)
                if (!error.Retriable)
                    return false;
            return true;
        }

        protected async ValueTask<SendRequestResult<TRequest, TResponse>> SendRequest<TRequest, TResponse>(
            TRequest request,
            IEncoder<RequestHeader, TRequest> requestEncoder,
            IDecoder<ResponseHeader, TResponse> responseDecoder,
            CancellationToken cancellationToken
        )
            where TRequest : notnull
            where TResponse : notnull
        {
            var offset = 0;
            var requestBytes = new byte[1024 * 1024];
            var requestHeader = CreateRequestHeader(requestEncoder.ApiKey, requestEncoder.ApiVersion);
            offset = requestEncoder.WriteHeader(requestBytes, offset, requestHeader);
            offset = requestEncoder.WritePayload(requestBytes, offset, request);
            await _connection.Send(requestBytes, 0, offset, cancellationToken).ConfigureAwait(false);

            var responseBytes = await _connection.Receive(cancellationToken).ConfigureAwait(false);
            if (responseBytes.Length == 0)
                throw new EndOfStreamException("No bytes received from server");

            offset = 0;
            (offset, var responeHeader) = responseDecoder.ReadHeader(responseBytes, offset);
            if (responeHeader.CorrelationIdField != requestHeader.CorrelationIdField)
                throw new CorrelationIdException(requestHeader.CorrelationIdField, responeHeader.CorrelationIdField);
            (_, var response) = responseDecoder.ReadPayload(responseBytes, offset);
            return new SendRequestResult<TRequest, TResponse>
            {
                RequestHeader = requestHeader,
                ResponseHeader = responeHeader,
                Request = request,
                Response = response
            };
        }

        protected async ValueTask SendRequestNoAck<TRequest>(
            TRequest request,
            IEncoder<RequestHeader, TRequest> requestEncoder,
            CancellationToken cancellationToken
        )
            where TRequest : notnull
        {
            var offset = 0;
            var requestBytes = new byte[1024 * 1024];
            var requestHeader = CreateRequestHeader(requestEncoder.ApiKey, requestEncoder.ApiVersion);
            offset = requestEncoder.WriteHeader(requestBytes, offset, requestHeader);
            offset = requestEncoder.WritePayload(requestBytes, offset, request);
            await _connection.Send(requestBytes, 0, offset, cancellationToken).ConfigureAwait(false);
        }

        protected RequestHeader CreateRequestHeader(
            ApiKey apiKey,
            Common.Model.Version version
        )
        {
            var correlationId = Interlocked.Increment(ref _coorelationIds);
            return new RequestHeader(
                apiKey,
                version,
                correlationId,
                _clientId,
                ImmutableArray<TaggedField>.Empty
            );
        }

        private void UpdateApiVersions(ApiVersionsResponse apiVersionsResponse)
        {
            _apiVersions.Clear();
            foreach (var apiKey in apiVersionsResponse.ApiKeysField)
                _apiVersions.Add(apiKey.ApiKeyField, new Api(apiKey.ApiKeyField, new(apiKey.MinVersionField, apiKey.MaxVersionField)));

            var apiVersionMax = _apiVersions[ApiKey.ApiVersions].Range.Max;
            _apiVersionRequestEncoder = ApiVersionsRequestSerde.CreateEncoder(apiVersionMax);
            _apiVersionResponseDecoder = ApiVersionsResponseSerde.CreateDecoder(apiVersionMax);

            var metadataMax = _apiVersions[ApiKey.Metadata].Range.Max;
            _metadataRequestEncoder = MetadataRequestSerde.CreateEncoder(metadataMax);
            _metadataResponseDecoder = MetadataResponseSerde.CreateDecoder(metadataMax);

            var findCoordinatorMax = _apiVersions[ApiKey.FindCoordinator].Range.Max;
            _findCoordinatorRequestEncoder = FindCoordinatorRequestSerde.CreateEncoder(findCoordinatorMax);
            _findCoordinatorResponseDecoder = FindCoordinatorResponseSerde.CreateDecoder(findCoordinatorMax);

            var offsetFetchMax = _apiVersions[ApiKey.OffsetFetch].Range.Max;
            _offsetFetchRequestEncoder = OffsetFetchRequestSerde.CreateEncoder(offsetFetchMax);
            _offsetFetchResponseDecoder = OffsetFetchResponseSerde.CreateDecoder(offsetFetchMax);

            var listOffsetsMax = _apiVersions[ApiKey.ListOffsets].Range.Max;
            _listOffsetsRequestEncoder = ListOffsetsRequestSerde.CreateEncoder(listOffsetsMax);
            _listOffsetsResponseDecoder = ListOffsetsResponseSerde.CreateDecoder(listOffsetsMax);

            OnApiVersions(_apiVersions);
        }

        protected abstract void OnApiVersions(IReadOnlyDictionary<ApiKey, Api> versions);

        async ValueTask IProtocol.Close(CancellationToken cancellationToken) =>
            await _connection.Close(cancellationToken).ConfigureAwait(false)
        ;
    }
}
