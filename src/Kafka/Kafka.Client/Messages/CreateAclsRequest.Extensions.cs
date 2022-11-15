using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AclCreation = Kafka.Client.Messages.CreateAclsRequest.AclCreation;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateAclsRequestSerde
    {
        private static readonly Func<Stream, CreateAclsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, CreateAclsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static CreateAclsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, CreateAclsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static CreateAclsRequest ReadV00(Stream buffer)
        {
            var creationsField = Decoder.ReadArray<AclCreation>(buffer, b => AclCreationSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Creations'");
            return new(
                creationsField
            );
        }
        private static void WriteV00(Stream buffer, CreateAclsRequest message)
        {
            Encoder.WriteArray<AclCreation>(buffer, message.CreationsField, (b, i) => AclCreationSerde.WriteV00(b, i));
        }
        private static CreateAclsRequest ReadV01(Stream buffer)
        {
            var creationsField = Decoder.ReadArray<AclCreation>(buffer, b => AclCreationSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Creations'");
            return new(
                creationsField
            );
        }
        private static void WriteV01(Stream buffer, CreateAclsRequest message)
        {
            Encoder.WriteArray<AclCreation>(buffer, message.CreationsField, (b, i) => AclCreationSerde.WriteV01(b, i));
        }
        private static CreateAclsRequest ReadV02(Stream buffer)
        {
            var creationsField = Decoder.ReadCompactArray<AclCreation>(buffer, b => AclCreationSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Creations'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                creationsField
            );
        }
        private static void WriteV02(Stream buffer, CreateAclsRequest message)
        {
            Encoder.WriteCompactArray<AclCreation>(buffer, message.CreationsField, (b, i) => AclCreationSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static CreateAclsRequest ReadV03(Stream buffer)
        {
            var creationsField = Decoder.ReadCompactArray<AclCreation>(buffer, b => AclCreationSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Creations'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                creationsField
            );
        }
        private static void WriteV03(Stream buffer, CreateAclsRequest message)
        {
            Encoder.WriteCompactArray<AclCreation>(buffer, message.CreationsField, (b, i) => AclCreationSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class AclCreationSerde
        {
            public static AclCreation ReadV00(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var resourcePatternTypeField = default(sbyte);
                var principalField = Decoder.ReadString(buffer);
                var hostField = Decoder.ReadString(buffer);
                var operationField = Decoder.ReadInt8(buffer);
                var permissionTypeField = Decoder.ReadInt8(buffer);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    resourcePatternTypeField,
                    principalField,
                    hostField,
                    operationField,
                    permissionTypeField
                );
            }
            public static void WriteV00(Stream buffer, AclCreation message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteString(buffer, message.PrincipalField);
                Encoder.WriteString(buffer, message.HostField);
                Encoder.WriteInt8(buffer, message.OperationField);
                Encoder.WriteInt8(buffer, message.PermissionTypeField);
            }
            public static AclCreation ReadV01(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var resourcePatternTypeField = Decoder.ReadInt8(buffer);
                var principalField = Decoder.ReadString(buffer);
                var hostField = Decoder.ReadString(buffer);
                var operationField = Decoder.ReadInt8(buffer);
                var permissionTypeField = Decoder.ReadInt8(buffer);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    resourcePatternTypeField,
                    principalField,
                    hostField,
                    operationField,
                    permissionTypeField
                );
            }
            public static void WriteV01(Stream buffer, AclCreation message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteInt8(buffer, message.ResourcePatternTypeField);
                Encoder.WriteString(buffer, message.PrincipalField);
                Encoder.WriteString(buffer, message.HostField);
                Encoder.WriteInt8(buffer, message.OperationField);
                Encoder.WriteInt8(buffer, message.PermissionTypeField);
            }
            public static AclCreation ReadV02(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadCompactString(buffer);
                var resourcePatternTypeField = Decoder.ReadInt8(buffer);
                var principalField = Decoder.ReadCompactString(buffer);
                var hostField = Decoder.ReadCompactString(buffer);
                var operationField = Decoder.ReadInt8(buffer);
                var permissionTypeField = Decoder.ReadInt8(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    resourcePatternTypeField,
                    principalField,
                    hostField,
                    operationField,
                    permissionTypeField
                );
            }
            public static void WriteV02(Stream buffer, AclCreation message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteCompactString(buffer, message.ResourceNameField);
                Encoder.WriteInt8(buffer, message.ResourcePatternTypeField);
                Encoder.WriteCompactString(buffer, message.PrincipalField);
                Encoder.WriteCompactString(buffer, message.HostField);
                Encoder.WriteInt8(buffer, message.OperationField);
                Encoder.WriteInt8(buffer, message.PermissionTypeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static AclCreation ReadV03(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadCompactString(buffer);
                var resourcePatternTypeField = Decoder.ReadInt8(buffer);
                var principalField = Decoder.ReadCompactString(buffer);
                var hostField = Decoder.ReadCompactString(buffer);
                var operationField = Decoder.ReadInt8(buffer);
                var permissionTypeField = Decoder.ReadInt8(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    resourcePatternTypeField,
                    principalField,
                    hostField,
                    operationField,
                    permissionTypeField
                );
            }
            public static void WriteV03(Stream buffer, AclCreation message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteCompactString(buffer, message.ResourceNameField);
                Encoder.WriteInt8(buffer, message.ResourcePatternTypeField);
                Encoder.WriteCompactString(buffer, message.PrincipalField);
                Encoder.WriteCompactString(buffer, message.HostField);
                Encoder.WriteInt8(buffer, message.OperationField);
                Encoder.WriteInt8(buffer, message.PermissionTypeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}