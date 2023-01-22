using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AlterUserScramCredentialsResult = Kafka.Client.Messages.AlterUserScramCredentialsResponse.AlterUserScramCredentialsResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AlterUserScramCredentialsResponseSerde
   {
       private static readonly DecodeDelegate<AlterUserScramCredentialsResponse>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<AlterUserScramCredentialsResponse>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, AlterUserScramCredentialsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AlterUserScramCredentialsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AlterUserScramCredentialsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<AlterUserScramCredentialsResult>(buffer, index, AlterUserScramCredentialsResultSerde.ReadV00);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AlterUserScramCredentialsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<AlterUserScramCredentialsResult>(buffer, index, message.ResultsField, AlterUserScramCredentialsResultSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class AlterUserScramCredentialsResultSerde
       {
           public static (int Offset, AlterUserScramCredentialsResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var userField) = Decoder.ReadCompactString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   userField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, AlterUserScramCredentialsResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.UserField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}