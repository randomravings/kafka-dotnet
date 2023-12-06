namespace Kafka.Common.Serialization.Nullable
{
    public static class StringSerde
    {
        public static ISerializer<string> Serializer =>
            StringSerializer.Instance
        ;

        public static ISerializer<string?> NullabeSerializer =>
            NullableStringSerializer.Instance
        ;

        public static IDeserializer<string> Deserializer =>
            StringDeserializer.Instance
        ;

        public static IDeserializer<string?> NullabeDeserializer =>
            NullableStringDeserializer.Instance
        ;

        private sealed class StringSerializer :
            ISerializer<string>
        {
            private StringSerializer() { }
            public static ISerializer<string> Instance { get; } = new StringSerializer();
            ReadOnlyMemory<byte>? ISerializer<string>.Write(in string value) =>
                value switch
                {
                    null => throw new ArgumentNullException(nameof(value)),
                    var v => NullableStringSerializer.Instance.Write(v)
                }
            ;
        }

        private sealed class NullableStringSerializer :
            ISerializer<string?>
        {
            private NullableStringSerializer() { }
            public static ISerializer<string?> Instance { get; } = new NullableStringSerializer();
            ReadOnlyMemory<byte>? ISerializer<string?>.Write(in string? value) =>
                value switch
                {
                    null => null,
                    "" => ReadOnlyMemory<byte>.Empty,
                    var s => System.Text.Encoding.UTF8.GetBytes(s)
                }
            ;
        }

        private sealed class StringDeserializer :
            IDeserializer<string>
        {
            public static IDeserializer<string> Instance { get; } =
                new StringDeserializer()
            ;
            string IDeserializer<string>.Read(in ReadOnlyMemory<byte>? buffer) =>
                NullableStringDeserializer.Instance.Read(buffer) switch
                {
                    null => throw new ArgumentNullException(nameof(buffer)),
                    var v => v
                }
            ;
        }

        private sealed class NullableStringDeserializer :
            IDeserializer<string?>
        {
            public static IDeserializer<string?> Instance { get; } =
                new NullableStringDeserializer()
            ;
            string? IDeserializer<string?>.Read(in ReadOnlyMemory<byte>? buffer) =>
                buffer switch
                {
                    null => null,
                    { IsEmpty: true } => "",
                    ReadOnlyMemory<byte> b => System.Text.Encoding.UTF8.GetString(b.Span)
                }
            ;
        }
    }
}
