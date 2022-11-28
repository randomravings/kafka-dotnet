using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AclDescription = Kafka.Client.Messages.DescribeAclsResponse.DescribeAclsResource.AclDescription;
using DescribeAclsResource = Kafka.Client.Messages.DescribeAclsResponse.DescribeAclsResource;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeAclsResponseSerde
    {
        private static readonly DecodeDelegate<DescribeAclsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<DescribeAclsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static DescribeAclsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeAclsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeAclsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadNullableString(ref buffer);
            var resourcesField = Decoder.ReadArray<DescribeAclsResource>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeAclsResourceSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeAclsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteArray<DescribeAclsResource>(buffer, message.ResourcesField, (b, i) => DescribeAclsResourceSerde.WriteV00(b, i));
            return buffer;
        }
        private static DescribeAclsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadNullableString(ref buffer);
            var resourcesField = Decoder.ReadArray<DescribeAclsResource>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeAclsResourceSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DescribeAclsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteArray<DescribeAclsResource>(buffer, message.ResourcesField, (b, i) => DescribeAclsResourceSerde.WriteV01(b, i));
            return buffer;
        }
        private static DescribeAclsResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
            var resourcesField = Decoder.ReadCompactArray<DescribeAclsResource>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeAclsResourceSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DescribeAclsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteCompactArray<DescribeAclsResource>(buffer, message.ResourcesField, (b, i) => DescribeAclsResourceSerde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DescribeAclsResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
            var resourcesField = Decoder.ReadCompactArray<DescribeAclsResource>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeAclsResourceSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, DescribeAclsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteCompactArray<DescribeAclsResource>(buffer, message.ResourcesField, (b, i) => DescribeAclsResourceSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DescribeAclsResourceSerde
        {
            public static DescribeAclsResource ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var patternTypeField = default(sbyte);
                var aclsField = Decoder.ReadArray<AclDescription>(ref buffer, (ref ReadOnlyMemory<byte> b) => AclDescriptionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Acls'");
                return new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DescribeAclsResource message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteArray<AclDescription>(buffer, message.AclsField, (b, i) => AclDescriptionSerde.WriteV00(b, i));
                return buffer;
            }
            public static DescribeAclsResource ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var patternTypeField = Decoder.ReadInt8(ref buffer);
                var aclsField = Decoder.ReadArray<AclDescription>(ref buffer, (ref ReadOnlyMemory<byte> b) => AclDescriptionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Acls'");
                return new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, DescribeAclsResource message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteInt8(buffer, message.PatternTypeField);
                buffer = Encoder.WriteArray<AclDescription>(buffer, message.AclsField, (b, i) => AclDescriptionSerde.WriteV01(b, i));
                return buffer;
            }
            public static DescribeAclsResource ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadCompactString(ref buffer);
                var patternTypeField = Decoder.ReadInt8(ref buffer);
                var aclsField = Decoder.ReadCompactArray<AclDescription>(ref buffer, (ref ReadOnlyMemory<byte> b) => AclDescriptionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Acls'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, DescribeAclsResource message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteInt8(buffer, message.PatternTypeField);
                buffer = Encoder.WriteCompactArray<AclDescription>(buffer, message.AclsField, (b, i) => AclDescriptionSerde.WriteV02(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static DescribeAclsResource ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadCompactString(ref buffer);
                var patternTypeField = Decoder.ReadInt8(ref buffer);
                var aclsField = Decoder.ReadCompactArray<AclDescription>(ref buffer, (ref ReadOnlyMemory<byte> b) => AclDescriptionSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Acls'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, DescribeAclsResource message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteInt8(buffer, message.PatternTypeField);
                buffer = Encoder.WriteCompactArray<AclDescription>(buffer, message.AclsField, (b, i) => AclDescriptionSerde.WriteV03(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class AclDescriptionSerde
            {
                public static AclDescription ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var principalField = Decoder.ReadString(ref buffer);
                    var hostField = Decoder.ReadString(ref buffer);
                    var operationField = Decoder.ReadInt8(ref buffer);
                    var permissionTypeField = Decoder.ReadInt8(ref buffer);
                    return new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, AclDescription message)
                {
                    buffer = Encoder.WriteString(buffer, message.PrincipalField);
                    buffer = Encoder.WriteString(buffer, message.HostField);
                    buffer = Encoder.WriteInt8(buffer, message.OperationField);
                    buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
                    return buffer;
                }
                public static AclDescription ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var principalField = Decoder.ReadString(ref buffer);
                    var hostField = Decoder.ReadString(ref buffer);
                    var operationField = Decoder.ReadInt8(ref buffer);
                    var permissionTypeField = Decoder.ReadInt8(ref buffer);
                    return new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, AclDescription message)
                {
                    buffer = Encoder.WriteString(buffer, message.PrincipalField);
                    buffer = Encoder.WriteString(buffer, message.HostField);
                    buffer = Encoder.WriteInt8(buffer, message.OperationField);
                    buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
                    return buffer;
                }
                public static AclDescription ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var principalField = Decoder.ReadCompactString(ref buffer);
                    var hostField = Decoder.ReadCompactString(ref buffer);
                    var operationField = Decoder.ReadInt8(ref buffer);
                    var permissionTypeField = Decoder.ReadInt8(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, AclDescription message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.PrincipalField);
                    buffer = Encoder.WriteCompactString(buffer, message.HostField);
                    buffer = Encoder.WriteInt8(buffer, message.OperationField);
                    buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static AclDescription ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var principalField = Decoder.ReadCompactString(ref buffer);
                    var hostField = Decoder.ReadCompactString(ref buffer);
                    var operationField = Decoder.ReadInt8(ref buffer);
                    var permissionTypeField = Decoder.ReadInt8(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, AclDescription message)
                {
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
}