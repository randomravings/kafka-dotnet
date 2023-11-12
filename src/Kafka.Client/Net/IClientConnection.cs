using Kafka.Client.Messages;
using Kafka.Common.Net;

namespace Kafka.Client.Net
{
    internal interface IClientConnection :
        IConnection
    {
        ValueTask<ApiVersionsResponseData> ApiVersions(
            CancellationToken cancellationToken
        );

        ValueTask<MetadataResponseData> Metadata(
            CancellationToken cancellationToken
        );

        ValueTask<MetadataResponseData> Metadata(
            MetadataRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<CreateTopicsResponseData> CreateTopics(
            CreateTopicsRequestData options,
            CancellationToken cancellationToken
        );

        ValueTask<DeleteTopicsResponseData> DeleteTopics(
            DeleteTopicsRequestData options,
            CancellationToken cancellationToken
        );

        ValueTask<FindCoordinatorResponseData> FindCoordinator(
            FindCoordinatorRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<OffsetFetchResponseData> OffsetFetch(
            OffsetFetchRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<ListOffsetsResponseData> ListOffsets(
            ListOffsetsRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<ProduceResponseData> Produce(
            ProduceRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask ProduceNoAck(
            ProduceRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<InitProducerIdResponseData> InitProducerId(
            InitProducerIdRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<AddPartitionsToTxnResponseData> AddPartitionsToTxn(
            AddPartitionsToTxnRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<EndTxnResponseData> EndTxn(
            EndTxnRequestData request,
            CancellationToken cancellationToken
        );

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
