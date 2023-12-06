using System.Runtime.Serialization;

namespace Kafka.Common.Serialization.Nullable
{
    public static class Int32Serde
    {
        public static ISerializer<int> Serializer =>
            Int32Serializer.Instance
        ;

        public static ISerializer<int?> NullabeSerializer =>
            NullableInt32Serializer.Instance
        ;

        public static IDeserializer<int> Deserializer =>
            Int32Deserializer.Instance
        ;

        public static IDeserializer<int?> NullabeDeserializer =>
            NullableInt32Deserializer.Instance
        ;

        private sealed class Int32Serializer :
            ISerializer<int>
        {
            private Int32Serializer() { }
            public static ISerializer<int> Instance { get; } = new Int32Serializer();
            ReadOnlyMemory<byte>? ISerializer<int>.Write(in int value) =>
                NullableInt32Serializer.Instance.Write(value)
            ;
        }

        private sealed class NullableInt32Serializer :
            ISerializer<int?>
        {
            private NullableInt32Serializer() { }
            public static ISerializer<int?> Instance { get; } = new NullableInt32Serializer();
            ReadOnlyMemory<byte>? ISerializer<int?>.Write(in int? value)
            {
                if (value == null)
                    return null;
                var buffer = new byte[4];
                for (int i = 0, j = 24; i < 4; i++, j -= 8)
                    buffer[i] = (byte)(value >> j & 0xff);
                return buffer;
            }
        }

        private sealed class Int32Deserializer :
            IDeserializer<int>
        {
            public static IDeserializer<int> Instance { get; } =
                new Int32Deserializer()
            ;
            int IDeserializer<int>.Read(in ReadOnlyMemory<byte>? buffer) =>
                NullableInt32Deserializer.Instance.Read(buffer) ??
                throw new ArgumentNullException(nameof(buffer))
            ;
        }

        private sealed class NullableInt32Deserializer :
            IDeserializer<int?>
        {
            public static IDeserializer<int?> Instance { get; } =
                new NullableInt32Deserializer()
            ;
            int? IDeserializer<int?>.Read(in ReadOnlyMemory<byte>? buffer)
            {
                if (buffer == null)
                    return null;
                var span = buffer.Value.Span;
                if (span.Length != 4)
                    throw new SerializationException("Size of buffer received by IntegerDeserializer is not 4");
                int value = 0;
                for (int i = 0; i < 4; i++)
                {
                    value <<= 8;
                    value |= span[i] & 0xff;
                }
                return value;
            }
        }
    }
}
