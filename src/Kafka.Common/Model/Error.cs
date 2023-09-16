namespace Kafka.Common.Model
{
    public sealed record Error(
        short Code,
        string Label,
        bool Retriable,
        string Message
    );
}
