namespace Kafka.Common.Protocol
{
    public record Response<TResponseHeader, TRequest>(
        int Size,
        TResponseHeader ApiKey,
        TRequest Version
    );
}
