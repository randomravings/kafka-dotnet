namespace Kafka.Common.Serialization.Common
{
    public sealed class IntegerSerializer :
        ISerializer<int?>
    {
        private IntegerSerializer() { }
        public static IntegerSerializer Instance { get; } = new();
        public byte[]? Write(int? value)
        {
            if (value == null)
                return default;
            var data = new byte[4];
            for (int i = 0, j = 24; i < 4; i++, j -= 8)
                data[i] = (byte)((value >> j) & 0xff);
            return data;
        }
    }
}
