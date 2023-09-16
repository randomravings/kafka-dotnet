using Kafka.Common.Model;

namespace Kafka.Common.Serialization.Nullable
{
    public sealed class BytesDeserializer :
        IDeserializer<byte[]>
    {
        private BytesDeserializer() { }
        public static IDeserializer<byte[]> Instance { get; } = new BytesDeserializer();
        OptionalValue<byte[]> IDeserializer<byte[]>.Read(in ReadOnlyMemory<byte>? buffer)
        {
            if (!buffer.HasValue)
                return OptionalValue<byte[]>.Null;
            var value = buffer.Value.ToArray();
            return new(false, value);
        }
    }
}
