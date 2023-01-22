using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribeAclsResource = Kafka.Client.Messages.DescribeAclsResponse.DescribeAclsResource;
using AclDescription = Kafka.Client.Messages.DescribeAclsResponse.DescribeAclsResource.AclDescription;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeAclsResponseSerde
   {
       private static readonly DecodeDelegate<DescribeAclsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<DescribeAclsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, DescribeAclsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeAclsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeAclsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
           (index, var resourcesField) = Decoder.ReadArray<DescribeAclsResource>(buffer, index, DescribeAclsResourceSerde.ReadV00);
           if (resourcesField == null)
               throw new NullReferenceException("Null not allowed for 'Resources'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               resourcesField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeAclsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteArray<DescribeAclsResource>(buffer, index, message.ResourcesField, DescribeAclsResourceSerde.WriteV00);
           return index;
       }
       private static (int Offset, DescribeAclsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
           (index, var resourcesField) = Decoder.ReadArray<DescribeAclsResource>(buffer, index, DescribeAclsResourceSerde.ReadV01);
           if (resourcesField == null)
               throw new NullReferenceException("Null not allowed for 'Resources'");
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               resourcesField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DescribeAclsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteArray<DescribeAclsResource>(buffer, index, message.ResourcesField, DescribeAclsResourceSerde.WriteV01);
           return index;
       }
       private static (int Offset, DescribeAclsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var resourcesField) = Decoder.ReadCompactArray<DescribeAclsResource>(buffer, index, DescribeAclsResourceSerde.ReadV02);
           if (resourcesField == null)
               throw new NullReferenceException("Null not allowed for 'Resources'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               resourcesField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DescribeAclsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteCompactArray<DescribeAclsResource>(buffer, index, message.ResourcesField, DescribeAclsResourceSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, DescribeAclsResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var resourcesField) = Decoder.ReadCompactArray<DescribeAclsResource>(buffer, index, DescribeAclsResourceSerde.ReadV03);
           if (resourcesField == null)
               throw new NullReferenceException("Null not allowed for 'Resources'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               resourcesField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, DescribeAclsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteCompactArray<DescribeAclsResource>(buffer, index, message.ResourcesField, DescribeAclsResourceSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DescribeAclsResourceSerde
       {
           public static (int Offset, DescribeAclsResource Value) ReadV00(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               var patternTypeField = default(sbyte);
               (index, var aclsField) = Decoder.ReadArray<AclDescription>(buffer, index, AclDescriptionSerde.ReadV00);
               if (aclsField == null)
                   throw new NullReferenceException("Null not allowed for 'Acls'");
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   patternTypeField,
                   aclsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DescribeAclsResource message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteArray<AclDescription>(buffer, index, message.AclsField, AclDescriptionSerde.WriteV00);
               return index;
           }
           public static (int Offset, DescribeAclsResource Value) ReadV01(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               (index, var patternTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var aclsField) = Decoder.ReadArray<AclDescription>(buffer, index, AclDescriptionSerde.ReadV01);
               if (aclsField == null)
                   throw new NullReferenceException("Null not allowed for 'Acls'");
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   patternTypeField,
                   aclsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, DescribeAclsResource message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteInt8(buffer, index, message.PatternTypeField);
               index = Encoder.WriteArray<AclDescription>(buffer, index, message.AclsField, AclDescriptionSerde.WriteV01);
               return index;
           }
           public static (int Offset, DescribeAclsResource Value) ReadV02(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var patternTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var aclsField) = Decoder.ReadCompactArray<AclDescription>(buffer, index, AclDescriptionSerde.ReadV02);
               if (aclsField == null)
                   throw new NullReferenceException("Null not allowed for 'Acls'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   patternTypeField,
                   aclsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, DescribeAclsResource message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteInt8(buffer, index, message.PatternTypeField);
               index = Encoder.WriteCompactArray<AclDescription>(buffer, index, message.AclsField, AclDescriptionSerde.WriteV02);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, DescribeAclsResource Value) ReadV03(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var patternTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var aclsField) = Decoder.ReadCompactArray<AclDescription>(buffer, index, AclDescriptionSerde.ReadV03);
               if (aclsField == null)
                   throw new NullReferenceException("Null not allowed for 'Acls'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   patternTypeField,
                   aclsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, DescribeAclsResource message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteInt8(buffer, index, message.PatternTypeField);
               index = Encoder.WriteCompactArray<AclDescription>(buffer, index, message.AclsField, AclDescriptionSerde.WriteV03);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class AclDescriptionSerde
           {
               public static (int Offset, AclDescription Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var principalField) = Decoder.ReadString(buffer, index);
                   (index, var hostField) = Decoder.ReadString(buffer, index);
                   (index, var operationField) = Decoder.ReadInt8(buffer, index);
                   (index, var permissionTypeField) = Decoder.ReadInt8(buffer, index);
                   return (index, new(
                       principalField,
                       hostField,
                       operationField,
                       permissionTypeField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, AclDescription message)
               {
                   index = Encoder.WriteString(buffer, index, message.PrincipalField);
                   index = Encoder.WriteString(buffer, index, message.HostField);
                   index = Encoder.WriteInt8(buffer, index, message.OperationField);
                   index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
                   return index;
               }
               public static (int Offset, AclDescription Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var principalField) = Decoder.ReadString(buffer, index);
                   (index, var hostField) = Decoder.ReadString(buffer, index);
                   (index, var operationField) = Decoder.ReadInt8(buffer, index);
                   (index, var permissionTypeField) = Decoder.ReadInt8(buffer, index);
                   return (index, new(
                       principalField,
                       hostField,
                       operationField,
                       permissionTypeField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, AclDescription message)
               {
                   index = Encoder.WriteString(buffer, index, message.PrincipalField);
                   index = Encoder.WriteString(buffer, index, message.HostField);
                   index = Encoder.WriteInt8(buffer, index, message.OperationField);
                   index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
                   return index;
               }
               public static (int Offset, AclDescription Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var principalField) = Decoder.ReadCompactString(buffer, index);
                   (index, var hostField) = Decoder.ReadCompactString(buffer, index);
                   (index, var operationField) = Decoder.ReadInt8(buffer, index);
                   (index, var permissionTypeField) = Decoder.ReadInt8(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       principalField,
                       hostField,
                       operationField,
                       permissionTypeField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, AclDescription message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.PrincipalField);
                   index = Encoder.WriteCompactString(buffer, index, message.HostField);
                   index = Encoder.WriteInt8(buffer, index, message.OperationField);
                   index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, AclDescription Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var principalField) = Decoder.ReadCompactString(buffer, index);
                   (index, var hostField) = Decoder.ReadCompactString(buffer, index);
                   (index, var operationField) = Decoder.ReadInt8(buffer, index);
                   (index, var permissionTypeField) = Decoder.ReadInt8(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       principalField,
                       hostField,
                       operationField,
                       permissionTypeField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, AclDescription message)
               {
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