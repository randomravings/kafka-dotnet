using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FindCoordinatorRequestSerde
    {
        private static readonly Func<Stream, FindCoordinatorRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
        };
        private static readonly Action<Stream, FindCoordinatorRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static FindCoordinatorRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, FindCoordinatorRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static FindCoordinatorRequest ReadV00(Stream buffer)
        {
            var keyField = Decoder.ReadString(buffer);
            var keyTypeField = default(sbyte);
            var coordinatorKeysField = ImmutableArray<string>.Empty;
            return new(
                keyField,
                keyTypeField,
                coordinatorKeysField
            );
        }
        private static void WriteV00(Stream buffer, FindCoordinatorRequest message)
        {
            Encoder.WriteString(buffer, message.KeyField);
        }
        private static FindCoordinatorRequest ReadV01(Stream buffer)
        {
            var keyField = Decoder.ReadString(buffer);
            var keyTypeField = Decoder.ReadInt8(buffer);
            var coordinatorKeysField = ImmutableArray<string>.Empty;
            return new(
                keyField,
                keyTypeField,
                coordinatorKeysField
            );
        }
        private static void WriteV01(Stream buffer, FindCoordinatorRequest message)
        {
            Encoder.WriteString(buffer, message.KeyField);
            Encoder.WriteInt8(buffer, message.KeyTypeField);
        }
        private static FindCoordinatorRequest ReadV02(Stream buffer)
        {
            var keyField = Decoder.ReadString(buffer);
            var keyTypeField = Decoder.ReadInt8(buffer);
            var coordinatorKeysField = ImmutableArray<string>.Empty;
            return new(
                keyField,
                keyTypeField,
                coordinatorKeysField
            );
        }
        private static void WriteV02(Stream buffer, FindCoordinatorRequest message)
        {
            Encoder.WriteString(buffer, message.KeyField);
            Encoder.WriteInt8(buffer, message.KeyTypeField);
        }
        private static FindCoordinatorRequest ReadV03(Stream buffer)
        {
            var keyField = Decoder.ReadCompactString(buffer);
            var keyTypeField = Decoder.ReadInt8(buffer);
            var coordinatorKeysField = ImmutableArray<string>.Empty;
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                keyField,
                keyTypeField,
                coordinatorKeysField
            );
        }
        private static void WriteV03(Stream buffer, FindCoordinatorRequest message)
        {
            Encoder.WriteCompactString(buffer, message.KeyField);
            Encoder.WriteInt8(buffer, message.KeyTypeField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static FindCoordinatorRequest ReadV04(Stream buffer)
        {
            var keyField = "";
            var keyTypeField = Decoder.ReadInt8(buffer);
            var coordinatorKeysField = Decoder.ReadCompactArray<string>(buffer, b => Decoder.ReadCompactString(b)) ?? throw new NullReferenceException("Null not allowed for 'CoordinatorKeys'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                keyField,
                keyTypeField,
                coordinatorKeysField
            );
        }
        private static void WriteV04(Stream buffer, FindCoordinatorRequest message)
        {
            Encoder.WriteInt8(buffer, message.KeyTypeField);
            Encoder.WriteCompactArray<string>(buffer, message.CoordinatorKeysField, (b, i) => Encoder.WriteCompactString(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}