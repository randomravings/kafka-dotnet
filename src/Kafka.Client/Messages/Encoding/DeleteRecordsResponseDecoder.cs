using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DeleteRecordsPartitionResult = Kafka.Client.Messages.DeleteRecordsResponseData.DeleteRecordsTopicResult.DeleteRecordsPartitionResult;
using DeleteRecordsTopicResult = Kafka.Client.Messages.DeleteRecordsResponseData.DeleteRecordsTopicResult;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class DeleteRecordsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, DeleteRecordsResponseData>
    {
        public DeleteRecordsResponseDecoder() :
            base(
                ApiKey.DeleteRecords,
                new(0, 2),
                new(2, 32767),
                ResponseHeaderDecoder.ReadV0,
                ReadV0
            )
        { }
        protected override DecodeDelegate<ResponseHeaderData> GetHeaderDecoder(short apiVersion)
        {
            if (_flexibleVersions.Includes(apiVersion))
                return ResponseHeaderDecoder.ReadV1;
            else
                return ResponseHeaderDecoder.ReadV0;
        }
        protected override DecodeDelegate<DeleteRecordsResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<DeleteRecordsResponseData> ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<DeleteRecordsTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<DeleteRecordsTopicResult>(buffer, index, DeleteRecordsTopicResultDecoder.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteRecordsResponseData> ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<DeleteRecordsTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<DeleteRecordsTopicResult>(buffer, index, DeleteRecordsTopicResultDecoder.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<DeleteRecordsResponseData> ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<DeleteRecordsTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<DeleteRecordsTopicResult>(buffer, index, DeleteRecordsTopicResultDecoder.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                    (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class DeleteRecordsTopicResultDecoder
        {
            public static DecodeResult<DeleteRecordsTopicResult> ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<DeleteRecordsPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<DeleteRecordsPartitionResult>(buffer, index, DeleteRecordsPartitionResultDecoder.ReadV0);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeleteRecordsTopicResult> ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<DeleteRecordsPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<DeleteRecordsPartitionResult>(buffer, index, DeleteRecordsPartitionResultDecoder.ReadV1);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<DeleteRecordsTopicResult> ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<DeleteRecordsPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<DeleteRecordsPartitionResult>(buffer, index, DeleteRecordsPartitionResultDecoder.ReadV2);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                        (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class DeleteRecordsPartitionResultDecoder
            {
                public static DecodeResult<DeleteRecordsPartitionResult> ReadV0(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var lowWatermarkField = default(long);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, lowWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return new(index, new(
                        partitionIndexField,
                        lowWatermarkField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<DeleteRecordsPartitionResult> ReadV1(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var lowWatermarkField = default(long);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, lowWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return new(index, new(
                        partitionIndexField,
                        lowWatermarkField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<DeleteRecordsPartitionResult> ReadV2(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var lowWatermarkField = default(long);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, lowWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                            (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            taggedFieldsCount--;
                        }
                    }
                    return new(index, new(
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
