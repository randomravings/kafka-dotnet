using DeleteTopicState = Kafka.Client.Messages.DeleteTopicsRequest.DeleteTopicState;
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
    public static class DeleteTopicsRequestSerde
    {
        private static readonly ApiKey API_KEY = new(20);
        private static readonly VersionRange API_VERSIONS = new(0, 6);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (4, 32767);
        public static IEncoder<RequestHeader, DeleteTopicsRequest> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 6 ? apiVersion : new Version(6);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = RequestHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<RequestHeader, DeleteTopicsRequest> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 6 ? apiVersion : new Version(6);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = RequestHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<RequestHeader, DeleteTopicsRequest>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = BinaryEncoder.WriteArray<string>(buffer, index, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static (int Offset, DeleteTopicsRequest Value) ReadV0(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = ImmutableArray<string>.Empty;
            var timeoutMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicNamesField_) = BinaryDecoder.ReadArray<string>(buffer, index, BinaryDecoder.ReadCompactString);
            if (_topicNamesField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicNames'");
            else
                topicNamesField = _topicNamesField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                topicsField,
                topicNamesField,
                timeoutMsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = BinaryEncoder.WriteArray<string>(buffer, index, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static (int Offset, DeleteTopicsRequest Value) ReadV1(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = ImmutableArray<string>.Empty;
            var timeoutMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicNamesField_) = BinaryDecoder.ReadArray<string>(buffer, index, BinaryDecoder.ReadCompactString);
            if (_topicNamesField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicNames'");
            else
                topicNamesField = _topicNamesField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                topicsField,
                topicNamesField,
                timeoutMsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = BinaryEncoder.WriteArray<string>(buffer, index, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static (int Offset, DeleteTopicsRequest Value) ReadV2(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = ImmutableArray<string>.Empty;
            var timeoutMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicNamesField_) = BinaryDecoder.ReadArray<string>(buffer, index, BinaryDecoder.ReadCompactString);
            if (_topicNamesField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicNames'");
            else
                topicNamesField = _topicNamesField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                topicsField,
                topicNamesField,
                timeoutMsField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = BinaryEncoder.WriteArray<string>(buffer, index, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            return index;
        }
        private static (int Offset, DeleteTopicsRequest Value) ReadV3(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = ImmutableArray<string>.Empty;
            var timeoutMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicNamesField_) = BinaryDecoder.ReadArray<string>(buffer, index, BinaryDecoder.ReadCompactString);
            if (_topicNamesField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicNames'");
            else
                topicNamesField = _topicNamesField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                topicsField,
                topicNamesField,
                timeoutMsField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = BinaryEncoder.WriteCompactArray<string>(buffer, index, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, DeleteTopicsRequest Value) ReadV4(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = ImmutableArray<string>.Empty;
            var timeoutMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicNamesField_) = BinaryDecoder.ReadCompactArray<string>(buffer, index, BinaryDecoder.ReadCompactString);
            if (_topicNamesField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicNames'");
            else
                topicNamesField = _topicNamesField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
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
                topicsField,
                topicNamesField,
                timeoutMsField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = BinaryEncoder.WriteCompactArray<string>(buffer, index, message.TopicNamesField, BinaryEncoder.WriteCompactString);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, DeleteTopicsRequest Value) ReadV5(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = ImmutableArray<string>.Empty;
            var timeoutMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicNamesField_) = BinaryDecoder.ReadCompactArray<string>(buffer, index, BinaryDecoder.ReadCompactString);
            if (_topicNamesField_ == null)
                throw new NullReferenceException("Null not allowed for 'TopicNames'");
            else
                topicNamesField = _topicNamesField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
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
                topicsField,
                topicNamesField,
                timeoutMsField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, DeleteTopicsRequest message)
        {
            index = BinaryEncoder.WriteCompactArray<DeleteTopicState>(buffer, index, message.TopicsField, DeleteTopicStateSerde.WriteV6);
            index = BinaryEncoder.WriteInt32(buffer, index, message.TimeoutMsField);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, DeleteTopicsRequest Value) ReadV6(byte[] buffer, int index)
        {
            var topicsField = ImmutableArray<DeleteTopicState>.Empty;
            var topicNamesField = ImmutableArray<string>.Empty;
            var timeoutMsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<DeleteTopicState>(buffer, index, DeleteTopicStateSerde.ReadV6);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, timeoutMsField) = BinaryDecoder.ReadInt32(buffer, index);
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
                topicsField,
                topicNamesField,
                timeoutMsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class DeleteTopicStateSerde
        {
            public static int WriteV0(byte[] buffer, int index, DeleteTopicState message)
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
            public static (int Offset, DeleteTopicState Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    nameField,
                    topicIdField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, DeleteTopicState message)
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
            public static (int Offset, DeleteTopicState Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    nameField,
                    topicIdField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, DeleteTopicState message)
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
            public static (int Offset, DeleteTopicState Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    nameField,
                    topicIdField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, DeleteTopicState message)
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
            public static (int Offset, DeleteTopicState Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    nameField,
                    topicIdField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, DeleteTopicState message)
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
            public static (int Offset, DeleteTopicState Value) ReadV4(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
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
                    topicIdField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, DeleteTopicState message)
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
            public static (int Offset, DeleteTopicState Value) ReadV5(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
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
                    topicIdField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, DeleteTopicState message)
            {
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, DeleteTopicState Value) ReadV6(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
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
                    topicIdField,
                    taggedFields
                ));
            }
        }
    }
}