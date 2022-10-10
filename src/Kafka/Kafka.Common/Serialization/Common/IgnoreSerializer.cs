namespace Kafka.Common.Serialization.Common
{
    /// <summary>
    /// Ignore serializer always returns null.
    /// </summary>
    public class IgnoreSerializer :
        ISerializer<Ignore>
    {
        public byte[]? Write(Ignore value) =>
            default
        ;
    }
}
