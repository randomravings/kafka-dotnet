using BatchIndexAndErrorMessage = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse.PartitionProduceResponse.BatchIndexAndErrorMessage;
using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using PartitionProduceResponse = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse.PartitionProduceResponse;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using TopicProduceResponse = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ProduceResponseSerde
    {
        private static readonly ApiKey API_KEY = new(0);
        private static readonly VersionRange API_VERSIONS = new(0, 9);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (9, 32767);
        public static IEncoder<ResponseHeader, ProduceResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 9 ? apiVersion : new Version(9);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, ProduceResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, ProduceResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, ProduceResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, ProduceResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<ResponseHeader, ProduceResponse>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<ResponseHeader, ProduceResponse>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<ResponseHeader, ProduceResponse>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<ResponseHeader, ProduceResponse>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                case 8:
                    return new Encoder<ResponseHeader, ProduceResponse>(API_KEY, 8, flexible, headerEncoder, WriteV8);
                case 9:
                    return new Encoder<ResponseHeader, ProduceResponse>(API_KEY, 9, flexible, headerEncoder, WriteV9);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, ProduceResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 9 ? apiVersion : new Version(9);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, ProduceResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, ProduceResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, ProduceResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, ProduceResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<ResponseHeader, ProduceResponse>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<ResponseHeader, ProduceResponse>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<ResponseHeader, ProduceResponse>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<ResponseHeader, ProduceResponse>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                case 8:
                    return new Decoder<ResponseHeader, ProduceResponse>(API_KEY, 8, flexible, headerDecoder, ReadV8);
                case 9:
                    return new Decoder<ResponseHeader, ProduceResponse>(API_KEY, 9, flexible, headerDecoder, ReadV9);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, ProduceResponse message)
        {
            index = BinaryEncoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV0);
            return index;
        }
        private static (int Offset, ProduceResponse Value) ReadV0(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV0);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, ProduceResponse message)
        {
            index = BinaryEncoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV1);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static (int Offset, ProduceResponse Value) ReadV1(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV1);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, ProduceResponse message)
        {
            index = BinaryEncoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV2);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static (int Offset, ProduceResponse Value) ReadV2(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV2);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, ProduceResponse message)
        {
            index = BinaryEncoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV3);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static (int Offset, ProduceResponse Value) ReadV3(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV3);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, ProduceResponse message)
        {
            index = BinaryEncoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV4);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static (int Offset, ProduceResponse Value) ReadV4(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV4);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, ProduceResponse message)
        {
            index = BinaryEncoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV5);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static (int Offset, ProduceResponse Value) ReadV5(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV5);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, ProduceResponse message)
        {
            index = BinaryEncoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV6);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static (int Offset, ProduceResponse Value) ReadV6(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV6);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, ProduceResponse message)
        {
            index = BinaryEncoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV7);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static (int Offset, ProduceResponse Value) ReadV7(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV7);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static int WriteV8(byte[] buffer, int index, ProduceResponse message)
        {
            index = BinaryEncoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV8);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            return index;
        }
        private static (int Offset, ProduceResponse Value) ReadV8(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV8);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        private static int WriteV9(byte[] buffer, int index, ProduceResponse message)
        {
            index = BinaryEncoder.WriteCompactArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV9);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
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
        private static (int Offset, ProduceResponse Value) ReadV9(byte[] buffer, int index)
        {
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadCompactArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV9);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
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
                responsesField,
                throttleTimeMsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class TopicProduceResponseSerde
        {
            public static int WriteV0(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV0);
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
            public static (int Offset, TopicProduceResponse Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV0);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return (index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV1);
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
            public static (int Offset, TopicProduceResponse Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV1);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return (index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV2);
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
            public static (int Offset, TopicProduceResponse Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV2);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return (index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV3);
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
            public static (int Offset, TopicProduceResponse Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV3);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return (index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV4);
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
            public static (int Offset, TopicProduceResponse Value) ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV4);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return (index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV5);
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
            public static (int Offset, TopicProduceResponse Value) ReadV5(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV5);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return (index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV6);
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
            public static (int Offset, TopicProduceResponse Value) ReadV6(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV6);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return (index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV7);
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
            public static (int Offset, TopicProduceResponse Value) ReadV7(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV7);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return (index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static int WriteV8(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV8);
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
            public static (int Offset, TopicProduceResponse Value) ReadV8(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV8);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return (index, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static int WriteV9(byte[] buffer, int index, TopicProduceResponse message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV9);
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
            public static (int Offset, TopicProduceResponse Value) ReadV9(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionResponsesField_) = BinaryDecoder.ReadCompactArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV9);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
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
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            [GeneratedCode("kgen", "1.0.0.0")]
            private static class PartitionProduceResponseSerde
            {
                public static int WriteV0(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.BaseOffsetField);
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
                public static (int Offset, PartitionProduceResponse Value) ReadV0(byte[] buffer, int index)
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
                    return (index, new(
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
                public static int WriteV1(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.BaseOffsetField);
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
                public static (int Offset, PartitionProduceResponse Value) ReadV1(byte[] buffer, int index)
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
                    return (index, new(
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
                public static int WriteV2(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
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
                public static (int Offset, PartitionProduceResponse Value) ReadV2(byte[] buffer, int index)
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
                    return (index, new(
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
                public static int WriteV3(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
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
                public static (int Offset, PartitionProduceResponse Value) ReadV3(byte[] buffer, int index)
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
                    return (index, new(
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
                public static int WriteV4(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
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
                public static (int Offset, PartitionProduceResponse Value) ReadV4(byte[] buffer, int index)
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
                    return (index, new(
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
                public static int WriteV5(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
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
                public static (int Offset, PartitionProduceResponse Value) ReadV5(byte[] buffer, int index)
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
                    return (index, new(
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
                public static int WriteV6(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
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
                public static (int Offset, PartitionProduceResponse Value) ReadV6(byte[] buffer, int index)
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
                    return (index, new(
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
                public static int WriteV7(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
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
                public static (int Offset, PartitionProduceResponse Value) ReadV7(byte[] buffer, int index)
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
                    return (index, new(
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
                public static int WriteV8(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteArray<BatchIndexAndErrorMessage>(buffer, index, message.RecordErrorsField, BatchIndexAndErrorMessageSerde.WriteV8);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.ErrorMessageField);
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
                public static (int Offset, PartitionProduceResponse Value) ReadV8(byte[] buffer, int index)
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
                    (index, var _recordErrorsField_) = BinaryDecoder.ReadArray<BatchIndexAndErrorMessage>(buffer, index, BatchIndexAndErrorMessageSerde.ReadV8);
                    if (_recordErrorsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                    else
                        recordErrorsField = _recordErrorsField_.Value;
                    (index, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
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
                public static int WriteV9(byte[] buffer, int index, PartitionProduceResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.BaseOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteCompactArray<BatchIndexAndErrorMessage>(buffer, index, message.RecordErrorsField, BatchIndexAndErrorMessageSerde.WriteV9);
                    index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
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
                public static (int Offset, PartitionProduceResponse Value) ReadV9(byte[] buffer, int index)
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
                    (index, var _recordErrorsField_) = BinaryDecoder.ReadCompactArray<BatchIndexAndErrorMessage>(buffer, index, BatchIndexAndErrorMessageSerde.ReadV9);
                    if (_recordErrorsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                    else
                        recordErrorsField = _recordErrorsField_.Value;
                    (index, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                [GeneratedCode("kgen", "1.0.0.0")]
                private static class BatchIndexAndErrorMessageSerde
                {
                    public static int WriteV0(byte[] buffer, int index, BatchIndexAndErrorMessage message)
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
                    public static (int Offset, BatchIndexAndErrorMessage Value) ReadV0(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static int WriteV1(byte[] buffer, int index, BatchIndexAndErrorMessage message)
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
                    public static (int Offset, BatchIndexAndErrorMessage Value) ReadV1(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static int WriteV2(byte[] buffer, int index, BatchIndexAndErrorMessage message)
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
                    public static (int Offset, BatchIndexAndErrorMessage Value) ReadV2(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static int WriteV3(byte[] buffer, int index, BatchIndexAndErrorMessage message)
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
                    public static (int Offset, BatchIndexAndErrorMessage Value) ReadV3(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static int WriteV4(byte[] buffer, int index, BatchIndexAndErrorMessage message)
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
                    public static (int Offset, BatchIndexAndErrorMessage Value) ReadV4(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static int WriteV5(byte[] buffer, int index, BatchIndexAndErrorMessage message)
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
                    public static (int Offset, BatchIndexAndErrorMessage Value) ReadV5(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static int WriteV6(byte[] buffer, int index, BatchIndexAndErrorMessage message)
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
                    public static (int Offset, BatchIndexAndErrorMessage Value) ReadV6(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static int WriteV7(byte[] buffer, int index, BatchIndexAndErrorMessage message)
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
                    public static (int Offset, BatchIndexAndErrorMessage Value) ReadV7(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static int WriteV8(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                    {
                        index = BinaryEncoder.WriteInt32(buffer, index, message.BatchIndexField);
                        index = BinaryEncoder.WriteNullableString(buffer, index, message.BatchIndexErrorMessageField);
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
                    public static (int Offset, BatchIndexAndErrorMessage Value) ReadV8(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, batchIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, batchIndexErrorMessageField) = BinaryDecoder.ReadNullableString(buffer, index);
                        return (index, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static int WriteV9(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                    {
                        index = BinaryEncoder.WriteInt32(buffer, index, message.BatchIndexField);
                        index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.BatchIndexErrorMessageField);
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
                    public static (int Offset, BatchIndexAndErrorMessage Value) ReadV9(byte[] buffer, int index)
                    {
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, batchIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, batchIndexErrorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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