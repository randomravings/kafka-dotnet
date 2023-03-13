using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Protocol;

namespace Kafka.Common.Network
{
    public interface IConnection :
        IDisposable
    {
        Task Init(
            CancellationToken cancellationToken
        );
        ClusterNodeId NodeId { get; }
        string Host { get; }
        int Port { get; }
        Task<Cluster> GetClusterInfo(CancellationToken cancellationToken);
        Task<IEnumerable<ApiVersion>> GetApiKeys(CancellationToken cancellationToken);
        Task<TResponse> ExecuteRequest<TRequest, TResponse>(
            TRequest request,
            EncodeVersionDelegate<TRequest> requestWriter,
            DecodeVersionDelegate<TResponse> responseReader,
            CancellationToken cancellationToken
        )
            where TRequest : notnull, Request
            where TResponse : notnull, Response
        ;
        Task Close(CancellationToken cancellationToken);
    }
}
