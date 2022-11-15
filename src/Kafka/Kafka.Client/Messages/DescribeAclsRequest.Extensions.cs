using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeAclsRequestSerde
    {
        private static readonly Func<Stream, DescribeAclsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, DescribeAclsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static DescribeAclsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeAclsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeAclsRequest ReadV00(Stream buffer)
        {
            var resourceTypeFilterField = Decoder.ReadInt8(buffer);
            var resourceNameFilterField = Decoder.ReadNullableString(buffer);
            var patternTypeFilterField = default(sbyte);
            var principalFilterField = Decoder.ReadNullableString(buffer);
            var hostFilterField = Decoder.ReadNullableString(buffer);
            var operationField = Decoder.ReadInt8(buffer);
            var permissionTypeField = Decoder.ReadInt8(buffer);
            return new(
                resourceTypeFilterField,
                resourceNameFilterField,
                patternTypeFilterField,
                principalFilterField,
                hostFilterField,
                operationField,
                permissionTypeField
            );
        }
        private static void WriteV00(Stream buffer, DescribeAclsRequest message)
        {
            Encoder.WriteInt8(buffer, message.ResourceTypeFilterField);
            Encoder.WriteNullableString(buffer, message.ResourceNameFilterField);
            Encoder.WriteNullableString(buffer, message.PrincipalFilterField);
            Encoder.WriteNullableString(buffer, message.HostFilterField);
            Encoder.WriteInt8(buffer, message.OperationField);
            Encoder.WriteInt8(buffer, message.PermissionTypeField);
        }
        private static DescribeAclsRequest ReadV01(Stream buffer)
        {
            var resourceTypeFilterField = Decoder.ReadInt8(buffer);
            var resourceNameFilterField = Decoder.ReadNullableString(buffer);
            var patternTypeFilterField = Decoder.ReadInt8(buffer);
            var principalFilterField = Decoder.ReadNullableString(buffer);
            var hostFilterField = Decoder.ReadNullableString(buffer);
            var operationField = Decoder.ReadInt8(buffer);
            var permissionTypeField = Decoder.ReadInt8(buffer);
            return new(
                resourceTypeFilterField,
                resourceNameFilterField,
                patternTypeFilterField,
                principalFilterField,
                hostFilterField,
                operationField,
                permissionTypeField
            );
        }
        private static void WriteV01(Stream buffer, DescribeAclsRequest message)
        {
            Encoder.WriteInt8(buffer, message.ResourceTypeFilterField);
            Encoder.WriteNullableString(buffer, message.ResourceNameFilterField);
            Encoder.WriteInt8(buffer, message.PatternTypeFilterField);
            Encoder.WriteNullableString(buffer, message.PrincipalFilterField);
            Encoder.WriteNullableString(buffer, message.HostFilterField);
            Encoder.WriteInt8(buffer, message.OperationField);
            Encoder.WriteInt8(buffer, message.PermissionTypeField);
        }
        private static DescribeAclsRequest ReadV02(Stream buffer)
        {
            var resourceTypeFilterField = Decoder.ReadInt8(buffer);
            var resourceNameFilterField = Decoder.ReadCompactNullableString(buffer);
            var patternTypeFilterField = Decoder.ReadInt8(buffer);
            var principalFilterField = Decoder.ReadCompactNullableString(buffer);
            var hostFilterField = Decoder.ReadCompactNullableString(buffer);
            var operationField = Decoder.ReadInt8(buffer);
            var permissionTypeField = Decoder.ReadInt8(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                resourceTypeFilterField,
                resourceNameFilterField,
                patternTypeFilterField,
                principalFilterField,
                hostFilterField,
                operationField,
                permissionTypeField
            );
        }
        private static void WriteV02(Stream buffer, DescribeAclsRequest message)
        {
            Encoder.WriteInt8(buffer, message.ResourceTypeFilterField);
            Encoder.WriteCompactNullableString(buffer, message.ResourceNameFilterField);
            Encoder.WriteInt8(buffer, message.PatternTypeFilterField);
            Encoder.WriteCompactNullableString(buffer, message.PrincipalFilterField);
            Encoder.WriteCompactNullableString(buffer, message.HostFilterField);
            Encoder.WriteInt8(buffer, message.OperationField);
            Encoder.WriteInt8(buffer, message.PermissionTypeField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DescribeAclsRequest ReadV03(Stream buffer)
        {
            var resourceTypeFilterField = Decoder.ReadInt8(buffer);
            var resourceNameFilterField = Decoder.ReadCompactNullableString(buffer);
            var patternTypeFilterField = Decoder.ReadInt8(buffer);
            var principalFilterField = Decoder.ReadCompactNullableString(buffer);
            var hostFilterField = Decoder.ReadCompactNullableString(buffer);
            var operationField = Decoder.ReadInt8(buffer);
            var permissionTypeField = Decoder.ReadInt8(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                resourceTypeFilterField,
                resourceNameFilterField,
                patternTypeFilterField,
                principalFilterField,
                hostFilterField,
                operationField,
                permissionTypeField
            );
        }
        private static void WriteV03(Stream buffer, DescribeAclsRequest message)
        {
            Encoder.WriteInt8(buffer, message.ResourceTypeFilterField);
            Encoder.WriteCompactNullableString(buffer, message.ResourceNameFilterField);
            Encoder.WriteInt8(buffer, message.PatternTypeFilterField);
            Encoder.WriteCompactNullableString(buffer, message.PrincipalFilterField);
            Encoder.WriteCompactNullableString(buffer, message.HostFilterField);
            Encoder.WriteInt8(buffer, message.OperationField);
            Encoder.WriteInt8(buffer, message.PermissionTypeField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}