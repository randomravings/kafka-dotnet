using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class RenewDelegationTokenRequestSerde
   {
       private static readonly DecodeDelegate<RenewDelegationTokenRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<RenewDelegationTokenRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, RenewDelegationTokenRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, RenewDelegationTokenRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, RenewDelegationTokenRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var hmacField) = Decoder.ReadBytes(buffer, index);
           (index, var renewPeriodMsField) = Decoder.ReadInt64(buffer, index);
           return (index, new(
               hmacField,
               renewPeriodMsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, RenewDelegationTokenRequest message)
       {
           index = Encoder.WriteBytes(buffer, index, message.HmacField);
           index = Encoder.WriteInt64(buffer, index, message.RenewPeriodMsField);
           return index;
       }
       private static (int Offset, RenewDelegationTokenRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var hmacField) = Decoder.ReadBytes(buffer, index);
           (index, var renewPeriodMsField) = Decoder.ReadInt64(buffer, index);
           return (index, new(
               hmacField,
               renewPeriodMsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, RenewDelegationTokenRequest message)
       {
           index = Encoder.WriteBytes(buffer, index, message.HmacField);
           index = Encoder.WriteInt64(buffer, index, message.RenewPeriodMsField);
           return index;
       }
       private static (int Offset, RenewDelegationTokenRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var hmacField) = Decoder.ReadCompactBytes(buffer, index);
           (index, var renewPeriodMsField) = Decoder.ReadInt64(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               hmacField,
               renewPeriodMsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, RenewDelegationTokenRequest message)
       {
           index = Encoder.WriteCompactBytes(buffer, index, message.HmacField);
           index = Encoder.WriteInt64(buffer, index, message.RenewPeriodMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}