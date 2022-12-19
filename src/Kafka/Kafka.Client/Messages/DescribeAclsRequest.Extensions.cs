using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeAclsRequestSerde
    {
        private static readonly DecodeDelegate<DescribeAclsRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<DescribeAclsRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static DescribeAclsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeAclsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeAclsRequest ReadV00(byte[] buffer, ref int index)
        {
            var resourceTypeFilterField = Decoder.ReadInt8(buffer, ref index);
            var resourceNameFilterField = Decoder.ReadNullableString(buffer, ref index);
            var patternTypeFilterField = default(sbyte);
            var principalFilterField = Decoder.ReadNullableString(buffer, ref index);
            var hostFilterField = Decoder.ReadNullableString(buffer, ref index);
            var operationField = Decoder.ReadInt8(buffer, ref index);
            var permissionTypeField = Decoder.ReadInt8(buffer, ref index);
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
        private static int WriteV00(byte[] buffer, int index, DescribeAclsRequest message)
        {
            index = Encoder.WriteInt8(buffer, index, message.ResourceTypeFilterField);
            index = Encoder.WriteNullableString(buffer, index, message.ResourceNameFilterField);
            index = Encoder.WriteNullableString(buffer, index, message.PrincipalFilterField);
            index = Encoder.WriteNullableString(buffer, index, message.HostFilterField);
            index = Encoder.WriteInt8(buffer, index, message.OperationField);
            index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
            return index;
        }
        private static DescribeAclsRequest ReadV01(byte[] buffer, ref int index)
        {
            var resourceTypeFilterField = Decoder.ReadInt8(buffer, ref index);
            var resourceNameFilterField = Decoder.ReadNullableString(buffer, ref index);
            var patternTypeFilterField = Decoder.ReadInt8(buffer, ref index);
            var principalFilterField = Decoder.ReadNullableString(buffer, ref index);
            var hostFilterField = Decoder.ReadNullableString(buffer, ref index);
            var operationField = Decoder.ReadInt8(buffer, ref index);
            var permissionTypeField = Decoder.ReadInt8(buffer, ref index);
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
        private static int WriteV01(byte[] buffer, int index, DescribeAclsRequest message)
        {
            index = Encoder.WriteInt8(buffer, index, message.ResourceTypeFilterField);
            index = Encoder.WriteNullableString(buffer, index, message.ResourceNameFilterField);
            index = Encoder.WriteInt8(buffer, index, message.PatternTypeFilterField);
            index = Encoder.WriteNullableString(buffer, index, message.PrincipalFilterField);
            index = Encoder.WriteNullableString(buffer, index, message.HostFilterField);
            index = Encoder.WriteInt8(buffer, index, message.OperationField);
            index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
            return index;
        }
        private static DescribeAclsRequest ReadV02(byte[] buffer, ref int index)
        {
            var resourceTypeFilterField = Decoder.ReadInt8(buffer, ref index);
            var resourceNameFilterField = Decoder.ReadCompactNullableString(buffer, ref index);
            var patternTypeFilterField = Decoder.ReadInt8(buffer, ref index);
            var principalFilterField = Decoder.ReadCompactNullableString(buffer, ref index);
            var hostFilterField = Decoder.ReadCompactNullableString(buffer, ref index);
            var operationField = Decoder.ReadInt8(buffer, ref index);
            var permissionTypeField = Decoder.ReadInt8(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
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
        private static int WriteV02(byte[] buffer, int index, DescribeAclsRequest message)
        {
            index = Encoder.WriteInt8(buffer, index, message.ResourceTypeFilterField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ResourceNameFilterField);
            index = Encoder.WriteInt8(buffer, index, message.PatternTypeFilterField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.PrincipalFilterField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.HostFilterField);
            index = Encoder.WriteInt8(buffer, index, message.OperationField);
            index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DescribeAclsRequest ReadV03(byte[] buffer, ref int index)
        {
            var resourceTypeFilterField = Decoder.ReadInt8(buffer, ref index);
            var resourceNameFilterField = Decoder.ReadCompactNullableString(buffer, ref index);
            var patternTypeFilterField = Decoder.ReadInt8(buffer, ref index);
            var principalFilterField = Decoder.ReadCompactNullableString(buffer, ref index);
            var hostFilterField = Decoder.ReadCompactNullableString(buffer, ref index);
            var operationField = Decoder.ReadInt8(buffer, ref index);
            var permissionTypeField = Decoder.ReadInt8(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
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
        private static int WriteV03(byte[] buffer, int index, DescribeAclsRequest message)
        {
            index = Encoder.WriteInt8(buffer, index, message.ResourceTypeFilterField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ResourceNameFilterField);
            index = Encoder.WriteInt8(buffer, index, message.PatternTypeFilterField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.PrincipalFilterField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.HostFilterField);
            index = Encoder.WriteInt8(buffer, index, message.OperationField);
            index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}