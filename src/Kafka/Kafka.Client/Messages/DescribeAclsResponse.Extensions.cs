using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeAclsResource = Kafka.Client.Messages.DescribeAclsResponse.DescribeAclsResource;
using AclDescription = Kafka.Client.Messages.DescribeAclsResponse.DescribeAclsResource.AclDescription;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeAclsResponseSerde
    {
        private static readonly Func<Stream, DescribeAclsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, DescribeAclsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static DescribeAclsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeAclsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeAclsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadNullableString(buffer);
            var resourcesField = Decoder.ReadArray<DescribeAclsResource>(buffer, b => DescribeAclsResourceSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField
            );
        }
        private static void WriteV00(Stream buffer, DescribeAclsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteArray<DescribeAclsResource>(buffer, message.ResourcesField, (b, i) => DescribeAclsResourceSerde.WriteV00(b, i));
        }
        private static DescribeAclsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadNullableString(buffer);
            var resourcesField = Decoder.ReadArray<DescribeAclsResource>(buffer, b => DescribeAclsResourceSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField
            );
        }
        private static void WriteV01(Stream buffer, DescribeAclsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteArray<DescribeAclsResource>(buffer, message.ResourcesField, (b, i) => DescribeAclsResourceSerde.WriteV01(b, i));
        }
        private static DescribeAclsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer);
            var resourcesField = Decoder.ReadCompactArray<DescribeAclsResource>(buffer, b => DescribeAclsResourceSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField
            );
        }
        private static void WriteV02(Stream buffer, DescribeAclsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteCompactArray<DescribeAclsResource>(buffer, message.ResourcesField, (b, i) => DescribeAclsResourceSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DescribeAclsResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer);
            var resourcesField = Decoder.ReadCompactArray<DescribeAclsResource>(buffer, b => DescribeAclsResourceSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField
            );
        }
        private static void WriteV03(Stream buffer, DescribeAclsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteCompactArray<DescribeAclsResource>(buffer, message.ResourcesField, (b, i) => DescribeAclsResourceSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DescribeAclsResourceSerde
        {
            public static DescribeAclsResource ReadV00(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var patternTypeField = default(sbyte);
                var aclsField = Decoder.ReadArray<AclDescription>(buffer, b => AclDescriptionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Acls'");
                return new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField
                );
            }
            public static void WriteV00(Stream buffer, DescribeAclsResource message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteArray<AclDescription>(buffer, message.AclsField, (b, i) => AclDescriptionSerde.WriteV00(b, i));
            }
            public static DescribeAclsResource ReadV01(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var patternTypeField = Decoder.ReadInt8(buffer);
                var aclsField = Decoder.ReadArray<AclDescription>(buffer, b => AclDescriptionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Acls'");
                return new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField
                );
            }
            public static void WriteV01(Stream buffer, DescribeAclsResource message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteInt8(buffer, message.PatternTypeField);
                Encoder.WriteArray<AclDescription>(buffer, message.AclsField, (b, i) => AclDescriptionSerde.WriteV01(b, i));
            }
            public static DescribeAclsResource ReadV02(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadCompactString(buffer);
                var patternTypeField = Decoder.ReadInt8(buffer);
                var aclsField = Decoder.ReadCompactArray<AclDescription>(buffer, b => AclDescriptionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Acls'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField
                );
            }
            public static void WriteV02(Stream buffer, DescribeAclsResource message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteCompactString(buffer, message.ResourceNameField);
                Encoder.WriteInt8(buffer, message.PatternTypeField);
                Encoder.WriteCompactArray<AclDescription>(buffer, message.AclsField, (b, i) => AclDescriptionSerde.WriteV02(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static DescribeAclsResource ReadV03(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadCompactString(buffer);
                var patternTypeField = Decoder.ReadInt8(buffer);
                var aclsField = Decoder.ReadCompactArray<AclDescription>(buffer, b => AclDescriptionSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Acls'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField
                );
            }
            public static void WriteV03(Stream buffer, DescribeAclsResource message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteCompactString(buffer, message.ResourceNameField);
                Encoder.WriteInt8(buffer, message.PatternTypeField);
                Encoder.WriteCompactArray<AclDescription>(buffer, message.AclsField, (b, i) => AclDescriptionSerde.WriteV03(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class AclDescriptionSerde
            {
                public static AclDescription ReadV00(Stream buffer)
                {
                    var principalField = Decoder.ReadString(buffer);
                    var hostField = Decoder.ReadString(buffer);
                    var operationField = Decoder.ReadInt8(buffer);
                    var permissionTypeField = Decoder.ReadInt8(buffer);
                    return new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static void WriteV00(Stream buffer, AclDescription message)
                {
                    Encoder.WriteString(buffer, message.PrincipalField);
                    Encoder.WriteString(buffer, message.HostField);
                    Encoder.WriteInt8(buffer, message.OperationField);
                    Encoder.WriteInt8(buffer, message.PermissionTypeField);
                }
                public static AclDescription ReadV01(Stream buffer)
                {
                    var principalField = Decoder.ReadString(buffer);
                    var hostField = Decoder.ReadString(buffer);
                    var operationField = Decoder.ReadInt8(buffer);
                    var permissionTypeField = Decoder.ReadInt8(buffer);
                    return new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static void WriteV01(Stream buffer, AclDescription message)
                {
                    Encoder.WriteString(buffer, message.PrincipalField);
                    Encoder.WriteString(buffer, message.HostField);
                    Encoder.WriteInt8(buffer, message.OperationField);
                    Encoder.WriteInt8(buffer, message.PermissionTypeField);
                }
                public static AclDescription ReadV02(Stream buffer)
                {
                    var principalField = Decoder.ReadCompactString(buffer);
                    var hostField = Decoder.ReadCompactString(buffer);
                    var operationField = Decoder.ReadInt8(buffer);
                    var permissionTypeField = Decoder.ReadInt8(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static void WriteV02(Stream buffer, AclDescription message)
                {
                    Encoder.WriteCompactString(buffer, message.PrincipalField);
                    Encoder.WriteCompactString(buffer, message.HostField);
                    Encoder.WriteInt8(buffer, message.OperationField);
                    Encoder.WriteInt8(buffer, message.PermissionTypeField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static AclDescription ReadV03(Stream buffer)
                {
                    var principalField = Decoder.ReadCompactString(buffer);
                    var hostField = Decoder.ReadCompactString(buffer);
                    var operationField = Decoder.ReadInt8(buffer);
                    var permissionTypeField = Decoder.ReadInt8(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static void WriteV03(Stream buffer, AclDescription message)
                {
                    Encoder.WriteCompactString(buffer, message.PrincipalField);
                    Encoder.WriteCompactString(buffer, message.HostField);
                    Encoder.WriteInt8(buffer, message.OperationField);
                    Encoder.WriteInt8(buffer, message.PermissionTypeField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}