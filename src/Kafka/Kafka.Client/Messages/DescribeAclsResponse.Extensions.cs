using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AclDescription = Kafka.Client.Messages.DescribeAclsResponse.DescribeAclsResource.AclDescription;
using DescribeAclsResource = Kafka.Client.Messages.DescribeAclsResponse.DescribeAclsResource;

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
        public static DescribeAclsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeAclsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeAclsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
            var resourcesField = Decoder.ReadArray<DescribeAclsResource>(buffer, ref index, DescribeAclsResourceSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeAclsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteArray<DescribeAclsResource>(buffer, index, message.ResourcesField, DescribeAclsResourceSerde.WriteV00);
            return index;
        }
        private static DescribeAclsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
            var resourcesField = Decoder.ReadArray<DescribeAclsResource>(buffer, ref index, DescribeAclsResourceSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DescribeAclsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteArray<DescribeAclsResource>(buffer, index, message.ResourcesField, DescribeAclsResourceSerde.WriteV01);
            return index;
        }
        private static DescribeAclsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
            var resourcesField = Decoder.ReadCompactArray<DescribeAclsResource>(buffer, ref index, DescribeAclsResourceSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField
            );
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
        private static DescribeAclsResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
            var resourcesField = Decoder.ReadCompactArray<DescribeAclsResource>(buffer, ref index, DescribeAclsResourceSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField
            );
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
        private static class DescribeAclsResourceSerde
        {
            public static DescribeAclsResource ReadV00(byte[] buffer, ref int index)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var resourceNameField = Decoder.ReadString(buffer, ref index);
                var patternTypeField = default(sbyte);
                var aclsField = Decoder.ReadArray<AclDescription>(buffer, ref index, AclDescriptionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Acls'");
                return new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, DescribeAclsResource message)
            {
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteArray<AclDescription>(buffer, index, message.AclsField, AclDescriptionSerde.WriteV00);
                return index;
            }
            public static DescribeAclsResource ReadV01(byte[] buffer, ref int index)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var resourceNameField = Decoder.ReadString(buffer, ref index);
                var patternTypeField = Decoder.ReadInt8(buffer, ref index);
                var aclsField = Decoder.ReadArray<AclDescription>(buffer, ref index, AclDescriptionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Acls'");
                return new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, DescribeAclsResource message)
            {
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteInt8(buffer, index, message.PatternTypeField);
                index = Encoder.WriteArray<AclDescription>(buffer, index, message.AclsField, AclDescriptionSerde.WriteV01);
                return index;
            }
            public static DescribeAclsResource ReadV02(byte[] buffer, ref int index)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var resourceNameField = Decoder.ReadCompactString(buffer, ref index);
                var patternTypeField = Decoder.ReadInt8(buffer, ref index);
                var aclsField = Decoder.ReadCompactArray<AclDescription>(buffer, ref index, AclDescriptionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Acls'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField
                );
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
            public static DescribeAclsResource ReadV03(byte[] buffer, ref int index)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var resourceNameField = Decoder.ReadCompactString(buffer, ref index);
                var patternTypeField = Decoder.ReadInt8(buffer, ref index);
                var aclsField = Decoder.ReadCompactArray<AclDescription>(buffer, ref index, AclDescriptionSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Acls'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField
                );
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
            private static class AclDescriptionSerde
            {
                public static AclDescription ReadV00(byte[] buffer, ref int index)
                {
                    var principalField = Decoder.ReadString(buffer, ref index);
                    var hostField = Decoder.ReadString(buffer, ref index);
                    var operationField = Decoder.ReadInt8(buffer, ref index);
                    var permissionTypeField = Decoder.ReadInt8(buffer, ref index);
                    return new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, AclDescription message)
                {
                    index = Encoder.WriteString(buffer, index, message.PrincipalField);
                    index = Encoder.WriteString(buffer, index, message.HostField);
                    index = Encoder.WriteInt8(buffer, index, message.OperationField);
                    index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
                    return index;
                }
                public static AclDescription ReadV01(byte[] buffer, ref int index)
                {
                    var principalField = Decoder.ReadString(buffer, ref index);
                    var hostField = Decoder.ReadString(buffer, ref index);
                    var operationField = Decoder.ReadInt8(buffer, ref index);
                    var permissionTypeField = Decoder.ReadInt8(buffer, ref index);
                    return new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, AclDescription message)
                {
                    index = Encoder.WriteString(buffer, index, message.PrincipalField);
                    index = Encoder.WriteString(buffer, index, message.HostField);
                    index = Encoder.WriteInt8(buffer, index, message.OperationField);
                    index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
                    return index;
                }
                public static AclDescription ReadV02(byte[] buffer, ref int index)
                {
                    var principalField = Decoder.ReadCompactString(buffer, ref index);
                    var hostField = Decoder.ReadCompactString(buffer, ref index);
                    var operationField = Decoder.ReadInt8(buffer, ref index);
                    var permissionTypeField = Decoder.ReadInt8(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
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
                public static AclDescription ReadV03(byte[] buffer, ref int index)
                {
                    var principalField = Decoder.ReadCompactString(buffer, ref index);
                    var hostField = Decoder.ReadCompactString(buffer, ref index);
                    var operationField = Decoder.ReadInt8(buffer, ref index);
                    var permissionTypeField = Decoder.ReadInt8(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
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