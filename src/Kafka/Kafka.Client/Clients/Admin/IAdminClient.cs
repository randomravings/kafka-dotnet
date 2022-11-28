using Kafka.Client.Clients.Admin.Model;

namespace Kafka.Client.Clients.Admin
{
    public interface IAdminClient :
        IClient
    {
        ValueTask<ApiVersionsResult> GetApiVersions(
            ApiVersionsOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<ListTopicsResult> ListTopics(
            ListTopicsOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<CreateTopicsResult> CreateTopics(
            CreateTopicsOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<DescribeTopicsResult> DescribeTopics(
            DescribeTopicsOptions options,
            CancellationToken cancellationToken
        );

        ValueTask<DeleteTopicsResult> DeleteTopics(
            DeleteTopicsOptions options,
            CancellationToken cancellationToken
        );
    }
}
