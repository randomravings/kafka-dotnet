using Kafka.Common.Model;

namespace Kafka.Common.Serialization
{
    public sealed class IntSerializer :
        ISerializer<int>
    {
        private IntSerializer() { }
        public static ISerializer<int> Instance { get; } = new IntSerializer();
        ReadOnlyMemory<byte>? ISerializer<int>.Write(in OptionalValue<int> parameter)
        {
            if(parameter.IsNull)
                return null;
            var value = parameter.Value;
            var buffer = new byte[4];
            for (int i = 0, j = 24; i < 4; i++, j -= 8)
                buffer[i] = (byte)(value >> j & 0xff);
            return buffer;
        }
    }
}
