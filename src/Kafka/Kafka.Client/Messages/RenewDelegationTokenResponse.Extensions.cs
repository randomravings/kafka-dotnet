using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class RenewDelegationTokenResponseSerde
   {
       private static readonly DecodeDelegate<RenewDelegationTokenResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<RenewDelegationTokenResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, RenewDelegationTokenResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, RenewDelegationTokenResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, RenewDelegationTokenResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var expiryTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               errorCodeField,
               expiryTimestampMsField,
               throttleTimeMsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, RenewDelegationTokenResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, RenewDelegationTokenResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var expiryTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               errorCodeField,
               expiryTimestampMsField,
               throttleTimeMsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, RenewDelegationTokenResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, RenewDelegationTokenResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var expiryTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               expiryTimestampMsField,
               throttleTimeMsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, RenewDelegationTokenResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}