using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class UpdateMetadataResponseSerde
    {
        private static readonly DecodeDelegate<UpdateMetadataResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
            ReadV08,
        };
        private static readonly EncodeDelegate<UpdateMetadataResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
            WriteV08,
        };
        public static UpdateMetadataResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, UpdateMetadataResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static UpdateMetadataResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            return new(
                errorCodeField
            );
        }
        private static int WriteV00(byte[] buffer, int index, UpdateMetadataResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static UpdateMetadataResponse ReadV01(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            return new(
                errorCodeField
            );
        }
        private static int WriteV01(byte[] buffer, int index, UpdateMetadataResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static UpdateMetadataResponse ReadV02(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            return new(
                errorCodeField
            );
        }
        private static int WriteV02(byte[] buffer, int index, UpdateMetadataResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static UpdateMetadataResponse ReadV03(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            return new(
                errorCodeField
            );
        }
        private static int WriteV03(byte[] buffer, int index, UpdateMetadataResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static UpdateMetadataResponse ReadV04(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            return new(
                errorCodeField
            );
        }
        private static int WriteV04(byte[] buffer, int index, UpdateMetadataResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static UpdateMetadataResponse ReadV05(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            return new(
                errorCodeField
            );
        }
        private static int WriteV05(byte[] buffer, int index, UpdateMetadataResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static UpdateMetadataResponse ReadV06(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField
            );
        }
        private static int WriteV06(byte[] buffer, int index, UpdateMetadataResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static UpdateMetadataResponse ReadV07(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField
            );
        }
        private static int WriteV07(byte[] buffer, int index, UpdateMetadataResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static UpdateMetadataResponse ReadV08(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField
            );
        }
        private static int WriteV08(byte[] buffer, int index, UpdateMetadataResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}