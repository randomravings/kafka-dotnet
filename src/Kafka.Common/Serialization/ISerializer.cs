using Kafka.Common.Model;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Common.Serialization
{
    public interface ISerializer<T>
    {
        ReadOnlyMemory<byte>? Write(in T value);
    }
}
