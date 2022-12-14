using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class HeartbeatResponseSerde
    {
        private static readonly DecodeDelegate<HeartbeatResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<HeartbeatResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static HeartbeatResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, HeartbeatResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static HeartbeatResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static int WriteV00(byte[] buffer, int index, HeartbeatResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static HeartbeatResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static int WriteV01(byte[] buffer, int index, HeartbeatResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static HeartbeatResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static int WriteV02(byte[] buffer, int index, HeartbeatResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static HeartbeatResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static int WriteV03(byte[] buffer, int index, HeartbeatResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static HeartbeatResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static int WriteV04(byte[] buffer, int index, HeartbeatResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}