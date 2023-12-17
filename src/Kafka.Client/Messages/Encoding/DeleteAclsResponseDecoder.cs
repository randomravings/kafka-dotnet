using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using DeleteAclsFilterResult = Kafka.Client.Messages.DeleteAclsResponseData.DeleteAclsFilterResult;
using DeleteAclsMatchingAcl = Kafka.Client.Messages.DeleteAclsResponseData.DeleteAclsFilterResult.DeleteAclsMatchingAcl;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class DeleteAclsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, DeleteAclsResponseData>
    {
        internal DeleteAclsResponseDecoder() :
            base(
                ApiKey.DeleteAcls,
                new(0, 3),
                new(2, 32767),
                ResponseHeaderDecoder.ReadV0,
                ReadV0
            )
        { }
        protected override DecodeValue<ResponseHeaderData> GetHeaderDecoder(short apiVersion)
        {
            if (FlexibleVersions.Includes(apiVersion))
                return ResponseHeaderDecoder.ReadV1;
            else
                return ResponseHeaderDecoder.ReadV0;
        }
        protected override DecodeValue<DeleteAclsResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<DeleteAclsResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var filterResultsField = ImmutableArray<DeleteAclsFilterResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, filterResultsField) = BinaryDecoder.ReadArray<DeleteAclsFilterResult>(buffer, i, DeleteAclsFilterResultDecoder.ReadV0);
            if (filterResultsField.IsDefault)
                throw new InvalidDataException("filterResultsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                filterResultsField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteAclsResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var filterResultsField = ImmutableArray<DeleteAclsFilterResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, filterResultsField) = BinaryDecoder.ReadArray<DeleteAclsFilterResult>(buffer, i, DeleteAclsFilterResultDecoder.ReadV1);
            if (filterResultsField.IsDefault)
                throw new InvalidDataException("filterResultsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                filterResultsField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteAclsResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var filterResultsField = ImmutableArray<DeleteAclsFilterResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, filterResultsField) = BinaryDecoder.ReadCompactArray<DeleteAclsFilterResult>(buffer, i, DeleteAclsFilterResultDecoder.ReadV2);
            if (filterResultsField.IsDefault)
                throw new InvalidDataException("filterResultsField was null");
;
            (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                    (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(i, new(
                throttleTimeMsField,
                filterResultsField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteAclsResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var filterResultsField = ImmutableArray<DeleteAclsFilterResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, filterResultsField) = BinaryDecoder.ReadCompactArray<DeleteAclsFilterResult>(buffer, i, DeleteAclsFilterResultDecoder.ReadV3);
            if (filterResultsField.IsDefault)
                throw new InvalidDataException("filterResultsField was null");
;
            (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                    (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(i, new(
                throttleTimeMsField,
                filterResultsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class DeleteAclsFilterResultDecoder
        {
            public static DecodeResult<DeleteAclsFilterResult> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var matchingAclsField = ImmutableArray<DeleteAclsMatchingAcl>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
                (i, matchingAclsField) = BinaryDecoder.ReadArray<DeleteAclsMatchingAcl>(buffer, i, DeleteAclsMatchingAclDecoder.ReadV0);
                if (matchingAclsField.IsDefault)
                    throw new InvalidDataException("matchingAclsField was null");
;
                return new(i, new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeleteAclsFilterResult> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var matchingAclsField = ImmutableArray<DeleteAclsMatchingAcl>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
                (i, matchingAclsField) = BinaryDecoder.ReadArray<DeleteAclsMatchingAcl>(buffer, i, DeleteAclsMatchingAclDecoder.ReadV1);
                if (matchingAclsField.IsDefault)
                    throw new InvalidDataException("matchingAclsField was null");
;
                return new(i, new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeleteAclsFilterResult> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var matchingAclsField = ImmutableArray<DeleteAclsMatchingAcl>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, matchingAclsField) = BinaryDecoder.ReadCompactArray<DeleteAclsMatchingAcl>(buffer, i, DeleteAclsMatchingAclDecoder.ReadV2);
                if (matchingAclsField.IsDefault)
                    throw new InvalidDataException("matchingAclsField was null");
;
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeleteAclsFilterResult> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var matchingAclsField = ImmutableArray<DeleteAclsMatchingAcl>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, matchingAclsField) = BinaryDecoder.ReadCompactArray<DeleteAclsMatchingAcl>(buffer, i, DeleteAclsMatchingAclDecoder.ReadV3);
                if (matchingAclsField.IsDefault)
                    throw new InvalidDataException("matchingAclsField was null");
;
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
                    errorCodeField,
                    errorMessageField,
                    matchingAclsField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class DeleteAclsMatchingAclDecoder
            {
                public static DecodeResult<DeleteAclsMatchingAcl> ReadV0([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var errorMessageField = default(string?);
                    var resourceTypeField = default(sbyte);
                    var resourceNameField = "";
                    var patternTypeField = default(sbyte);
                    var principalField = "";
                    var hostField = "";
                    var operationField = default(sbyte);
                    var permissionTypeField = default(sbyte);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
                    (i, resourceTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, resourceNameField) = BinaryDecoder.ReadString(buffer, i);
                    (i, principalField) = BinaryDecoder.ReadString(buffer, i);
                    (i, hostField) = BinaryDecoder.ReadString(buffer, i);
                    (i, operationField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, permissionTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                    return new(i, new(
                        errorCodeField,
                        errorMessageField,
                        resourceTypeField,
                        resourceNameField,
                        patternTypeField,
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<DeleteAclsMatchingAcl> ReadV1([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var errorMessageField = default(string?);
                    var resourceTypeField = default(sbyte);
                    var resourceNameField = "";
                    var patternTypeField = default(sbyte);
                    var principalField = "";
                    var hostField = "";
                    var operationField = default(sbyte);
                    var permissionTypeField = default(sbyte);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
                    (i, resourceTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, resourceNameField) = BinaryDecoder.ReadString(buffer, i);
                    (i, patternTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, principalField) = BinaryDecoder.ReadString(buffer, i);
                    (i, hostField) = BinaryDecoder.ReadString(buffer, i);
                    (i, operationField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, permissionTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                    return new(i, new(
                        errorCodeField,
                        errorMessageField,
                        resourceTypeField,
                        resourceNameField,
                        patternTypeField,
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<DeleteAclsMatchingAcl> ReadV2([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var errorMessageField = default(string?);
                    var resourceTypeField = default(sbyte);
                    var resourceNameField = "";
                    var patternTypeField = default(sbyte);
                    var principalField = "";
                    var hostField = "";
                    var operationField = default(sbyte);
                    var permissionTypeField = default(sbyte);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                    (i, resourceTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, resourceNameField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, patternTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, principalField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, hostField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, operationField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, permissionTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                            (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            taggedFieldsCount--;
                        }
                    }
                    return new(i, new(
                        errorCodeField,
                        errorMessageField,
                        resourceTypeField,
                        resourceNameField,
                        patternTypeField,
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<DeleteAclsMatchingAcl> ReadV3([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var errorMessageField = default(string?);
                    var resourceTypeField = default(sbyte);
                    var resourceNameField = "";
                    var patternTypeField = default(sbyte);
                    var principalField = "";
                    var hostField = "";
                    var operationField = default(sbyte);
                    var permissionTypeField = default(sbyte);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                    (i, resourceTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, resourceNameField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, patternTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, principalField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, hostField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, operationField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, permissionTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                            (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            taggedFieldsCount--;
                        }
                    }
                    return new(i, new(
                        errorCodeField,
                        errorMessageField,
                        resourceTypeField,
                        resourceNameField,
                        patternTypeField,
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField,
                        taggedFields
                    ));
                }
            }
        }
    }
}
