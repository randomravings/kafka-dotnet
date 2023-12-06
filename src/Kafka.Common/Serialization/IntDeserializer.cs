using System.Runtime.Serialization;
using Kafka.Common.Model;

namespace Kafka.Common.Serialization
{
    public sealed class IntDeserializer :
        IDeserializer<int?>
    {
        private IntDeserializer() { }
        public static IDeserializer<int?> Instance { get; } = new IntDeserializer();
        int? IDeserializer<int?>.Read(in ReadOnlyMemory<byte>? buffer)
        {
            if (buffer == null)
                return null;
            var span = buffer.Value.Span;
            if (span.Length != 4)
                throw new SerializationException("Size of buffer received by IntegerDeserializer is not 4");
            int value = 0;
            for (int i = 0; i < 4; i++)
            {
                value <<= 8;
                value |= span[i] & 0xff;
            }
            return value;
        }
    }
}
