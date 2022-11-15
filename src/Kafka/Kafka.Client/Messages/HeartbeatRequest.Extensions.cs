using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class HeartbeatRequestSerde
    {
        private static readonly Func<Stream, HeartbeatRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
        };
        private static readonly Action<Stream, HeartbeatRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static HeartbeatRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, HeartbeatRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static HeartbeatRequest ReadV00(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static void WriteV00(Stream buffer, HeartbeatRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
        }
        private static HeartbeatRequest ReadV01(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static void WriteV01(Stream buffer, HeartbeatRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
        }
        private static HeartbeatRequest ReadV02(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static void WriteV02(Stream buffer, HeartbeatRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
        }
        private static HeartbeatRequest ReadV03(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = Decoder.ReadNullableString(buffer);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static void WriteV03(Stream buffer, HeartbeatRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
        }
        private static HeartbeatRequest ReadV04(Stream buffer)
        {
            var groupIdField = Decoder.ReadCompactString(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadCompactString(buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static void WriteV04(Stream buffer, HeartbeatRequest message)
        {
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteCompactString(buffer, message.MemberIdField);
            Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}