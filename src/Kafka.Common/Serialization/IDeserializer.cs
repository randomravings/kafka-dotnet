namespace Kafka.Common.Serialization
{
    public interface IDeserializer<T>
    {
        T Read(in ReadOnlyMemory<byte>? buffer);
    }
}
