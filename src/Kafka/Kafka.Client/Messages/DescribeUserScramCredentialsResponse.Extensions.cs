using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using CredentialInfo = Kafka.Client.Messages.DescribeUserScramCredentialsResponse.DescribeUserScramCredentialsResult.CredentialInfo;
using DescribeUserScramCredentialsResult = Kafka.Client.Messages.DescribeUserScramCredentialsResponse.DescribeUserScramCredentialsResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeUserScramCredentialsResponseSerde
   {
       private static readonly DecodeDelegate<DescribeUserScramCredentialsResponse>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<DescribeUserScramCredentialsResponse>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, DescribeUserScramCredentialsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeUserScramCredentialsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeUserScramCredentialsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<DescribeUserScramCredentialsResult>(buffer, index, DescribeUserScramCredentialsResultSerde.ReadV00);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               resultsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeUserScramCredentialsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteCompactArray<DescribeUserScramCredentialsResult>(buffer, index, message.ResultsField, DescribeUserScramCredentialsResultSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DescribeUserScramCredentialsResultSerde
       {
           public static (int Offset, DescribeUserScramCredentialsResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var userField) = Decoder.ReadCompactString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var credentialInfosField) = Decoder.ReadCompactArray<CredentialInfo>(buffer, index, CredentialInfoSerde.ReadV00);
               if (credentialInfosField == null)
                   throw new NullReferenceException("Null not allowed for 'CredentialInfos'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   userField,
                   errorCodeField,
                   errorMessageField,
                   credentialInfosField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DescribeUserScramCredentialsResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.UserField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteCompactArray<CredentialInfo>(buffer, index, message.CredentialInfosField, CredentialInfoSerde.WriteV00);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class CredentialInfoSerde
           {
               public static (int Offset, CredentialInfo Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var mechanismField) = Decoder.ReadInt8(buffer, index);
                   (index, var iterationsField) = Decoder.ReadInt32(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       mechanismField,
                       iterationsField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, CredentialInfo message)
               {
                   index = Encoder.WriteInt8(buffer, index, message.MechanismField);
                   index = Encoder.WriteInt32(buffer, index, message.IterationsField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}