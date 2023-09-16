using Kafka.Common.Model;

namespace Kafka.Common.Serialization
{
    public interface ISerializer<T>
    {
        ReadOnlyMemory<byte>? Write(in OptionalValue<T> parameter);
    }
}
