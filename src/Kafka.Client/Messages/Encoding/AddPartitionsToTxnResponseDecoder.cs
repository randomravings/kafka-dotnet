using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using AddPartitionsToTxnTopicResult = Kafka.Client.Messages.AddPartitionsToTxnResponseData.AddPartitionsToTxnTopicResult;
using AddPartitionsToTxnPartitionResult = Kafka.Client.Messages.AddPartitionsToTxnResponseData.AddPartitionsToTxnPartitionResult;
using AddPartitionsToTxnResult = Kafka.Client.Messages.AddPartitionsToTxnResponseData.AddPartitionsToTxnResult;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class AddPartitionsToTxnResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, AddPartitionsToTxnResponseData>
    {
        public AddPartitionsToTxnResponseDecoder() :
            base(
                ApiKey.AddPartitionsToTxn,
                new(0, 4),
                new(3, 32767),
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
        protected override DecodeDelegate<AddPartitionsToTxnResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                4 => ReadV4,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<AddPartitionsToTxnResponseData> ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var resultsByTransactionField = ImmutableArray<AddPartitionsToTxnResult>.Empty;
            var resultsByTopicV3AndBelowField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _resultsByTopicV3AndBelowField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, index, AddPartitionsToTxnTopicResultDecoder.ReadV0);
            if (_resultsByTopicV3AndBelowField_ == null)
                throw new NullReferenceException("Null not allowed for 'ResultsByTopicV3AndBelow'");
            else
                resultsByTopicV3AndBelowField = _resultsByTopicV3AndBelowField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                resultsByTransactionField,
                resultsByTopicV3AndBelowField,
                taggedFields
            ));
        }
        private static DecodeResult<AddPartitionsToTxnResponseData> ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var resultsByTransactionField = ImmutableArray<AddPartitionsToTxnResult>.Empty;
            var resultsByTopicV3AndBelowField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _resultsByTopicV3AndBelowField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, index, AddPartitionsToTxnTopicResultDecoder.ReadV1);
            if (_resultsByTopicV3AndBelowField_ == null)
                throw new NullReferenceException("Null not allowed for 'ResultsByTopicV3AndBelow'");
            else
                resultsByTopicV3AndBelowField = _resultsByTopicV3AndBelowField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                resultsByTransactionField,
                resultsByTopicV3AndBelowField,
                taggedFields
            ));
        }
        private static DecodeResult<AddPartitionsToTxnResponseData> ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var resultsByTransactionField = ImmutableArray<AddPartitionsToTxnResult>.Empty;
            var resultsByTopicV3AndBelowField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _resultsByTopicV3AndBelowField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, index, AddPartitionsToTxnTopicResultDecoder.ReadV2);
            if (_resultsByTopicV3AndBelowField_ == null)
                throw new NullReferenceException("Null not allowed for 'ResultsByTopicV3AndBelow'");
            else
                resultsByTopicV3AndBelowField = _resultsByTopicV3AndBelowField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                resultsByTransactionField,
                resultsByTopicV3AndBelowField,
                taggedFields
            ));
        }
        private static DecodeResult<AddPartitionsToTxnResponseData> ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var resultsByTransactionField = ImmutableArray<AddPartitionsToTxnResult>.Empty;
            var resultsByTopicV3AndBelowField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _resultsByTopicV3AndBelowField_) = BinaryDecoder.ReadCompactArray<AddPartitionsToTxnTopicResult>(buffer, index, AddPartitionsToTxnTopicResultDecoder.ReadV3);
            if (_resultsByTopicV3AndBelowField_ == null)
                throw new NullReferenceException("Null not allowed for 'ResultsByTopicV3AndBelow'");
            else
                resultsByTopicV3AndBelowField = _resultsByTopicV3AndBelowField_.Value;
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
                errorCodeField,
                resultsByTransactionField,
                resultsByTopicV3AndBelowField,
                taggedFields
            ));
        }
        private static DecodeResult<AddPartitionsToTxnResponseData> ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var resultsByTransactionField = ImmutableArray<AddPartitionsToTxnResult>.Empty;
            var resultsByTopicV3AndBelowField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _resultsByTransactionField_) = BinaryDecoder.ReadCompactArray<AddPartitionsToTxnResult>(buffer, index, AddPartitionsToTxnResultDecoder.ReadV4);
            if (_resultsByTransactionField_ == null)
                throw new NullReferenceException("Null not allowed for 'ResultsByTransaction'");
            else
                resultsByTransactionField = _resultsByTransactionField_.Value;
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
                errorCodeField,
                resultsByTransactionField,
                resultsByTopicV3AndBelowField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class AddPartitionsToTxnPartitionResultDecoder
        {
            public static DecodeResult<AddPartitionsToTxnPartitionResult> ReadV0(byte[] buffer, int index)
            {
                var partitionIndexField = default(int);
                var partitionErrorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, partitionErrorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                return new(index, new(
                    partitionIndexField,
                    partitionErrorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnPartitionResult> ReadV1(byte[] buffer, int index)
            {
                var partitionIndexField = default(int);
                var partitionErrorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, partitionErrorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                return new(index, new(
                    partitionIndexField,
                    partitionErrorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnPartitionResult> ReadV2(byte[] buffer, int index)
            {
                var partitionIndexField = default(int);
                var partitionErrorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, partitionErrorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                return new(index, new(
                    partitionIndexField,
                    partitionErrorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnPartitionResult> ReadV3(byte[] buffer, int index)
            {
                var partitionIndexField = default(int);
                var partitionErrorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, partitionErrorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                    partitionErrorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnPartitionResult> ReadV4(byte[] buffer, int index)
            {
                var partitionIndexField = default(int);
                var partitionErrorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, partitionErrorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                    partitionErrorCodeField,
                    taggedFields
                ));
            }
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class AddPartitionsToTxnResultDecoder
        {
            public static DecodeResult<AddPartitionsToTxnResult> ReadV0(byte[] buffer, int index)
            {
                var transactionalIdField = "";
                var topicResultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    transactionalIdField,
                    topicResultsField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnResult> ReadV1(byte[] buffer, int index)
            {
                var transactionalIdField = "";
                var topicResultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    transactionalIdField,
                    topicResultsField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnResult> ReadV2(byte[] buffer, int index)
            {
                var transactionalIdField = "";
                var topicResultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    transactionalIdField,
                    topicResultsField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnResult> ReadV3(byte[] buffer, int index)
            {
                var transactionalIdField = "";
                var topicResultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                    transactionalIdField,
                    topicResultsField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnResult> ReadV4(byte[] buffer, int index)
            {
                var transactionalIdField = "";
                var topicResultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, transactionalIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _topicResultsField_) = BinaryDecoder.ReadCompactArray<AddPartitionsToTxnTopicResult>(buffer, index, AddPartitionsToTxnTopicResultDecoder.ReadV4);
                if (_topicResultsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'TopicResults'");
                else
                    topicResultsField = _topicResultsField_.Value;
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
                    transactionalIdField,
                    topicResultsField,
                    taggedFields
                ));
            }
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class AddPartitionsToTxnTopicResultDecoder
        {
            public static DecodeResult<AddPartitionsToTxnTopicResult> ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var resultsByPartitionField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _resultsByPartitionField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, index, AddPartitionsToTxnPartitionResultDecoder.ReadV0);
                if (_resultsByPartitionField_ == null)
                    throw new NullReferenceException("Null not allowed for 'ResultsByPartition'");
                else
                    resultsByPartitionField = _resultsByPartitionField_.Value;
                return new(index, new(
                    nameField,
                    resultsByPartitionField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnTopicResult> ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var resultsByPartitionField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _resultsByPartitionField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, index, AddPartitionsToTxnPartitionResultDecoder.ReadV1);
                if (_resultsByPartitionField_ == null)
                    throw new NullReferenceException("Null not allowed for 'ResultsByPartition'");
                else
                    resultsByPartitionField = _resultsByPartitionField_.Value;
                return new(index, new(
                    nameField,
                    resultsByPartitionField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnTopicResult> ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var resultsByPartitionField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _resultsByPartitionField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, index, AddPartitionsToTxnPartitionResultDecoder.ReadV2);
                if (_resultsByPartitionField_ == null)
                    throw new NullReferenceException("Null not allowed for 'ResultsByPartition'");
                else
                    resultsByPartitionField = _resultsByPartitionField_.Value;
                return new(index, new(
                    nameField,
                    resultsByPartitionField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnTopicResult> ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var resultsByPartitionField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _resultsByPartitionField_) = BinaryDecoder.ReadCompactArray<AddPartitionsToTxnPartitionResult>(buffer, index, AddPartitionsToTxnPartitionResultDecoder.ReadV3);
                if (_resultsByPartitionField_ == null)
                    throw new NullReferenceException("Null not allowed for 'ResultsByPartition'");
                else
                    resultsByPartitionField = _resultsByPartitionField_.Value;
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
                    resultsByPartitionField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnTopicResult> ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var resultsByPartitionField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _resultsByPartitionField_) = BinaryDecoder.ReadCompactArray<AddPartitionsToTxnPartitionResult>(buffer, index, AddPartitionsToTxnPartitionResultDecoder.ReadV4);
                if (_resultsByPartitionField_ == null)
                    throw new NullReferenceException("Null not allowed for 'ResultsByPartition'");
                else
                    resultsByPartitionField = _resultsByPartitionField_.Value;
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
                    resultsByPartitionField,
                    taggedFields
                ));
            }
        }
    }
}
