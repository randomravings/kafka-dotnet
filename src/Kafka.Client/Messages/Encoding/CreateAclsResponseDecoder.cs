using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using AclCreationResult = Kafka.Client.Messages.CreateAclsResponseData.AclCreationResult;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class CreateAclsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, CreateAclsResponseData>
    {
        internal CreateAclsResponseDecoder() :
            base(
                ApiKey.CreateAcls,
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
        protected override DecodeValue<CreateAclsResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<CreateAclsResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var resultsField = ImmutableArray<AclCreationResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, resultsField) = BinaryDecoder.ReadArray<AclCreationResult>(buffer, i, AclCreationResultDecoder.ReadV0);
            if (resultsField.IsDefault)
                throw new InvalidDataException("resultsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                resultsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateAclsResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var resultsField = ImmutableArray<AclCreationResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, resultsField) = BinaryDecoder.ReadArray<AclCreationResult>(buffer, i, AclCreationResultDecoder.ReadV1);
            if (resultsField.IsDefault)
                throw new InvalidDataException("resultsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                resultsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateAclsResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var resultsField = ImmutableArray<AclCreationResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, resultsField) = BinaryDecoder.ReadCompactArray<AclCreationResult>(buffer, i, AclCreationResultDecoder.ReadV2);
            if (resultsField.IsDefault)
                throw new InvalidDataException("resultsField was null");
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
                resultsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateAclsResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var resultsField = ImmutableArray<AclCreationResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, resultsField) = BinaryDecoder.ReadCompactArray<AclCreationResult>(buffer, i, AclCreationResultDecoder.ReadV3);
            if (resultsField.IsDefault)
                throw new InvalidDataException("resultsField was null");
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
                resultsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class AclCreationResultDecoder
        {
            public static DecodeResult<AclCreationResult> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<AclCreationResult> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<AclCreationResult> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
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
                    taggedFields
                ));
            }
            public static DecodeResult<AclCreationResult> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
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
                    taggedFields
                ));
            }
        }
    }
}
