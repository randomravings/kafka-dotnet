using Kafka.Common.Model;

namespace Kafka.Common.Net
{
    public interface INode
    {
        NodeId NodeId { get; }
        IReadOnlyDictionary<ApiKey, ApiVersion> Apis { get; }
        Task Open(
            CancellationToken cancellationToken
        );
        Task Close(
            CancellationToken cancellationToken
        );
    }
}
