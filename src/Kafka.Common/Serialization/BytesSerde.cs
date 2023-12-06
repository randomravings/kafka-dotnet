namespace Kafka.Common.Serialization.Nullable
{
    public static class BytesSerde
    {
        public static ISerializer<byte[]> Serializer =>
            BytesSerializer.Instance
        ;

        public static ISerializer<byte[]?> NullabeSerializer =>
            NullableBytesSerializer.Instance
        ;

        public static IDeserializer<byte[]> Deserializer =>
            BytesDeserializer.Instance
        ;

        public static IDeserializer<byte[]?> NullabeDeserializer =>
            NullableBytesDeserializer.Instance
        ;

        private sealed class BytesSerializer :
            ISerializer<byte[]>
        {
            private BytesSerializer() { }
            public static ISerializer<byte[]> Instance { get; } = new BytesSerializer();
            ReadOnlyMemory<byte>? ISerializer<byte[]>.Write(in byte[] value) =>
                value switch
                {
                    null => throw new ArgumentNullException(nameof(value)),
                    var v => NullableBytesSerializer.Instance.Write(v)
                }
            ;
        }

        private sealed class NullableBytesSerializer :
            ISerializer<byte[]?>
        {
            private NullableBytesSerializer() { }
            public static ISerializer<byte[]?> Instance { get; } = new NullableBytesSerializer();
            ReadOnlyMemory<byte>? ISerializer<byte[]?>.Write(in byte[]? value)
            {
                if (value == null)
                    return null;
                var buffer = new byte[value.Length];
                Array.Copy(value, buffer, value.Length);
                return buffer;
            }
        }

        private sealed class BytesDeserializer :
            IDeserializer<byte[]>
        {
            public static IDeserializer<byte[]> Instance { get; } =
                new BytesDeserializer()
            ;
            byte[] IDeserializer<byte[]>.Read(in ReadOnlyMemory<byte>? buffer) =>
                NullableBytesDeserializer.Instance.Read(buffer) switch
                {
                    null => throw new ArgumentNullException(nameof(buffer)),
                    var v => v
                }
            ;
        }

        private sealed class NullableBytesDeserializer :
            IDeserializer<byte[]?>
        {
            public static IDeserializer<byte[]?> Instance { get; } =
                new NullableBytesDeserializer()
            ;
            byte[]? IDeserializer<byte[]?>.Read(in ReadOnlyMemory<byte>? buffer)
            {
                if (buffer == null)
                    return null;
                var value = buffer.Value.ToArray();
                return value;
            }
        }
    }
}
