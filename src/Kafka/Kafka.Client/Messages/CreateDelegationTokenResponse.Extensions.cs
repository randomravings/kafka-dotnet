using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class CreateDelegationTokenResponseSerde
   {
       private static readonly DecodeDelegate<CreateDelegationTokenResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<CreateDelegationTokenResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, CreateDelegationTokenResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, CreateDelegationTokenResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, CreateDelegationTokenResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var principalTypeField) = Decoder.ReadString(buffer, index);
           (index, var principalNameField) = Decoder.ReadString(buffer, index);
           var tokenRequesterPrincipalTypeField = "";
           var tokenRequesterPrincipalNameField = "";
           (index, var issueTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var expiryTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var maxTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var tokenIdField) = Decoder.ReadString(buffer, index);
           (index, var hmacField) = Decoder.ReadBytes(buffer, index);
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               errorCodeField,
               principalTypeField,
               principalNameField,
               tokenRequesterPrincipalTypeField,
               tokenRequesterPrincipalNameField,
               issueTimestampMsField,
               expiryTimestampMsField,
               maxTimestampMsField,
               tokenIdField,
               hmacField,
               throttleTimeMsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, CreateDelegationTokenResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
           index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
           index = Encoder.WriteInt64(buffer, index, message.IssueTimestampMsField);
           index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
           index = Encoder.WriteInt64(buffer, index, message.MaxTimestampMsField);
           index = Encoder.WriteString(buffer, index, message.TokenIdField);
           index = Encoder.WriteBytes(buffer, index, message.HmacField);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, CreateDelegationTokenResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var principalTypeField) = Decoder.ReadString(buffer, index);
           (index, var principalNameField) = Decoder.ReadString(buffer, index);
           var tokenRequesterPrincipalTypeField = "";
           var tokenRequesterPrincipalNameField = "";
           (index, var issueTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var expiryTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var maxTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var tokenIdField) = Decoder.ReadString(buffer, index);
           (index, var hmacField) = Decoder.ReadBytes(buffer, index);
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               errorCodeField,
               principalTypeField,
               principalNameField,
               tokenRequesterPrincipalTypeField,
               tokenRequesterPrincipalNameField,
               issueTimestampMsField,
               expiryTimestampMsField,
               maxTimestampMsField,
               tokenIdField,
               hmacField,
               throttleTimeMsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, CreateDelegationTokenResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
           index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
           index = Encoder.WriteInt64(buffer, index, message.IssueTimestampMsField);
           index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
           index = Encoder.WriteInt64(buffer, index, message.MaxTimestampMsField);
           index = Encoder.WriteString(buffer, index, message.TokenIdField);
           index = Encoder.WriteBytes(buffer, index, message.HmacField);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, CreateDelegationTokenResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var principalTypeField) = Decoder.ReadCompactString(buffer, index);
           (index, var principalNameField) = Decoder.ReadCompactString(buffer, index);
           var tokenRequesterPrincipalTypeField = "";
           var tokenRequesterPrincipalNameField = "";
           (index, var issueTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var expiryTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var maxTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var tokenIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var hmacField) = Decoder.ReadCompactBytes(buffer, index);
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               principalTypeField,
               principalNameField,
               tokenRequesterPrincipalTypeField,
               tokenRequesterPrincipalNameField,
               issueTimestampMsField,
               expiryTimestampMsField,
               maxTimestampMsField,
               tokenIdField,
               hmacField,
               throttleTimeMsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, CreateDelegationTokenResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
           index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
           index = Encoder.WriteInt64(buffer, index, message.IssueTimestampMsField);
           index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
           index = Encoder.WriteInt64(buffer, index, message.MaxTimestampMsField);
           index = Encoder.WriteCompactString(buffer, index, message.TokenIdField);
           index = Encoder.WriteCompactBytes(buffer, index, message.HmacField);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, CreateDelegationTokenResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var principalTypeField) = Decoder.ReadCompactString(buffer, index);
           (index, var principalNameField) = Decoder.ReadCompactString(buffer, index);
           (index, var tokenRequesterPrincipalTypeField) = Decoder.ReadCompactString(buffer, index);
           (index, var tokenRequesterPrincipalNameField) = Decoder.ReadCompactString(buffer, index);
           (index, var issueTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var expiryTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var maxTimestampMsField) = Decoder.ReadInt64(buffer, index);
           (index, var tokenIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var hmacField) = Decoder.ReadCompactBytes(buffer, index);
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               principalTypeField,
               principalNameField,
               tokenRequesterPrincipalTypeField,
               tokenRequesterPrincipalNameField,
               issueTimestampMsField,
               expiryTimestampMsField,
               maxTimestampMsField,
               tokenIdField,
               hmacField,
               throttleTimeMsField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, CreateDelegationTokenResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
           index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
           index = Encoder.WriteCompactString(buffer, index, message.TokenRequesterPrincipalTypeField);
           index = Encoder.WriteCompactString(buffer, index, message.TokenRequesterPrincipalNameField);
           index = Encoder.WriteInt64(buffer, index, message.IssueTimestampMsField);
           index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampMsField);
           index = Encoder.WriteInt64(buffer, index, message.MaxTimestampMsField);
           index = Encoder.WriteCompactString(buffer, index, message.TokenIdField);
           index = Encoder.WriteCompactBytes(buffer, index, message.HmacField);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}