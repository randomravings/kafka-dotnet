using Kafka.Common.Model;
using System.Runtime.Serialization;

namespace Kafka.Common.Serialization
{
    public static class NullSerde
    {
        public static ISerializer<Null> Serializer =>
            NullSerializer.Instance
        ;

        public static IDeserializer<Null> Deserializer =>
            NullDeserializer.Instance
        ;

        private sealed class NullSerializer :
            ISerializer<Null>
        {
            private NullSerializer() { }
            public static NullSerializer Instance { get; } = new();
            ReadOnlyMemory<byte>? ISerializer<Null>.Write(in Null value) =>
                null
            ;
        }

        private sealed class NullDeserializer :
            IDeserializer<Null>
        {
            private NullDeserializer() { }
            public static NullDeserializer Instance { get; } = new();
            Null IDeserializer<Null>.Read(in ReadOnlyMemory<byte>? buffer) =>
                buffer switch
                {
                    null => Null.Value,
                    _ => throw new SerializationException("Data was not null")
                }
            ;
        }
    }
}