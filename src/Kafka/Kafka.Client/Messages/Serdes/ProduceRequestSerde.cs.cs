using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using PartitionProduceData = Kafka.Client.Messages.ProduceRequest.TopicProduceData.PartitionProduceData;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using TopicProduceData = Kafka.Client.Messages.ProduceRequest.TopicProduceData;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ProduceRequestSerde
    {
        private static readonly ApiKey API_KEY = new(0);
        private static readonly VersionRange API_VERSIONS = new(0, 9);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (9, 32767);
        public static IEncoder<RequestHeader, ProduceRequest> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 9 ? apiVersion : new Version(9);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = RequestHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<RequestHeader, ProduceRequest>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<RequestHeader, ProduceRequest>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<RequestHeader, ProduceRequest>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<RequestHeader, ProduceRequest>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<RequestHeader, ProduceRequest>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<RequestHeader, ProduceRequest>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<RequestHeader, ProduceRequest>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<RequestHeader, ProduceRequest>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                case 8:
                    return new Encoder<RequestHeader, ProduceRequest>(API_KEY, 8, flexible, headerEncoder, WriteV8);
                case 9:
                    return new Encoder<RequestHeader, ProduceRequest>(API_KEY, 9, flexible, headerEncoder, WriteV9);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<RequestHeader, ProduceRequest> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 9 ? apiVersion : new Version(9);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = RequestHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<RequestHeader, ProduceRequest>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<RequestHeader, ProduceRequest>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<RequestHeader, ProduceRequest>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<RequestHeader, ProduceRequest>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<RequestHeader, ProduceRequest>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<RequestHeader, ProduceRequest>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<RequestHeader, ProduceRequest>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<RequestHeader, ProduceRequest>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                case 8:
                    return new Decoder<RequestHeader, ProduceRequest>(API_KEY, 8, flexible, headerDecoder, ReadV8);
                case 9:
                    return new Decoder<RequestHeader, ProduceRequest>(API_KEY, 9, flexible, headerDecoder, ReadV9);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, ProduceRequest message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV0);
            return index;
        }
        private static (int Offset, ProduceRequest Value) ReadV0(byte[] buffer, int index)
        {
            var transactionalIdField = default(string?);
            var acksField = default(short);
            var timeoutMsField = default(int);
            var topicDataField = ImmutableArray<TopicProduceData>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, acksField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicDataField_) = BinaryDecoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV0);
            if (_topicDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicData'");
            else
                topicDataField = _topicDataField_.Value;
            return (index, new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, ProduceRequest message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV1);
            return index;
        }
        private static (int Offset, ProduceRequest Value) ReadV1(byte[] buffer, int index)
        {
            var transactionalIdField = default(string?);
            var acksField = default(short);
            var timeoutMsField = default(int);
            var topicDataField = ImmutableArray<TopicProduceData>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, acksField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicDataField_) = BinaryDecoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV1);
            if (_topicDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicData'");
            else
                topicDataField = _topicDataField_.Value;
            return (index, new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, ProduceRequest message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV2);
            return index;
        }
        private static (int Offset, ProduceRequest Value) ReadV2(byte[] buffer, int index)
        {
            var transactionalIdField = default(string?);
            var acksField = default(short);
            var timeoutMsField = default(int);
            var topicDataField = ImmutableArray<TopicProduceData>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, acksField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicDataField_) = BinaryDecoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV2);
            if (_topicDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicData'");
            else
                topicDataField = _topicDataField_.Value;
            return (index, new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, ProduceRequest message)
        {
            index = BinaryEncoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV3);
            return index;
        }
        private static (int Offset, ProduceRequest Value) ReadV3(byte[] buffer, int index)
        {
            var transactionalIdField = default(string?);
            var acksField = default(short);
            var timeoutMsField = default(int);
            var topicDataField = ImmutableArray<TopicProduceData>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, transactionalIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, acksField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicDataField_) = BinaryDecoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV3);
            if (_topicDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicData'");
            else
                topicDataField = _topicDataField_.Value;
            return (index, new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, ProduceRequest message)
        {
            index = BinaryEncoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV4);
            return index;
        }
        private static (int Offset, ProduceRequest Value) ReadV4(byte[] buffer, int index)
        {
            var transactionalIdField = default(string?);
            var acksField = default(short);
            var timeoutMsField = default(int);
            var topicDataField = ImmutableArray<TopicProduceData>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, transactionalIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, acksField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicDataField_) = BinaryDecoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV4);
            if (_topicDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicData'");
            else
                topicDataField = _topicDataField_.Value;
            return (index, new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, ProduceRequest message)
        {
            index = BinaryEncoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV5);
            return index;
        }
        private static (int Offset, ProduceRequest Value) ReadV5(byte[] buffer, int index)
        {
            var transactionalIdField = default(string?);
            var acksField = default(short);
            var timeoutMsField = default(int);
            var topicDataField = ImmutableArray<TopicProduceData>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, transactionalIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, acksField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicDataField_) = BinaryDecoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV5);
            if (_topicDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicData'");
            else
                topicDataField = _topicDataField_.Value;
            return (index, new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, ProduceRequest message)
        {
            index = BinaryEncoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV6);
            return index;
        }
        private static (int Offset, ProduceRequest Value) ReadV6(byte[] buffer, int index)
        {
            var transactionalIdField = default(string?);
            var acksField = default(short);
            var timeoutMsField = default(int);
            var topicDataField = ImmutableArray<TopicProduceData>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, transactionalIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, acksField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicDataField_) = BinaryDecoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV6);
            if (_topicDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicData'");
            else
                topicDataField = _topicDataField_.Value;
            return (index, new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, ProduceRequest message)
        {
            index = BinaryEncoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV7);
            return index;
        }
        private static (int Offset, ProduceRequest Value) ReadV7(byte[] buffer, int index)
        {
            var transactionalIdField = default(string?);
            var acksField = default(short);
            var timeoutMsField = default(int);
            var topicDataField = ImmutableArray<TopicProduceData>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, transactionalIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, acksField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicDataField_) = BinaryDecoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV7);
            if (_topicDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicData'");
            else
                topicDataField = _topicDataField_.Value;
            return (index, new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField,
                taggedFields
            ));
        }
        private static int WriteV8(byte[] buffer, int index, ProduceRequest message)
        {
            index = BinaryEncoder.WriteNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV8);
            return index;
        }
        private static (int Offset, ProduceRequest Value) ReadV8(byte[] buffer, int index)
        {
            var transactionalIdField = default(string?);
            var acksField = default(short);
            var timeoutMsField = default(int);
            var topicDataField = ImmutableArray<TopicProduceData>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, transactionalIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, acksField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicDataField_) = BinaryDecoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV8);
            if (_topicDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicData'");
            else
                topicDataField = _topicDataField_.Value;
            return (index, new(
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField,
                taggedFields
            ));
        }
        private static int WriteV9(byte[] buffer, int index, ProduceRequest message)
        {
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.AcksField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            index = BinaryEncoder.WriteCompactArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV9);
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
        private static (int Offset, ProduceRequest Value) ReadV9(byte[] buffer, int index)
        {
            var transactionalIdField = default(string?);
            var acksField = default(short);
            var timeoutMsField = default(int);
            var topicDataField = ImmutableArray<TopicProduceData>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, transactionalIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, acksField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicDataField_) = BinaryDecoder.ReadCompactArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV9);
            if (_topicDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicData'");
            else
                topicDataField = _topicDataField_.Value;
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
                transactionalIdField,
                acksField,
                timeoutMsField,
                topicDataField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class TopicProduceDataSerde
        {
            public static int WriteV0(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV0);
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
            public static (int Offset, TopicProduceData Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionDataField = ImmutableArray<PartitionProduceData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionDataField_) = BinaryDecoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV0);
                if (_partitionDataField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionData'");
                else
                    partitionDataField = _partitionDataField_.Value;
                return (index, new(
                    nameField,
                    partitionDataField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV1);
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
            public static (int Offset, TopicProduceData Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionDataField = ImmutableArray<PartitionProduceData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionDataField_) = BinaryDecoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV1);
                if (_partitionDataField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionData'");
                else
                    partitionDataField = _partitionDataField_.Value;
                return (index, new(
                    nameField,
                    partitionDataField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV2);
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
            public static (int Offset, TopicProduceData Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionDataField = ImmutableArray<PartitionProduceData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionDataField_) = BinaryDecoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV2);
                if (_partitionDataField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionData'");
                else
                    partitionDataField = _partitionDataField_.Value;
                return (index, new(
                    nameField,
                    partitionDataField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV3);
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
            public static (int Offset, TopicProduceData Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionDataField = ImmutableArray<PartitionProduceData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionDataField_) = BinaryDecoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV3);
                if (_partitionDataField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionData'");
                else
                    partitionDataField = _partitionDataField_.Value;
                return (index, new(
                    nameField,
                    partitionDataField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV4);
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
            public static (int Offset, TopicProduceData Value) ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionDataField = ImmutableArray<PartitionProduceData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionDataField_) = BinaryDecoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV4);
                if (_partitionDataField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionData'");
                else
                    partitionDataField = _partitionDataField_.Value;
                return (index, new(
                    nameField,
                    partitionDataField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV5);
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
            public static (int Offset, TopicProduceData Value) ReadV5(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionDataField = ImmutableArray<PartitionProduceData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionDataField_) = BinaryDecoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV5);
                if (_partitionDataField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionData'");
                else
                    partitionDataField = _partitionDataField_.Value;
                return (index, new(
                    nameField,
                    partitionDataField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV6);
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
            public static (int Offset, TopicProduceData Value) ReadV6(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionDataField = ImmutableArray<PartitionProduceData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionDataField_) = BinaryDecoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV6);
                if (_partitionDataField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionData'");
                else
                    partitionDataField = _partitionDataField_.Value;
                return (index, new(
                    nameField,
                    partitionDataField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV7);
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
            public static (int Offset, TopicProduceData Value) ReadV7(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionDataField = ImmutableArray<PartitionProduceData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionDataField_) = BinaryDecoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV7);
                if (_partitionDataField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionData'");
                else
                    partitionDataField = _partitionDataField_.Value;
                return (index, new(
                    nameField,
                    partitionDataField,
                    taggedFields
                ));
            }
            public static int WriteV8(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV8);
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
            public static (int Offset, TopicProduceData Value) ReadV8(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionDataField = ImmutableArray<PartitionProduceData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionDataField_) = BinaryDecoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV8);
                if (_partitionDataField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionData'");
                else
                    partitionDataField = _partitionDataField_.Value;
                return (index, new(
                    nameField,
                    partitionDataField,
                    taggedFields
                ));
            }
            public static int WriteV9(byte[] buffer, int index, TopicProduceData message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV9);
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
            public static (int Offset, TopicProduceData Value) ReadV9(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionDataField = ImmutableArray<PartitionProduceData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionDataField_) = BinaryDecoder.ReadCompactArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV9);
                if (_partitionDataField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionData'");
                else
                    partitionDataField = _partitionDataField_.Value;
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
                    partitionDataField,
                    taggedFields
                ));
            }
            [GeneratedCode("kgen", "1.0.0.0")]
            private static class PartitionProduceDataSerde
            {
                public static int WriteV0(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
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
                public static (int Offset, PartitionProduceData Value) ReadV0(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        indexField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
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
                public static (int Offset, PartitionProduceData Value) ReadV1(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        indexField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
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
                public static (int Offset, PartitionProduceData Value) ReadV2(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        indexField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
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
                public static (int Offset, PartitionProduceData Value) ReadV3(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        indexField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV4(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
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
                public static (int Offset, PartitionProduceData Value) ReadV4(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        indexField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV5(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
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
                public static (int Offset, PartitionProduceData Value) ReadV5(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        indexField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV6(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
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
                public static (int Offset, PartitionProduceData Value) ReadV6(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        indexField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV7(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
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
                public static (int Offset, PartitionProduceData Value) ReadV7(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        indexField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV8(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
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
                public static (int Offset, PartitionProduceData Value) ReadV8(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return (index, new(
                        indexField,
                        recordsField,
                        taggedFields
                    ));
                }
                public static int WriteV9(byte[] buffer, int index, PartitionProduceData message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.IndexField);
                    index = BinaryEncoder.WriteCompactRecords(buffer, index, message.RecordsField);
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
                public static (int Offset, PartitionProduceData Value) ReadV9(byte[] buffer, int index)
                {
                    var indexField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, indexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadCompactRecords(buffer, index);
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
                        recordsField,
                        taggedFields
                    ));
                }
            }
        }
    }
}