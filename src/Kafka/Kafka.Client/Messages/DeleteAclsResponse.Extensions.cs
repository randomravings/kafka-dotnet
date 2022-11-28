using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DeleteAclsMatchingAcl = Kafka.Client.Messages.DeleteAclsResponse.DeleteAclsFilterResult.DeleteAclsMatchingAcl;
using DeleteAclsFilterResult = Kafka.Client.Messages.DeleteAclsResponse.DeleteAclsFilterResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteAclsResponseSerde
    {
        private static readonly DecodeDelegate<DeleteAclsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<DeleteAclsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static DeleteAclsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DeleteAclsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DeleteAclsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var filterResultsField = Decoder.ReadArray<DeleteAclsFilterResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteAclsFilterResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'FilterResults'");
            return new(
                throttleTimeMsField,
                filterResultsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DeleteAclsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DeleteAclsFilterResult>(buffer, message.FilterResultsField, (b, i) => DeleteAclsFilterResultSerde.WriteV00(b, i));
            return buffer;
        }
        private static DeleteAclsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var filterResultsField = Decoder.ReadArray<DeleteAclsFilterResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteAclsFilterResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'FilterResults'");
            return new(
                throttleTimeMsField,
                filterResultsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DeleteAclsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DeleteAclsFilterResult>(buffer, message.FilterResultsField, (b, i) => DeleteAclsFilterResultSerde.WriteV01(b, i));
            return buffer;
        }
        private static DeleteAclsResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var filterResultsField = Decoder.ReadCompactArray<DeleteAclsFilterResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteAclsFilterResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'FilterResults'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                filterResultsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DeleteAclsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<DeleteAclsFilterResult>(buffer, message.FilterResultsField, (b, i) => DeleteAclsFilterResultSerde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static DeleteAclsResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var filterResultsField = Decoder.ReadCompactArray<DeleteAclsFilterResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteAclsFilterResultSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'FilterResults'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                filterResultsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, DeleteAclsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<DeleteAclsFilterResult>(buffer, message.FilterResultsField, (b, i) => DeleteAclsFilterResultSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DeleteAclsFilterResultSerde
        {
            public static DeleteAclsFilterResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
                var matchingAclsField = Decoder.ReadArray<DeleteAclsMatchingAcl>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteAclsMatchingAclSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DeleteAclsFilterResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteArray<DeleteAclsMatchingAcl>(buffer, message.MatchingAclsField, (b, i) => DeleteAclsMatchingAclSerde.WriteV00(b, i));
                return buffer;
            }
            public static DeleteAclsFilterResult ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
                var matchingAclsField = Decoder.ReadArray<DeleteAclsMatchingAcl>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteAclsMatchingAclSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, DeleteAclsFilterResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteArray<DeleteAclsMatchingAcl>(buffer, message.MatchingAclsField, (b, i) => DeleteAclsMatchingAclSerde.WriteV01(b, i));
                return buffer;
            }
            public static DeleteAclsFilterResult ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                var matchingAclsField = Decoder.ReadCompactArray<DeleteAclsMatchingAcl>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteAclsMatchingAclSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, DeleteAclsFilterResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteCompactArray<DeleteAclsMatchingAcl>(buffer, message.MatchingAclsField, (b, i) => DeleteAclsMatchingAclSerde.WriteV02(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static DeleteAclsFilterResult ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                var matchingAclsField = Decoder.ReadCompactArray<DeleteAclsMatchingAcl>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteAclsMatchingAclSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, DeleteAclsFilterResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteCompactArray<DeleteAclsMatchingAcl>(buffer, message.MatchingAclsField, (b, i) => DeleteAclsMatchingAclSerde.WriteV03(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class DeleteAclsMatchingAclSerde
            {
                public static DeleteAclsMatchingAcl ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var errorMessageField = Decoder.ReadNullableString(ref buffer);
                    var resourceTypeField = Decoder.ReadInt8(ref buffer);
                    var resourceNameField = Decoder.ReadString(ref buffer);
                    var patternTypeField = default(sbyte);
                    var principalField = Decoder.ReadString(ref buffer);
                    var hostField = Decoder.ReadString(ref buffer);
                    var operationField = Decoder.ReadInt8(ref buffer);
                    var permissionTypeField = Decoder.ReadInt8(ref buffer);
                    return new(
                        errorCodeField,
                        errorMessageField,
                        resourceTypeField,
                        resourceNameField,
                        patternTypeField,
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, DeleteAclsMatchingAcl message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                    buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                    buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                    buffer = Encoder.WriteString(buffer, message.PrincipalField);
                    buffer = Encoder.WriteString(buffer, message.HostField);
                    buffer = Encoder.WriteInt8(buffer, message.OperationField);
                    buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
                    return buffer;
                }
                public static DeleteAclsMatchingAcl ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var errorMessageField = Decoder.ReadNullableString(ref buffer);
                    var resourceTypeField = Decoder.ReadInt8(ref buffer);
                    var resourceNameField = Decoder.ReadString(ref buffer);
                    var patternTypeField = Decoder.ReadInt8(ref buffer);
                    var principalField = Decoder.ReadString(ref buffer);
                    var hostField = Decoder.ReadString(ref buffer);
                    var operationField = Decoder.ReadInt8(ref buffer);
                    var permissionTypeField = Decoder.ReadInt8(ref buffer);
                    return new(
                        errorCodeField,
                        errorMessageField,
                        resourceTypeField,
                        resourceNameField,
                        patternTypeField,
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, DeleteAclsMatchingAcl message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                    buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                    buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                    buffer = Encoder.WriteInt8(buffer, message.PatternTypeField);
                    buffer = Encoder.WriteString(buffer, message.PrincipalField);
                    buffer = Encoder.WriteString(buffer, message.HostField);
                    buffer = Encoder.WriteInt8(buffer, message.OperationField);
                    buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
                    return buffer;
                }
                public static DeleteAclsMatchingAcl ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                    var resourceTypeField = Decoder.ReadInt8(ref buffer);
                    var resourceNameField = Decoder.ReadCompactString(ref buffer);
                    var patternTypeField = Decoder.ReadInt8(ref buffer);
                    var principalField = Decoder.ReadCompactString(ref buffer);
                    var hostField = Decoder.ReadCompactString(ref buffer);
                    var operationField = Decoder.ReadInt8(ref buffer);
                    var permissionTypeField = Decoder.ReadInt8(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        errorCodeField,
                        errorMessageField,
                        resourceTypeField,
                        resourceNameField,
                        patternTypeField,
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, DeleteAclsMatchingAcl message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                    buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                    buffer = Encoder.WriteCompactString(buffer, message.ResourceNameField);
                    buffer = Encoder.WriteInt8(buffer, message.PatternTypeField);
                    buffer = Encoder.WriteCompactString(buffer, message.PrincipalField);
                    buffer = Encoder.WriteCompactString(buffer, message.HostField);
                    buffer = Encoder.WriteInt8(buffer, message.OperationField);
                    buffer = Encoder.WriteInt8(buffer, message.PermissionTypeField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static DeleteAclsMatchingAcl ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                    var resourceTypeField = Decoder.ReadInt8(ref buffer);
                    var resourceNameField = Decoder.ReadCompactString(ref buffer);
                    var patternTypeField = Decoder.ReadInt8(ref buffer);
                    var principalField = Decoder.ReadCompactString(ref buffer);
                    var hostField = Decoder.ReadCompactString(ref buffer);
                    var operationField = Decoder.ReadInt8(ref buffer);
                    var permissionTypeField = Decoder.ReadInt8(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        errorCodeField,
                        errorMessageField,
                        resourceTypeField,
                        resourceNameField,
                        patternTypeField,
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, DeleteAclsMatchingAcl message)
                {
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                    buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                    buffer = Encoder.WriteCompactString(buffer, message.ResourceNameField);
                    buffer = Encoder.WriteInt8(buffer, message.PatternTypeField);
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