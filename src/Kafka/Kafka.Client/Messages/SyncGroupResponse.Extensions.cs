using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SyncGroupResponseSerde
    {
        private static readonly DecodeDelegate<SyncGroupResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
        };
        private static readonly EncodeDelegate<SyncGroupResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
        };
        public static SyncGroupResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, SyncGroupResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static SyncGroupResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadBytes(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static int WriteV00(byte[] buffer, int index, SyncGroupResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
            return index;
        }
        private static SyncGroupResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadBytes(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static int WriteV01(byte[] buffer, int index, SyncGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
            return index;
        }
        private static SyncGroupResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadBytes(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static int WriteV02(byte[] buffer, int index, SyncGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
            return index;
        }
        private static SyncGroupResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadBytes(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static int WriteV03(byte[] buffer, int index, SyncGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteBytes(buffer, index, message.AssignmentField);
            return index;
        }
        private static SyncGroupResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadCompactBytes(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static int WriteV04(byte[] buffer, int index, SyncGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactBytes(buffer, index, message.AssignmentField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static SyncGroupResponse ReadV05(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var protocolTypeField = Decoder.ReadCompactNullableString(buffer, ref index);
            var protocolNameField = Decoder.ReadCompactNullableString(buffer, ref index);
            var assignmentField = Decoder.ReadCompactBytes(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static int WriteV05(byte[] buffer, int index, SyncGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
            index = Encoder.WriteCompactBytes(buffer, index, message.AssignmentField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}