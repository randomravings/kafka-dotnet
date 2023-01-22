using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class EnvelopeRequestSerde
   {
       private static readonly DecodeDelegate<EnvelopeRequest>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<EnvelopeRequest>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, EnvelopeRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, EnvelopeRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, EnvelopeRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var requestDataField) = Decoder.ReadCompactBytes(buffer, index);
           (index, var requestPrincipalField) = Decoder.ReadCompactNullableBytes(buffer, index);
           (index, var clientHostAddressField) = Decoder.ReadCompactBytes(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               requestDataField,
               requestPrincipalField,
               clientHostAddressField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, EnvelopeRequest message)
       {
           index = Encoder.WriteCompactBytes(buffer, index, message.RequestDataField);
           index = Encoder.WriteCompactNullableBytes(buffer, index, message.RequestPrincipalField);
           index = Encoder.WriteCompactBytes(buffer, index, message.ClientHostAddressField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}