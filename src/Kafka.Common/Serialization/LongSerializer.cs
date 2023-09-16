using Kafka.Common.Model;

namespace Kafka.Common.Serialization
{
    public sealed class LongSerializer :
        ISerializer<long>
    {
        private LongSerializer() { }
        public static ISerializer<long> Instance { get; } = new LongSerializer();

        ReadOnlyMemory<byte>? ISerializer<long>.Write(in OptionalValue<long> parameter)
        {
            if (parameter.IsNull)
                return null;
            var value = parameter.Value;
            var buffer = new byte[8];
            for (int i = 0, j = 56; i < 4; i++, j -= 8)
                buffer[i] = (byte)(value >> j & 0xff);
            return buffer;
        }
    }
}
