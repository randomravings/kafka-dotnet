using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using AddPartitionsToTxnPartitionResult = Kafka.Client.Messages.AddPartitionsToTxnResponseData.AddPartitionsToTxnPartitionResult;
using AddPartitionsToTxnResult = Kafka.Client.Messages.AddPartitionsToTxnResponseData.AddPartitionsToTxnResult;
using AddPartitionsToTxnTopicResult = Kafka.Client.Messages.AddPartitionsToTxnResponseData.AddPartitionsToTxnTopicResult;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class AddPartitionsToTxnResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, AddPartitionsToTxnResponseData>
    {
        internal AddPartitionsToTxnResponseDecoder() :
            base(
                ApiKey.AddPartitionsToTxn,
                new(0, 4),
                new(3, 32767),
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
        protected override DecodeValue<AddPartitionsToTxnResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<AddPartitionsToTxnResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var resultsByTransactionField = ImmutableArray<AddPartitionsToTxnResult>.Empty;
            var resultsByTopicV3AndBelowField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, resultsByTopicV3AndBelowField) = BinaryDecoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, i, AddPartitionsToTxnTopicResultDecoder.ReadV0);
            if (resultsByTopicV3AndBelowField.IsDefault)
                throw new InvalidDataException("resultsByTopicV3AndBelowField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                resultsByTransactionField,
                resultsByTopicV3AndBelowField,
                taggedFields
            ));
        }
        private static DecodeResult<AddPartitionsToTxnResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var resultsByTransactionField = ImmutableArray<AddPartitionsToTxnResult>.Empty;
            var resultsByTopicV3AndBelowField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, resultsByTopicV3AndBelowField) = BinaryDecoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, i, AddPartitionsToTxnTopicResultDecoder.ReadV1);
            if (resultsByTopicV3AndBelowField.IsDefault)
                throw new InvalidDataException("resultsByTopicV3AndBelowField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                resultsByTransactionField,
                resultsByTopicV3AndBelowField,
                taggedFields
            ));
        }
        private static DecodeResult<AddPartitionsToTxnResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var resultsByTransactionField = ImmutableArray<AddPartitionsToTxnResult>.Empty;
            var resultsByTopicV3AndBelowField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, resultsByTopicV3AndBelowField) = BinaryDecoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, i, AddPartitionsToTxnTopicResultDecoder.ReadV2);
            if (resultsByTopicV3AndBelowField.IsDefault)
                throw new InvalidDataException("resultsByTopicV3AndBelowField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                resultsByTransactionField,
                resultsByTopicV3AndBelowField,
                taggedFields
            ));
        }
        private static DecodeResult<AddPartitionsToTxnResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var resultsByTransactionField = ImmutableArray<AddPartitionsToTxnResult>.Empty;
            var resultsByTopicV3AndBelowField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, resultsByTopicV3AndBelowField) = BinaryDecoder.ReadCompactArray<AddPartitionsToTxnTopicResult>(buffer, i, AddPartitionsToTxnTopicResultDecoder.ReadV3);
            if (resultsByTopicV3AndBelowField.IsDefault)
                throw new InvalidDataException("resultsByTopicV3AndBelowField was null");
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
                resultsByTransactionField,
                resultsByTopicV3AndBelowField,
                taggedFields
            ));
        }
        private static DecodeResult<AddPartitionsToTxnResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var resultsByTransactionField = ImmutableArray<AddPartitionsToTxnResult>.Empty;
            var resultsByTopicV3AndBelowField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, resultsByTransactionField) = BinaryDecoder.ReadCompactArray<AddPartitionsToTxnResult>(buffer, i, AddPartitionsToTxnResultDecoder.ReadV4);
            if (resultsByTransactionField.IsDefault)
                throw new InvalidDataException("resultsByTransactionField was null");
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
                resultsByTransactionField,
                resultsByTopicV3AndBelowField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class AddPartitionsToTxnPartitionResultDecoder
        {
            public static DecodeResult<AddPartitionsToTxnPartitionResult> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var partitionIndexField = default(int);
                var partitionErrorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, partitionErrorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
                    partitionIndexField,
                    partitionErrorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnPartitionResult> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var partitionIndexField = default(int);
                var partitionErrorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, partitionErrorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
                    partitionIndexField,
                    partitionErrorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnPartitionResult> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var partitionIndexField = default(int);
                var partitionErrorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, partitionErrorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
                    partitionIndexField,
                    partitionErrorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnPartitionResult> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var partitionIndexField = default(int);
                var partitionErrorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, partitionErrorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
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
                    partitionErrorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnPartitionResult> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var partitionIndexField = default(int);
                var partitionErrorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, partitionErrorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
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
                    partitionErrorCodeField,
                    taggedFields
                ));
            }
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class AddPartitionsToTxnResultDecoder
        {
            public static DecodeResult<AddPartitionsToTxnResult> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var transactionalIdField = "";
                var topicResultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    transactionalIdField,
                    topicResultsField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnResult> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var transactionalIdField = "";
                var topicResultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    transactionalIdField,
                    topicResultsField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnResult> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var transactionalIdField = "";
                var topicResultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    transactionalIdField,
                    topicResultsField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnResult> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var transactionalIdField = "";
                var topicResultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                    transactionalIdField,
                    topicResultsField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnResult> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var transactionalIdField = "";
                var topicResultsField = ImmutableArray<AddPartitionsToTxnTopicResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, transactionalIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, topicResultsField) = BinaryDecoder.ReadCompactArray<AddPartitionsToTxnTopicResult>(buffer, i, AddPartitionsToTxnTopicResultDecoder.ReadV4);
                if (topicResultsField.IsDefault)
                    throw new InvalidDataException("topicResultsField was null");
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
                    transactionalIdField,
                    topicResultsField,
                    taggedFields
                ));
            }
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class AddPartitionsToTxnTopicResultDecoder
        {
            public static DecodeResult<AddPartitionsToTxnTopicResult> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var resultsByPartitionField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, resultsByPartitionField) = BinaryDecoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, i, AddPartitionsToTxnPartitionResultDecoder.ReadV0);
                if (resultsByPartitionField.IsDefault)
                    throw new InvalidDataException("resultsByPartitionField was null");
;
                return new(i, new(
                    nameField,
                    resultsByPartitionField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnTopicResult> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var resultsByPartitionField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, resultsByPartitionField) = BinaryDecoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, i, AddPartitionsToTxnPartitionResultDecoder.ReadV1);
                if (resultsByPartitionField.IsDefault)
                    throw new InvalidDataException("resultsByPartitionField was null");
;
                return new(i, new(
                    nameField,
                    resultsByPartitionField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnTopicResult> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var resultsByPartitionField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, resultsByPartitionField) = BinaryDecoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, i, AddPartitionsToTxnPartitionResultDecoder.ReadV2);
                if (resultsByPartitionField.IsDefault)
                    throw new InvalidDataException("resultsByPartitionField was null");
;
                return new(i, new(
                    nameField,
                    resultsByPartitionField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnTopicResult> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var resultsByPartitionField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, resultsByPartitionField) = BinaryDecoder.ReadCompactArray<AddPartitionsToTxnPartitionResult>(buffer, i, AddPartitionsToTxnPartitionResultDecoder.ReadV3);
                if (resultsByPartitionField.IsDefault)
                    throw new InvalidDataException("resultsByPartitionField was null");
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
                    resultsByPartitionField,
                    taggedFields
                ));
            }
            public static DecodeResult<AddPartitionsToTxnTopicResult> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var resultsByPartitionField = ImmutableArray<AddPartitionsToTxnPartitionResult>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, resultsByPartitionField) = BinaryDecoder.ReadCompactArray<AddPartitionsToTxnPartitionResult>(buffer, i, AddPartitionsToTxnPartitionResultDecoder.ReadV4);
                if (resultsByPartitionField.IsDefault)
                    throw new InvalidDataException("resultsByPartitionField was null");
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
                    resultsByPartitionField,
                    taggedFields
                ));
            }
        }
    }
}
