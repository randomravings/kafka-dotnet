using Kafka.Common.Encoding;
using Kafka.Common.Network;

namespace Kafka.Common.Protocol
{
    public delegate TResponse RequestDelegate<TRequest, TResponse>(
        IConnection connection,
        TRequest request,
        EncodeVersionDelegate<TRequest> requestWriter,
        DecodeVersionDelegate<TResponse> responseReader,
        CancellationToken cancellationToken
    )
        where TRequest : notnull, Request
        where TResponse : notnull, Response
    ;
}
