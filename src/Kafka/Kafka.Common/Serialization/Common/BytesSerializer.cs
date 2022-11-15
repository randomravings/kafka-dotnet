namespace Kafka.Common.Serialization.Common
{
    public sealed class dataSerializer :
        ISerializer<byte[]>
    {
        private dataSerializer() { }
        public static dataSerializer Instance { get; } = new();
        public byte[]? Write(byte[]? value)
        {
            if (value == null)
                return default;
            var result = new byte[value.Length];
            value.CopyTo(result, 0);
            return result;
        }
    }
}
