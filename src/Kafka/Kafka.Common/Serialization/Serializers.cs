using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Common.Serialization
{
    public static class Serializers
    {
        public static ISerializer<Ignore> Ignore { get; } = new IgnoreSerializer();
        public static ISerializer<Null> Null { get; } = new NullSerializer();
        public static ISerializer<ImmutableArray<byte>> Bytes { get; } = new BytesSerializer();
        public static ISerializer<int> Int32 { get; } = new Int32Serializer();
        public static ISerializer<string> Utf8 { get; } = new Utf8Serializer();

        private sealed class IgnoreSerializer :
            ISerializer<Ignore>
        {
            ImmutableArray<byte>? ISerializer<Ignore>.Write(Ignore value) =>
                null
            ;
        }

        private sealed class NullSerializer :
            ISerializer<Null>
        {
            ImmutableArray<byte>? ISerializer<Null>.Write(Null value) =>
                null
            ;
        }

        private sealed class BytesSerializer :
            ISerializer<ImmutableArray<byte>>
        {
            ImmutableArray<byte>? ISerializer<ImmutableArray<byte>>.Write(ImmutableArray<byte> value) =>
                Nullable.Bytes.Write(value)
            ;
        }

        private sealed class Int32Serializer :
            ISerializer<int>
        {
            ImmutableArray<byte>? ISerializer<int>.Write(int value) =>
                Nullable.Int32.Write(value)
            ;
        }

        private sealed class Utf8Serializer :
            ISerializer<string>
        {
            ImmutableArray<byte>? ISerializer<string>.Write(string value) =>
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
            public static ISerializer<ImmutableArray<byte>?> Bytes { get; } = new BytesSerializer();
            public static ISerializer<int?> Int32 { get; } = new Int32Serializer();
            public static ISerializer<string?> Utf8 { get; } = new Utf8Serializer();

            private sealed class BytesSerializer :
                ISerializer<ImmutableArray<byte>?>
            {
                ImmutableArray<byte>? ISerializer<ImmutableArray<byte>?>.Write(ImmutableArray<byte>? value) =>
                    value
                ;
            }

            private sealed class Int32Serializer :
                ISerializer<int?>
            {
                ImmutableArray<byte>? ISerializer<int?>.Write(int? value)
                {
                    if (value == null)
                        return null;
                    var data = ImmutableArray.CreateBuilder<byte>(4);
                    for (int i = 0, j = 24; i < 4; i++, j -= 8)
                        data[i] = (byte)((value >> j) & 0xff);
                    return data.ToImmutable();
                }
            }

            private sealed class Utf8Serializer :
                ISerializer<string?>
            {
                ImmutableArray<byte>? ISerializer<string?>.Write(string? value)
                {
                    if (value == null)
                        return default;
                    return System.Text.Encoding.UTF8.GetBytes(value).ToImmutableArray();
                }
            }
        }
    }
}
