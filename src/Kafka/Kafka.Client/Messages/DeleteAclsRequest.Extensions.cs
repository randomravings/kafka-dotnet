using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DeleteAclsFilter = Kafka.Client.Messages.DeleteAclsRequest.DeleteAclsFilter;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteAclsRequestSerde
    {
        private static readonly Func<Stream, DeleteAclsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, DeleteAclsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static DeleteAclsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DeleteAclsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DeleteAclsRequest ReadV00(Stream buffer)
        {
            var filtersField = Decoder.ReadArray<DeleteAclsFilter>(buffer, b => DeleteAclsFilterSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Filters'");
            return new(
                filtersField
            );
        }
        private static void WriteV00(Stream buffer, DeleteAclsRequest message)
        {
            Encoder.WriteArray<DeleteAclsFilter>(buffer, message.FiltersField, (b, i) => DeleteAclsFilterSerde.WriteV00(b, i));
        }
        private static DeleteAclsRequest ReadV01(Stream buffer)
        {
            var filtersField = Decoder.ReadArray<DeleteAclsFilter>(buffer, b => DeleteAclsFilterSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Filters'");
            return new(
                filtersField
            );
        }
        private static void WriteV01(Stream buffer, DeleteAclsRequest message)
        {
            Encoder.WriteArray<DeleteAclsFilter>(buffer, message.FiltersField, (b, i) => DeleteAclsFilterSerde.WriteV01(b, i));
        }
        private static DeleteAclsRequest ReadV02(Stream buffer)
        {
            var filtersField = Decoder.ReadCompactArray<DeleteAclsFilter>(buffer, b => DeleteAclsFilterSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Filters'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                filtersField
            );
        }
        private static void WriteV02(Stream buffer, DeleteAclsRequest message)
        {
            Encoder.WriteCompactArray<DeleteAclsFilter>(buffer, message.FiltersField, (b, i) => DeleteAclsFilterSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DeleteAclsRequest ReadV03(Stream buffer)
        {
            var filtersField = Decoder.ReadCompactArray<DeleteAclsFilter>(buffer, b => DeleteAclsFilterSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Filters'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                filtersField
            );
        }
        private static void WriteV03(Stream buffer, DeleteAclsRequest message)
        {
            Encoder.WriteCompactArray<DeleteAclsFilter>(buffer, message.FiltersField, (b, i) => DeleteAclsFilterSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DeleteAclsFilterSerde
        {
            public static DeleteAclsFilter ReadV00(Stream buffer)
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
            public static void WriteV00(Stream buffer, DeleteAclsFilter message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeFilterField);
                Encoder.WriteNullableString(buffer, message.ResourceNameFilterField);
                Encoder.WriteNullableString(buffer, message.PrincipalFilterField);
                Encoder.WriteNullableString(buffer, message.HostFilterField);
                Encoder.WriteInt8(buffer, message.OperationField);
                Encoder.WriteInt8(buffer, message.PermissionTypeField);
            }
            public static DeleteAclsFilter ReadV01(Stream buffer)
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
            public static void WriteV01(Stream buffer, DeleteAclsFilter message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeFilterField);
                Encoder.WriteNullableString(buffer, message.ResourceNameFilterField);
                Encoder.WriteInt8(buffer, message.PatternTypeFilterField);
                Encoder.WriteNullableString(buffer, message.PrincipalFilterField);
                Encoder.WriteNullableString(buffer, message.HostFilterField);
                Encoder.WriteInt8(buffer, message.OperationField);
                Encoder.WriteInt8(buffer, message.PermissionTypeField);
            }
            public static DeleteAclsFilter ReadV02(Stream buffer)
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
            public static void WriteV02(Stream buffer, DeleteAclsFilter message)
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
            public static DeleteAclsFilter ReadV03(Stream buffer)
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
            public static void WriteV03(Stream buffer, DeleteAclsFilter message)
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
}