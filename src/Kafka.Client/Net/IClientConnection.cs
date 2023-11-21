using Kafka.Client.Messages;
using Kafka.Common.Net;

namespace Kafka.Client.Net
{
    internal interface IClientConnection :
        IConnection
    {
        Task<ApiVersionsResponseData> ApiVersions(
            CancellationToken cancellationToken
        );

        Task<MetadataResponseData> Metadata(
            CancellationToken cancellationToken
        );

        Task<MetadataResponseData> Metadata(
            MetadataRequestData request,
            CancellationToken cancellationToken
        );

        Task<CreateTopicsResponseData> CreateTopics(
            CreateTopicsRequestData options,
            CancellationToken cancellationToken
        );

        Task<DeleteTopicsResponseData> DeleteTopics(
            DeleteTopicsRequestData options,
            CancellationToken cancellationToken
        );

        Task<FindCoordinatorResponseData> FindCoordinator(
            FindCoordinatorRequestData request,
            CancellationToken cancellationToken
        );

        Task<OffsetFetchResponseData> OffsetFetch(
            OffsetFetchRequestData request,
            CancellationToken cancellationToken
        );

        Task<ListOffsetsResponseData> ListOffsets(
            ListOffsetsRequestData request,
            CancellationToken cancellationToken
        );

        Task<ProduceResponseData> Produce(
            ProduceRequestData request,
            CancellationToken cancellationToken
        );

        Task ProduceNoAck(
            ProduceRequestData request,
            CancellationToken cancellationToken
        );

        Task<InitProducerIdResponseData> InitProducerId(
            InitProducerIdRequestData request,
            CancellationToken cancellationToken
        );

        Task<AddPartitionsToTxnResponseData> AddPartitionsToTxn(
            AddPartitionsToTxnRequestData request,
            CancellationToken cancellationToken
        );

        Task<EndTxnResponseData> EndTxn(
            EndTxnRequestData request,
            CancellationToken cancellationToken
        );

        Task<HeartbeatResponseData> Heartbeat(
            HeartbeatRequestData request,
            CancellationToken cancellationToken
        );

        Task<JoinGroupResponseData> JoinGroup(
            JoinGroupRequestData request,
            CancellationToken cancellationToken
        );

        Task<SyncGroupResponseData> SyncGroup(
            SyncGroupRequestData request,
            CancellationToken cancellationToken
        );

        Task<LeaveGroupResponseData> LeaveGroup(
            LeaveGroupRequestData request,
            CancellationToken cancellationToken
        );

        Task<OffsetCommitResponseData> OffsetCommit(
            OffsetCommitRequestData request,
            CancellationToken cancellationToken
        );

        Task<FetchResponseData> Fetch(
            FetchRequestData request,
            CancellationToken cancellationToken
        );
    }
}
