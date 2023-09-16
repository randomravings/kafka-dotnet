using Kafka.Common.Model;

namespace Kafka.Common.Serialization
{
    public interface IDeserializer<T>
    {
        OptionalValue<T> Read(in ReadOnlyMemory<byte>? buffer);
    }
}
