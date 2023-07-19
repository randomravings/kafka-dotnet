using AddPartitionsToTxnTopic = Kafka.Client.Messages.AddPartitionsToTxnRequest.AddPartitionsToTxnTopic;
using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AddPartitionsToTxnRequestSerde
    {
        private static readonly ApiKey API_KEY = new(24);
        private static readonly VersionRange API_VERSIONS = new(0, 3);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (3, 32767);
        public static IEncoder<RequestHeader, AddPartitionsToTxnRequest> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 3 ? apiVersion : new Version(3);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = RequestHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<RequestHeader, AddPartitionsToTxnRequest>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<RequestHeader, AddPartitionsToTxnRequest>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<RequestHeader, AddPartitionsToTxnRequest>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<RequestHeader, AddPartitionsToTxnRequest>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<RequestHeader, AddPartitionsToTxnRequest> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 3 ? apiVersion : new Version(3);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = RequestHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<RequestHeader, AddPartitionsToTxnRequest>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<RequestHeader, AddPartitionsToTxnRequest>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<RequestHeader, AddPartitionsToTxnRequest>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<RequestHeader, AddPartitionsToTxnRequest>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, AddPartitionsToTxnRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = BinaryEncoder.WriteArray<AddPartitionsToTxnTopic>(buffer, index, message.TopicsField, AddPartitionsToTxnTopicSerde.WriteV0);
            return index;
        }
        private static (int Offset, AddPartitionsToTxnRequest Value) ReadV0(byte[] buffer, int index)
        {
            var transactionalIdField = "";
            var producerIdField = default(long);
            var producerEpochField = default(short);
            var topicsField = ImmutableArray<AddPartitionsToTxnTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, transactionalIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
            (index, producerEpochField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnTopic>(buffer, index, AddPartitionsToTxnTopicSerde.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, AddPartitionsToTxnRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = BinaryEncoder.WriteArray<AddPartitionsToTxnTopic>(buffer, index, message.TopicsField, AddPartitionsToTxnTopicSerde.WriteV1);
            return index;
        }
        private static (int Offset, AddPartitionsToTxnRequest Value) ReadV1(byte[] buffer, int index)
        {
            var transactionalIdField = "";
            var producerIdField = default(long);
            var producerEpochField = default(short);
            var topicsField = ImmutableArray<AddPartitionsToTxnTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, transactionalIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
            (index, producerEpochField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnTopic>(buffer, index, AddPartitionsToTxnTopicSerde.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, AddPartitionsToTxnRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = BinaryEncoder.WriteArray<AddPartitionsToTxnTopic>(buffer, index, message.TopicsField, AddPartitionsToTxnTopicSerde.WriteV2);
            return index;
        }
        private static (int Offset, AddPartitionsToTxnRequest Value) ReadV2(byte[] buffer, int index)
        {
            var transactionalIdField = "";
            var producerIdField = default(long);
            var producerEpochField = default(short);
            var topicsField = ImmutableArray<AddPartitionsToTxnTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, transactionalIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
            (index, producerEpochField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<AddPartitionsToTxnTopic>(buffer, index, AddPartitionsToTxnTopicSerde.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                transactionalIdField,
                producerIdField,
                producerEpochField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, AddPartitionsToTxnRequest message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.TransactionalIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = BinaryEncoder.WriteCompactArray<AddPartitionsToTxnTopic>(buffer, index, message.TopicsField, AddPartitionsToTxnTopicSerde.WriteV3);
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
        private static (int Offset, AddPartitionsToTxnRequest Value) ReadV3(byte[] buffer, int index)
        {
            var transactionalIdField = "";
            var producerIdField = default(long);
            var producerEpochField = default(short);
            var topicsField = ImmutableArray<AddPartitionsToTxnTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, transactionalIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
            (index, producerEpochField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<AddPartitionsToTxnTopic>(buffer, index, AddPartitionsToTxnTopicSerde.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
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
                producerIdField,
                producerEpochField,
                topicsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class AddPartitionsToTxnTopicSerde
        {
            public static int WriteV0(byte[] buffer, int index, AddPartitionsToTxnTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static (int Offset, AddPartitionsToTxnTopic Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, AddPartitionsToTxnTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static (int Offset, AddPartitionsToTxnTopic Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, AddPartitionsToTxnTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static (int Offset, AddPartitionsToTxnTopic Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, AddPartitionsToTxnTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
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
            public static (int Offset, AddPartitionsToTxnTopic Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
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
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
        }
    }
}