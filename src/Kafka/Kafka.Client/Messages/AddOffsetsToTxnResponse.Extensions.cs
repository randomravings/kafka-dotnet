using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AddOffsetsToTxnResponseSerde
    {
        private static readonly DecodeDelegate<AddOffsetsToTxnResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<AddOffsetsToTxnResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static AddOffsetsToTxnResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AddOffsetsToTxnResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AddOffsetsToTxnResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AddOffsetsToTxnResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static AddOffsetsToTxnResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static int WriteV01(byte[] buffer, int index, AddOffsetsToTxnResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static AddOffsetsToTxnResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static int WriteV02(byte[] buffer, int index, AddOffsetsToTxnResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static AddOffsetsToTxnResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField
            );
        }
        private static int WriteV03(byte[] buffer, int index, AddOffsetsToTxnResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}