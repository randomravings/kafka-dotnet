using Kafka.Client.Messages;
using Kafka.Client.Messages.Serdes;
using Kafka.Client.Protocol;
using Kafka.Common.Model;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using ApiVersion = Kafka.Common.Model.ApiVersion;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class ConsumerProtocol :
        ClientProtocol,
        IConsumerProtocol
    {
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
        
        public ConsumerProtocol(
            ITransport connection,
            ConsumerConfig config,
            ILogger logger
        ) : base(connection, config, logger) { }

        async ValueTask<HeartbeatResponseData> IConsumerProtocol.Heartbeat(
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

        private static ImmutableArray<Error> HeartbeatError(
            HeartbeatResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<JoinGroupResponseData> IConsumerProtocol.JoinGroup(
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

        private static ImmutableArray<Error> JoinGroupError(
            JoinGroupResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<SyncGroupResponseData> IConsumerProtocol.SyncGroup(
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

        private static ImmutableArray<Error> SyncGroupError(
            SyncGroupResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<LeaveGroupResponseData> IConsumerProtocol.LeaveGroup(
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

        private static ImmutableArray<Error> LeaveGroupError(
            LeaveGroupResponseData response
        )
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<OffsetCommitResponseData> IConsumerProtocol.OffsetCommit(
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

        private static ImmutableArray<Error> OffsetCommitError(
            OffsetCommitResponseData response
        ) =>
            response
                .TopicsField
                .SelectMany(t => t.PartitionsField
                    .Where(p => p.ErrorCodeField != 0)
                    .Select(p => Errors.Translate(p.ErrorCodeField))
                )
                .ToImmutableArray()
        ;

        async ValueTask<FetchResponseData> IConsumerProtocol.Fetch(
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

        private static ImmutableArray<Error> FetchError(
            FetchResponseData response
        )
        {
            if (response.ErrorCodeField != 0)
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
            return response
                .ResponsesField
                .SelectMany(t => t.PartitionsField
                    .Where(p => p.ErrorCodeField != 0)
                    .Select(p => Errors.Translate(p.ErrorCodeField))
                )
                .ToImmutableArray();
        }

        protected override void UpdateApiVersions(IReadOnlyDictionary<ApiKey, ApiVersion> apiVersions)
        {
            SetCodecVersion(_heartbeatRequestHandler, apiVersions);
            SetCodecVersion(_heartbeatResponseHandler, apiVersions);

            SetCodecVersion(_joinGroupRequestHandler, apiVersions);
            SetCodecVersion(_joinGroupResponseHandler, apiVersions);

            SetCodecVersion(_syncGroupRequestHandler, apiVersions);
            SetCodecVersion(_syncGroupResponseHandler, apiVersions);

            SetCodecVersion(_leaveGroupRequestHandler, apiVersions);
            SetCodecVersion(_leaveGroupResponseHandler, apiVersions);

            SetCodecVersion(_offsetCommitRequestHandler, apiVersions);
            SetCodecVersion(_offsetCommitResponseHandler, apiVersions);

            SetCodecVersion(_fetchRequestHandler, apiVersions);
            SetCodecVersion(_fetchResponseHandler, apiVersions);
        }
    }
}
