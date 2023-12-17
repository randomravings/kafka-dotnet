using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using AclDescription = Kafka.Client.Messages.DescribeAclsResponseData.DescribeAclsResource.AclDescription;
using DescribeAclsResource = Kafka.Client.Messages.DescribeAclsResponseData.DescribeAclsResource;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class DescribeAclsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, DescribeAclsResponseData>
    {
        internal DescribeAclsResponseDecoder() :
            base(
                ApiKey.DescribeAcls,
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
        protected override DecodeValue<DescribeAclsResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<DescribeAclsResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var resourcesField = ImmutableArray<DescribeAclsResource>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
            (i, resourcesField) = BinaryDecoder.ReadArray<DescribeAclsResource>(buffer, i, DescribeAclsResourceDecoder.ReadV0);
            if (resourcesField.IsDefault)
                throw new InvalidDataException("resourcesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField,
                taggedFields
            ));
        }
        private static DecodeResult<DescribeAclsResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var resourcesField = ImmutableArray<DescribeAclsResource>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
            (i, resourcesField) = BinaryDecoder.ReadArray<DescribeAclsResource>(buffer, i, DescribeAclsResourceDecoder.ReadV1);
            if (resourcesField.IsDefault)
                throw new InvalidDataException("resourcesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                resourcesField,
                taggedFields
            ));
        }
        private static DecodeResult<DescribeAclsResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var resourcesField = ImmutableArray<DescribeAclsResource>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, resourcesField) = BinaryDecoder.ReadCompactArray<DescribeAclsResource>(buffer, i, DescribeAclsResourceDecoder.ReadV2);
            if (resourcesField.IsDefault)
                throw new InvalidDataException("resourcesField was null");
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
                errorCodeField,
                errorMessageField,
                resourcesField,
                taggedFields
            ));
        }
        private static DecodeResult<DescribeAclsResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var errorMessageField = default(string?);
            var resourcesField = ImmutableArray<DescribeAclsResource>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, resourcesField) = BinaryDecoder.ReadCompactArray<DescribeAclsResource>(buffer, i, DescribeAclsResourceDecoder.ReadV3);
            if (resourcesField.IsDefault)
                throw new InvalidDataException("resourcesField was null");
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
                errorCodeField,
                errorMessageField,
                resourcesField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class DescribeAclsResourceDecoder
        {
            public static DecodeResult<DescribeAclsResource> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var resourceTypeField = default(sbyte);
                var resourceNameField = "";
                var patternTypeField = default(sbyte);
                var aclsField = ImmutableArray<AclDescription>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, resourceTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                (i, resourceNameField) = BinaryDecoder.ReadString(buffer, i);
                (i, aclsField) = BinaryDecoder.ReadArray<AclDescription>(buffer, i, AclDescriptionDecoder.ReadV0);
                if (aclsField.IsDefault)
                    throw new InvalidDataException("aclsField was null");
;
                return new(i, new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DescribeAclsResource> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var resourceTypeField = default(sbyte);
                var resourceNameField = "";
                var patternTypeField = default(sbyte);
                var aclsField = ImmutableArray<AclDescription>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, resourceTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                (i, resourceNameField) = BinaryDecoder.ReadString(buffer, i);
                (i, patternTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                (i, aclsField) = BinaryDecoder.ReadArray<AclDescription>(buffer, i, AclDescriptionDecoder.ReadV1);
                if (aclsField.IsDefault)
                    throw new InvalidDataException("aclsField was null");
;
                return new(i, new(
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DescribeAclsResource> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var resourceTypeField = default(sbyte);
                var resourceNameField = "";
                var patternTypeField = default(sbyte);
                var aclsField = ImmutableArray<AclDescription>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, resourceTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                (i, resourceNameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, patternTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                (i, aclsField) = BinaryDecoder.ReadCompactArray<AclDescription>(buffer, i, AclDescriptionDecoder.ReadV2);
                if (aclsField.IsDefault)
                    throw new InvalidDataException("aclsField was null");
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
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DescribeAclsResource> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var resourceTypeField = default(sbyte);
                var resourceNameField = "";
                var patternTypeField = default(sbyte);
                var aclsField = ImmutableArray<AclDescription>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, resourceTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                (i, resourceNameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, patternTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                (i, aclsField) = BinaryDecoder.ReadCompactArray<AclDescription>(buffer, i, AclDescriptionDecoder.ReadV3);
                if (aclsField.IsDefault)
                    throw new InvalidDataException("aclsField was null");
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
                    resourceTypeField,
                    resourceNameField,
                    patternTypeField,
                    aclsField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class AclDescriptionDecoder
            {
                public static DecodeResult<AclDescription> ReadV0([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var principalField = "";
                    var hostField = "";
                    var operationField = default(sbyte);
                    var permissionTypeField = default(sbyte);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, principalField) = BinaryDecoder.ReadString(buffer, i);
                    (i, hostField) = BinaryDecoder.ReadString(buffer, i);
                    (i, operationField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, permissionTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                    return new(i, new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<AclDescription> ReadV1([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var principalField = "";
                    var hostField = "";
                    var operationField = default(sbyte);
                    var permissionTypeField = default(sbyte);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, principalField) = BinaryDecoder.ReadString(buffer, i);
                    (i, hostField) = BinaryDecoder.ReadString(buffer, i);
                    (i, operationField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, permissionTypeField) = BinaryDecoder.ReadInt8(buffer, i);
                    return new(i, new(
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<AclDescription> ReadV2([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var principalField = "";
                    var hostField = "";
                    var operationField = default(sbyte);
                    var permissionTypeField = default(sbyte);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                        principalField,
                        hostField,
                        operationField,
                        permissionTypeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<AclDescription> ReadV3([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var principalField = "";
                    var hostField = "";
                    var operationField = default(sbyte);
                    var permissionTypeField = default(sbyte);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
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
