using Kafka.Client.Messages;
using Kafka.Client.Protocol;

namespace Kafka.Client.Clients.Consumer
{
    public interface IConsumerProtocol :
        IClientProtocol
    {
        ValueTask<HeartbeatResponse> Heartbeat(
            HeartbeatRequest request,
            CancellationToken cancellationToken
        );

        ValueTask<JoinGroupResponse> JoinGroup(
            JoinGroupRequest request,
            CancellationToken cancellationToken
        );

        ValueTask<SyncGroupResponse> SyncGroup(
            SyncGroupRequest request,
            CancellationToken cancellationToken
        );

        ValueTask<LeaveGroupResponse> LeaveGroup(
            LeaveGroupRequest request,
            CancellationToken cancellationToken
        );

        ValueTask<OffsetCommitResponse> OffsetCommit(
            OffsetCommitRequest request,
            CancellationToken cancellationToken
        );

        ValueTask<FetchResponse> Fetch(
            FetchRequest request,
            CancellationToken cancellationToken
        );
    }
}
