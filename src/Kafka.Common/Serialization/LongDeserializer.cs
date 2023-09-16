using System.Runtime.Serialization;
using Kafka.Common.Model;

namespace Kafka.Common.Serialization
{
    public sealed class LongDeserializer :
        IDeserializer<long>
    {
        private LongDeserializer() { }
        public static IDeserializer<long> Instance { get; } = new LongDeserializer();
        OptionalValue<long> IDeserializer<long>.Read(in ReadOnlyMemory<byte>? buffer)
        {
            if (!buffer.HasValue)
                return OptionalValue<long>.Null;
            var span = buffer.Value.Span;
            if (span.Length != 8)
                throw new SerializationException("Size of buffer received by IntegerDeserializer is not 8");
            long value = 0;
            for (int i = 0; i < 8; i++)
            {
                value <<= 8;
                value |= (long)span[i] & 0xff;
            }
            return new (false, value);
        }
    }
}
