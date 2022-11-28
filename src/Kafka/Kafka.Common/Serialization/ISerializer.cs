using System.Collections.Immutable;

namespace Kafka.Common.Serialization
{
    public interface ISerializer<T>
    {
        ImmutableArray<byte>? Write(T value);
    }
}
