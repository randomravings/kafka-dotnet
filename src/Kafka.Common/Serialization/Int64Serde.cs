using System.Runtime.Serialization;

namespace Kafka.Common.Serialization.Nullable
{
    public static class Int64Serde
    {
        public static ISerializer<long> Serializer =>
            Int64Serializer.Instance
        ;

        public static ISerializer<long?> NullabeSerializer =>
            NullableInt64Serializer.Instance
        ;

        public static IDeserializer<long> Deserializer =>
            Int64Deserializer.Instance
        ;

        public static IDeserializer<long?> NullabeDeserializer =>
            NullableInt64Deserializer.Instance
        ;

        private sealed class Int64Serializer :
            ISerializer<long>
        {
            private Int64Serializer() { }
            public static ISerializer<long> Instance { get; } = new Int64Serializer();
            ReadOnlyMemory<byte>? ISerializer<long>.Write(in long value) =>
                NullableInt64Serializer.Instance.Write(value)
            ;
        }

        private sealed class NullableInt64Serializer :
            ISerializer<long?>
        {
            private NullableInt64Serializer() { }
            public static ISerializer<long?> Instance { get; } = new NullableInt64Serializer();
            ReadOnlyMemory<byte>? ISerializer<long?>.Write(in long? value)
            {
                if (value == null)
                    return null;
                var buffer = new byte[8];
                for (int i = 0, j = 56; i < 4; i++, j -= 8)
                    buffer[i] = (byte)(value >> j & 0xff);
                return buffer;
            }
        }

        private sealed class Int64Deserializer :
            IDeserializer<long>
        {
            public static IDeserializer<long> Instance { get; } =
                new Int64Deserializer()
            ;
            long IDeserializer<long>.Read(in ReadOnlyMemory<byte>? buffer) =>
                NullableInt64Deserializer.Instance.Read(buffer) ??
                throw new ArgumentNullException(nameof(buffer))
            ;
        }

        private sealed class NullableInt64Deserializer :
            IDeserializer<long?>
        {
            public static IDeserializer<long?> Instance { get; } =
                new NullableInt64Deserializer()
            ;
            long? IDeserializer<long?>.Read(in ReadOnlyMemory<byte>? buffer)
            {
                if (!buffer.HasValue)
                    return null;
                var span = buffer.Value.Span;
                if (span.Length != 8)
                    throw new SerializationException("Size of buffer received by IntegerDeserializer is not 8");
                long value = 0;
                for (int i = 0; i < 8; i++)
                {
                    value <<= 8;
                    value |= (long)span[i] & 0xff;
                }
                return value;
            }
        }
    }
}
