using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class HeartbeatRequestSerde
    {
        private static readonly DecodeDelegate<HeartbeatRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
        };
        private static readonly EncodeDelegate<HeartbeatRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static HeartbeatRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, HeartbeatRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static HeartbeatRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, HeartbeatRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            return buffer;
        }
        private static HeartbeatRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, HeartbeatRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            return buffer;
        }
        private static HeartbeatRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, HeartbeatRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            return buffer;
        }
        private static HeartbeatRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = Decoder.ReadNullableString(ref buffer);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, HeartbeatRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
            return buffer;
        }
        private static HeartbeatRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadCompactString(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadCompactString(ref buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, HeartbeatRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}