using Kafka.Common.Model;

namespace Kafka.Common.Serialization
{
    public sealed class StringDeserializer :
        IDeserializer<string>
    {
        private StringDeserializer() { }
        public static IDeserializer<string> Instance { get; } = new StringDeserializer();
        public OptionalValue<string> Read(in ReadOnlyMemory<byte>? buffer)
        {
            if (!buffer.HasValue)
                return OptionalValue<string>.Null;
            var value = System.Text.Encoding.UTF8.GetString(buffer.Value.Span);
            return new(false, value);
        }
    }
}
