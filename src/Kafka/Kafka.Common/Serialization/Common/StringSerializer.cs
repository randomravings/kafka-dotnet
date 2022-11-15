namespace Kafka.Common.Serialization.Common
{
    public sealed class StringSerializer :
        ISerializer<string?>
    {
        private readonly System.Text.Encoding _encoding;
        private StringSerializer(System.Text.Encoding encoding) =>
            _encoding = encoding
        ;
        public static StringSerializer Default { get; } =
            new(System.Text.Encoding.UTF8)
        ;
        public byte[]? Write(string? value)
        {
            if (value == null)
                return default;
            return _encoding.GetBytes(value);
        }
    }
}
