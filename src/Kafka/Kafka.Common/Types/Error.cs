namespace Kafka.Common.Types
{
    public readonly record struct Error(
        ErrorCode ErrorCode,
        bool Retriable,
        string Message
    );
}
