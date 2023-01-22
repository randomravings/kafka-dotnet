using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class RequestHeaderSerde
   {
        private delegate (int Offset, RequestHeader Value) DecodeDelegate(byte[] buffer, int index, bool flexible);
        private delegate int EncodeDelegate(byte[] buffer, int offset, RequestHeader item, bool flexible);
        private static readonly DecodeDelegate[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static (int Offset, RequestHeader Value) Read(byte[] buffer, int index, short version, bool flexible) =>
            READ_VERSIONS[version](buffer, index, flexible)
        ;
        public static int Write(byte[] buffer, int index, RequestHeader message, short version, bool flexible) =>
            WRITE_VERSIONS[version](buffer, index, message,flexible)
        ;
        private static (int Offset, RequestHeader Value) ReadV00(byte[] buffer, int index, bool flexible)
        {
            (index, var requestApiKeyField) = Decoder.ReadInt16(buffer, index);
            (index, var requestApiVersionField) = Decoder.ReadInt16(buffer, index);
            (index, var correlationIdField) = Decoder.ReadInt32(buffer, index);
            var clientIdField = default(string?);
            return (index, new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField
            ));
        }
        private static int WriteV00(byte[] buffer, int index, RequestHeader message, bool flexible)
        {
            index = Encoder.WriteInt16(buffer, index, message.RequestApiKeyField);
            index = Encoder.WriteInt16(buffer, index, message.RequestApiVersionField);
            index = Encoder.WriteInt32(buffer, index, message.CorrelationIdField);
            return index;
        }
        private static (int Offset, RequestHeader Value) ReadV01(byte[] buffer, int index, bool flexible)
        {
            (index, var requestApiKeyField) = Decoder.ReadInt16(buffer, index);
            (index, var requestApiVersionField) = Decoder.ReadInt16(buffer, index);
            (index, var correlationIdField) = Decoder.ReadInt32(buffer, index);
            (index, var clientIdField) = Decoder.ReadNullableString(buffer, index);
            return (index, new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField
            ));
        }
        private static int WriteV01(byte[] buffer, int index, RequestHeader message, bool flexible)
        {
            index = Encoder.WriteInt16(buffer, index, message.RequestApiKeyField);
            index = Encoder.WriteInt16(buffer, index, message.RequestApiVersionField);
            index = Encoder.WriteInt32(buffer, index, message.CorrelationIdField);
            index = Encoder.WriteNullableString(buffer, index, message.ClientIdField);
            return index;
        }
        private static (int Offset, RequestHeader Value) ReadV02(byte[] buffer, int index, bool flexible)
        {
            (index, var requestApiKeyField) = Decoder.ReadInt16(buffer, index);
            (index, var requestApiVersionField) = Decoder.ReadInt16(buffer, index);
            (index, var correlationIdField) = Decoder.ReadInt32(buffer, index);
            (index, var clientIdField) = Decoder.ReadNullableString(buffer, index);
            if (flexible)
                (index, _) = Decoder.ReadVarUInt32(buffer, index);
            return (index, new(
                requestApiKeyField,
                requestApiVersionField,
                correlationIdField,
                clientIdField
            ));
        }
        private static int WriteV02(byte[] buffer, int index, RequestHeader message, bool flexible)
        {
            index = Encoder.WriteInt16(buffer, index, message.RequestApiKeyField);
            index = Encoder.WriteInt16(buffer, index, message.RequestApiVersionField);
            index = Encoder.WriteInt32(buffer, index, message.CorrelationIdField);
            index = Encoder.WriteNullableString(buffer, index, message.ClientIdField);
            if (flexible)
                index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
   }
}