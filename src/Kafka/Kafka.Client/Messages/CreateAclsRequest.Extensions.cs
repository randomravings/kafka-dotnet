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
        public static CreateAclsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, CreateAclsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static CreateAclsRequest ReadV00(byte[] buffer, ref int index)
        {
            var creationsField = Decoder.ReadArray<AclCreation>(buffer, ref index, AclCreationSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Creations'");
            return new(
                creationsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, CreateAclsRequest message)
        {
            index = Encoder.WriteArray<AclCreation>(buffer, index, message.CreationsField, AclCreationSerde.WriteV00);
            return index;
        }
        private static CreateAclsRequest ReadV01(byte[] buffer, ref int index)
        {
            var creationsField = Decoder.ReadArray<AclCreation>(buffer, ref index, AclCreationSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Creations'");
            return new(
                creationsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, CreateAclsRequest message)
        {
            index = Encoder.WriteArray<AclCreation>(buffer, index, message.CreationsField, AclCreationSerde.WriteV01);
            return index;
        }
        private static CreateAclsRequest ReadV02(byte[] buffer, ref int index)
        {
            var creationsField = Decoder.ReadCompactArray<AclCreation>(buffer, ref index, AclCreationSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Creations'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                creationsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, CreateAclsRequest message)
        {
            index = Encoder.WriteCompactArray<AclCreation>(buffer, index, message.CreationsField, AclCreationSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static CreateAclsRequest ReadV03(byte[] buffer, ref int index)
        {
            var creationsField = Decoder.ReadCompactArray<AclCreation>(buffer, ref index, AclCreationSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Creations'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                creationsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, CreateAclsRequest message)
        {
            index = Encoder.WriteCompactArray<AclCreation>(buffer, index, message.CreationsField, AclCreationSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class AclCreationSerde
        {
            public static AclCreation ReadV00(byte[] buffer, ref int index)
            {
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadString(buffer, ref index);
                var ResourcePatternTypeField = default(sbyte);
                var PrincipalField = Decoder.ReadString(buffer, ref index);
                var HostField = Decoder.ReadString(buffer, ref index);
                var OperationField = Decoder.ReadInt8(buffer, ref index);
                var PermissionTypeField = Decoder.ReadInt8(buffer, ref index);
                return new(
                    ResourceTypeField,
                    ResourceNameField,
                    ResourcePatternTypeField,
                    PrincipalField,
                    HostField,
                    OperationField,
                    PermissionTypeField
                );
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
            public static AclCreation ReadV01(byte[] buffer, ref int index)
            {
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadString(buffer, ref index);
                var ResourcePatternTypeField = Decoder.ReadInt8(buffer, ref index);
                var PrincipalField = Decoder.ReadString(buffer, ref index);
                var HostField = Decoder.ReadString(buffer, ref index);
                var OperationField = Decoder.ReadInt8(buffer, ref index);
                var PermissionTypeField = Decoder.ReadInt8(buffer, ref index);
                return new(
                    ResourceTypeField,
                    ResourceNameField,
                    ResourcePatternTypeField,
                    PrincipalField,
                    HostField,
                    OperationField,
                    PermissionTypeField
                );
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
            public static AclCreation ReadV02(byte[] buffer, ref int index)
            {
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadCompactString(buffer, ref index);
                var ResourcePatternTypeField = Decoder.ReadInt8(buffer, ref index);
                var PrincipalField = Decoder.ReadCompactString(buffer, ref index);
                var HostField = Decoder.ReadCompactString(buffer, ref index);
                var OperationField = Decoder.ReadInt8(buffer, ref index);
                var PermissionTypeField = Decoder.ReadInt8(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ResourceTypeField,
                    ResourceNameField,
                    ResourcePatternTypeField,
                    PrincipalField,
                    HostField,
                    OperationField,
                    PermissionTypeField
                );
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
            public static AclCreation ReadV03(byte[] buffer, ref int index)
            {
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadCompactString(buffer, ref index);
                var ResourcePatternTypeField = Decoder.ReadInt8(buffer, ref index);
                var PrincipalField = Decoder.ReadCompactString(buffer, ref index);
                var HostField = Decoder.ReadCompactString(buffer, ref index);
                var OperationField = Decoder.ReadInt8(buffer, ref index);
                var PermissionTypeField = Decoder.ReadInt8(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ResourceTypeField,
                    ResourceNameField,
                    ResourcePatternTypeField,
                    PrincipalField,
                    HostField,
                    OperationField,
                    PermissionTypeField
                );
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