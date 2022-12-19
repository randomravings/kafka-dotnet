using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class HeartbeatRequestSerde
    {
        private static readonly DecodeDelegate<HeartbeatRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<HeartbeatRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static HeartbeatRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, HeartbeatRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static HeartbeatRequest ReadV00(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static int WriteV00(byte[] buffer, int index, HeartbeatRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            return index;
        }
        private static HeartbeatRequest ReadV01(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static int WriteV01(byte[] buffer, int index, HeartbeatRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            return index;
        }
        private static HeartbeatRequest ReadV02(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static int WriteV02(byte[] buffer, int index, HeartbeatRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            return index;
        }
        private static HeartbeatRequest ReadV03(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = Decoder.ReadNullableString(buffer, ref index);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static int WriteV03(byte[] buffer, int index, HeartbeatRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
            return index;
        }
        private static HeartbeatRequest ReadV04(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadCompactString(buffer, ref index);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField
            );
        }
        private static int WriteV04(byte[] buffer, int index, HeartbeatRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}