using Kafka.Client.Messages;

namespace Kafka.Client.Clients.Admin.Model
{
    internal readonly record struct SendRequestResult<TRequest, TResponse>(
        RequestHeaderData RequestHeader,
        TRequest Request,
        ResponseHeaderData ResponseHeader,
        TResponse Response
    )
        where TRequest: notnull
        where TResponse : notnull
    ;
}
