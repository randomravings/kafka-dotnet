using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribedDelegationTokenRenewer = Kafka.Client.Messages.DescribeDelegationTokenResponse.DescribedDelegationToken.DescribedDelegationTokenRenewer;
using DescribedDelegationToken = Kafka.Client.Messages.DescribeDelegationTokenResponse.DescribedDelegationToken;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeDelegationTokenResponseSerde
   {
       private static readonly DecodeDelegate<DescribeDelegationTokenResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<DescribeDelegationTokenResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, DescribeDelegationTokenResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeDelegationTokenResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeDelegationTokenResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var tokensField) = Decoder.ReadArray<DescribedDelegationToken>(buffer, index, DescribedDelegationTokenSerde.ReadV00);
           if (tokensField == null)
               throw new NullReferenceException("Null not allowed for 'Tokens'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               errorCodeField,
               tokensField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeDelegationTokenResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<DescribedDelegationToken>(buffer, index, message.TokensField, DescribedDelegationTokenSerde.WriteV00);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, DescribeDelegationTokenResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var tokensField) = Decoder.ReadArray<DescribedDelegationToken>(buffer, index, DescribedDelegationTokenSerde.ReadV01);
           if (tokensField == null)
               throw new NullReferenceException("Null not allowed for 'Tokens'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               errorCodeField,
               tokensField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DescribeDelegationTokenResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<DescribedDelegationToken>(buffer, index, message.TokensField, DescribedDelegationTokenSerde.WriteV01);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, DescribeDelegationTokenResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var tokensField) = Decoder.ReadCompactArray<DescribedDelegationToken>(buffer, index, DescribedDelegationTokenSerde.ReadV02);
           if (tokensField == null)
               throw new NullReferenceException("Null not allowed for 'Tokens'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               tokensField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DescribeDelegationTokenResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<DescribedDelegationToken>(buffer, index, message.TokensField, DescribedDelegationTokenSerde.WriteV02);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, DescribeDelegationTokenResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var tokensField) = Decoder.ReadCompactArray<DescribedDelegationToken>(buffer, index, DescribedDelegationTokenSerde.ReadV03);
           if (tokensField == null)
               throw new NullReferenceException("Null not allowed for 'Tokens'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               tokensField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, DescribeDelegationTokenResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<DescribedDelegationToken>(buffer, index, message.TokensField, DescribedDelegationTokenSerde.WriteV03);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DescribedDelegationTokenSerde
       {
           public static (int Offset, DescribedDelegationToken Value) ReadV00(byte[] buffer, int index)
           {
               (index, var principalTypeField) = Decoder.ReadString(buffer, index);
               (index, var principalNameField) = Decoder.ReadString(buffer, index);
               var tokenRequesterPrincipalTypeField = "";
               var tokenRequesterPrincipalNameField = "";
               (index, var issueTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, var expiryTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, var maxTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, var tokenIdField) = Decoder.ReadString(buffer, index);
               (index, var hmacField) = Decoder.ReadBytes(buffer, index);
               (index, var renewersField) = Decoder.ReadArray<DescribedDelegationTokenRenewer>(buffer, index, DescribedDelegationTokenRenewerSerde.ReadV00);
               if (renewersField == null)
                   throw new NullReferenceException("Null not allowed for 'Renewers'");
               return (index, new(
                   principalTypeField,
                   principalNameField,
                   tokenRequesterPrincipalTypeField,
                   tokenRequesterPrincipalNameField,
                   issueTimestampField,
                   expiryTimestampField,
                   maxTimestampField,
                   tokenIdField,
                   hmacField,
                   renewersField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DescribedDelegationToken message)
           {
               index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
               index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
               index = Encoder.WriteInt64(buffer, index, message.IssueTimestampField);
               index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampField);
               index = Encoder.WriteInt64(buffer, index, message.MaxTimestampField);
               index = Encoder.WriteString(buffer, index, message.TokenIdField);
               index = Encoder.WriteBytes(buffer, index, message.HmacField);
               index = Encoder.WriteArray<DescribedDelegationTokenRenewer>(buffer, index, message.RenewersField, DescribedDelegationTokenRenewerSerde.WriteV00);
               return index;
           }
           public static (int Offset, DescribedDelegationToken Value) ReadV01(byte[] buffer, int index)
           {
               (index, var principalTypeField) = Decoder.ReadString(buffer, index);
               (index, var principalNameField) = Decoder.ReadString(buffer, index);
               var tokenRequesterPrincipalTypeField = "";
               var tokenRequesterPrincipalNameField = "";
               (index, var issueTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, var expiryTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, var maxTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, var tokenIdField) = Decoder.ReadString(buffer, index);
               (index, var hmacField) = Decoder.ReadBytes(buffer, index);
               (index, var renewersField) = Decoder.ReadArray<DescribedDelegationTokenRenewer>(buffer, index, DescribedDelegationTokenRenewerSerde.ReadV01);
               if (renewersField == null)
                   throw new NullReferenceException("Null not allowed for 'Renewers'");
               return (index, new(
                   principalTypeField,
                   principalNameField,
                   tokenRequesterPrincipalTypeField,
                   tokenRequesterPrincipalNameField,
                   issueTimestampField,
                   expiryTimestampField,
                   maxTimestampField,
                   tokenIdField,
                   hmacField,
                   renewersField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, DescribedDelegationToken message)
           {
               index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
               index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
               index = Encoder.WriteInt64(buffer, index, message.IssueTimestampField);
               index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampField);
               index = Encoder.WriteInt64(buffer, index, message.MaxTimestampField);
               index = Encoder.WriteString(buffer, index, message.TokenIdField);
               index = Encoder.WriteBytes(buffer, index, message.HmacField);
               index = Encoder.WriteArray<DescribedDelegationTokenRenewer>(buffer, index, message.RenewersField, DescribedDelegationTokenRenewerSerde.WriteV01);
               return index;
           }
           public static (int Offset, DescribedDelegationToken Value) ReadV02(byte[] buffer, int index)
           {
               (index, var principalTypeField) = Decoder.ReadCompactString(buffer, index);
               (index, var principalNameField) = Decoder.ReadCompactString(buffer, index);
               var tokenRequesterPrincipalTypeField = "";
               var tokenRequesterPrincipalNameField = "";
               (index, var issueTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, var expiryTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, var maxTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, var tokenIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var hmacField) = Decoder.ReadCompactBytes(buffer, index);
               (index, var renewersField) = Decoder.ReadCompactArray<DescribedDelegationTokenRenewer>(buffer, index, DescribedDelegationTokenRenewerSerde.ReadV02);
               if (renewersField == null)
                   throw new NullReferenceException("Null not allowed for 'Renewers'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   principalTypeField,
                   principalNameField,
                   tokenRequesterPrincipalTypeField,
                   tokenRequesterPrincipalNameField,
                   issueTimestampField,
                   expiryTimestampField,
                   maxTimestampField,
                   tokenIdField,
                   hmacField,
                   renewersField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, DescribedDelegationToken message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
               index = Encoder.WriteInt64(buffer, index, message.IssueTimestampField);
               index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampField);
               index = Encoder.WriteInt64(buffer, index, message.MaxTimestampField);
               index = Encoder.WriteCompactString(buffer, index, message.TokenIdField);
               index = Encoder.WriteCompactBytes(buffer, index, message.HmacField);
               index = Encoder.WriteCompactArray<DescribedDelegationTokenRenewer>(buffer, index, message.RenewersField, DescribedDelegationTokenRenewerSerde.WriteV02);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, DescribedDelegationToken Value) ReadV03(byte[] buffer, int index)
           {
               (index, var principalTypeField) = Decoder.ReadCompactString(buffer, index);
               (index, var principalNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var tokenRequesterPrincipalTypeField) = Decoder.ReadCompactString(buffer, index);
               (index, var tokenRequesterPrincipalNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var issueTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, var expiryTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, var maxTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, var tokenIdField) = Decoder.ReadCompactString(buffer, index);
               (index, var hmacField) = Decoder.ReadCompactBytes(buffer, index);
               (index, var renewersField) = Decoder.ReadCompactArray<DescribedDelegationTokenRenewer>(buffer, index, DescribedDelegationTokenRenewerSerde.ReadV03);
               if (renewersField == null)
                   throw new NullReferenceException("Null not allowed for 'Renewers'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   principalTypeField,
                   principalNameField,
                   tokenRequesterPrincipalTypeField,
                   tokenRequesterPrincipalNameField,
                   issueTimestampField,
                   expiryTimestampField,
                   maxTimestampField,
                   tokenIdField,
                   hmacField,
                   renewersField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, DescribedDelegationToken message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
               index = Encoder.WriteCompactString(buffer, index, message.TokenRequesterPrincipalTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.TokenRequesterPrincipalNameField);
               index = Encoder.WriteInt64(buffer, index, message.IssueTimestampField);
               index = Encoder.WriteInt64(buffer, index, message.ExpiryTimestampField);
               index = Encoder.WriteInt64(buffer, index, message.MaxTimestampField);
               index = Encoder.WriteCompactString(buffer, index, message.TokenIdField);
               index = Encoder.WriteCompactBytes(buffer, index, message.HmacField);
               index = Encoder.WriteCompactArray<DescribedDelegationTokenRenewer>(buffer, index, message.RenewersField, DescribedDelegationTokenRenewerSerde.WriteV03);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class DescribedDelegationTokenRenewerSerde
           {
               public static (int Offset, DescribedDelegationTokenRenewer Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var principalTypeField) = Decoder.ReadString(buffer, index);
                   (index, var principalNameField) = Decoder.ReadString(buffer, index);
                   return (index, new(
                       principalTypeField,
                       principalNameField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, DescribedDelegationTokenRenewer message)
               {
                   index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
                   index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
                   return index;
               }
               public static (int Offset, DescribedDelegationTokenRenewer Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var principalTypeField) = Decoder.ReadString(buffer, index);
                   (index, var principalNameField) = Decoder.ReadString(buffer, index);
                   return (index, new(
                       principalTypeField,
                       principalNameField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, DescribedDelegationTokenRenewer message)
               {
                   index = Encoder.WriteString(buffer, index, message.PrincipalTypeField);
                   index = Encoder.WriteString(buffer, index, message.PrincipalNameField);
                   return index;
               }
               public static (int Offset, DescribedDelegationTokenRenewer Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var principalTypeField) = Decoder.ReadCompactString(buffer, index);
                   (index, var principalNameField) = Decoder.ReadCompactString(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       principalTypeField,
                       principalNameField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, DescribedDelegationTokenRenewer message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
                   index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, DescribedDelegationTokenRenewer Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var principalTypeField) = Decoder.ReadCompactString(buffer, index);
                   (index, var principalNameField) = Decoder.ReadCompactString(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       principalTypeField,
                       principalNameField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, DescribedDelegationTokenRenewer message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.PrincipalTypeField);
                   index = Encoder.WriteCompactString(buffer, index, message.PrincipalNameField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}