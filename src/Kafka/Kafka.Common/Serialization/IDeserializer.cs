namespace Kafka.Common.Serialization
{
    public interface IDeserializer<T>
    {
        T Read(byte[]? data);
    }
}
