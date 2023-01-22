using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DeleteAclsFilterResult = Kafka.Client.Messages.DeleteAclsResponse.DeleteAclsFilterResult;
using DeleteAclsMatchingAcl = Kafka.Client.Messages.DeleteAclsResponse.DeleteAclsFilterResult.DeleteAclsMatchingAcl;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DeleteAclsResponseSerde
   {
       private static readonly DecodeDelegate<DeleteAclsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<DeleteAclsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, DeleteAclsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DeleteAclsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DeleteAclsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var filterResultsField) = Decoder.ReadArray<DeleteAclsFilterResult>(buffer, index, DeleteAclsFilterResultSerde.ReadV00);
           if (filterResultsField == null)
               throw new NullReferenceException("Null not allowed for 'FilterResults'");
           return (index, new(
               throttleTimeMsField,
               filterResultsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DeleteAclsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DeleteAclsFilterResult>(buffer, index, message.FilterResultsField, DeleteAclsFilterResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, DeleteAclsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var filterResultsField) = Decoder.ReadArray<DeleteAclsFilterResult>(buffer, index, DeleteAclsFilterResultSerde.ReadV01);
           if (filterResultsField == null)
               throw new NullReferenceException("Null not allowed for 'FilterResults'");
           return (index, new(
               throttleTimeMsField,
               filterResultsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DeleteAclsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DeleteAclsFilterResult>(buffer, index, message.FilterResultsField, DeleteAclsFilterResultSerde.WriteV01);
           return index;
       }
       private static (int Offset, DeleteAclsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var filterResultsField) = Decoder.ReadCompactArray<DeleteAclsFilterResult>(buffer, index, DeleteAclsFilterResultSerde.ReadV02);
           if (filterResultsField == null)
               throw new NullReferenceException("Null not allowed for 'FilterResults'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               filterResultsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DeleteAclsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<DeleteAclsFilterResult>(buffer, index, message.FilterResultsField, DeleteAclsFilterResultSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, DeleteAclsResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var filterResultsField) = Decoder.ReadCompactArray<DeleteAclsFilterResult>(buffer, index, DeleteAclsFilterResultSerde.ReadV03);
           if (filterResultsField == null)
               throw new NullReferenceException("Null not allowed for 'FilterResults'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               filterResultsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, DeleteAclsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<DeleteAclsFilterResult>(buffer, index, message.FilterResultsField, DeleteAclsFilterResultSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DeleteAclsFilterResultSerde
       {
           public static (int Offset, DeleteAclsFilterResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               (index, var matchingAclsField) = Decoder.ReadArray<DeleteAclsMatchingAcl>(buffer, index, DeleteAclsMatchingAclSerde.ReadV00);
               if (matchingAclsField == null)
                   throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   matchingAclsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DeleteAclsFilterResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteArray<DeleteAclsMatchingAcl>(buffer, index, message.MatchingAclsField, DeleteAclsMatchingAclSerde.WriteV00);
               return index;
           }
           public static (int Offset, DeleteAclsFilterResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               (index, var matchingAclsField) = Decoder.ReadArray<DeleteAclsMatchingAcl>(buffer, index, DeleteAclsMatchingAclSerde.ReadV01);
               if (matchingAclsField == null)
                   throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   matchingAclsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, DeleteAclsFilterResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteArray<DeleteAclsMatchingAcl>(buffer, index, message.MatchingAclsField, DeleteAclsMatchingAclSerde.WriteV01);
               return index;
           }
           public static (int Offset, DeleteAclsFilterResult Value) ReadV02(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var matchingAclsField) = Decoder.ReadCompactArray<DeleteAclsMatchingAcl>(buffer, index, DeleteAclsMatchingAclSerde.ReadV02);
               if (matchingAclsField == null)
                   throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   matchingAclsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, DeleteAclsFilterResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteCompactArray<DeleteAclsMatchingAcl>(buffer, index, message.MatchingAclsField, DeleteAclsMatchingAclSerde.WriteV02);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, DeleteAclsFilterResult Value) ReadV03(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var matchingAclsField) = Decoder.ReadCompactArray<DeleteAclsMatchingAcl>(buffer, index, DeleteAclsMatchingAclSerde.ReadV03);
               if (matchingAclsField == null)
                   throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   matchingAclsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, DeleteAclsFilterResult message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteCompactArray<DeleteAclsMatchingAcl>(buffer, index, message.MatchingAclsField, DeleteAclsMatchingAclSerde.WriteV03);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class DeleteAclsMatchingAclSerde
           {
               public static (int Offset, DeleteAclsMatchingAcl Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
                   (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
                   (index, var resourceNameField) = Decoder.ReadString(buffer, index);
                   var patternTypeField = default(sbyte);
                   (index, var principalField) = Decoder.ReadString(buffer, index);
                   (index, var hostField) = Decoder.ReadString(buffer, index);
                   (index, var operationField) = Decoder.ReadInt8(buffer, index);
                   (index, var permissionTypeField) = Decoder.ReadInt8(buffer, index);
                   return (index, new(
                       errorCodeField,
                       errorMessageField,
                       resourceTypeField,
                       resourceNameField,
                       patternTypeField,
                       principalField,
                       hostField,
                       operationField,
                       permissionTypeField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, DeleteAclsMatchingAcl message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                   index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                   index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                   index = Encoder.WriteString(buffer, index, message.PrincipalField);
                   index = Encoder.WriteString(buffer, index, message.HostField);
                   index = Encoder.WriteInt8(buffer, index, message.OperationField);
                   index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
                   return index;
               }
               public static (int Offset, DeleteAclsMatchingAcl Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
                   (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
                   (index, var resourceNameField) = Decoder.ReadString(buffer, index);
                   (index, var patternTypeField) = Decoder.ReadInt8(buffer, index);
                   (index, var principalField) = Decoder.ReadString(buffer, index);
                   (index, var hostField) = Decoder.ReadString(buffer, index);
                   (index, var operationField) = Decoder.ReadInt8(buffer, index);
                   (index, var permissionTypeField) = Decoder.ReadInt8(buffer, index);
                   return (index, new(
                       errorCodeField,
                       errorMessageField,
                       resourceTypeField,
                       resourceNameField,
                       patternTypeField,
                       principalField,
                       hostField,
                       operationField,
                       permissionTypeField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, DeleteAclsMatchingAcl message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                   index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                   index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                   index = Encoder.WriteInt8(buffer, index, message.PatternTypeField);
                   index = Encoder.WriteString(buffer, index, message.PrincipalField);
                   index = Encoder.WriteString(buffer, index, message.HostField);
                   index = Encoder.WriteInt8(buffer, index, message.OperationField);
                   index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
                   return index;
               }
               public static (int Offset, DeleteAclsMatchingAcl Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
                   (index, var resourceNameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var patternTypeField) = Decoder.ReadInt8(buffer, index);
                   (index, var principalField) = Decoder.ReadCompactString(buffer, index);
                   (index, var hostField) = Decoder.ReadCompactString(buffer, index);
                   (index, var operationField) = Decoder.ReadInt8(buffer, index);
                   (index, var permissionTypeField) = Decoder.ReadInt8(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       errorCodeField,
                       errorMessageField,
                       resourceTypeField,
                       resourceNameField,
                       patternTypeField,
                       principalField,
                       hostField,
                       operationField,
                       permissionTypeField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, DeleteAclsMatchingAcl message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                   index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                   index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
                   index = Encoder.WriteInt8(buffer, index, message.PatternTypeField);
                   index = Encoder.WriteCompactString(buffer, index, message.PrincipalField);
                   index = Encoder.WriteCompactString(buffer, index, message.HostField);
                   index = Encoder.WriteInt8(buffer, index, message.OperationField);
                   index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, DeleteAclsMatchingAcl Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
                   (index, var resourceNameField) = Decoder.ReadCompactString(buffer, index);
                   (index, var patternTypeField) = Decoder.ReadInt8(buffer, index);
                   (index, var principalField) = Decoder.ReadCompactString(buffer, index);
                   (index, var hostField) = Decoder.ReadCompactString(buffer, index);
                   (index, var operationField) = Decoder.ReadInt8(buffer, index);
                   (index, var permissionTypeField) = Decoder.ReadInt8(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       errorCodeField,
                       errorMessageField,
                       resourceTypeField,
                       resourceNameField,
                       patternTypeField,
                       principalField,
                       hostField,
                       operationField,
                       permissionTypeField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, DeleteAclsMatchingAcl message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                   index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                   index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
                   index = Encoder.WriteInt8(buffer, index, message.PatternTypeField);
                   index = Encoder.WriteCompactString(buffer, index, message.PrincipalField);
                   index = Encoder.WriteCompactString(buffer, index, message.HostField);
                   index = Encoder.WriteInt8(buffer, index, message.OperationField);
                   index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}