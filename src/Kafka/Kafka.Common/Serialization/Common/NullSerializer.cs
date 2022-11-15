namespace Kafka.Common.Serialization.Common
{
    /// <summary>
    /// Null serializer always returns null.
    /// </summary>
    public class NullSerializer :
        ISerializer<Null>
    {
        public byte[]? Write(Null value) =>
            default
        ;
    }
}
