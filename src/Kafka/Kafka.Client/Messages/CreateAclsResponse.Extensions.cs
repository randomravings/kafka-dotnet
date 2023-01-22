using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AclCreationResult = Kafka.Client.Messages.CreateAclsResponse.AclCreationResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class CreateAclsResponseSerde
   {
       private static readonly DecodeDelegate<CreateAclsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<CreateAclsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, CreateAclsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, CreateAclsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, CreateAclsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<AclCreationResult>(buffer, index, AclCreationResultSerde.ReadV00);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, CreateAclsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<AclCreationResult>(buffer, index, message.ResultsField, AclCreationResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, CreateAclsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<AclCreationResult>(buffer, index, AclCreationResultSerde.ReadV01);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, CreateAclsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<AclCreationResult>(buffer, index, message.ResultsField, AclCreationResultSerde.WriteV01);
           return index;
       }
       private static (int Offset, CreateAclsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<AclCreationResult>(buffer, index, AclCreationResultSerde.ReadV02);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, CreateAclsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<AclCreationResult>(buffer, index, message.ResultsField, AclCreationResultSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, CreateAclsResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<AclCreationResult>(buffer, index, AclCreationResultSerde.ReadV03);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, CreateAclsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<AclCreationResult>(buffer, index, message.ResultsField, AclCreationResultSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class AclCreationResultSerde
       {
           public static (int Offset, AclCreationResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, AclCreationResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               return index;
           }
           public static (int Offset, AclCreationResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, AclCreationResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               return index;
           }
           public static (int Offset, AclCreationResult Value) ReadV02(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, AclCreationResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, AclCreationResult Value) ReadV03(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, AclCreationResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}