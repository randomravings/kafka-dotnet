using System.Collections.Immutable;

namespace Kafka.Common.Serialization
{
    public interface IDeserializer<T>
    {
        T Read(ImmutableArray<byte>? data);
    }
}
