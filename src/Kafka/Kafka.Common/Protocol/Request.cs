namespace Kafka.Common.Protocol
{
    public record Request<TRequestHeader, TRequest>(
        int Size,
        TRequestHeader Header,
        TRequest Body
    );
}