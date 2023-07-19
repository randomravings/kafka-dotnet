using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using OffsetFetchResponseGroup = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup;
using OffsetFetchResponsePartition = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseTopic.OffsetFetchResponsePartition;
using OffsetFetchResponsePartitions = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics.OffsetFetchResponsePartitions;
using OffsetFetchResponseTopic = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseTopic;
using OffsetFetchResponseTopics = Kafka.Client.Messages.OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetFetchResponseSerde
    {
        private static readonly ApiKey API_KEY = new(9);
        private static readonly VersionRange API_VERSIONS = new(0, 8);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (6, 32767);
        public static IEncoder<ResponseHeader, OffsetFetchResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 8 ? apiVersion : new Version(8);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                case 8:
                    return new Encoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 8, flexible, headerEncoder, WriteV8);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, OffsetFetchResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 8 ? apiVersion : new Version(8);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                case 8:
                    return new Decoder<ResponseHeader, OffsetFetchResponse>(API_KEY, 8, flexible, headerDecoder, ReadV8);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = BinaryEncoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV0);
            return index;
        }
        private static (int Offset, OffsetFetchResponse Value) ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = BinaryEncoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV1);
            return index;
        }
        private static (int Offset, OffsetFetchResponse Value) ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = BinaryEncoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV2);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static (int Offset, OffsetFetchResponse Value) ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return (index, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV3);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static (int Offset, OffsetFetchResponse Value) ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return (index, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV4);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static (int Offset, OffsetFetchResponse Value) ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return (index, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV5);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static (int Offset, OffsetFetchResponse Value) ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return (index, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV6);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
        private static (int Offset, OffsetFetchResponse Value) ReadV6(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV6);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<OffsetFetchResponseTopic>(buffer, index, message.TopicsField, OffsetFetchResponseTopicSerde.WriteV7);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
        private static (int Offset, OffsetFetchResponse Value) ReadV7(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicSerde.ReadV7);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static int WriteV8(byte[] buffer, int index, OffsetFetchResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<OffsetFetchResponseGroup>(buffer, index, message.GroupsField, OffsetFetchResponseGroupSerde.WriteV8);
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
        private static (int Offset, OffsetFetchResponse Value) ReadV8(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _groupsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseGroup>(buffer, index, OffsetFetchResponseGroupSerde.ReadV8);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
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
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class OffsetFetchResponseTopicSerde
        {
            public static int WriteV0(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV0);
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
            public static (int Offset, OffsetFetchResponseTopic Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV0);
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
            public static int WriteV1(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV1);
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
            public static (int Offset, OffsetFetchResponseTopic Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV1);
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
            public static int WriteV2(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV2);
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
            public static (int Offset, OffsetFetchResponseTopic Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV2);
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
            public static int WriteV3(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV3);
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
            public static (int Offset, OffsetFetchResponseTopic Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV3);
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
            public static int WriteV4(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV4);
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
            public static (int Offset, OffsetFetchResponseTopic Value) ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV4);
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
            public static int WriteV5(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV5);
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
            public static (int Offset, OffsetFetchResponseTopic Value) ReadV5(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV5);
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
            public static int WriteV6(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV6);
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
            public static (int Offset, OffsetFetchResponseTopic Value) ReadV6(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV6);
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
            public static int WriteV7(byte[] buffer, int index, OffsetFetchResponseTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<OffsetFetchResponsePartition>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionSerde.WriteV7);
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
            public static (int Offset, OffsetFetchResponseTopic Value) ReadV7(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionSerde.ReadV7);
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
            public static int WriteV8(byte[] buffer, int index, OffsetFetchResponseTopic message)
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
            public static (int Offset, OffsetFetchResponseTopic Value) ReadV8(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
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
            [GeneratedCode("kgen", "1.0.0.0")]
            private static class OffsetFetchResponsePartitionSerde
            {
                public static int WriteV0(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.MetadataField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                public static (int Offset, OffsetFetchResponsePartition Value) ReadV0(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.MetadataField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                public static (int Offset, OffsetFetchResponsePartition Value) ReadV1(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.MetadataField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                public static (int Offset, OffsetFetchResponsePartition Value) ReadV2(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.MetadataField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                public static (int Offset, OffsetFetchResponsePartition Value) ReadV3(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static int WriteV4(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.MetadataField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                public static (int Offset, OffsetFetchResponsePartition Value) ReadV4(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static int WriteV5(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.MetadataField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                public static (int Offset, OffsetFetchResponsePartition Value) ReadV5(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static int WriteV6(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.MetadataField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                public static (int Offset, OffsetFetchResponsePartition Value) ReadV6(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static int WriteV7(byte[] buffer, int index, OffsetFetchResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.MetadataField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                public static (int Offset, OffsetFetchResponsePartition Value) ReadV7(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static int WriteV8(byte[] buffer, int index, OffsetFetchResponsePartition message)
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
                public static (int Offset, OffsetFetchResponsePartition Value) ReadV8(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
            }
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class OffsetFetchResponseGroupSerde
        {
            public static int WriteV0(byte[] buffer, int index, OffsetFetchResponseGroup message)
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
            public static (int Offset, OffsetFetchResponseGroup Value) ReadV0(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, OffsetFetchResponseGroup message)
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
            public static (int Offset, OffsetFetchResponseGroup Value) ReadV1(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, OffsetFetchResponseGroup message)
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
            public static (int Offset, OffsetFetchResponseGroup Value) ReadV2(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, OffsetFetchResponseGroup message)
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
            public static (int Offset, OffsetFetchResponseGroup Value) ReadV3(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, OffsetFetchResponseGroup message)
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
            public static (int Offset, OffsetFetchResponseGroup Value) ReadV4(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, OffsetFetchResponseGroup message)
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
            public static (int Offset, OffsetFetchResponseGroup Value) ReadV5(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, OffsetFetchResponseGroup message)
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
            public static (int Offset, OffsetFetchResponseGroup Value) ReadV6(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, OffsetFetchResponseGroup message)
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
            public static (int Offset, OffsetFetchResponseGroup Value) ReadV7(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static int WriteV8(byte[] buffer, int index, OffsetFetchResponseGroup message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
                index = BinaryEncoder.WriteCompactArray<OffsetFetchResponseTopics>(buffer, index, message.TopicsField, OffsetFetchResponseTopicsSerde.WriteV8);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
            public static (int Offset, OffsetFetchResponseGroup Value) ReadV8(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseTopics>(buffer, index, OffsetFetchResponseTopicsSerde.ReadV8);
                if (_topicsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Topics'");
                else
                    topicsField = _topicsField_.Value;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            [GeneratedCode("kgen", "1.0.0.0")]
            private static class OffsetFetchResponseTopicsSerde
            {
                public static int WriteV0(byte[] buffer, int index, OffsetFetchResponseTopics message)
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
                public static (int Offset, OffsetFetchResponseTopics Value) ReadV0(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, OffsetFetchResponseTopics message)
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
                public static (int Offset, OffsetFetchResponseTopics Value) ReadV1(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, OffsetFetchResponseTopics message)
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
                public static (int Offset, OffsetFetchResponseTopics Value) ReadV2(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, OffsetFetchResponseTopics message)
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
                public static (int Offset, OffsetFetchResponseTopics Value) ReadV3(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static int WriteV4(byte[] buffer, int index, OffsetFetchResponseTopics message)
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
                public static (int Offset, OffsetFetchResponseTopics Value) ReadV4(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static int WriteV5(byte[] buffer, int index, OffsetFetchResponseTopics message)
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
                public static (int Offset, OffsetFetchResponseTopics Value) ReadV5(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static int WriteV6(byte[] buffer, int index, OffsetFetchResponseTopics message)
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
                public static (int Offset, OffsetFetchResponseTopics Value) ReadV6(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                public static int WriteV7(byte[] buffer, int index, OffsetFetchResponseTopics message)
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
                public static (int Offset, OffsetFetchResponseTopics Value) ReadV7(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                public static int WriteV8(byte[] buffer, int index, OffsetFetchResponseTopics message)
                {
                    index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteCompactArray<OffsetFetchResponsePartitions>(buffer, index, message.PartitionsField, OffsetFetchResponsePartitionsSerde.WriteV8);
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
                public static (int Offset, OffsetFetchResponseTopics Value) ReadV8(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                    (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponsePartitions>(buffer, index, OffsetFetchResponsePartitionsSerde.ReadV8);
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
                [GeneratedCode("kgen", "1.0.0.0")]
                private static class OffsetFetchResponsePartitionsSerde
                {
                    public static int WriteV0(byte[] buffer, int index, OffsetFetchResponsePartitions message)
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
                    public static (int Offset, OffsetFetchResponsePartitions Value) ReadV0(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static int WriteV1(byte[] buffer, int index, OffsetFetchResponsePartitions message)
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
                    public static (int Offset, OffsetFetchResponsePartitions Value) ReadV1(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static int WriteV2(byte[] buffer, int index, OffsetFetchResponsePartitions message)
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
                    public static (int Offset, OffsetFetchResponsePartitions Value) ReadV2(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static int WriteV3(byte[] buffer, int index, OffsetFetchResponsePartitions message)
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
                    public static (int Offset, OffsetFetchResponsePartitions Value) ReadV3(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static int WriteV4(byte[] buffer, int index, OffsetFetchResponsePartitions message)
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
                    public static (int Offset, OffsetFetchResponsePartitions Value) ReadV4(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static int WriteV5(byte[] buffer, int index, OffsetFetchResponsePartitions message)
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
                    public static (int Offset, OffsetFetchResponsePartitions Value) ReadV5(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return (index, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static int WriteV6(byte[] buffer, int index, OffsetFetchResponsePartitions message)
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
                    public static (int Offset, OffsetFetchResponsePartitions Value) ReadV6(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static int WriteV7(byte[] buffer, int index, OffsetFetchResponsePartitions message)
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
                    public static (int Offset, OffsetFetchResponsePartitions Value) ReadV7(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static int WriteV8(byte[] buffer, int index, OffsetFetchResponsePartitions message)
                    {
                        index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                        index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                        index = BinaryEncoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                        index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.MetadataField);
                        index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                    public static (int Offset, OffsetFetchResponsePartitions Value) ReadV8(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, metadataField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                        (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                }
            }
        }
    }
}