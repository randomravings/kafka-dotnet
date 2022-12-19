using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ResponseHeaderSerde
    {
        private delegate ResponseHeader DecodeDelegate(byte[] buffer, ref int index, bool flexible);
        private delegate int EncodeDelegate(byte[] buffer, int offset, ResponseHeader item, bool flexible);
        private static readonly DecodeDelegate[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
        };
        private static readonly EncodeDelegate[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
        };
        public static ResponseHeader Read(byte[] buffer, ref int index, short version, bool flexible) =>
            READ_VERSIONS[version](buffer, ref index, flexible)
        ;
        public static int Write(byte[] buffer, int index, ResponseHeader message, short version, bool flexible) =>
            WRITE_VERSIONS[version](buffer, index, message,flexible)
        ;
        private static ResponseHeader ReadV00(byte[] buffer, ref int index, bool flexible)
        {
            var correlationIdField = Decoder.ReadInt32(buffer, ref index);
            return new(
                correlationIdField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ResponseHeader message, bool flexible)
        {
            index = Encoder.WriteInt32(buffer, index, message.CorrelationIdField);
            return index;
        }
        private static ResponseHeader ReadV01(byte[] buffer, ref int index, bool flexible)
        {
            var correlationIdField = Decoder.ReadInt32(buffer, ref index);
            if (flexible)
                _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                correlationIdField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ResponseHeader message, bool flexible)
        {
            index = Encoder.WriteInt32(buffer, index, message.CorrelationIdField);
            if (flexible)
                index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}