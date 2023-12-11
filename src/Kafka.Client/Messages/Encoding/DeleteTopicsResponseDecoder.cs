using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using DeletableTopicResult = Kafka.Client.Messages.DeleteTopicsResponseData.DeletableTopicResult;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class DeleteTopicsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, DeleteTopicsResponseData>
    {
        internal DeleteTopicsResponseDecoder() :
            base(
                ApiKey.DeleteTopics,
                new(0, 6),
                new(4, 32767),
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
        protected override DecodeValue<DeleteTopicsResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                4 => ReadV4,
                5 => ReadV5,
                6 => ReadV6,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<DeleteTopicsResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, responsesField) = BinaryDecoder.ReadArray<DeletableTopicResult>(buffer, i, DeletableTopicResultDecoder.ReadV0);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                responsesField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteTopicsResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<DeletableTopicResult>(buffer, i, DeletableTopicResultDecoder.ReadV1);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                responsesField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteTopicsResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<DeletableTopicResult>(buffer, i, DeletableTopicResultDecoder.ReadV2);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                responsesField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteTopicsResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<DeletableTopicResult>(buffer, i, DeletableTopicResultDecoder.ReadV3);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                responsesField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteTopicsResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadCompactArray<DeletableTopicResult>(buffer, i, DeletableTopicResultDecoder.ReadV4);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
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
                responsesField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteTopicsResponseData> ReadV5([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadCompactArray<DeletableTopicResult>(buffer, i, DeletableTopicResultDecoder.ReadV5);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
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
                responsesField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteTopicsResponseData> ReadV6([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadCompactArray<DeletableTopicResult>(buffer, i, DeletableTopicResultDecoder.ReadV6);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
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
                responsesField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class DeletableTopicResultDecoder
        {
            public static DecodeResult<DeletableTopicResult> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeletableTopicResult> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeletableTopicResult> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeletableTopicResult> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeletableTopicResult> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
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
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeletableTopicResult> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
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
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeletableTopicResult> ReadV6([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, topicIdField) = BinaryDecoder.ReadUuid(buffer, i);
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
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
        }
    }
}
