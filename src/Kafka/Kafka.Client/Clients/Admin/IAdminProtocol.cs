using Kafka.Client.Messages;
using Kafka.Client.Protocol;

namespace Kafka.Client.Clients.Admin
{
    internal interface IAdminProtocol
        : IClientProtocol
    {
        ValueTask<CreateTopicsResponse> CreateTopics(
            CreateTopicsRequest request,
            CancellationToken cancellationToken
        );

        ValueTask<DeleteTopicsResponse> DeleteTopics(
            DeleteTopicsRequest request,
            CancellationToken cancellationToken
        );
    }
}
