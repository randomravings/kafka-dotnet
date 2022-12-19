using Kafka.Common.Attributes;

namespace Kafka.Common.Records
{
    public sealed record RecordHeader(
        [property: Serialization(SerializationType.CompactString, 0)] string Key,
        [property: Serialization(SerializationType.CompactBytes, 1)] ReadOnlyMemory<byte> Value
    );
}
