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
        private static readonly Func<Stream, DeleteAclsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, DeleteAclsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static DeleteAclsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DeleteAclsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DeleteAclsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var filterResultsField = Decoder.ReadArray<DeleteAclsFilterResult>(buffer, b => DeleteAclsFilterResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'FilterResults'");
            return new(
                throttleTimeMsField,
                filterResultsField
            );
        }
        private static void WriteV00(Stream buffer, DeleteAclsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DeleteAclsFilterResult>(buffer, message.FilterResultsField, (b, i) => DeleteAclsFilterResultSerde.WriteV00(b, i));
        }
        private static DeleteAclsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var filterResultsField = Decoder.ReadArray<DeleteAclsFilterResult>(buffer, b => DeleteAclsFilterResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'FilterResults'");
            return new(
                throttleTimeMsField,
                filterResultsField
            );
        }
        private static void WriteV01(Stream buffer, DeleteAclsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DeleteAclsFilterResult>(buffer, message.FilterResultsField, (b, i) => DeleteAclsFilterResultSerde.WriteV01(b, i));
        }
        private static DeleteAclsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var filterResultsField = Decoder.ReadCompactArray<DeleteAclsFilterResult>(buffer, b => DeleteAclsFilterResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'FilterResults'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                filterResultsField
            );
        }
        private static void WriteV02(Stream buffer, DeleteAclsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<DeleteAclsFilterResult>(buffer, message.FilterResultsField, (b, i) => DeleteAclsFilterResultSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static DeleteAclsResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var filterResultsField = Decoder.ReadCompactArray<DeleteAclsFilterResult>(buffer, b => DeleteAclsFilterResultSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'FilterResults'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                filterResultsField
            );
        }
        private static void WriteV03(Stream buffer, DeleteAclsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<DeleteAclsFilterResult>(buffer, message.FilterResultsField, (b, i) => DeleteAclsFilterResultSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DeleteAclsFilterResultSerde
        {
            public static DeleteAclsFilterResult ReadV00(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
                var matchingAclsField = Decoder.ReadArray<DeleteAclsMatchingAcl>(buffer, b => DeleteAclsMatchingAclSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField
                );
            }
            public static void WriteV00(Stream buffer, DeleteAclsFilterResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteArray<DeleteAclsMatchingAcl>(buffer, message.MatchingAclsField, (b, i) => DeleteAclsMatchingAclSerde.WriteV00(b, i));
            }
            public static DeleteAclsFilterResult ReadV01(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
                var matchingAclsField = Decoder.ReadArray<DeleteAclsMatchingAcl>(buffer, b => DeleteAclsMatchingAclSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField
                );
            }
            public static void WriteV01(Stream buffer, DeleteAclsFilterResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteArray<DeleteAclsMatchingAcl>(buffer, message.MatchingAclsField, (b, i) => DeleteAclsMatchingAclSerde.WriteV01(b, i));
            }
            public static DeleteAclsFilterResult ReadV02(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                var matchingAclsField = Decoder.ReadCompactArray<DeleteAclsMatchingAcl>(buffer, b => DeleteAclsMatchingAclSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField
                );
            }
            public static void WriteV02(Stream buffer, DeleteAclsFilterResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteCompactArray<DeleteAclsMatchingAcl>(buffer, message.MatchingAclsField, (b, i) => DeleteAclsMatchingAclSerde.WriteV02(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static DeleteAclsFilterResult ReadV03(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                var matchingAclsField = Decoder.ReadCompactArray<DeleteAclsMatchingAcl>(buffer, b => DeleteAclsMatchingAclSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField
                );
            }
            public static void WriteV03(Stream buffer, DeleteAclsFilterResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteCompactArray<DeleteAclsMatchingAcl>(buffer, message.MatchingAclsField, (b, i) => DeleteAclsMatchingAclSerde.WriteV03(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class DeleteAclsMatchingAclSerde
            {
                public static DeleteAclsMatchingAcl ReadV00(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var errorMessageField = Decoder.ReadNullableString(buffer);
                    var resourceTypeField = Decoder.ReadInt8(buffer);
                    var resourceNameField = Decoder.ReadString(buffer);
                    var patternTypeField = default(sbyte);
                    var principalField = Decoder.ReadString(buffer);
                    var hostField = Decoder.ReadString(buffer);
                    var operationField = Decoder.ReadInt8(buffer);
                    var permissionTypeField = Decoder.ReadInt8(buffer);
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
                public static void WriteV00(Stream buffer, DeleteAclsMatchingAcl message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                    Encoder.WriteInt8(buffer, message.ResourceTypeField);
                    Encoder.WriteString(buffer, message.ResourceNameField);
                    Encoder.WriteString(buffer, message.PrincipalField);
                    Encoder.WriteString(buffer, message.HostField);
                    Encoder.WriteInt8(buffer, message.OperationField);
                    Encoder.WriteInt8(buffer, message.PermissionTypeField);
                }
                public static DeleteAclsMatchingAcl ReadV01(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var errorMessageField = Decoder.ReadNullableString(buffer);
                    var resourceTypeField = Decoder.ReadInt8(buffer);
                    var resourceNameField = Decoder.ReadString(buffer);
                    var patternTypeField = Decoder.ReadInt8(buffer);
                    var principalField = Decoder.ReadString(buffer);
                    var hostField = Decoder.ReadString(buffer);
                    var operationField = Decoder.ReadInt8(buffer);
                    var permissionTypeField = Decoder.ReadInt8(buffer);
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
                public static void WriteV01(Stream buffer, DeleteAclsMatchingAcl message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                    Encoder.WriteInt8(buffer, message.ResourceTypeField);
                    Encoder.WriteString(buffer, message.ResourceNameField);
                    Encoder.WriteInt8(buffer, message.PatternTypeField);
                    Encoder.WriteString(buffer, message.PrincipalField);
                    Encoder.WriteString(buffer, message.HostField);
                    Encoder.WriteInt8(buffer, message.OperationField);
                    Encoder.WriteInt8(buffer, message.PermissionTypeField);
                }
                public static DeleteAclsMatchingAcl ReadV02(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                    var resourceTypeField = Decoder.ReadInt8(buffer);
                    var resourceNameField = Decoder.ReadCompactString(buffer);
                    var patternTypeField = Decoder.ReadInt8(buffer);
                    var principalField = Decoder.ReadCompactString(buffer);
                    var hostField = Decoder.ReadCompactString(buffer);
                    var operationField = Decoder.ReadInt8(buffer);
                    var permissionTypeField = Decoder.ReadInt8(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
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
                public static void WriteV02(Stream buffer, DeleteAclsMatchingAcl message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                    Encoder.WriteInt8(buffer, message.ResourceTypeField);
                    Encoder.WriteCompactString(buffer, message.ResourceNameField);
                    Encoder.WriteInt8(buffer, message.PatternTypeField);
                    Encoder.WriteCompactString(buffer, message.PrincipalField);
                    Encoder.WriteCompactString(buffer, message.HostField);
                    Encoder.WriteInt8(buffer, message.OperationField);
                    Encoder.WriteInt8(buffer, message.PermissionTypeField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static DeleteAclsMatchingAcl ReadV03(Stream buffer)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                    var resourceTypeField = Decoder.ReadInt8(buffer);
                    var resourceNameField = Decoder.ReadCompactString(buffer);
                    var patternTypeField = Decoder.ReadInt8(buffer);
                    var principalField = Decoder.ReadCompactString(buffer);
                    var hostField = Decoder.ReadCompactString(buffer);
                    var operationField = Decoder.ReadInt8(buffer);
                    var permissionTypeField = Decoder.ReadInt8(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
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
                public static void WriteV03(Stream buffer, DeleteAclsMatchingAcl message)
                {
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                    Encoder.WriteInt8(buffer, message.ResourceTypeField);
                    Encoder.WriteCompactString(buffer, message.ResourceNameField);
                    Encoder.WriteInt8(buffer, message.PatternTypeField);
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