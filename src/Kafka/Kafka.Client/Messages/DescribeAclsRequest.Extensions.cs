using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeAclsRequestSerde
    {
        private static readonly DecodeDelegate<DescribeAclsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<DescribeAclsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static DescribeAclsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeAclsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeAclsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var resourceTypeFilterField = Decoder.ReadInt8(ref buffer);
            var resourceNameFilterField = Decoder.ReadNullableString(ref buffer);
            var patternTypeFilterField = default(sbyte);
            var principalFilterField = Decoder.ReadNullableString(ref buffer);
            var hostFilterField = Decoder.ReadNullableString(ref buffer);
            var operationField = Decoder.ReadInt8(ref buffer);
            var permissionTypeField = Decoder.ReadInt8(ref buffer);
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
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeAclsRequest message)
        {
            buffer = Encoder.WriteInt8(buffer, message.ResourceTypeFilterField);
            buffer = Encoder.WriteNullableString(buffer, message.ResourceNameFilterField);
            buffer = Encoder.WriteNullableString(buffer, message.PrincipalFilterField);
            buffer = Encoder.WriteNullableString(buffer, message.HostFilterField);
            buffer = Encoder.WriteInt8(buffer, message.OperationField);
            buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
            return buffer;
        }
        private static DescribeAclsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var resourceTypeFilterField = Decoder.ReadInt8(ref buffer);
            var resourceNameFilterField = Decoder.ReadNullableString(ref buffer);
            var patternTypeFilterField = Decoder.ReadInt8(ref buffer);
            var principalFilterField = Decoder.ReadNullableString(ref buffer);
            var hostFilterField = Decoder.ReadNullableString(ref buffer);
            var operationField = Decoder.ReadInt8(ref buffer);
            var permissionTypeField = Decoder.ReadInt8(ref buffer);
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
        private static Memory<byte> WriteV01(Memory<byte> buffer, DescribeAclsRequest message)
        {
            buffer = Encoder.WriteInt8(buffer, message.ResourceTypeFilterField);
            buffer = Encoder.WriteNullableString(buffer, message.ResourceNameFilterField);
            buffer = Encoder.WriteInt8(buffer, message.PatternTypeFilterField);
            buffer = Encoder.WriteNullableString(buffer, message.PrincipalFilterField);
            buffer = Encoder.WriteNullableString(buffer, message.HostFilterField);
            buffer = Encoder.WriteInt8(buffer, message.OperationField);
            buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
            return buffer;
        }
        private static DescribeAclsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var resourceTypeFilterField = Decoder.ReadInt8(ref buffer);
            var resourceNameFilterField = Decoder.ReadCompactNullableString(ref buffer);
            var patternTypeFilterField = Decoder.ReadInt8(ref buffer);
            var principalFilterField = Decoder.ReadCompactNullableString(ref buffer);
            var hostFilterField = Decoder.ReadCompactNullableString(ref buffer);
            var operationField = Decoder.ReadInt8(ref buffer);
            var permissionTypeField = Decoder.ReadInt8(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV02(Memory<byte> buffer, DescribeAclsRequest message)
        {
            buffer = Encoder.WriteInt8(buffer, message.ResourceTypeFilterField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ResourceNameFilterField);
            buffer = Encoder.WriteInt8(buffer, message.PatternTypeFilterField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.PrincipalFilterField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.HostFilterField);
            buffer = Encoder.WriteInt8(buffer, message.OperationField);
            buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DescribeAclsRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var resourceTypeFilterField = Decoder.ReadInt8(ref buffer);
            var resourceNameFilterField = Decoder.ReadCompactNullableString(ref buffer);
            var patternTypeFilterField = Decoder.ReadInt8(ref buffer);
            var principalFilterField = Decoder.ReadCompactNullableString(ref buffer);
            var hostFilterField = Decoder.ReadCompactNullableString(ref buffer);
            var operationField = Decoder.ReadInt8(ref buffer);
            var permissionTypeField = Decoder.ReadInt8(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV03(Memory<byte> buffer, DescribeAclsRequest message)
        {
            buffer = Encoder.WriteInt8(buffer, message.ResourceTypeFilterField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ResourceNameFilterField);
            buffer = Encoder.WriteInt8(buffer, message.PatternTypeFilterField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.PrincipalFilterField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.HostFilterField);
            buffer = Encoder.WriteInt8(buffer, message.OperationField);
            buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}