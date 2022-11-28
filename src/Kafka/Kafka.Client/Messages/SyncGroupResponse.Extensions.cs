using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SyncGroupResponseSerde
    {
        private static readonly DecodeDelegate<SyncGroupResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
        };
        private static readonly EncodeDelegate<SyncGroupResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
        };
        public static SyncGroupResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, SyncGroupResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static SyncGroupResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadBytes(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, SyncGroupResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteBytes(buffer, message.AssignmentField);
            return buffer;
        }
        private static SyncGroupResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadBytes(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, SyncGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteBytes(buffer, message.AssignmentField);
            return buffer;
        }
        private static SyncGroupResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadBytes(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, SyncGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteBytes(buffer, message.AssignmentField);
            return buffer;
        }
        private static SyncGroupResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadBytes(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, SyncGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteBytes(buffer, message.AssignmentField);
            return buffer;
        }
        private static SyncGroupResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var assignmentField = Decoder.ReadCompactBytes(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, SyncGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactBytes(buffer, message.AssignmentField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static SyncGroupResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var protocolTypeField = Decoder.ReadCompactNullableString(ref buffer);
            var protocolNameField = Decoder.ReadCompactNullableString(ref buffer);
            var assignmentField = Decoder.ReadCompactBytes(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                protocolTypeField,
                protocolNameField,
                assignmentField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, SyncGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ProtocolNameField);
            buffer = Encoder.WriteCompactBytes(buffer, message.AssignmentField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}