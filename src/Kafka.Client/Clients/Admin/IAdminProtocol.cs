using Kafka.Client.Messages;
using Kafka.Client.Protocol;

namespace Kafka.Client.Clients.Admin
{
    internal interface IAdminProtocol
        : IClientProtocol
    {
        ValueTask<CreateTopicsResponseData> CreateTopics(
            CreateTopicsRequestData request,
            CancellationToken cancellationToken
        );

        ValueTask<DeleteTopicsResponseData> DeleteTopics(
            DeleteTopicsRequestData request,
            CancellationToken cancellationToken
        );
    }
}
