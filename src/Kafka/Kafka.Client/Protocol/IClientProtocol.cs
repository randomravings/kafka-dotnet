using Kafka.Client.Messages;
using Kafka.Common.Model;
using Kafka.Common.Protocol;

namespace Kafka.Client.Protocol
{
    public interface IClientProtocol :
        IProtocol
    {
        ClusterNodeId NodeId { get; }
        ValueTask<ApiVersionsResponse> ApiVersions(
            CancellationToken cancellationToken
        );

        ValueTask<MetadataResponse> Metadata(
            CancellationToken cancellationToken
        );

        ValueTask<MetadataResponse> Metadata(
            MetadataRequest request,
            CancellationToken cancellationToken
        );

        ValueTask<FindCoordinatorResponse> FindCoordinator(
            FindCoordinatorRequest request,
            CancellationToken cancellationToken
        );

        ValueTask<OffsetFetchResponse> OffsetFetch(
            OffsetFetchRequest request,
            CancellationToken cancellationToken
        );

        ValueTask<ListOffsetsResponse> ListOffsets(
            ListOffsetsRequest request,
            CancellationToken cancellationToken
        );
    }
}
