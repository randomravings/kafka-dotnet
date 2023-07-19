using Kafka.Client.Clients.Admin.Model;
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
        private IEncoder<RequestHeader, InitProducerIdRequest> _initProducerIdRequestEncoder = InitProducerIdRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, InitProducerIdResponse> _initProducerIdResponseDecoder = InitProducerIdResponseSerde.CreateDecoder(0);

        private IEncoder<RequestHeader, ProduceRequest> _produceRequestEncoder = ProduceRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, ProduceResponse> _produceResponseDecoder = ProduceResponseSerde.CreateDecoder(0);

        private IEncoder<RequestHeader, AddPartitionsToTxnRequest> _addPartitionsToTxnRequestEncoder = AddPartitionsToTxnRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, AddPartitionsToTxnResponse> _adPartitionsToTxnResponseDecoder = AddPartitionsToTxnResponseSerde.CreateDecoder(0);

        private IEncoder<RequestHeader, EndTxnRequest> _endTxnRequestRequestEncoder = EndTxnRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, EndTxnResponse> _endTxnResponseResponseDecoder = EndTxnResponseSerde.CreateDecoder(0);

        public ProducerProtocol(
            IConnection connection,
            ProducerConfig config,
            ILogger logger
        ) : base(connection, config, logger) { }

        async ValueTask<InitProducerIdResponse> IProducerConnection.InitProducerId(
            InitProducerIdRequest request,
            CancellationToken cancellationToken
        ) => await ExecuteRequest(
                request,
                InitProducerId,
                InitProducerIdError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<InitProducerIdRequest, InitProducerIdResponse>> InitProducerId(
            InitProducerIdRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _initProducerIdRequestEncoder,
                _initProducerIdResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> InitProducerIdError(InitProducerIdResponse response)
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<ProduceResponse> IProducerConnection.Produce(
            ProduceRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                Produce,
                ProduceError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<ProduceRequest, ProduceResponse>> Produce(
            ProduceRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _produceRequestEncoder,
                _produceResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> ProduceError(ProduceResponse response) =>
            response
                .ResponsesField
                    .SelectMany(t => t.PartitionResponsesField
                        .Where(r => r.ErrorCodeField != 0)
                        .Select(r => Errors.Translate(r.ErrorCodeField))
                    )
                .ToImmutableArray()
        ;

        async ValueTask IProducerConnection.ProduceNoAck(
            ProduceRequest request,
            CancellationToken cancellationToken
        )
        {
            await ExecuteRequestNoAck(
                request,
                ProduceNoAck,
                cancellationToken
            ).ConfigureAwait(false);
        }

        private async ValueTask ProduceNoAck(
            ProduceRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequestNoAck(
                request,
                _produceRequestEncoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        async ValueTask<AddPartitionsToTxnResponse> IProducerConnection.AddPartitionsToTxn(
            AddPartitionsToTxnRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                AddPartitionsToTxn,
                AddPartitionsToTxnError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<AddPartitionsToTxnRequest, AddPartitionsToTxnResponse>> AddPartitionsToTxn(
            AddPartitionsToTxnRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _addPartitionsToTxnRequestEncoder,
                _adPartitionsToTxnResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> AddPartitionsToTxnError(AddPartitionsToTxnResponse response) =>
            response
                .ResultsField
                .SelectMany(t => t.ResultsField
                    .Where(p => p.ErrorCodeField != 0)
                    .Select(p => Errors.Translate(p.ErrorCodeField))
                )
                .ToImmutableArray()
        ;

        async ValueTask<EndTxnResponse> IProducerConnection.EndTxn(
            EndTxnRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                EndTxn,
                EndTxnError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<EndTxnRequest, EndTxnResponse>> EndTxn(
            EndTxnRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _endTxnRequestRequestEncoder,
                _endTxnResponseResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> EndTxnError(EndTxnResponse response) =>
            response.ErrorCodeField switch
            {
                0 => ImmutableArray<Error>.Empty,
                var e => ImmutableArray.Create(Errors.Translate(e))
            }                    
        ;

        protected override void OnApiVersions(IReadOnlyDictionary<ApiKey, Api> versions)
        {
            var initProducerIdMax = versions[ApiKey.InitProducerId].Range.Max;
            _initProducerIdRequestEncoder = InitProducerIdRequestSerde.CreateEncoder(initProducerIdMax);
            _initProducerIdResponseDecoder = InitProducerIdResponseSerde.CreateDecoder(initProducerIdMax);

            var produceMax = versions[ApiKey.Produce].Range.Max;
            _produceRequestEncoder = ProduceRequestSerde.CreateEncoder(produceMax);
            _produceResponseDecoder = ProduceResponseSerde.CreateDecoder(produceMax);

            var addPartitionsToTxnMax = versions[ApiKey.AddPartitionsToTxn].Range.Max;
            _addPartitionsToTxnRequestEncoder = AddPartitionsToTxnRequestSerde.CreateEncoder(addPartitionsToTxnMax);
            _adPartitionsToTxnResponseDecoder = AddPartitionsToTxnResponseSerde.CreateDecoder(addPartitionsToTxnMax);

            var endTxnMax = versions[ApiKey.EndTxn].Range.Max;
            _endTxnRequestRequestEncoder = EndTxnRequestSerde.CreateEncoder(endTxnMax);
            _endTxnResponseResponseDecoder = EndTxnResponseSerde.CreateDecoder(endTxnMax);
        }
    }
}
