namespace Kafka.Common.Model
{
    public sealed record RecordHeader(
        string Key,
        ReadOnlyMemory<byte> Value
    );
}
