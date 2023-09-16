using Kafka.Client.Messages;
using Kafka.Common.Model;
using Kafka.Common.Protocol;

namespace Kafka.Client.Protocol
{
    public interface IClientProtocol :
        IProtocol,
        IDisposable
    {
        ClusterNodeId NodeId { get; }
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
    }
}
