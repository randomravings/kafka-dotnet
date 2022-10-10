using System.Runtime.Serialization;

namespace Kafka.Common.Serialization.Common
{
    public sealed class IntegerDeserializer :
        IDeserializer<int?>
    {
        private IntegerDeserializer() { }
        public static IntegerDeserializer Instance { get; } = new();
        public int? Read(byte[]? data)
        {
            if (data == null)
                return default;
            if (data.Length != 4)
                throw new SerializationException("Size of data received by IntegerDeserializer is not 4");
            int value = 0;
            for (int i = 0; i < 4; i++)
            {
                value <<= 8;
                value |= data[i] & 0xff;
            }
            return value;
        }
    }
}
