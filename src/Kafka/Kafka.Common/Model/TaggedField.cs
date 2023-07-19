namespace Kafka.Common.Model
{
    public sealed record TaggedField(
        int Tag,
        ReadOnlyMemory<byte> Value
    );
}
