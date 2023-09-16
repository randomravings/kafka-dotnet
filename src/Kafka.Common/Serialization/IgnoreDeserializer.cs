using Kafka.Common.Model;

namespace Kafka.Common.Serialization
{
    public sealed class IgnoreDeserializer :
        IDeserializer<Ignore>
    {
        private static readonly OptionalValue<Ignore> RESULT = new(false, Ignore.Value);
        private IgnoreDeserializer() { }
        public static IgnoreDeserializer Instance { get; } = new();
        OptionalValue<Ignore> IDeserializer<Ignore>.Read(in ReadOnlyMemory<byte>? buffer) =>
            RESULT
        ;
    }
}
