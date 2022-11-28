using Kafka.Common.Types;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Kafka.Common.Serialization
{
    public static class Deserializers
    {
        public static IDeserializer<Ignore> Ignore { get; } = new IgnoreDeserializer();
        public static IDeserializer<Null> Null { get; } = new NullDeserializer();
        public static IDeserializer<int> Int32 { get; } = new Int32Deserializer();
        public static IDeserializer<ImmutableArray<byte>> Bytes { get; } = new BytesDeserializer();
        public static IDeserializer<string> Utf8 { get; } = new Utf8Deserializer();

        /// <summary>
        /// Deserializer that ignores values.
        /// </summary>
        private sealed class IgnoreDeserializer :
            IDeserializer<Ignore>
        {
            Ignore IDeserializer<Ignore>.Read(ImmutableArray<byte>? data) =>
                Types.Ignore.Value
            ;
        }

        /// <summary>
        /// Deserializer that requires null values
        /// </summary>
        private sealed class NullDeserializer :
            IDeserializer<Null>
        {
            Null IDeserializer<Null>.Read(ImmutableArray<byte>? data) =>
                data switch
                {
                    null => Types.Null.Value,
                    _ => throw new SerializationException("Data was not null")
                }
            ;
        }

        /// <summary>
        /// Deserializer that reads bytes.
        /// </summary>
        private sealed class BytesDeserializer :
            IDeserializer<ImmutableArray<byte>>
        {
            ImmutableArray<byte> IDeserializer<ImmutableArray<byte>>.Read(ImmutableArray<byte>? data) =>
                Nullable.Bytes.Read(data) switch
                {
                    null => throw NullEx(),
                    var v => v.Value
                }
            ;
        }

        /// <summary>
        /// Deserializer that reads bytes.
        /// </summary>
        private sealed class Int32Deserializer :
            IDeserializer<int>
        {
            int IDeserializer<int>.Read(ImmutableArray<byte>? data) =>
                Nullable.Int32.Read(data) switch
                {
                    null => throw NullEx(),
                    var v => v.Value
                }
            ;
        }

        /// <summary>
        /// Deserializer that reads UTF8 encoded strings.
        /// </summary>
        private sealed class Utf8Deserializer :
            IDeserializer<string>
        {
            string IDeserializer<string>.Read(ImmutableArray<byte>? data) =>
                Nullable.Utf8.Read(data) switch
                {
                    null => throw NullEx(),
                    var v => v
                }
            ;
        }

        private static InvalidDataException NullEx() =>
            new("Null exception")
        ;

        public static class Nullable
        {
            public static IDeserializer<int?> Int32 { get; } = new Int32Deserializer();
            public static IDeserializer<ImmutableArray<byte>?> Bytes { get; } = new BytesDeserializer();
            public static IDeserializer<string?> Utf8 { get; } = new Utf8Deserializer();

            /// <summary>
            /// Deserializer that reads bytes.
            /// </summary>
            private sealed class BytesDeserializer :
                IDeserializer<ImmutableArray<byte>?>
            {
                ImmutableArray<byte>? IDeserializer<ImmutableArray<byte>?>.Read(ImmutableArray<byte>? data) =>
                    data
                ;
            }

            /// <summary>
            /// Deserializer that reads bytes.
            /// </summary>
            private sealed class Int32Deserializer :
                IDeserializer<int?>
            {
                int? IDeserializer<int?>.Read(ImmutableArray<byte>? data)
                {
                    if (data == null)
                        return default;
                    var array = data.Value;
                    if (array.Length != 4)
                        throw new SerializationException("Size of data received by IntegerDeserializer is not 4");
                    int value = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        value <<= 8;
                        value |= array[i] & 0xff;
                    }
                    return value;
                }
            }

            /// <summary>
            /// Deserializer that reads UTF8 encoded strings.
            /// </summary>
            private sealed class Utf8Deserializer :
                IDeserializer<string?>
            {
                public string? Read(ImmutableArray<byte>? data)
                {
                    if (data == null)
                        return default;
                    return System.Text.Encoding.UTF8.GetString(data.Value.AsSpan());
                }
            }
        }
    }
}
