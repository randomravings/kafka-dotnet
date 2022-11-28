using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AclCreation = Kafka.Client.Messages.CreateAclsRequest.AclCreation;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateAclsRequestSerde
    {
        private static readonly DecodeDelegate<CreateAclsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<CreateAclsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static CreateAclsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, CreateAclsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static CreateAclsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var creationsField = Decoder.ReadArray<AclCreation>(ref buffer, (ref ReadOnlyMemory<byte> b) => AclCreationSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Creations'");
            return new(
                creationsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, CreateAclsRequest message)
        {
            buffer = Encoder.WriteArray<AclCreation>(buffer, message.CreationsField, (b, i) => AclCreationSerde.WriteV00(b, i));
            return buffer;
        }
        private static CreateAclsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var creationsField = Decoder.ReadArray<AclCreation>(ref buffer, (ref ReadOnlyMemory<byte> b) => AclCreationSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Creations'");
            return new(
                creationsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, CreateAclsRequest message)
        {
            buffer = Encoder.WriteArray<AclCreation>(buffer, message.CreationsField, (b, i) => AclCreationSerde.WriteV01(b, i));
            return buffer;
        }
        private static CreateAclsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var creationsField = Decoder.ReadCompactArray<AclCreation>(ref buffer, (ref ReadOnlyMemory<byte> b) => AclCreationSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Creations'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                creationsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, CreateAclsRequest message)
        {
            buffer = Encoder.WriteCompactArray<AclCreation>(buffer, message.CreationsField, (b, i) => AclCreationSerde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static CreateAclsRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var creationsField = Decoder.ReadCompactArray<AclCreation>(ref buffer, (ref ReadOnlyMemory<byte> b) => AclCreationSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Creations'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                creationsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, CreateAclsRequest message)
        {
            buffer = Encoder.WriteCompactArray<AclCreation>(buffer, message.CreationsField, (b, i) => AclCreationSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class AclCreationSerde
        {
            public static AclCreation ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var resourcePatternTypeField = default(sbyte);
                var principalField = Decoder.ReadString(ref buffer);
                var hostField = Decoder.ReadString(ref buffer);
                var operationField = Decoder.ReadInt8(ref buffer);
                var permissionTypeField = Decoder.ReadInt8(ref buffer);
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
            public static Memory<byte> WriteV00(Memory<byte> buffer, AclCreation message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteString(buffer, message.PrincipalField);
                buffer = Encoder.WriteString(buffer, message.HostField);
                buffer = Encoder.WriteInt8(buffer, message.OperationField);
                buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
                return buffer;
            }
            public static AclCreation ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var resourcePatternTypeField = Decoder.ReadInt8(ref buffer);
                var principalField = Decoder.ReadString(ref buffer);
                var hostField = Decoder.ReadString(ref buffer);
                var operationField = Decoder.ReadInt8(ref buffer);
                var permissionTypeField = Decoder.ReadInt8(ref buffer);
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
            public static Memory<byte> WriteV01(Memory<byte> buffer, AclCreation message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteInt8(buffer, message.ResourcePatternTypeField);
                buffer = Encoder.WriteString(buffer, message.PrincipalField);
                buffer = Encoder.WriteString(buffer, message.HostField);
                buffer = Encoder.WriteInt8(buffer, message.OperationField);
                buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
                return buffer;
            }
            public static AclCreation ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadCompactString(ref buffer);
                var resourcePatternTypeField = Decoder.ReadInt8(ref buffer);
                var principalField = Decoder.ReadCompactString(ref buffer);
                var hostField = Decoder.ReadCompactString(ref buffer);
                var operationField = Decoder.ReadInt8(ref buffer);
                var permissionTypeField = Decoder.ReadInt8(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
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
            public static Memory<byte> WriteV02(Memory<byte> buffer, AclCreation message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteInt8(buffer, message.ResourcePatternTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalField);
                buffer = Encoder.WriteCompactString(buffer, message.HostField);
                buffer = Encoder.WriteInt8(buffer, message.OperationField);
                buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static AclCreation ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadCompactString(ref buffer);
                var resourcePatternTypeField = Decoder.ReadInt8(ref buffer);
                var principalField = Decoder.ReadCompactString(ref buffer);
                var hostField = Decoder.ReadCompactString(ref buffer);
                var operationField = Decoder.ReadInt8(ref buffer);
                var permissionTypeField = Decoder.ReadInt8(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
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
            public static Memory<byte> WriteV03(Memory<byte> buffer, AclCreation message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteInt8(buffer, message.ResourcePatternTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.PrincipalField);
                buffer = Encoder.WriteCompactString(buffer, message.HostField);
                buffer = Encoder.WriteInt8(buffer, message.OperationField);
                buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}