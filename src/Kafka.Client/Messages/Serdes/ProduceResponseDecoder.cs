using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using PartitionProduceResponse = Kafka.Client.Messages.ProduceResponseData.TopicProduceResponse.PartitionProduceResponse;
using BatchIndexAndErrorMessage = Kafka.Client.Messages.ProduceResponseData.TopicProduceResponse.PartitionProduceResponse.BatchIndexAndErrorMessage;
using TopicProduceResponse = Kafka.Client.Messages.ProduceResponseData.TopicProduceResponse;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class ProduceResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, ProduceResponseData>
    {
        public ProduceResponseDecoder() :
            base(
                ApiKey.Produce,
                new(0, 9),
                new(9, 32767),
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
        protected override DecodeDelegate<ProduceResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                4 => ReadV4,
                5 => ReadV5,
                6 => ReadV6,
                7 => ReadV7,
                8 => ReadV8,
                9 => ReadV9,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<ProduceResponseData> ReadV0(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseDecoder.ReadV0);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV1(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseDecoder.ReadV1);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV2(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseDecoder.ReadV2);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV3(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseDecoder.ReadV3);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV4(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseDecoder.ReadV4);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV5(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseDecoder.ReadV5);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV6(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseDecoder.ReadV6);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV7(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseDecoder.ReadV7);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV8(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseDecoder.ReadV8);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV9(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadCompactArray<TopicProduceResponse>(buffer, index, TopicProduceResponseDecoder.ReadV9);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
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
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class TopicProduceResponseDecoder
        {
            public static DecodeResult<TopicProduceResponse> ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseDecoder.ReadV0);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseDecoder.ReadV1);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseDecoder.ReadV2);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseDecoder.ReadV3);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseDecoder.ReadV4);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV5(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseDecoder.ReadV5);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV6(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseDecoder.ReadV6);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV7(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseDecoder.ReadV7);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV8(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseDecoder.ReadV8);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV9(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadCompactArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseDecoder.ReadV9);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
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
                    partitionResponsesField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class PartitionProduceResponseDecoder
            {
                public static DecodeResult<PartitionProduceResponse> ReadV0(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    return new(index, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV1(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    return new(index, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV2(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, index);
                    return new(index, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV3(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, index);
                    return new(index, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV4(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, index);
                    return new(index, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV5(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    return new(index, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV6(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    return new(index, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV7(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    return new(index, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV8(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, var _recordErrorsField_) = BinaryDecoder.ReadArray<BatchIndexAndErrorMessage>(buffer, index, BatchIndexAndErrorMessageDecoder.ReadV8);
                    if (_recordErrorsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                    else
                        recordErrorsField = _recordErrorsField_.Value;
                    (index, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return new(index, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV9(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, var _recordErrorsField_) = BinaryDecoder.ReadCompactArray<BatchIndexAndErrorMessage>(buffer, index, BatchIndexAndErrorMessageDecoder.ReadV9);
                    if (_recordErrorsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                    else
                        recordErrorsField = _recordErrorsField_.Value;
                    (index, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        taggedFields
                    ));
                }
                [GeneratedCodeAttribute("kgen", "1.0.0.0")]
                private static class BatchIndexAndErrorMessageDecoder
                {
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV0(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV1(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV2(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV3(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV4(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV5(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV6(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV7(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV8(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, batchIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, batchIndexErrorMessageField) = BinaryDecoder.ReadNullableString(buffer, index);
                        return new(index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV9(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, batchIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, batchIndexErrorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                }
            }
        }
    }
}
