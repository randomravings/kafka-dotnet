using AbortedTransaction = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.AbortedTransaction;
using EpochEndOffset = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.EpochEndOffset;
using FetchableTopicResponse = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse;
using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.LeaderIdAndEpoch;
using PartitionData = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData;
using SnapshotId = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.SnapshotId;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchResponseSerde
    {
        private static readonly ApiKey API_KEY = new(1);
        private static readonly VersionRange API_VERSIONS = new(0, 13);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (12, 32767);
        public static IEncoder<ResponseHeader, FetchResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 13 ? apiVersion : new Version(13);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                case 8:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 8, flexible, headerEncoder, WriteV8);
                case 9:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 9, flexible, headerEncoder, WriteV9);
                case 10:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 10, flexible, headerEncoder, WriteV10);
                case 11:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 11, flexible, headerEncoder, WriteV11);
                case 12:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 12, flexible, headerEncoder, WriteV12);
                case 13:
                    return new Encoder<ResponseHeader, FetchResponse>(API_KEY, 13, flexible, headerEncoder, WriteV13);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, FetchResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 13 ? apiVersion : new Version(13);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                case 8:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 8, flexible, headerDecoder, ReadV8);
                case 9:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 9, flexible, headerDecoder, ReadV9);
                case 10:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 10, flexible, headerDecoder, ReadV10);
                case 11:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 11, flexible, headerDecoder, ReadV11);
                case 12:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 12, flexible, headerDecoder, ReadV12);
                case 13:
                    return new Decoder<ResponseHeader, FetchResponse>(API_KEY, 13, flexible, headerDecoder, ReadV13);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV0);
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV0);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV1);
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV1);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV2);
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV2);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV3);
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV3);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV4);
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV4);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV5);
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV5);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV6);
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV6(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV6);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV7);
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV7(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV7);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV8(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV8);
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV8(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV8);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV9(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV9);
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV9(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV9);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV10(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV10);
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV10(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV10);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV11(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV11);
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV11(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV11);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV12(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteCompactArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV12);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV12(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadCompactArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV12);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if(taggedFieldsCount > 0)
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
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV13(byte[] buffer, int index, FetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteCompactArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV13);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, FetchResponse Value) ReadV13(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadCompactArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseSerde.ReadV13);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if(taggedFieldsCount > 0)
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
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class FetchableTopicResponseSerde
        {
            public static int WriteV0(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV0);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV0(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV0);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV1);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV1(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV1);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV2);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV2(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV2);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV3);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV3(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV3);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV4);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV4(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV4);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV5);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV5(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV5);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV6);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV6(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV6);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV7);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV7(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV7);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV8(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV8);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV8(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV8);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV9(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV9);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV9(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV9);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV10(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV10);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV10(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV10);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV11(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV11);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV11(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV11);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV12(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV12);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV12(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV12);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
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
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV13(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV13);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchableTopicResponse Value) ReadV13(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV13);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
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
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            [GeneratedCode("kgen", "1.0.0.0")]
            private static class PartitionDataSerde
            {
                public static int WriteV0(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV0(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV1(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV2(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV3(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV4(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = BinaryEncoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV4);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV4(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV4);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV5(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV5);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV5(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV5);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV6(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV6);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV6(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV6);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV7(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV7);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV7(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV7);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV8(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV8);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV8(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV8);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV9(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV9);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV9(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV9);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV10(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV10);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV10(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV10);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV11(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV11);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PreferredReadReplicaField);
                    index = BinaryEncoder.WriteRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV11(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV11);
                    (index, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV12(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteCompactArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV12);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PreferredReadReplicaField);
                    index = BinaryEncoder.WriteCompactRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 3u;
                    var previousTagged = 2;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    {
                        index = BinaryEncoder.WriteVarInt32(buffer, index, 0);
                        index = EpochEndOffsetSerde.WriteV12(buffer, index, message.DivergingEpochField);
                    }
                    {
                        index = BinaryEncoder.WriteVarInt32(buffer, index, 1);
                        index = LeaderIdAndEpochSerde.WriteV12(buffer, index, message.CurrentLeaderField);
                    }
                    {
                        index = BinaryEncoder.WriteVarInt32(buffer, index, 2);
                        index = SnapshotIdSerde.WriteV12(buffer, index, message.SnapshotIdField);
                    }
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 2");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV12(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadCompactArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV12);
                    (index, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadCompactRecords(buffer, index);
                    (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                    if(taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                            switch (tag)
                            {
                                case 0:
                                    (index, divergingEpochField) = EpochEndOffsetSerde.ReadV12(buffer, index);
                                    break;
                                case 1:
                                    (index, currentLeaderField) = LeaderIdAndEpochSerde.ReadV12(buffer, index);
                                    break;
                                case 2:
                                    (index, snapshotIdField) = SnapshotIdSerde.ReadV12(buffer, index);
                                    break;
                                default:
                                    (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                                    taggedFieldsBuilder.Add(new(tag, bytes));
                                break;
                            }
                            taggedFieldsCount--;
                        }
                    }
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV13(byte[] buffer, int index, PartitionData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteCompactArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV13);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PreferredReadReplicaField);
                    index = BinaryEncoder.WriteCompactRecords(buffer, index, message.RecordsField);
                    var taggedFieldsCount = 3u;
                    var previousTagged = 2;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    {
                        index = BinaryEncoder.WriteVarInt32(buffer, index, 0);
                        index = EpochEndOffsetSerde.WriteV13(buffer, index, message.DivergingEpochField);
                    }
                    {
                        index = BinaryEncoder.WriteVarInt32(buffer, index, 1);
                        index = LeaderIdAndEpochSerde.WriteV13(buffer, index, message.CurrentLeaderField);
                    }
                    {
                        index = BinaryEncoder.WriteVarInt32(buffer, index, 2);
                        index = SnapshotIdSerde.WriteV13(buffer, index, message.SnapshotIdField);
                    }
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 2");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, PartitionData Value) ReadV13(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadCompactArray<AbortedTransaction>(buffer, index, AbortedTransactionSerde.ReadV13);
                    (index, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadCompactRecords(buffer, index);
                    (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                    if(taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                            switch (tag)
                            {
                                case 0:
                                    (index, divergingEpochField) = EpochEndOffsetSerde.ReadV13(buffer, index);
                                    break;
                                case 1:
                                    (index, currentLeaderField) = LeaderIdAndEpochSerde.ReadV13(buffer, index);
                                    break;
                                case 2:
                                    (index, snapshotIdField) = SnapshotIdSerde.ReadV13(buffer, index);
                                    break;
                                default:
                                    (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                                    taggedFieldsBuilder.Add(new(tag, bytes));
                                break;
                            }
                            taggedFieldsCount--;
                        }
                    }
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField,
                        taggedFields
                    ));
                }
                [GeneratedCode("kgen", "1.0.0.0")]
                private static class EpochEndOffsetSerde
                {
                    public static int WriteV0(byte[] buffer, int index, EpochEndOffset message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV0(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV1(byte[] buffer, int index, EpochEndOffset message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV1(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV2(byte[] buffer, int index, EpochEndOffset message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV2(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV3(byte[] buffer, int index, EpochEndOffset message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV3(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV4(byte[] buffer, int index, EpochEndOffset message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV4(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV5(byte[] buffer, int index, EpochEndOffset message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV5(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV6(byte[] buffer, int index, EpochEndOffset message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV6(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV7(byte[] buffer, int index, EpochEndOffset message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV7(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV8(byte[] buffer, int index, EpochEndOffset message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV8(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV9(byte[] buffer, int index, EpochEndOffset message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV9(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV10(byte[] buffer, int index, EpochEndOffset message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV10(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV11(byte[] buffer, int index, EpochEndOffset message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV11(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV12(byte[] buffer, int index, EpochEndOffset message)
                    {
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV12(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                        if(taggedFieldsCount > 0)
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
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV13(byte[] buffer, int index, EpochEndOffset message)
                    {
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, EpochEndOffset Value) ReadV13(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                        if(taggedFieldsCount > 0)
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
                        return (index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                }
                [GeneratedCode("kgen", "1.0.0.0")]
                private static class AbortedTransactionSerde
                {
                    public static int WriteV0(byte[] buffer, int index, AbortedTransaction message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV0(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV1(byte[] buffer, int index, AbortedTransaction message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV1(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV2(byte[] buffer, int index, AbortedTransaction message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV2(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV3(byte[] buffer, int index, AbortedTransaction message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV3(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV4(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = BinaryEncoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV4(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV5(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = BinaryEncoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV5(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV6(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = BinaryEncoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV6(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV7(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = BinaryEncoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV7(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV8(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = BinaryEncoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV8(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV9(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = BinaryEncoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV9(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV10(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = BinaryEncoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV10(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV11(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = BinaryEncoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV11(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV12(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = BinaryEncoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV12(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                        if(taggedFieldsCount > 0)
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
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static int WriteV13(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = BinaryEncoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, AbortedTransaction Value) ReadV13(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                        if(taggedFieldsCount > 0)
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
                        return (index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                }
                [GeneratedCode("kgen", "1.0.0.0")]
                private static class SnapshotIdSerde
                {
                    public static int WriteV0(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV0(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV1(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV1(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV2(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV2(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV3(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV3(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV4(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV4(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV5(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV5(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV6(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV6(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV7(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV7(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV8(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV8(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV9(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV9(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV10(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV10(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV11(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV11(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV12(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV12(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                        if(taggedFieldsCount > 0)
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
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV13(byte[] buffer, int index, SnapshotId message)
                    {
                        index = BinaryEncoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.EpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, SnapshotId Value) ReadV13(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                        if(taggedFieldsCount > 0)
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
                        return (index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                }
                [GeneratedCode("kgen", "1.0.0.0")]
                private static class LeaderIdAndEpochSerde
                {
                    public static int WriteV0(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV0(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV1(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV1(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV2(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV2(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV3(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV3(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV4(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV4(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV5(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV5(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV6(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV6(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV7(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV7(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV8(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV8(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV9(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV9(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV10(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV10(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV11(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV11(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV12(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderEpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV12(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                        if(taggedFieldsCount > 0)
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
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static int WriteV13(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderEpochField);
                        var taggedFieldsCount = 0u;
                        var previousTagged = -1;
                        taggedFieldsCount += (uint)message.TaggedFields.Length;
                        index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                        foreach(var taggedField in message.TaggedFields)
                        {
                            if(taggedField.Tag <= previousTagged)
                                throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                            index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                            index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                        }
                        return index;
                    }
                    public static (int Offset, LeaderIdAndEpoch Value) ReadV13(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                        if(taggedFieldsCount > 0)
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
                        return (index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                }
            }
        }
    }
}