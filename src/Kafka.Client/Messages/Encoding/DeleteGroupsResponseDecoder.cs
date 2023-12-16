using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using DeletableGroupResult = Kafka.Client.Messages.DeleteGroupsResponseData.DeletableGroupResult;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class DeleteGroupsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, DeleteGroupsResponseData>
    {
        internal DeleteGroupsResponseDecoder() :
            base(
                ApiKey.DeleteGroups,
                new(0, 2),
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
        protected override DecodeValue<DeleteGroupsResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<DeleteGroupsResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var resultsField = ImmutableArray<DeletableGroupResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, resultsField) = BinaryDecoder.ReadArray<DeletableGroupResult>(buffer, i, DeletableGroupResultDecoder.ReadV0);
            if (resultsField.IsDefault)
                throw new InvalidDataException("resultsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                resultsField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteGroupsResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var resultsField = ImmutableArray<DeletableGroupResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, resultsField) = BinaryDecoder.ReadArray<DeletableGroupResult>(buffer, i, DeletableGroupResultDecoder.ReadV1);
            if (resultsField.IsDefault)
                throw new InvalidDataException("resultsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                resultsField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteGroupsResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var resultsField = ImmutableArray<DeletableGroupResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, resultsField) = BinaryDecoder.ReadCompactArray<DeletableGroupResult>(buffer, i, DeletableGroupResultDecoder.ReadV2);
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
        private static class DeletableGroupResultDecoder
        {
            public static DecodeResult<DeletableGroupResult> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, groupIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
                    groupIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeletableGroupResult> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, groupIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
                    groupIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeletableGroupResult> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, groupIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
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
                    groupIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
        }
    }
}
