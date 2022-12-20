namespace Kafka.Common.Records
{
    public sealed record RecordHeader(
        string Key,
        ReadOnlyMemory<byte> Value
    );
}
