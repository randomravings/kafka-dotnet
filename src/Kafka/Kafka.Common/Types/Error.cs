namespace Kafka.Common.Types
{
    public sealed record Error(
        short Code,
        string Label,
        bool Retriable,
        string Message
    );
}
