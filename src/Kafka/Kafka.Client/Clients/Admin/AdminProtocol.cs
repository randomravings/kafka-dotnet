using Kafka.Client.Clients.Admin.Model;
using Kafka.Client.Messages;
using Kafka.Client.Messages.Serdes;
using Kafka.Client.Protocol;
using Kafka.Common.Model;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin
{
    internal sealed class AdminProtocol :
        ClientProtocol,
        IAdminProtocol
    {
        private IEncoder<RequestHeader, CreateTopicsRequest> _createTopicsRequestEncoder = CreateTopicsRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, CreateTopicsResponse> _createTopicsResponseDecoder = CreateTopicsResponseSerde.CreateDecoder(0);

        private IEncoder<RequestHeader, DeleteTopicsRequest> _deleteTopicsRequestEncoder = DeleteTopicsRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, DeleteTopicsResponse> _deleteTopicsResponseDecoder = DeleteTopicsResponseSerde.CreateDecoder(0);

        public AdminProtocol(
            IConnection connection,
            AdminClientConfig config,
            ILogger logger
        ) : base(connection, config, logger)
        { }

        async ValueTask<CreateTopicsResponse> IAdminProtocol.CreateTopics(
            CreateTopicsRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                CreateTopics,
                CreateTopicsError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<CreateTopicsRequest, CreateTopicsResponse>> CreateTopics(
            CreateTopicsRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _createTopicsRequestEncoder,
                _createTopicsResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> CreateTopicsError(
            CreateTopicsResponse response
        ) =>
            response
                .TopicsField
                .Where(r => r.ErrorCodeField != 0)
                .Select(r => Errors.Translate(r.ErrorCodeField))
                .ToImmutableArray()
        ;

        async ValueTask<DeleteTopicsResponse> IAdminProtocol.DeleteTopics(
            DeleteTopicsRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                DeleteTopics,
                DeleteTopicsError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<DeleteTopicsRequest, DeleteTopicsResponse>> DeleteTopics(
            DeleteTopicsRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _deleteTopicsRequestEncoder,
                _deleteTopicsResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> DeleteTopicsError(
            DeleteTopicsResponse response
        ) =>
            response.ResponsesField
                .Where(r => r.ErrorCodeField != 0)
                .Select(r => Errors.Translate(r.ErrorCodeField))
                .ToImmutableArray()
        ;

        protected override void OnApiVersions(IReadOnlyDictionary<ApiKey, Api> versions)
        {
            var createTopicsMax = versions[ApiKey.CreateTopics].Range.Max;
            _createTopicsRequestEncoder = CreateTopicsRequestSerde.CreateEncoder(createTopicsMax);
            _createTopicsResponseDecoder = CreateTopicsResponseSerde.CreateDecoder(createTopicsMax);

            var deleteTopicsMax = versions[ApiKey.DeleteTopics].Range.Max; 
            _deleteTopicsRequestEncoder = DeleteTopicsRequestSerde.CreateEncoder(deleteTopicsMax);
            _deleteTopicsResponseDecoder = DeleteTopicsResponseSerde.CreateDecoder(deleteTopicsMax);            
        }
    }
}
