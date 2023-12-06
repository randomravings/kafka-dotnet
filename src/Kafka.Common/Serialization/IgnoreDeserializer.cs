using Kafka.Common.Model;

namespace Kafka.Common.Serialization
{
    public static class IgnoreSerde
    {
        public static IDeserializer<Ignore> Deserializer =>
            IgnoreDeserializer.Instance
        ;

        private sealed class IgnoreDeserializer :
            IDeserializer<Ignore>
        {
            private IgnoreDeserializer() { }
            public static IgnoreDeserializer Instance { get; } = new();
            Ignore IDeserializer<Ignore>.Read(in ReadOnlyMemory<byte>? buffer) =>
                Ignore.Value
            ;
        }
    }
}
