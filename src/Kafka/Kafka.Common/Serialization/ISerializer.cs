namespace Kafka.Common.Serialization
{
    public interface ISerializer<T>
    {
        ReadOnlyMemory<byte>? Write(T value);
    }
}
