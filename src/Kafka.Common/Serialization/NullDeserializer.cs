using Kafka.Common.Model;
using System.Runtime.Serialization;

namespace Kafka.Common.Serialization
{
    public sealed class NullDeserializer :
        IDeserializer<Null>
    {
        private static readonly OptionalValue<Null> RESULT = new(true, Null.Value);
        private NullDeserializer() { }
        public static NullDeserializer Instance { get; } = new();
        OptionalValue<Null> IDeserializer<Null>.Read(in ReadOnlyMemory<byte>? buffer) =>
            buffer switch
            {
                null => RESULT,
                _ => throw new SerializationException("Data was not null")
            }
        ;
    }
}
