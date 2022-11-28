using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FindCoordinatorRequestSerde
    {
        private static readonly DecodeDelegate<FindCoordinatorRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
        };
        private static readonly EncodeDelegate<FindCoordinatorRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static FindCoordinatorRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, FindCoordinatorRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static FindCoordinatorRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var keyField = Decoder.ReadString(ref buffer);
            var keyTypeField = default(sbyte);
            var coordinatorKeysField = ImmutableArray<string>.Empty;
            return new(
                keyField,
                keyTypeField,
                coordinatorKeysField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, FindCoordinatorRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.KeyField);
            return buffer;
        }
        private static FindCoordinatorRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var keyField = Decoder.ReadString(ref buffer);
            var keyTypeField = Decoder.ReadInt8(ref buffer);
            var coordinatorKeysField = ImmutableArray<string>.Empty;
            return new(
                keyField,
                keyTypeField,
                coordinatorKeysField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, FindCoordinatorRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.KeyField);
            buffer = Encoder.WriteInt8(buffer, message.KeyTypeField);
            return buffer;
        }
        private static FindCoordinatorRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var keyField = Decoder.ReadString(ref buffer);
            var keyTypeField = Decoder.ReadInt8(ref buffer);
            var coordinatorKeysField = ImmutableArray<string>.Empty;
            return new(
                keyField,
                keyTypeField,
                coordinatorKeysField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, FindCoordinatorRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.KeyField);
            buffer = Encoder.WriteInt8(buffer, message.KeyTypeField);
            return buffer;
        }
        private static FindCoordinatorRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var keyField = Decoder.ReadCompactString(ref buffer);
            var keyTypeField = Decoder.ReadInt8(ref buffer);
            var coordinatorKeysField = ImmutableArray<string>.Empty;
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                keyField,
                keyTypeField,
                coordinatorKeysField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, FindCoordinatorRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.KeyField);
            buffer = Encoder.WriteInt8(buffer, message.KeyTypeField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static FindCoordinatorRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var keyField = "";
            var keyTypeField = Decoder.ReadInt8(ref buffer);
            var coordinatorKeysField = Decoder.ReadCompactArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b)) ?? throw new NullReferenceException("Null not allowed for 'CoordinatorKeys'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                keyField,
                keyTypeField,
                coordinatorKeysField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, FindCoordinatorRequest message)
        {
            buffer = Encoder.WriteInt8(buffer, message.KeyTypeField);
            buffer = Encoder.WriteCompactArray<string>(buffer, message.CoordinatorKeysField, (b, i) => Encoder.WriteCompactString(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}