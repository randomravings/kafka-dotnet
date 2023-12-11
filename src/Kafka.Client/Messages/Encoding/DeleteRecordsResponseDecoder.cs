using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using DeleteRecordsPartitionResult = Kafka.Client.Messages.DeleteRecordsResponseData.DeleteRecordsTopicResult.DeleteRecordsPartitionResult;
using DeleteRecordsTopicResult = Kafka.Client.Messages.DeleteRecordsResponseData.DeleteRecordsTopicResult;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class DeleteRecordsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, DeleteRecordsResponseData>
    {
        internal DeleteRecordsResponseDecoder() :
            base(
                ApiKey.DeleteRecords,
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
        protected override DecodeValue<DeleteRecordsResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<DeleteRecordsResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<DeleteRecordsTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, topicsField) = BinaryDecoder.ReadArray<DeleteRecordsTopicResult>(buffer, i, DeleteRecordsTopicResultDecoder.ReadV0);
            if (topicsField.IsDefault)
                throw new InvalidDataException("topicsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteRecordsResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<DeleteRecordsTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, topicsField) = BinaryDecoder.ReadArray<DeleteRecordsTopicResult>(buffer, i, DeleteRecordsTopicResultDecoder.ReadV1);
            if (topicsField.IsDefault)
                throw new InvalidDataException("topicsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteRecordsResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<DeleteRecordsTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, topicsField) = BinaryDecoder.ReadCompactArray<DeleteRecordsTopicResult>(buffer, i, DeleteRecordsTopicResultDecoder.ReadV2);
            if (topicsField.IsDefault)
                throw new InvalidDataException("topicsField was null");
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
                topicsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class DeleteRecordsTopicResultDecoder
        {
            public static DecodeResult<DeleteRecordsTopicResult> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<DeleteRecordsPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<DeleteRecordsPartitionResult>(buffer, i, DeleteRecordsPartitionResultDecoder.ReadV0);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeleteRecordsTopicResult> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<DeleteRecordsPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<DeleteRecordsPartitionResult>(buffer, i, DeleteRecordsPartitionResultDecoder.ReadV1);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeleteRecordsTopicResult> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<DeleteRecordsPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadCompactArray<DeleteRecordsPartitionResult>(buffer, i, DeleteRecordsPartitionResultDecoder.ReadV2);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
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
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class DeleteRecordsPartitionResultDecoder
            {
                public static DecodeResult<DeleteRecordsPartitionResult> ReadV0([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var lowWatermarkField = default(long);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, lowWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        lowWatermarkField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<DeleteRecordsPartitionResult> ReadV1([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var lowWatermarkField = default(long);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, lowWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        lowWatermarkField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<DeleteRecordsPartitionResult> ReadV2([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var lowWatermarkField = default(long);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, lowWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
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
                        partitionIndexField,
                        lowWatermarkField,
                        errorCodeField,
                        taggedFields
                    ));
                }
            }
        }
    }
}
