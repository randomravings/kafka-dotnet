using Kafka.Client.Messages;

namespace Kafka.Client.Clients.Admin.Model
{
    internal readonly record struct SendRequestResult<TRequest, TResponse>(
        RequestHeader RequestHeader,
        TRequest Request,
        ResponseHeader ResponseHeader,
        TResponse Response
    )
        where TRequest: notnull
        where TResponse : notnull
    ;
}
