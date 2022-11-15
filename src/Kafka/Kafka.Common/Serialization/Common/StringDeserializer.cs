namespace Kafka.Common.Serialization.Common
{
    public sealed class StringDeserializer :
        IDeserializer<string?>
    {
        private readonly System.Text.Encoding _encoding;
        private StringDeserializer(System.Text.Encoding encoding) =>
            _encoding = encoding
        ;
        public static StringDeserializer Default { get; } =
            new(System.Text.Encoding.UTF8)
        ;
        public string? Read(byte[]? data)
        {
            if (data == null)
                return default;
            return _encoding.GetString(data);
        }
    }
}
