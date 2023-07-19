using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using OffsetFetchRequestGroup = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestGroup;
using OffsetFetchRequestTopic = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestTopic;
using OffsetFetchRequestTopics = Kafka.Client.Messages.OffsetFetchRequest.OffsetFetchRequestGroup.OffsetFetchRequestTopics;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetFetchRequestSerde
    {
        private static readonly ApiKey API_KEY = new(9);
        private static readonly VersionRange API_VERSIONS = new(0, 8);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (6, 32767);
        public static IEncoder<RequestHeader, OffsetFetchRequest> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 8 ? apiVersion : new Version(8);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = RequestHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<RequestHeader, OffsetFetchRequest>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<RequestHeader, OffsetFetchRequest>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<RequestHeader, OffsetFetchRequest>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<RequestHeader, OffsetFetchRequest>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<RequestHeader, OffsetFetchRequest>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<RequestHeader, OffsetFetchRequest>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<RequestHeader, OffsetFetchRequest>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<RequestHeader, OffsetFetchRequest>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                case 8:
                    return new Encoder<RequestHeader, OffsetFetchRequest>(API_KEY, 8, flexible, headerEncoder, WriteV8);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<RequestHeader, OffsetFetchRequest> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 8 ? apiVersion : new Version(8);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = RequestHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<RequestHeader, OffsetFetchRequest>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<RequestHeader, OffsetFetchRequest>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<RequestHeader, OffsetFetchRequest>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<RequestHeader, OffsetFetchRequest>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<RequestHeader, OffsetFetchRequest>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<RequestHeader, OffsetFetchRequest>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<RequestHeader, OffsetFetchRequest>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<RequestHeader, OffsetFetchRequest>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                case 8:
                    return new Decoder<RequestHeader, OffsetFetchRequest>(API_KEY, 8, flexible, headerDecoder, ReadV8);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            index = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV0);
            return index;
        }
        private static (int Offset, OffsetFetchRequest Value) ReadV0(byte[] buffer, int index)
        {
            var groupIdField = "";
            var topicsField = default(ImmutableArray<OffsetFetchRequestTopic>?);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            index = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV1);
            return index;
        }
        private static (int Offset, OffsetFetchRequest Value) ReadV1(byte[] buffer, int index)
        {
            var groupIdField = "";
            var topicsField = default(ImmutableArray<OffsetFetchRequestTopic>?);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV2);
            return index;
        }
        private static (int Offset, OffsetFetchRequest Value) ReadV2(byte[] buffer, int index)
        {
            var groupIdField = "";
            var topicsField = default(ImmutableArray<OffsetFetchRequestTopic>?);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, topicsField) = BinaryDecoder.ReadArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV2);
            return (index, new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV3);
            return index;
        }
        private static (int Offset, OffsetFetchRequest Value) ReadV3(byte[] buffer, int index)
        {
            var groupIdField = "";
            var topicsField = default(ImmutableArray<OffsetFetchRequestTopic>?);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, topicsField) = BinaryDecoder.ReadArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV3);
            return (index, new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV4);
            return index;
        }
        private static (int Offset, OffsetFetchRequest Value) ReadV4(byte[] buffer, int index)
        {
            var groupIdField = "";
            var topicsField = default(ImmutableArray<OffsetFetchRequestTopic>?);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, topicsField) = BinaryDecoder.ReadArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV4);
            return (index, new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV5);
            return index;
        }
        private static (int Offset, OffsetFetchRequest Value) ReadV5(byte[] buffer, int index)
        {
            var groupIdField = "";
            var topicsField = default(ImmutableArray<OffsetFetchRequestTopic>?);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, topicsField) = BinaryDecoder.ReadArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV5);
            return (index, new(
                groupIdField,
                topicsField,
                groupsField,
                requireStableField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV6);
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
        private static (int Offset, OffsetFetchRequest Value) ReadV6(byte[] buffer, int index)
        {
            var groupIdField = "";
            var topicsField = default(ImmutableArray<OffsetFetchRequestTopic>?);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, topicsField) = BinaryDecoder.ReadCompactArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV6);
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
                groupsField,
                requireStableField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteCompactArray<OffsetFetchRequestTopic>(buffer, index, message.TopicsField, OffsetFetchRequestTopicSerde.WriteV7);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.RequireStableField);
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
        private static (int Offset, OffsetFetchRequest Value) ReadV7(byte[] buffer, int index)
        {
            var groupIdField = "";
            var topicsField = default(ImmutableArray<OffsetFetchRequestTopic>?);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, topicsField) = BinaryDecoder.ReadCompactArray<OffsetFetchRequestTopic>(buffer, index, OffsetFetchRequestTopicSerde.ReadV7);
            (index, requireStableField) = BinaryDecoder.ReadBoolean(buffer, index);
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
                groupsField,
                requireStableField,
                taggedFields
            ));
        }
        private static int WriteV8(byte[] buffer, int index, OffsetFetchRequest message)
        {
            index = BinaryEncoder.WriteCompactArray<OffsetFetchRequestGroup>(buffer, index, message.GroupsField, OffsetFetchRequestGroupSerde.WriteV8);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.RequireStableField);
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
        private static (int Offset, OffsetFetchRequest Value) ReadV8(byte[] buffer, int index)
        {
            var groupIdField = "";
            var topicsField = default(ImmutableArray<OffsetFetchRequestTopic>?);
            var groupsField = ImmutableArray<OffsetFetchRequestGroup>.Empty;
            var requireStableField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _groupsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchRequestGroup>(buffer, index, OffsetFetchRequestGroupSerde.ReadV8);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
            (index, requireStableField) = BinaryDecoder.ReadBoolean(buffer, index);
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
                groupsField,
                requireStableField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class OffsetFetchRequestTopicSerde
        {
            public static int WriteV0(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
            public static (int Offset, OffsetFetchRequestTopic Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionIndexesField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionIndexesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionIndexesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                else
                    partitionIndexesField = _partitionIndexesField_.Value;
                return (index, new(
                    nameField,
                    partitionIndexesField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
            public static (int Offset, OffsetFetchRequestTopic Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionIndexesField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionIndexesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionIndexesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                else
                    partitionIndexesField = _partitionIndexesField_.Value;
                return (index, new(
                    nameField,
                    partitionIndexesField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
            public static (int Offset, OffsetFetchRequestTopic Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionIndexesField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionIndexesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionIndexesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                else
                    partitionIndexesField = _partitionIndexesField_.Value;
                return (index, new(
                    nameField,
                    partitionIndexesField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
            public static (int Offset, OffsetFetchRequestTopic Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionIndexesField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionIndexesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionIndexesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                else
                    partitionIndexesField = _partitionIndexesField_.Value;
                return (index, new(
                    nameField,
                    partitionIndexesField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
            public static (int Offset, OffsetFetchRequestTopic Value) ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionIndexesField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionIndexesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionIndexesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                else
                    partitionIndexesField = _partitionIndexesField_.Value;
                return (index, new(
                    nameField,
                    partitionIndexesField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
            public static (int Offset, OffsetFetchRequestTopic Value) ReadV5(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionIndexesField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionIndexesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionIndexesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                else
                    partitionIndexesField = _partitionIndexesField_.Value;
                return (index, new(
                    nameField,
                    partitionIndexesField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
            public static (int Offset, OffsetFetchRequestTopic Value) ReadV6(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionIndexesField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionIndexesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionIndexesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                else
                    partitionIndexesField = _partitionIndexesField_.Value;
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
                    partitionIndexesField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, OffsetFetchRequestTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
            public static (int Offset, OffsetFetchRequestTopic Value) ReadV7(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionIndexesField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionIndexesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionIndexesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                else
                    partitionIndexesField = _partitionIndexesField_.Value;
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
                    partitionIndexesField,
                    taggedFields
                ));
            }
            public static int WriteV8(byte[] buffer, int index, OffsetFetchRequestTopic message)
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
            public static (int Offset, OffsetFetchRequestTopic Value) ReadV8(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionIndexesField = ImmutableArray<int>.Empty;
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
                    partitionIndexesField,
                    taggedFields
                ));
            }
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class OffsetFetchRequestGroupSerde
        {
            public static int WriteV0(byte[] buffer, int index, OffsetFetchRequestGroup message)
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
            public static (int Offset, OffsetFetchRequestGroup Value) ReadV0(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = default(ImmutableArray<OffsetFetchRequestTopics>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    groupIdField,
                    topicsField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, OffsetFetchRequestGroup message)
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
            public static (int Offset, OffsetFetchRequestGroup Value) ReadV1(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = default(ImmutableArray<OffsetFetchRequestTopics>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    groupIdField,
                    topicsField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, OffsetFetchRequestGroup message)
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
            public static (int Offset, OffsetFetchRequestGroup Value) ReadV2(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = default(ImmutableArray<OffsetFetchRequestTopics>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    groupIdField,
                    topicsField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, OffsetFetchRequestGroup message)
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
            public static (int Offset, OffsetFetchRequestGroup Value) ReadV3(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = default(ImmutableArray<OffsetFetchRequestTopics>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    groupIdField,
                    topicsField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, OffsetFetchRequestGroup message)
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
            public static (int Offset, OffsetFetchRequestGroup Value) ReadV4(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = default(ImmutableArray<OffsetFetchRequestTopics>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    groupIdField,
                    topicsField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, OffsetFetchRequestGroup message)
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
            public static (int Offset, OffsetFetchRequestGroup Value) ReadV5(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = default(ImmutableArray<OffsetFetchRequestTopics>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    groupIdField,
                    topicsField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, OffsetFetchRequestGroup message)
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
            public static (int Offset, OffsetFetchRequestGroup Value) ReadV6(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = default(ImmutableArray<OffsetFetchRequestTopics>?);
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
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, OffsetFetchRequestGroup message)
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
            public static (int Offset, OffsetFetchRequestGroup Value) ReadV7(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = default(ImmutableArray<OffsetFetchRequestTopics>?);
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
                    taggedFields
                ));
            }
            public static int WriteV8(byte[] buffer, int index, OffsetFetchRequestGroup message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
                index = BinaryEncoder.WriteCompactArray<OffsetFetchRequestTopics>(buffer, index, message.TopicsField, OffsetFetchRequestTopicsSerde.WriteV8);
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
            public static (int Offset, OffsetFetchRequestGroup Value) ReadV8(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = default(ImmutableArray<OffsetFetchRequestTopics>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, topicsField) = BinaryDecoder.ReadCompactArray<OffsetFetchRequestTopics>(buffer, index, OffsetFetchRequestTopicsSerde.ReadV8);
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
                    taggedFields
                ));
            }
            [GeneratedCode("kgen", "1.0.0.0")]
            private static class OffsetFetchRequestTopicsSerde
            {
                public static int WriteV0(byte[] buffer, int index, OffsetFetchRequestTopics message)
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
                public static (int Offset, OffsetFetchRequestTopics Value) ReadV0(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionIndexesField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        partitionIndexesField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, OffsetFetchRequestTopics message)
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
                public static (int Offset, OffsetFetchRequestTopics Value) ReadV1(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionIndexesField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        partitionIndexesField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, OffsetFetchRequestTopics message)
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
                public static (int Offset, OffsetFetchRequestTopics Value) ReadV2(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionIndexesField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        partitionIndexesField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, OffsetFetchRequestTopics message)
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
                public static (int Offset, OffsetFetchRequestTopics Value) ReadV3(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionIndexesField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        partitionIndexesField,
                        taggedFields
                    ));
                }
                public static int WriteV4(byte[] buffer, int index, OffsetFetchRequestTopics message)
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
                public static (int Offset, OffsetFetchRequestTopics Value) ReadV4(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionIndexesField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        partitionIndexesField,
                        taggedFields
                    ));
                }
                public static int WriteV5(byte[] buffer, int index, OffsetFetchRequestTopics message)
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
                public static (int Offset, OffsetFetchRequestTopics Value) ReadV5(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionIndexesField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        partitionIndexesField,
                        taggedFields
                    ));
                }
                public static int WriteV6(byte[] buffer, int index, OffsetFetchRequestTopics message)
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
                public static (int Offset, OffsetFetchRequestTopics Value) ReadV6(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionIndexesField = ImmutableArray<int>.Empty;
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
                        partitionIndexesField,
                        taggedFields
                    ));
                }
                public static int WriteV7(byte[] buffer, int index, OffsetFetchRequestTopics message)
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
                public static (int Offset, OffsetFetchRequestTopics Value) ReadV7(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionIndexesField = ImmutableArray<int>.Empty;
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
                        partitionIndexesField,
                        taggedFields
                    ));
                }
                public static int WriteV8(byte[] buffer, int index, OffsetFetchRequestTopics message)
                {
                    index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, OffsetFetchRequestTopics Value) ReadV8(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionIndexesField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                    (index, var _partitionIndexesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_partitionIndexesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
                    else
                        partitionIndexesField = _partitionIndexesField_.Value;
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
                        partitionIndexesField,
                        taggedFields
                    ));
                }
            }
        }
    }
}