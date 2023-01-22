using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ResponseHeaderSerde
   {
        private delegate (int Offset, ResponseHeader Value) DecodeDelegate(byte[] buffer, int index, bool flexible);
        private delegate int EncodeDelegate(byte[] buffer, int offset, ResponseHeader item, bool flexible);
        private static readonly DecodeDelegate[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
        };
        private static readonly EncodeDelegate[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
        };
        public static (int Offset, ResponseHeader Value) Read(byte[] buffer, int index, short version, bool flexible) =>
            READ_VERSIONS[version](buffer, index, flexible)
        ;
        public static int Write(byte[] buffer, int index, ResponseHeader message, short version, bool flexible) =>
            WRITE_VERSIONS[version](buffer, index, message,flexible)
        ;
        private static (int Offset, ResponseHeader Value) ReadV00(byte[] buffer, int index, bool flexible)
        {
            (index, var correlationIdField) = Decoder.ReadInt32(buffer, index);
            return (index, new(
                correlationIdField
            ));
        }
        private static int WriteV00(byte[] buffer, int index, ResponseHeader message, bool flexible)
        {
            index = Encoder.WriteInt32(buffer, index, message.CorrelationIdField);
            return index;
        }
        private static (int Offset, ResponseHeader Value) ReadV01(byte[] buffer, int index, bool flexible)
        {
            (index, var correlationIdField) = Decoder.ReadInt32(buffer, index);
            if (flexible)
                (index, _) = Decoder.ReadVarUInt32(buffer, index);
            return (index, new(
                correlationIdField
            ));
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