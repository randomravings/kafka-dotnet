using Kafka.Common.Model;

namespace Kafka.Common.Serialization
{
    public static class Serializers
    {
        public static ISerializer<Null> Null { get; } = new NullSerializer();
        public static ISerializer<byte[]> Bytes { get; } = new BytesSerializer();
        public static ISerializer<int> Int32 { get; } = new Int32Serializer();
        public static ISerializer<string> Utf8 { get; } = new Utf8Serializer();

        private sealed class NullSerializer :
            ISerializer<Null>
        {
            ReadOnlyMemory<byte>? ISerializer<Null>.Write(Null value) =>
                null
            ;
        }

        private sealed class BytesSerializer :
            ISerializer<byte[]>
        {
            ReadOnlyMemory<byte>? ISerializer<byte[]>.Write(byte[] value) =>
                Nullable.Bytes.Write(value)
            ;
        }

        private sealed class Int32Serializer :
            ISerializer<int>
        {
            ReadOnlyMemory<byte>? ISerializer<int>.Write(int value) =>
                Nullable.Int32.Write(value)
            ;
        }

        private sealed class Utf8Serializer :
            ISerializer<string>
        {
            ReadOnlyMemory<byte>? ISerializer<string>.Write(string value) =>
                value switch
                {
                    null => throw NullEx(),
                    var v => Nullable.Utf8.Write(v)
                }
            ;
        }

        private static ArgumentNullException NullEx() =>
            new("Null exception")
        ;

        private static class Nullable
        {
            public static ISerializer<ReadOnlyMemory<byte>?> Bytes { get; } = new BytesSerializer();
            public static ISerializer<int?> Int32 { get; } = new Int32Serializer();
            public static ISerializer<string?> Utf8 { get; } = new Utf8Serializer();

            private sealed class BytesSerializer :
                ISerializer<ReadOnlyMemory<byte>?>
            {
                ReadOnlyMemory<byte>? ISerializer<ReadOnlyMemory<byte>?>.Write(ReadOnlyMemory<byte>? value) =>
                    value
                ;
            }

            private sealed class Int32Serializer :
                ISerializer<int?>
            {
                ReadOnlyMemory<byte>? ISerializer<int?>.Write(int? value)
                {
                    if (value == null)
                        return null;
                    var buffer = new byte[4];
                    for (int i = 0, j = 24; i < 4; i++, j -= 8)
                        buffer[i] = (byte)((value >> j) & 0xff);
                    return buffer;
                }
            }

            private sealed class Utf8Serializer :
                ISerializer<string?>
            {
                ReadOnlyMemory<byte>? ISerializer<string?>.Write(string? value)
                {
                    if (value == null)
                        return null;
                    return System.Text.Encoding.UTF8.GetBytes(value);
                }
            }
        }
    }
}
