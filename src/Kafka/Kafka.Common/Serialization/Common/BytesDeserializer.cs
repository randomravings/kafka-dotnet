namespace Kafka.Common.Serialization.Common
{
    public sealed class BytesDeserializer :
        IDeserializer<byte[]?>
    {
        private BytesDeserializer() { }
        public static BytesDeserializer Instance { get; } = new();
        public byte[]? Read(byte[]? data)
        {
            if (data == null)
                return default;
            var result = new byte[data.Length];
            data.CopyTo(result, 0);
            return result;
        }
    }
}
