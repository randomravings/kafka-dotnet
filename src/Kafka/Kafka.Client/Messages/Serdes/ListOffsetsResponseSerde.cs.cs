using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using ListOffsetsPartitionResponse = Kafka.Client.Messages.ListOffsetsResponse.ListOffsetsTopicResponse.ListOffsetsPartitionResponse;
using ListOffsetsTopicResponse = Kafka.Client.Messages.ListOffsetsResponse.ListOffsetsTopicResponse;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListOffsetsResponseSerde
    {
        private static readonly ApiKey API_KEY = new(2);
        private static readonly VersionRange API_VERSIONS = new(0, 7);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (6, 32767);
        public static IEncoder<ResponseHeader, ListOffsetsResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 7 ? apiVersion : new Version(7);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, ListOffsetsResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 7 ? apiVersion : new Version(7);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<ResponseHeader, ListOffsetsResponse>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = BinaryEncoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV0);
            return index;
        }
        private static (int Offset, ListOffsetsResponse Value) ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = BinaryEncoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV1);
            return index;
        }
        private static (int Offset, ListOffsetsResponse Value) ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV2);
            return index;
        }
        private static (int Offset, ListOffsetsResponse Value) ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV3);
            return index;
        }
        private static (int Offset, ListOffsetsResponse Value) ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV4);
            return index;
        }
        private static (int Offset, ListOffsetsResponse Value) ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV5);
            return index;
        }
        private static (int Offset, ListOffsetsResponse Value) ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV6);
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
        private static (int Offset, ListOffsetsResponse Value) ReadV6(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV6);
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
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, ListOffsetsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<ListOffsetsTopicResponse>(buffer, index, message.TopicsField, ListOffsetsTopicResponseSerde.WriteV7);
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
        private static (int Offset, ListOffsetsResponse Value) ReadV7(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseSerde.ReadV7);
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
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class ListOffsetsTopicResponseSerde
        {
            public static int WriteV0(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV0);
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
            public static (int Offset, ListOffsetsTopicResponse Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV0);
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
            public static int WriteV1(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV1);
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
            public static (int Offset, ListOffsetsTopicResponse Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV1);
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
            public static int WriteV2(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV2);
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
            public static (int Offset, ListOffsetsTopicResponse Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV2);
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
            public static int WriteV3(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV3);
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
            public static (int Offset, ListOffsetsTopicResponse Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV3);
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
            public static int WriteV4(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV4);
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
            public static (int Offset, ListOffsetsTopicResponse Value) ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV4);
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
            public static int WriteV5(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV5);
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
            public static (int Offset, ListOffsetsTopicResponse Value) ReadV5(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV5);
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
            public static int WriteV6(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV6);
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
            public static (int Offset, ListOffsetsTopicResponse Value) ReadV6(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV6);
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
            public static int WriteV7(byte[] buffer, int index, ListOffsetsTopicResponse message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteCompactArray<ListOffsetsPartitionResponse>(buffer, index, message.PartitionsField, ListOffsetsPartitionResponseSerde.WriteV7);
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
            public static (int Offset, ListOffsetsTopicResponse Value) ReadV7(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseSerde.ReadV7);
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
            private static class ListOffsetsPartitionResponseSerde
            {
                public static int WriteV0(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteArray<long>(buffer, index, message.OldStyleOffsetsField, BinaryEncoder.WriteInt64);
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
                public static (int Offset, ListOffsetsPartitionResponse Value) ReadV0(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, var _oldStyleOffsetsField_) = BinaryDecoder.ReadArray<long>(buffer, index, BinaryDecoder.ReadInt64);
                    if (_oldStyleOffsetsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OldStyleOffsets'");
                    else
                        oldStyleOffsetsField = _oldStyleOffsetsField_.Value;
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.OffsetField);
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
                public static (int Offset, ListOffsetsPartitionResponse Value) ReadV1(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.OffsetField);
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
                public static (int Offset, ListOffsetsPartitionResponse Value) ReadV2(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.OffsetField);
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
                public static (int Offset, ListOffsetsPartitionResponse Value) ReadV3(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static int WriteV4(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.OffsetField);
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
                public static (int Offset, ListOffsetsPartitionResponse Value) ReadV4(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static int WriteV5(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.OffsetField);
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
                public static (int Offset, ListOffsetsPartitionResponse Value) ReadV5(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static int WriteV6(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.OffsetField);
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
                public static (int Offset, ListOffsetsPartitionResponse Value) ReadV6(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static int WriteV7(byte[] buffer, int index, ListOffsetsPartitionResponse message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.TimestampField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.OffsetField);
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
                public static (int Offset, ListOffsetsPartitionResponse Value) ReadV7(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
            }
        }
    }
}