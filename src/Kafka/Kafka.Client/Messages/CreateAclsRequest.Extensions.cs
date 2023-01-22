using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AclCreation = Kafka.Client.Messages.CreateAclsRequest.AclCreation;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class CreateAclsRequestSerde
   {
       private static readonly DecodeDelegate<CreateAclsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<CreateAclsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, CreateAclsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, CreateAclsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, CreateAclsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var creationsField) = Decoder.ReadArray<AclCreation>(buffer, index, AclCreationSerde.ReadV00);
           if (creationsField == null)
               throw new NullReferenceException("Null not allowed for 'Creations'");
           return (index, new(
               creationsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, CreateAclsRequest message)
       {
           index = Encoder.WriteArray<AclCreation>(buffer, index, message.CreationsField, AclCreationSerde.WriteV00);
           return index;
       }
       private static (int Offset, CreateAclsRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var creationsField) = Decoder.ReadArray<AclCreation>(buffer, index, AclCreationSerde.ReadV01);
           if (creationsField == null)
               throw new NullReferenceException("Null not allowed for 'Creations'");
           return (index, new(
               creationsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, CreateAclsRequest message)
       {
           index = Encoder.WriteArray<AclCreation>(buffer, index, message.CreationsField, AclCreationSerde.WriteV01);
           return index;
       }
       private static (int Offset, CreateAclsRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var creationsField) = Decoder.ReadCompactArray<AclCreation>(buffer, index, AclCreationSerde.ReadV02);
           if (creationsField == null)
               throw new NullReferenceException("Null not allowed for 'Creations'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               creationsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, CreateAclsRequest message)
       {
           index = Encoder.WriteCompactArray<AclCreation>(buffer, index, message.CreationsField, AclCreationSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, CreateAclsRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var creationsField) = Decoder.ReadCompactArray<AclCreation>(buffer, index, AclCreationSerde.ReadV03);
           if (creationsField == null)
               throw new NullReferenceException("Null not allowed for 'Creations'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               creationsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, CreateAclsRequest message)
       {
           index = Encoder.WriteCompactArray<AclCreation>(buffer, index, message.CreationsField, AclCreationSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class AclCreationSerde
       {
           public static (int Offset, AclCreation Value) ReadV00(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               var resourcePatternTypeField = default(sbyte);
               (index, var principalField) = Decoder.ReadString(buffer, index);
               (index, var hostField) = Decoder.ReadString(buffer, index);
               (index, var operationField) = Decoder.ReadInt8(buffer, index);
               (index, var permissionTypeField) = Decoder.ReadInt8(buffer, index);
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   resourcePatternTypeField,
                   principalField,
                   hostField,
                   operationField,
                   permissionTypeField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, AclCreation message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteString(buffer, index, message.PrincipalField);
               index = Encoder.WriteString(buffer, index, message.HostField);
               index = Encoder.WriteInt8(buffer, index, message.OperationField);
               index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
               return index;
           }
           public static (int Offset, AclCreation Value) ReadV01(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               (index, var resourcePatternTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var principalField) = Decoder.ReadString(buffer, index);
               (index, var hostField) = Decoder.ReadString(buffer, index);
               (index, var operationField) = Decoder.ReadInt8(buffer, index);
               (index, var permissionTypeField) = Decoder.ReadInt8(buffer, index);
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   resourcePatternTypeField,
                   principalField,
                   hostField,
                   operationField,
                   permissionTypeField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, AclCreation message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteInt8(buffer, index, message.ResourcePatternTypeField);
               index = Encoder.WriteString(buffer, index, message.PrincipalField);
               index = Encoder.WriteString(buffer, index, message.HostField);
               index = Encoder.WriteInt8(buffer, index, message.OperationField);
               index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
               return index;
           }
           public static (int Offset, AclCreation Value) ReadV02(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var resourcePatternTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var principalField) = Decoder.ReadCompactString(buffer, index);
               (index, var hostField) = Decoder.ReadCompactString(buffer, index);
               (index, var operationField) = Decoder.ReadInt8(buffer, index);
               (index, var permissionTypeField) = Decoder.ReadInt8(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   resourcePatternTypeField,
                   principalField,
                   hostField,
                   operationField,
                   permissionTypeField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, AclCreation message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteInt8(buffer, index, message.ResourcePatternTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.PrincipalField);
               index = Encoder.WriteCompactString(buffer, index, message.HostField);
               index = Encoder.WriteInt8(buffer, index, message.OperationField);
               index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, AclCreation Value) ReadV03(byte[] buffer, int index)
           {
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var resourcePatternTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var principalField) = Decoder.ReadCompactString(buffer, index);
               (index, var hostField) = Decoder.ReadCompactString(buffer, index);
               (index, var operationField) = Decoder.ReadInt8(buffer, index);
               (index, var permissionTypeField) = Decoder.ReadInt8(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   resourceTypeField,
                   resourceNameField,
                   resourcePatternTypeField,
                   principalField,
                   hostField,
                   operationField,
                   permissionTypeField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, AclCreation message)
           {
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteInt8(buffer, index, message.ResourcePatternTypeField);
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