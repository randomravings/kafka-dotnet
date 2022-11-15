using Kafka.Client.Clients.Admin.Model;
using Kafka.Client.Messages;

namespace Kafka.Client.Clients.Admin
{
    public interface IAdminClient :
        IClient
    {
        ValueTask<ApiVersionsResult> GetApiVersions(
            ApiVersionsOptions apiVersionsOptions,
            CancellationToken cancellationToken
        );

        ValueTask<ListTopicsResult> ListTopics(
            ListTopicsOptions listTopicOption,
            CancellationToken cancellationToken
        );

        ValueTask<CreateTopicsResult> CreateTopic(
            CreateTopicsOptions createTopicOptions,
            CancellationToken cancellationToken
        );
    }
}
