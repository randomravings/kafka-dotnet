using Kafka.Client.Messages;
using Kafka.Client.Protocol;

namespace Kafka.Client.Clients.Consumer
{
    public interface IConsumerProtocol :
        IClientProtocol
    {
        ValueTask<HeartbeatResponseData> Heartbeat(
            HeartbeatRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<JoinGroupResponseData> JoinGroup(
            JoinGroupRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<SyncGroupResponseData> SyncGroup(
            SyncGroupRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<LeaveGroupResponseData> LeaveGroup(
            LeaveGroupRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<OffsetCommitResponseData> OffsetCommit(
            OffsetCommitRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<FetchResponseData> Fetch(
            FetchRequestData request,
            CancellationToken cancellationToken
        );
    }
}
