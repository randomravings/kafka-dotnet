namespace Kafka.Common.Serialization.Common
{
    /// <summary>
    /// Ignore deserializer returns singleton value regardless of data.
    /// </summary>
    public class IgnoreDeserializer :
        IDeserializer<Ignore>
    {
        public Ignore Read(byte[]? data) =>
            Ignore.Value
        ;
    }
}
