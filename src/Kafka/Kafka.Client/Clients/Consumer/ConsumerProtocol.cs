using Kafka.Client.Clients.Admin.Model;
using Kafka.Client.Messages;
using Kafka.Client.Messages.Serdes;
using Kafka.Client.Protocol;
using Kafka.Common.Model;
using Kafka.Common.Network;
using Kafka.Common.Protocol;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class ConsumerProtocol :
        ClientProtocol,
        IConsumerProtocol
    {
        private IEncoder<RequestHeader, HeartbeatRequest> _heartbeatRequestEncoder = HeartbeatRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, HeartbeatResponse> _heartbeatResponseDecoder = HeartbeatResponseSerde.CreateDecoder(0);

        private IEncoder<RequestHeader, JoinGroupRequest> _joinGroupRequestEncoder = JoinGroupRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, JoinGroupResponse> _joinGroupResponseDecoder = JoinGroupResponseSerde.CreateDecoder(0);

        private IEncoder<RequestHeader, SyncGroupRequest> _syncGroupRequestEncoder = SyncGroupRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, SyncGroupResponse> _syncGroupResponseDecoder = SyncGroupResponseSerde.CreateDecoder(0);

        private IEncoder<RequestHeader, LeaveGroupRequest> _leaveGroupRequestEncoder = LeaveGroupRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, LeaveGroupResponse> _leaveGroupResponseDecoder = LeaveGroupResponseSerde.CreateDecoder(0);

        private IEncoder<RequestHeader, OffsetCommitRequest> _offsetCommitRequestEncoder = OffsetCommitRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, OffsetCommitResponse> _offsetCommitResponseDecoder = OffsetCommitResponseSerde.CreateDecoder(0);

        private IEncoder<RequestHeader, FetchRequest> _fetchRequestEncoder = FetchRequestSerde.CreateEncoder(0);
        private IDecoder<ResponseHeader, FetchResponse> _fetchResponseDecoder = FetchResponseSerde.CreateDecoder(0);

        public ConsumerProtocol(
            IConnection connection,
            ConsumerConfig config,
            ILogger logger
        ) : base(connection, config, logger) { }

        async ValueTask<HeartbeatResponse> IConsumerProtocol.Heartbeat(
            HeartbeatRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                Heartbeat,
                HeartbeatError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<HeartbeatRequest, HeartbeatResponse>> Heartbeat(
            HeartbeatRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _heartbeatRequestEncoder,
                _heartbeatResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> HeartbeatError(
            HeartbeatResponse response
        )
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<JoinGroupResponse> IConsumerProtocol.JoinGroup(
            JoinGroupRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                JoinGroup,
                JoinGroupError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<JoinGroupRequest, JoinGroupResponse>> JoinGroup(
            JoinGroupRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _joinGroupRequestEncoder,
                _joinGroupResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> JoinGroupError(
            JoinGroupResponse response
        )
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<SyncGroupResponse> IConsumerProtocol.SyncGroup(
            SyncGroupRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                SyncGroup,
                SyncGroupError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<SyncGroupRequest, SyncGroupResponse>> SyncGroup(
            SyncGroupRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _syncGroupRequestEncoder,
                _syncGroupResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> SyncGroupError(
            SyncGroupResponse response
        )
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<LeaveGroupResponse> IConsumerProtocol.LeaveGroup(
            LeaveGroupRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                LeaveGroup,
                LeaveGroupError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<LeaveGroupRequest, LeaveGroupResponse>> LeaveGroup(
            LeaveGroupRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _leaveGroupRequestEncoder,
                _leaveGroupResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> LeaveGroupError(
            LeaveGroupResponse response
        )
        {
            if (response.ErrorCodeField == 0)
                return ImmutableArray<Error>.Empty;
            else
                return ImmutableArray.Create(Errors.Translate(response.ErrorCodeField));
        }

        async ValueTask<OffsetCommitResponse> IConsumerProtocol.OffsetCommit(
            OffsetCommitRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                OffsetCommit,
                OffsetCommitError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<OffsetCommitRequest, OffsetCommitResponse>> OffsetCommit(
            OffsetCommitRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _offsetCommitRequestEncoder,
                _offsetCommitResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> OffsetCommitError(
            OffsetCommitResponse response
        ) =>
            response
                .TopicsField
                .SelectMany(t => t.PartitionsField
                    .Where(p => p.ErrorCodeField != 0)
                    .Select(p => Errors.Translate(p.ErrorCodeField))
                )
                .ToImmutableArray()
        ;

        async ValueTask<FetchResponse> IConsumerProtocol.Fetch(
            FetchRequest request,
            CancellationToken cancellationToken
        ) =>
            await ExecuteRequest(
                request,
                Fetch,
                FetchError,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private async ValueTask<SendRequestResult<FetchRequest, FetchResponse>> Fetch(
            FetchRequest request,
            CancellationToken cancellationToken
        ) =>
            await SendRequest(
                request,
                _fetchRequestEncoder,
                _fetchResponseDecoder,
                cancellationToken
            ).ConfigureAwait(false)
        ;

        private static ImmutableArray<Error> FetchError(
            FetchResponse response
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

        protected override void OnApiVersions(IReadOnlyDictionary<ApiKey, Api> versions)
        {
            var heartbeatMax = versions[ApiKey.Heartbeat].Range.Max;
            _heartbeatRequestEncoder = HeartbeatRequestSerde.CreateEncoder(heartbeatMax);
            _heartbeatResponseDecoder = HeartbeatResponseSerde.CreateDecoder(heartbeatMax);

            var joinGroupMax = versions[ApiKey.JoinGroup].Range.Max;
            _joinGroupRequestEncoder = JoinGroupRequestSerde.CreateEncoder(joinGroupMax);
            _joinGroupResponseDecoder = JoinGroupResponseSerde.CreateDecoder(joinGroupMax);

            var syncGroupMax = versions[ApiKey.SyncGroup].Range.Max;
            _syncGroupRequestEncoder = SyncGroupRequestSerde.CreateEncoder(syncGroupMax);
            _syncGroupResponseDecoder = SyncGroupResponseSerde.CreateDecoder(syncGroupMax);

            var leaveGroupMax = versions[ApiKey.LeaveGroup].Range.Max;
            _leaveGroupRequestEncoder = LeaveGroupRequestSerde.CreateEncoder(leaveGroupMax);
            _leaveGroupResponseDecoder = LeaveGroupResponseSerde.CreateDecoder(leaveGroupMax);

            var offsetCommitMax = versions[ApiKey.OffsetCommit].Range.Max;
            _offsetCommitRequestEncoder = OffsetCommitRequestSerde.CreateEncoder(offsetCommitMax);
            _offsetCommitResponseDecoder = OffsetCommitResponseSerde.CreateDecoder(offsetCommitMax);

            var fetchMax = versions[ApiKey.Fetch].Range.Max;
            _fetchRequestEncoder = FetchRequestSerde.CreateEncoder(fetchMax);
            _fetchResponseDecoder = FetchResponseSerde.CreateDecoder(fetchMax);
        }
    }
}
