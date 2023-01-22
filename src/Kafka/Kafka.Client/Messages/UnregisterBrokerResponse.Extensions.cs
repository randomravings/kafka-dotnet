using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class UnregisterBrokerResponseSerde
   {
       private static readonly DecodeDelegate<UnregisterBrokerResponse>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<UnregisterBrokerResponse>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, UnregisterBrokerResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, UnregisterBrokerResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, UnregisterBrokerResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, UnregisterBrokerResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}