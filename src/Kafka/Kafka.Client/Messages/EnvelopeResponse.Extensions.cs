using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class EnvelopeResponseSerde
   {
       private static readonly DecodeDelegate<EnvelopeResponse>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<EnvelopeResponse>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, EnvelopeResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, EnvelopeResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, EnvelopeResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var responseDataField) = Decoder.ReadCompactNullableBytes(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               responseDataField,
               errorCodeField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, EnvelopeResponse message)
       {
           index = Encoder.WriteCompactNullableBytes(buffer, index, message.ResponseDataField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}