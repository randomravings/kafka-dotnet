using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SyncGroupResponseSerde
    {
        private static readonly Func<Stream, SyncGroupResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
        };
        private static readonly Action<Stream, SyncGroupResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
        };
        public static SyncGroupResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, SyncGroupResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static SyncGroupResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadBytes(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static void WriteV00(Stream buffer, SyncGroupResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteBytes(buffer, message.AssignmentField);
        }
        private static SyncGroupResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadBytes(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static void WriteV01(Stream buffer, SyncGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteBytes(buffer, message.AssignmentField);
        }
        private static SyncGroupResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadBytes(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static void WriteV02(Stream buffer, SyncGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteBytes(buffer, message.AssignmentField);
        }
        private static SyncGroupResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadBytes(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static void WriteV03(Stream buffer, SyncGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteBytes(buffer, message.AssignmentField);
        }
        private static SyncGroupResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadCompactBytes(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static void WriteV04(Stream buffer, SyncGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactBytes(buffer, message.AssignmentField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static SyncGroupResponse ReadV05(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var protocolTypeField = Decoder.ReadCompactNullableString(buffer);
            var protocolNameField = Decoder.ReadCompactNullableString(buffer);
            var assignmentField = Decoder.ReadCompactBytes(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static void WriteV05(Stream buffer, SyncGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactNullableString(buffer, message.ProtocolTypeField);
            Encoder.WriteCompactNullableString(buffer, message.ProtocolNameField);
            Encoder.WriteCompactBytes(buffer, message.AssignmentField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}