using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using OffsetCommitRequestPartition = Kafka.Client.Messages.OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition;
using OffsetCommitRequestTopic = Kafka.Client.Messages.OffsetCommitRequest.OffsetCommitRequestTopic;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetCommitRequestSerde
    {
        private static readonly ApiKey API_KEY = new(8);
        private static readonly VersionRange API_VERSIONS = new(0, 8);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (8, 32767);
        public static IEncoder<RequestHeader, OffsetCommitRequest> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 8 ? apiVersion : new Version(8);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = RequestHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<RequestHeader, OffsetCommitRequest>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<RequestHeader, OffsetCommitRequest>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<RequestHeader, OffsetCommitRequest>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<RequestHeader, OffsetCommitRequest>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<RequestHeader, OffsetCommitRequest>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<RequestHeader, OffsetCommitRequest>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<RequestHeader, OffsetCommitRequest>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<RequestHeader, OffsetCommitRequest>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                case 8:
                    return new Encoder<RequestHeader, OffsetCommitRequest>(API_KEY, 8, flexible, headerEncoder, WriteV8);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<RequestHeader, OffsetCommitRequest> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 8 ? apiVersion : new Version(8);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = RequestHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<RequestHeader, OffsetCommitRequest>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<RequestHeader, OffsetCommitRequest>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<RequestHeader, OffsetCommitRequest>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<RequestHeader, OffsetCommitRequest>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<RequestHeader, OffsetCommitRequest>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<RequestHeader, OffsetCommitRequest>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<RequestHeader, OffsetCommitRequest>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<RequestHeader, OffsetCommitRequest>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                case 8:
                    return new Decoder<RequestHeader, OffsetCommitRequest>(API_KEY, 8, flexible, headerDecoder, ReadV8);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV0);
            return index;
        }
        private static (int Offset, OffsetCommitRequest Value) ReadV0(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = ImmutableArray<OffsetCommitRequestTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV1);
            return index;
        }
        private static (int Offset, OffsetCommitRequest Value) ReadV1(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = ImmutableArray<OffsetCommitRequestTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.RetentionTimeMsField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV2);
            return index;
        }
        private static (int Offset, OffsetCommitRequest Value) ReadV2(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = ImmutableArray<OffsetCommitRequestTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, retentionTimeMsField) = BinaryDecoder.ReadInt64(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.RetentionTimeMsField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV3);
            return index;
        }
        private static (int Offset, OffsetCommitRequest Value) ReadV3(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = ImmutableArray<OffsetCommitRequestTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, retentionTimeMsField) = BinaryDecoder.ReadInt64(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteInt64(buffer, index, message.RetentionTimeMsField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV4);
            return index;
        }
        private static (int Offset, OffsetCommitRequest Value) ReadV4(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = ImmutableArray<OffsetCommitRequestTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, retentionTimeMsField) = BinaryDecoder.ReadInt64(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV5);
            return index;
        }
        private static (int Offset, OffsetCommitRequest Value) ReadV5(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = ImmutableArray<OffsetCommitRequestTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV6);
            return index;
        }
        private static (int Offset, OffsetCommitRequest Value) ReadV6(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = ImmutableArray<OffsetCommitRequestTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV6);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV7);
            return index;
        }
        private static (int Offset, OffsetCommitRequest Value) ReadV7(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = ImmutableArray<OffsetCommitRequestTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, groupInstanceIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV7);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV8(byte[] buffer, int index, OffsetCommitRequest message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = BinaryEncoder.WriteCompactArray<OffsetCommitRequestTopic>(buffer, index, message.TopicsField, OffsetCommitRequestTopicSerde.WriteV8);
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
        private static (int Offset, OffsetCommitRequest Value) ReadV8(byte[] buffer, int index)
        {
            var groupIdField = "";
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var retentionTimeMsField = default(long);
            var topicsField = ImmutableArray<OffsetCommitRequestTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<OffsetCommitRequestTopic>(buffer, index, OffsetCommitRequestTopicSerde.ReadV8);
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
                groupIdField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                retentionTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class OffsetCommitRequestTopicSerde
        {
            public static int WriteV0(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV0);
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
            public static (int Offset, OffsetCommitRequestTopic Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitRequestPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV0);
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
            public static int WriteV1(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV1);
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
            public static (int Offset, OffsetCommitRequestTopic Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitRequestPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV1);
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
            public static int WriteV2(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV2);
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
            public static (int Offset, OffsetCommitRequestTopic Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitRequestPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV2);
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
            public static int WriteV3(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV3);
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
            public static (int Offset, OffsetCommitRequestTopic Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitRequestPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV3);
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
            public static int WriteV4(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV4);
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
            public static (int Offset, OffsetCommitRequestTopic Value) ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitRequestPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV4);
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
            public static int WriteV5(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV5);
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
            public static (int Offset, OffsetCommitRequestTopic Value) ReadV5(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitRequestPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV5);
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
            public static int WriteV6(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV6);
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
            public static (int Offset, OffsetCommitRequestTopic Value) ReadV6(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitRequestPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV6);
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
            public static int WriteV7(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV7);
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
            public static (int Offset, OffsetCommitRequestTopic Value) ReadV7(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitRequestPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV7);
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
            public static int WriteV8(byte[] buffer, int index, OffsetCommitRequestTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<OffsetCommitRequestPartition>(buffer, index, message.PartitionsField, OffsetCommitRequestPartitionSerde.WriteV8);
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
            public static (int Offset, OffsetCommitRequestTopic Value) ReadV8(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitRequestPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<OffsetCommitRequestPartition>(buffer, index, OffsetCommitRequestPartitionSerde.ReadV8);
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
            private static class OffsetCommitRequestPartitionSerde
            {
                public static int WriteV0(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
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
                public static (int Offset, OffsetCommitRequestPartition Value) ReadV0(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedMetadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommitTimestampField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
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
                public static (int Offset, OffsetCommitRequestPartition Value) ReadV1(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, commitTimestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedMetadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
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
                public static (int Offset, OffsetCommitRequestPartition Value) ReadV2(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedMetadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
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
                public static (int Offset, OffsetCommitRequestPartition Value) ReadV3(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedMetadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField,
                        taggedFields
                    ));
                }
                public static int WriteV4(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
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
                public static (int Offset, OffsetCommitRequestPartition Value) ReadV4(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedMetadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField,
                        taggedFields
                    ));
                }
                public static int WriteV5(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
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
                public static (int Offset, OffsetCommitRequestPartition Value) ReadV5(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedMetadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField,
                        taggedFields
                    ));
                }
                public static int WriteV6(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
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
                public static (int Offset, OffsetCommitRequestPartition Value) ReadV6(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedMetadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField,
                        taggedFields
                    ));
                }
                public static int WriteV7(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = BinaryEncoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
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
                public static (int Offset, OffsetCommitRequestPartition Value) ReadV7(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedMetadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        commitTimestampField,
                        committedMetadataField,
                        taggedFields
                    ));
                }
                public static int WriteV8(byte[] buffer, int index, OffsetCommitRequestPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.CommittedMetadataField);
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
                public static (int Offset, OffsetCommitRequestPartition Value) ReadV8(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var commitTimestampField = default(long);
                    var committedMetadataField = default(string?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedMetadataField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                        commitTimestampField,
                        committedMetadataField,
                        taggedFields
                    ));
                }
            }
        }
    }
}