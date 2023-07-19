using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using ListOffsetsPartition = Kafka.Client.Messages.ListOffsetsRequest.ListOffsetsTopic.ListOffsetsPartition;
using ListOffsetsTopic = Kafka.Client.Messages.ListOffsetsRequest.ListOffsetsTopic;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListOffsetsRequestSerde
    {
        private static readonly ApiKey API_KEY = new(2);
        private static readonly VersionRange API_VERSIONS = new(0, 7);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (6, 32767);
        public static IEncoder<RequestHeader, ListOffsetsRequest> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 7 ? apiVersion : new Version(7);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = RequestHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<RequestHeader, ListOffsetsRequest>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<RequestHeader, ListOffsetsRequest>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<RequestHeader, ListOffsetsRequest>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<RequestHeader, ListOffsetsRequest>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<RequestHeader, ListOffsetsRequest>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<RequestHeader, ListOffsetsRequest>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<RequestHeader, ListOffsetsRequest>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<RequestHeader, ListOffsetsRequest>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<RequestHeader, ListOffsetsRequest> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 7 ? apiVersion : new Version(7);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = RequestHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<RequestHeader, ListOffsetsRequest>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<RequestHeader, ListOffsetsRequest>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<RequestHeader, ListOffsetsRequest>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<RequestHeader, ListOffsetsRequest>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<RequestHeader, ListOffsetsRequest>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<RequestHeader, ListOffsetsRequest>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<RequestHeader, ListOffsetsRequest>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<RequestHeader, ListOffsetsRequest>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV0);
            return index;
        }
        private static (int Offset, ListOffsetsRequest Value) ReadV0(byte[] buffer, int index)
        {
            var replicaIdField = default(int);
            var isolationLevelField = default(sbyte);
            var topicsField = ImmutableArray<ListOffsetsTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                replicaIdField,
                isolationLevelField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV1);
            return index;
        }
        private static (int Offset, ListOffsetsRequest Value) ReadV1(byte[] buffer, int index)
        {
            var replicaIdField = default(int);
            var isolationLevelField = default(sbyte);
            var topicsField = ImmutableArray<ListOffsetsTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                replicaIdField,
                isolationLevelField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV2);
            return index;
        }
        private static (int Offset, ListOffsetsRequest Value) ReadV2(byte[] buffer, int index)
        {
            var replicaIdField = default(int);
            var isolationLevelField = default(sbyte);
            var topicsField = ImmutableArray<ListOffsetsTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                replicaIdField,
                isolationLevelField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV3);
            return index;
        }
        private static (int Offset, ListOffsetsRequest Value) ReadV3(byte[] buffer, int index)
        {
            var replicaIdField = default(int);
            var isolationLevelField = default(sbyte);
            var topicsField = ImmutableArray<ListOffsetsTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                replicaIdField,
                isolationLevelField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV4);
            return index;
        }
        private static (int Offset, ListOffsetsRequest Value) ReadV4(byte[] buffer, int index)
        {
            var replicaIdField = default(int);
            var isolationLevelField = default(sbyte);
            var topicsField = ImmutableArray<ListOffsetsTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                replicaIdField,
                isolationLevelField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV5);
            return index;
        }
        private static (int Offset, ListOffsetsRequest Value) ReadV5(byte[] buffer, int index)
        {
            var replicaIdField = default(int);
            var isolationLevelField = default(sbyte);
            var topicsField = ImmutableArray<ListOffsetsTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                replicaIdField,
                isolationLevelField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteCompactArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV6);
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
        private static (int Offset, ListOffsetsRequest Value) ReadV6(byte[] buffer, int index)
        {
            var replicaIdField = default(int);
            var isolationLevelField = default(sbyte);
            var topicsField = ImmutableArray<ListOffsetsTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV6);
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
                replicaIdField,
                isolationLevelField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteCompactArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV7);
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
        private static (int Offset, ListOffsetsRequest Value) ReadV7(byte[] buffer, int index)
        {
            var replicaIdField = default(int);
            var isolationLevelField = default(sbyte);
            var topicsField = ImmutableArray<ListOffsetsTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsTopic>(buffer, index, ListOffsetsTopicSerde.ReadV7);
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
                replicaIdField,
                isolationLevelField,
                topicsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class ListOffsetsTopicSerde
        {
            public static int WriteV0(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV0);
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
            public static (int Offset, ListOffsetsTopic Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV0);
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
            public static int WriteV1(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV1);
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
            public static (int Offset, ListOffsetsTopic Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV1);
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
            public static int WriteV2(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV2);
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
            public static (int Offset, ListOffsetsTopic Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV2);
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
            public static int WriteV3(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV3);
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
            public static (int Offset, ListOffsetsTopic Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV3);
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
            public static int WriteV4(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV4);
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
            public static (int Offset, ListOffsetsTopic Value) ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV4);
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
            public static int WriteV5(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV5);
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
            public static (int Offset, ListOffsetsTopic Value) ReadV5(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV5);
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
            public static int WriteV6(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV6);
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
            public static (int Offset, ListOffsetsTopic Value) ReadV6(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV6);
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
            public static int WriteV7(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV7);
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
            public static (int Offset, ListOffsetsTopic Value) ReadV7(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsPartition>(buffer, index, ListOffsetsPartitionSerde.ReadV7);
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
            private static class ListOffsetsPartitionSerde
            {
                public static int WriteV0(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.MaxNumOffsetsField);
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
                public static (int Offset, ListOffsetsPartition Value) ReadV0(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var currentLeaderEpochField = default(int);
                    var timestampField = default(long);
                    var maxNumOffsetsField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, maxNumOffsetsField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
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
                public static (int Offset, ListOffsetsPartition Value) ReadV1(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var currentLeaderEpochField = default(int);
                    var timestampField = default(long);
                    var maxNumOffsetsField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
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
                public static (int Offset, ListOffsetsPartition Value) ReadV2(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var currentLeaderEpochField = default(int);
                    var timestampField = default(long);
                    var maxNumOffsetsField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
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
                public static (int Offset, ListOffsetsPartition Value) ReadV3(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var currentLeaderEpochField = default(int);
                    var timestampField = default(long);
                    var maxNumOffsetsField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField,
                        taggedFields
                    ));
                }
                public static int WriteV4(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
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
                public static (int Offset, ListOffsetsPartition Value) ReadV4(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var currentLeaderEpochField = default(int);
                    var timestampField = default(long);
                    var maxNumOffsetsField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, currentLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField,
                        taggedFields
                    ));
                }
                public static int WriteV5(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
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
                public static (int Offset, ListOffsetsPartition Value) ReadV5(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var currentLeaderEpochField = default(int);
                    var timestampField = default(long);
                    var maxNumOffsetsField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, currentLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField,
                        taggedFields
                    ));
                }
                public static int WriteV6(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
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
                public static (int Offset, ListOffsetsPartition Value) ReadV6(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var currentLeaderEpochField = default(int);
                    var timestampField = default(long);
                    var maxNumOffsetsField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, currentLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
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
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField,
                        taggedFields
                    ));
                }
                public static int WriteV7(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
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
                public static (int Offset, ListOffsetsPartition Value) ReadV7(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var currentLeaderEpochField = default(int);
                    var timestampField = default(long);
                    var maxNumOffsetsField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, currentLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
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
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField,
                        taggedFields
                    ));
                }
            }
        }
    }
}