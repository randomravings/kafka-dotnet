using Kafka.Client.Messages;
using Kafka.Client.Messages.Serdes;
using Kafka.Client.Protocol;
using Kafka.Common.Model;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    internal sealed class ProducerProtocol :
        ClientProtocol,
        IProducerConnection
    {
        private readonly IRequestEncoder<RequestHeaderData, InitProducerIdRequestData> _initProducerIdRequestHandler = new InitProducerIdRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, InitProducerIdResponseData> _initProducerIdResponseHandler = new InitProducerIdResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, ProduceRequestData> _produceRequestHandler = new ProduceRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, ProduceResponseData> _produceResponseHandler = new ProduceResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, AddPartitionsToTxnRequestData> _addPartitionsToTxnRequestHandler = new AddPartitionsToTxnRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, AddPartitionsToTxnResponseData> _addPartitionsToTxnResponseHandler = new AddPartitionsToTxnResponseDecoder();

        private readonly IRequestEncoder<RequestHeaderData, EndTxnRequestData> _endTxnRequestHandler = new EndTxnRequestEncoder();
        private readonly IResponseDecoder<ResponseHeaderData, EndTxnResponseData> _endTxnResponseHandler = new EndTxnResponseDecoder();

        public ProducerProtocol(
            ITransport connection,
            ProducerConfig config,
            ILogger logger
        ) : base(connection, config, logger) { }

        async ValueTask<InitProducerIdResponseData> IProducerConnection.InitProducerId(
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

        private static ImmutableArray<Error> InitProducerIdError(InitProducerIdResponseData response)
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<ProduceResponseData> IProducerConnection.Produce(
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

        private static ImmutableArray<Error> ProduceError(ProduceResponseData response) =>
            response
                .ResponsesField
                    .SelectMany(t => t.PartitionResponsesField
                        .Where(r => r.ErrorCodeField != 0)
                        .Select(r => Errors.Translate(r.ErrorCodeField))
                    )
                .ToImmutableArray()
        ;

        async ValueTask IProducerConnection.ProduceNoAck(
            ProduceRequestData request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteOneWay(
                request,
                _produceRequestHandler,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<AddPartitionsToTxnResponseData> IProducerConnection.AddPartitionsToTxn(
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

        private static ImmutableArray<Error> AddPartitionsToTxnError(AddPartitionsToTxnResponseData response) =>
            response
                .ResultsByTopicV3AndBelowField
                .SelectMany(t => t.ResultsByPartitionField
                    .Where(p => p.PartitionErrorCodeField != 0)
                    .Select(p => Errors.Translate(p.PartitionErrorCodeField))
                )
                .ToImmutableArray()
        ;

        async ValueTask<EndTxnResponseData> IProducerConnection.EndTxn(
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

        private static ImmutableArray<Error> EndTxnError(EndTxnResponseData response) =>
            response.ErrorCodeField switch
            {
                0 => ImmutableArray<Error>.Empty,
                var e => ImmutableArray.Create(Errors.Translate(e))
            }
        ;

        protected override void UpdateApiVersions(IReadOnlyDictionary<ApiKey, ApiVersion> apiVersions)
        {
            SetCodecVersion(_initProducerIdRequestHandler, apiVersions);
            SetCodecVersion(_initProducerIdResponseHandler, apiVersions);

            SetCodecVersion(_produceRequestHandler, apiVersions);
            SetCodecVersion(_produceResponseHandler, apiVersions);

            SetCodecVersion(_addPartitionsToTxnRequestHandler, apiVersions);
            SetCodecVersion(_addPartitionsToTxnResponseHandler, apiVersions);

            SetCodecVersion(_endTxnRequestHandler, apiVersions);
            SetCodecVersion(_endTxnResponseHandler, apiVersions);


        }
    }
}
