using System.Runtime.Serialization;

namespace Kafka.Common.Serialization.Common
{
    /// <summary>
    /// Null deserializer requires the data to be null.
    /// </summary>
    public class NullDeserializer :
        IDeserializer<Null>
    {
        public Null Read(byte[]? data) =>
            data switch
            {
                null => Null.Value,
                _ => throw new SerializationException("Data was not null")
            }
            
        ;
    }
}
