namespace Kafka.Common.Serialization
{
    public interface ISerializer<T>
    {
        byte[]? Write(T value);
    }
}
