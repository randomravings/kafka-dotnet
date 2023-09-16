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
        private readonly IRequestEncoder<RequestHeaderData, CreateTopicsRequestData> _createTopicsRequestHandler = new CreateTopicsRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, CreateTopicsResponseData> _createTopicsResponseHandler = new CreateTopicsResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, DeleteTopicsRequestData> _deleteTopicsRequestHandler = new DeleteTopicsRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, DeleteTopicsResponseData> _deleteTopicsResponseHandler = new DeleteTopicsResponseDecoder();

        public AdminProtocol(
            ITransport connection,
            AdminClientConfig config,
            ILogger logger
        ) : base(connection, config, logger)
        { }

        async ValueTask<CreateTopicsResponseData> IAdminProtocol.CreateTopics(
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

        private static ImmutableArray<Error> CreateTopicsError(
            CreateTopicsResponseData response
        ) =>
            response
                .TopicsField
                .Where(r => r.ErrorCodeField != 0)
                .Select(r => Errors.Translate(r.ErrorCodeField))
                .ToImmutableArray()
        ;

        async ValueTask<DeleteTopicsResponseData> IAdminProtocol.DeleteTopics(
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

        private static ImmutableArray<Error> DeleteTopicsError(
            DeleteTopicsResponseData response
        ) =>
            response.ResponsesField
                .Where(r => r.ErrorCodeField != 0)
                .Select(r => Errors.Translate(r.ErrorCodeField))
                .ToImmutableArray()
        ;

        protected override void UpdateApiVersions(IReadOnlyDictionary<ApiKey, ApiVersion> apiVersions)
        {
            SetCodecVersion(_createTopicsRequestHandler, apiVersions);
            SetCodecVersion(_createTopicsResponseHandler, apiVersions);

            SetCodecVersion(_deleteTopicsRequestHandler, apiVersions);
            SetCodecVersion(_deleteTopicsResponseHandler, apiVersions);
        }
    }
}
