using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DeleteAclsFilter = Kafka.Client.Messages.DeleteAclsRequest.DeleteAclsFilter;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteAclsRequestSerde
    {
        private static readonly DecodeDelegate<DeleteAclsRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<DeleteAclsRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static DeleteAclsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DeleteAclsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DeleteAclsRequest ReadV00(byte[] buffer, ref int index)
        {
            var filtersField = Decoder.ReadArray<DeleteAclsFilter>(buffer, ref index, DeleteAclsFilterSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Filters'");
            return new(
                filtersField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DeleteAclsRequest message)
        {
            index = Encoder.WriteArray<DeleteAclsFilter>(buffer, index, message.FiltersField, DeleteAclsFilterSerde.WriteV00);
            return index;
        }
        private static DeleteAclsRequest ReadV01(byte[] buffer, ref int index)
        {
            var filtersField = Decoder.ReadArray<DeleteAclsFilter>(buffer, ref index, DeleteAclsFilterSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Filters'");
            return new(
                filtersField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DeleteAclsRequest message)
        {
            index = Encoder.WriteArray<DeleteAclsFilter>(buffer, index, message.FiltersField, DeleteAclsFilterSerde.WriteV01);
            return index;
        }
        private static DeleteAclsRequest ReadV02(byte[] buffer, ref int index)
        {
            var filtersField = Decoder.ReadCompactArray<DeleteAclsFilter>(buffer, ref index, DeleteAclsFilterSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Filters'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                filtersField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DeleteAclsRequest message)
        {
            index = Encoder.WriteCompactArray<DeleteAclsFilter>(buffer, index, message.FiltersField, DeleteAclsFilterSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DeleteAclsRequest ReadV03(byte[] buffer, ref int index)
        {
            var filtersField = Decoder.ReadCompactArray<DeleteAclsFilter>(buffer, ref index, DeleteAclsFilterSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Filters'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                filtersField
            );
        }
        private static int WriteV03(byte[] buffer, int index, DeleteAclsRequest message)
        {
            index = Encoder.WriteCompactArray<DeleteAclsFilter>(buffer, index, message.FiltersField, DeleteAclsFilterSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DeleteAclsFilterSerde
        {
            public static DeleteAclsFilter ReadV00(byte[] buffer, ref int index)
            {
                var ResourceTypeFilterField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameFilterField = Decoder.ReadNullableString(buffer, ref index);
                var PatternTypeFilterField = default(sbyte);
                var PrincipalFilterField = Decoder.ReadNullableString(buffer, ref index);
                var HostFilterField = Decoder.ReadNullableString(buffer, ref index);
                var OperationField = Decoder.ReadInt8(buffer, ref index);
                var PermissionTypeField = Decoder.ReadInt8(buffer, ref index);
                return new(
                    ResourceTypeFilterField,
                    ResourceNameFilterField,
                    PatternTypeFilterField,
                    PrincipalFilterField,
                    HostFilterField,
                    OperationField,
                    PermissionTypeField
                );
            }
            public static int WriteV00(byte[] buffer, int index, DeleteAclsFilter message)
            {
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeFilterField);
                index = Encoder.WriteNullableString(buffer, index, message.ResourceNameFilterField);
                index = Encoder.WriteNullableString(buffer, index, message.PrincipalFilterField);
                index = Encoder.WriteNullableString(buffer, index, message.HostFilterField);
                index = Encoder.WriteInt8(buffer, index, message.OperationField);
                index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
                return index;
            }
            public static DeleteAclsFilter ReadV01(byte[] buffer, ref int index)
            {
                var ResourceTypeFilterField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameFilterField = Decoder.ReadNullableString(buffer, ref index);
                var PatternTypeFilterField = Decoder.ReadInt8(buffer, ref index);
                var PrincipalFilterField = Decoder.ReadNullableString(buffer, ref index);
                var HostFilterField = Decoder.ReadNullableString(buffer, ref index);
                var OperationField = Decoder.ReadInt8(buffer, ref index);
                var PermissionTypeField = Decoder.ReadInt8(buffer, ref index);
                return new(
                    ResourceTypeFilterField,
                    ResourceNameFilterField,
                    PatternTypeFilterField,
                    PrincipalFilterField,
                    HostFilterField,
                    OperationField,
                    PermissionTypeField
                );
            }
            public static int WriteV01(byte[] buffer, int index, DeleteAclsFilter message)
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
            public static DeleteAclsFilter ReadV02(byte[] buffer, ref int index)
            {
                var ResourceTypeFilterField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameFilterField = Decoder.ReadCompactNullableString(buffer, ref index);
                var PatternTypeFilterField = Decoder.ReadInt8(buffer, ref index);
                var PrincipalFilterField = Decoder.ReadCompactNullableString(buffer, ref index);
                var HostFilterField = Decoder.ReadCompactNullableString(buffer, ref index);
                var OperationField = Decoder.ReadInt8(buffer, ref index);
                var PermissionTypeField = Decoder.ReadInt8(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ResourceTypeFilterField,
                    ResourceNameFilterField,
                    PatternTypeFilterField,
                    PrincipalFilterField,
                    HostFilterField,
                    OperationField,
                    PermissionTypeField
                );
            }
            public static int WriteV02(byte[] buffer, int index, DeleteAclsFilter message)
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
            public static DeleteAclsFilter ReadV03(byte[] buffer, ref int index)
            {
                var ResourceTypeFilterField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameFilterField = Decoder.ReadCompactNullableString(buffer, ref index);
                var PatternTypeFilterField = Decoder.ReadInt8(buffer, ref index);
                var PrincipalFilterField = Decoder.ReadCompactNullableString(buffer, ref index);
                var HostFilterField = Decoder.ReadCompactNullableString(buffer, ref index);
                var OperationField = Decoder.ReadInt8(buffer, ref index);
                var PermissionTypeField = Decoder.ReadInt8(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ResourceTypeFilterField,
                    ResourceNameFilterField,
                    PatternTypeFilterField,
                    PrincipalFilterField,
                    HostFilterField,
                    OperationField,
                    PermissionTypeField
                );
            }
            public static int WriteV03(byte[] buffer, int index, DeleteAclsFilter message)
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
}