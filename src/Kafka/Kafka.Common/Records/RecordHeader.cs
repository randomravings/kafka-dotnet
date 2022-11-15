using Kafka.Common.Attributes;

namespace Kafka.Common.Records
{
    public sealed record RecordHeader(
        [property: Serialization(SerializationType.CompactString, 0)] string HeaderKey,
        [property: Serialization(SerializationType.CompactBytes, 1)] byte[] Value
    );
}
