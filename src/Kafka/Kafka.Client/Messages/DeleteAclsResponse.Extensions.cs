using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DeleteAclsFilterResult = Kafka.Client.Messages.DeleteAclsResponse.DeleteAclsFilterResult;
using DeleteAclsMatchingAcl = Kafka.Client.Messages.DeleteAclsResponse.DeleteAclsFilterResult.DeleteAclsMatchingAcl;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteAclsResponseSerde
    {
        private static readonly DecodeDelegate<DeleteAclsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<DeleteAclsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static DeleteAclsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DeleteAclsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DeleteAclsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var filterResultsField = Decoder.ReadArray<DeleteAclsFilterResult>(buffer, ref index, DeleteAclsFilterResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'FilterResults'");
            return new(
                throttleTimeMsField,
                filterResultsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DeleteAclsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DeleteAclsFilterResult>(buffer, index, message.FilterResultsField, DeleteAclsFilterResultSerde.WriteV00);
            return index;
        }
        private static DeleteAclsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var filterResultsField = Decoder.ReadArray<DeleteAclsFilterResult>(buffer, ref index, DeleteAclsFilterResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'FilterResults'");
            return new(
                throttleTimeMsField,
                filterResultsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DeleteAclsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DeleteAclsFilterResult>(buffer, index, message.FilterResultsField, DeleteAclsFilterResultSerde.WriteV01);
            return index;
        }
        private static DeleteAclsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var filterResultsField = Decoder.ReadCompactArray<DeleteAclsFilterResult>(buffer, ref index, DeleteAclsFilterResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'FilterResults'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                filterResultsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DeleteAclsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<DeleteAclsFilterResult>(buffer, index, message.FilterResultsField, DeleteAclsFilterResultSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static DeleteAclsResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var filterResultsField = Decoder.ReadCompactArray<DeleteAclsFilterResult>(buffer, ref index, DeleteAclsFilterResultSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'FilterResults'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                filterResultsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, DeleteAclsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<DeleteAclsFilterResult>(buffer, index, message.FilterResultsField, DeleteAclsFilterResultSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DeleteAclsFilterResultSerde
        {
            public static DeleteAclsFilterResult ReadV00(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var matchingAclsField = Decoder.ReadArray<DeleteAclsMatchingAcl>(buffer, ref index, DeleteAclsMatchingAclSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, DeleteAclsFilterResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteArray<DeleteAclsMatchingAcl>(buffer, index, message.MatchingAclsField, DeleteAclsMatchingAclSerde.WriteV00);
                return index;
            }
            public static DeleteAclsFilterResult ReadV01(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var matchingAclsField = Decoder.ReadArray<DeleteAclsMatchingAcl>(buffer, ref index, DeleteAclsMatchingAclSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, DeleteAclsFilterResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteArray<DeleteAclsMatchingAcl>(buffer, index, message.MatchingAclsField, DeleteAclsMatchingAclSerde.WriteV01);
                return index;
            }
            public static DeleteAclsFilterResult ReadV02(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                var matchingAclsField = Decoder.ReadCompactArray<DeleteAclsMatchingAcl>(buffer, ref index, DeleteAclsMatchingAclSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, DeleteAclsFilterResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteCompactArray<DeleteAclsMatchingAcl>(buffer, index, message.MatchingAclsField, DeleteAclsMatchingAclSerde.WriteV02);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static DeleteAclsFilterResult ReadV03(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                var matchingAclsField = Decoder.ReadCompactArray<DeleteAclsMatchingAcl>(buffer, ref index, DeleteAclsMatchingAclSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'MatchingAcls'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, DeleteAclsFilterResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteCompactArray<DeleteAclsMatchingAcl>(buffer, index, message.MatchingAclsField, DeleteAclsMatchingAclSerde.WriteV03);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class DeleteAclsMatchingAclSerde
            {
                public static DeleteAclsMatchingAcl ReadV00(byte[] buffer, ref int index)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
                    var resourceTypeField = Decoder.ReadInt8(buffer, ref index);
                    var resourceNameField = Decoder.ReadString(buffer, ref index);
                    var patternTypeField = default(sbyte);
                    var principalField = Decoder.ReadString(buffer, ref index);
                    var hostField = Decoder.ReadString(buffer, ref index);
                    var operationField = Decoder.ReadInt8(buffer, ref index);
                    var permissionTypeField = Decoder.ReadInt8(buffer, ref index);
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
                public static int WriteV00(byte[] buffer, int index, DeleteAclsMatchingAcl message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                    index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                    index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                    index = Encoder.WriteString(buffer, index, message.PrincipalField);
                    index = Encoder.WriteString(buffer, index, message.HostField);
                    index = Encoder.WriteInt8(buffer, index, message.OperationField);
                    index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
                    return index;
                }
                public static DeleteAclsMatchingAcl ReadV01(byte[] buffer, ref int index)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
                    var resourceTypeField = Decoder.ReadInt8(buffer, ref index);
                    var resourceNameField = Decoder.ReadString(buffer, ref index);
                    var patternTypeField = Decoder.ReadInt8(buffer, ref index);
                    var principalField = Decoder.ReadString(buffer, ref index);
                    var hostField = Decoder.ReadString(buffer, ref index);
                    var operationField = Decoder.ReadInt8(buffer, ref index);
                    var permissionTypeField = Decoder.ReadInt8(buffer, ref index);
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
                public static int WriteV01(byte[] buffer, int index, DeleteAclsMatchingAcl message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                    index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                    index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                    index = Encoder.WriteInt8(buffer, index, message.PatternTypeField);
                    index = Encoder.WriteString(buffer, index, message.PrincipalField);
                    index = Encoder.WriteString(buffer, index, message.HostField);
                    index = Encoder.WriteInt8(buffer, index, message.OperationField);
                    index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
                    return index;
                }
                public static DeleteAclsMatchingAcl ReadV02(byte[] buffer, ref int index)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                    var resourceTypeField = Decoder.ReadInt8(buffer, ref index);
                    var resourceNameField = Decoder.ReadCompactString(buffer, ref index);
                    var patternTypeField = Decoder.ReadInt8(buffer, ref index);
                    var principalField = Decoder.ReadCompactString(buffer, ref index);
                    var hostField = Decoder.ReadCompactString(buffer, ref index);
                    var operationField = Decoder.ReadInt8(buffer, ref index);
                    var permissionTypeField = Decoder.ReadInt8(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
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
                public static int WriteV02(byte[] buffer, int index, DeleteAclsMatchingAcl message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                    index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                    index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
                    index = Encoder.WriteInt8(buffer, index, message.PatternTypeField);
                    index = Encoder.WriteCompactString(buffer, index, message.PrincipalField);
                    index = Encoder.WriteCompactString(buffer, index, message.HostField);
                    index = Encoder.WriteInt8(buffer, index, message.OperationField);
                    index = Encoder.WriteInt8(buffer, index, message.PermissionTypeField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static DeleteAclsMatchingAcl ReadV03(byte[] buffer, ref int index)
                {
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                    var resourceTypeField = Decoder.ReadInt8(buffer, ref index);
                    var resourceNameField = Decoder.ReadCompactString(buffer, ref index);
                    var patternTypeField = Decoder.ReadInt8(buffer, ref index);
                    var principalField = Decoder.ReadCompactString(buffer, ref index);
                    var hostField = Decoder.ReadCompactString(buffer, ref index);
                    var operationField = Decoder.ReadInt8(buffer, ref index);
                    var permissionTypeField = Decoder.ReadInt8(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
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
                public static int WriteV03(byte[] buffer, int index, DeleteAclsMatchingAcl message)
                {
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                    index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                    index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
                    index = Encoder.WriteInt8(buffer, index, message.PatternTypeField);
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