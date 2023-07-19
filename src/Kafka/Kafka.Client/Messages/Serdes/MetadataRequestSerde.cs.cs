using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using MetadataRequestTopic = Kafka.Client.Messages.MetadataRequest.MetadataRequestTopic;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class MetadataRequestSerde
    {
        private static readonly ApiKey API_KEY = new(3);
        private static readonly VersionRange API_VERSIONS = new(0, 12);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (9, 32767);
        public static IEncoder<RequestHeader, MetadataRequest> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 12 ? apiVersion : new Version(12);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = RequestHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<RequestHeader, MetadataRequest>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<RequestHeader, MetadataRequest>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<RequestHeader, MetadataRequest>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<RequestHeader, MetadataRequest>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<RequestHeader, MetadataRequest>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<RequestHeader, MetadataRequest>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<RequestHeader, MetadataRequest>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<RequestHeader, MetadataRequest>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                case 8:
                    return new Encoder<RequestHeader, MetadataRequest>(API_KEY, 8, flexible, headerEncoder, WriteV8);
                case 9:
                    return new Encoder<RequestHeader, MetadataRequest>(API_KEY, 9, flexible, headerEncoder, WriteV9);
                case 10:
                    return new Encoder<RequestHeader, MetadataRequest>(API_KEY, 10, flexible, headerEncoder, WriteV10);
                case 11:
                    return new Encoder<RequestHeader, MetadataRequest>(API_KEY, 11, flexible, headerEncoder, WriteV11);
                case 12:
                    return new Encoder<RequestHeader, MetadataRequest>(API_KEY, 12, flexible, headerEncoder, WriteV12);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<RequestHeader, MetadataRequest> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 12 ? apiVersion : new Version(12);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = RequestHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<RequestHeader, MetadataRequest>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<RequestHeader, MetadataRequest>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<RequestHeader, MetadataRequest>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<RequestHeader, MetadataRequest>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<RequestHeader, MetadataRequest>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<RequestHeader, MetadataRequest>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<RequestHeader, MetadataRequest>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<RequestHeader, MetadataRequest>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                case 8:
                    return new Decoder<RequestHeader, MetadataRequest>(API_KEY, 8, flexible, headerDecoder, ReadV8);
                case 9:
                    return new Decoder<RequestHeader, MetadataRequest>(API_KEY, 9, flexible, headerDecoder, ReadV9);
                case 10:
                    return new Decoder<RequestHeader, MetadataRequest>(API_KEY, 10, flexible, headerDecoder, ReadV10);
                case 11:
                    return new Decoder<RequestHeader, MetadataRequest>(API_KEY, 11, flexible, headerDecoder, ReadV11);
                case 12:
                    return new Decoder<RequestHeader, MetadataRequest>(API_KEY, 12, flexible, headerDecoder, ReadV12);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, MetadataRequest message)
        {
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV0);
            return index;
        }
        private static (int Offset, MetadataRequest Value) ReadV0(byte[] buffer, int index)
        {
            var topicsField = default(ImmutableArray<MetadataRequestTopic>?);
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataRequestTopic>(buffer, index, MetadataRequestTopicSerde.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, MetadataRequest message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV1);
            return index;
        }
        private static (int Offset, MetadataRequest Value) ReadV1(byte[] buffer, int index)
        {
            var topicsField = default(ImmutableArray<MetadataRequestTopic>?);
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, topicsField) = BinaryDecoder.ReadArray<MetadataRequestTopic>(buffer, index, MetadataRequestTopicSerde.ReadV1);
            return (index, new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, MetadataRequest message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV2);
            return index;
        }
        private static (int Offset, MetadataRequest Value) ReadV2(byte[] buffer, int index)
        {
            var topicsField = default(ImmutableArray<MetadataRequestTopic>?);
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, topicsField) = BinaryDecoder.ReadArray<MetadataRequestTopic>(buffer, index, MetadataRequestTopicSerde.ReadV2);
            return (index, new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, MetadataRequest message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV3);
            return index;
        }
        private static (int Offset, MetadataRequest Value) ReadV3(byte[] buffer, int index)
        {
            var topicsField = default(ImmutableArray<MetadataRequestTopic>?);
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, topicsField) = BinaryDecoder.ReadArray<MetadataRequestTopic>(buffer, index, MetadataRequestTopicSerde.ReadV3);
            return (index, new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, MetadataRequest message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV4);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            return index;
        }
        private static (int Offset, MetadataRequest Value) ReadV4(byte[] buffer, int index)
        {
            var topicsField = default(ImmutableArray<MetadataRequestTopic>?);
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, topicsField) = BinaryDecoder.ReadArray<MetadataRequestTopic>(buffer, index, MetadataRequestTopicSerde.ReadV4);
            (index, allowAutoTopicCreationField) = BinaryDecoder.ReadBoolean(buffer, index);
            return (index, new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, MetadataRequest message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV5);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            return index;
        }
        private static (int Offset, MetadataRequest Value) ReadV5(byte[] buffer, int index)
        {
            var topicsField = default(ImmutableArray<MetadataRequestTopic>?);
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, topicsField) = BinaryDecoder.ReadArray<MetadataRequestTopic>(buffer, index, MetadataRequestTopicSerde.ReadV5);
            (index, allowAutoTopicCreationField) = BinaryDecoder.ReadBoolean(buffer, index);
            return (index, new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, MetadataRequest message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV6);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            return index;
        }
        private static (int Offset, MetadataRequest Value) ReadV6(byte[] buffer, int index)
        {
            var topicsField = default(ImmutableArray<MetadataRequestTopic>?);
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, topicsField) = BinaryDecoder.ReadArray<MetadataRequestTopic>(buffer, index, MetadataRequestTopicSerde.ReadV6);
            (index, allowAutoTopicCreationField) = BinaryDecoder.ReadBoolean(buffer, index);
            return (index, new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, MetadataRequest message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV7);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            return index;
        }
        private static (int Offset, MetadataRequest Value) ReadV7(byte[] buffer, int index)
        {
            var topicsField = default(ImmutableArray<MetadataRequestTopic>?);
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, topicsField) = BinaryDecoder.ReadArray<MetadataRequestTopic>(buffer, index, MetadataRequestTopicSerde.ReadV7);
            (index, allowAutoTopicCreationField) = BinaryDecoder.ReadBoolean(buffer, index);
            return (index, new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV8(byte[] buffer, int index, MetadataRequest message)
        {
            index = BinaryEncoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV8);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeClusterAuthorizedOperationsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
            return index;
        }
        private static (int Offset, MetadataRequest Value) ReadV8(byte[] buffer, int index)
        {
            var topicsField = default(ImmutableArray<MetadataRequestTopic>?);
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, topicsField) = BinaryDecoder.ReadArray<MetadataRequestTopic>(buffer, index, MetadataRequestTopicSerde.ReadV8);
            (index, allowAutoTopicCreationField) = BinaryDecoder.ReadBoolean(buffer, index);
            (index, includeClusterAuthorizedOperationsField) = BinaryDecoder.ReadBoolean(buffer, index);
            (index, includeTopicAuthorizedOperationsField) = BinaryDecoder.ReadBoolean(buffer, index);
            return (index, new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV9(byte[] buffer, int index, MetadataRequest message)
        {
            index = BinaryEncoder.WriteCompactArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV9);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeClusterAuthorizedOperationsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, MetadataRequest Value) ReadV9(byte[] buffer, int index)
        {
            var topicsField = default(ImmutableArray<MetadataRequestTopic>?);
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, topicsField) = BinaryDecoder.ReadCompactArray<MetadataRequestTopic>(buffer, index, MetadataRequestTopicSerde.ReadV9);
            (index, allowAutoTopicCreationField) = BinaryDecoder.ReadBoolean(buffer, index);
            (index, includeClusterAuthorizedOperationsField) = BinaryDecoder.ReadBoolean(buffer, index);
            (index, includeTopicAuthorizedOperationsField) = BinaryDecoder.ReadBoolean(buffer, index);
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
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV10(byte[] buffer, int index, MetadataRequest message)
        {
            index = BinaryEncoder.WriteCompactArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV10);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeClusterAuthorizedOperationsField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, MetadataRequest Value) ReadV10(byte[] buffer, int index)
        {
            var topicsField = default(ImmutableArray<MetadataRequestTopic>?);
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, topicsField) = BinaryDecoder.ReadCompactArray<MetadataRequestTopic>(buffer, index, MetadataRequestTopicSerde.ReadV10);
            (index, allowAutoTopicCreationField) = BinaryDecoder.ReadBoolean(buffer, index);
            (index, includeClusterAuthorizedOperationsField) = BinaryDecoder.ReadBoolean(buffer, index);
            (index, includeTopicAuthorizedOperationsField) = BinaryDecoder.ReadBoolean(buffer, index);
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
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV11(byte[] buffer, int index, MetadataRequest message)
        {
            index = BinaryEncoder.WriteCompactArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV11);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, MetadataRequest Value) ReadV11(byte[] buffer, int index)
        {
            var topicsField = default(ImmutableArray<MetadataRequestTopic>?);
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, topicsField) = BinaryDecoder.ReadCompactArray<MetadataRequestTopic>(buffer, index, MetadataRequestTopicSerde.ReadV11);
            (index, allowAutoTopicCreationField) = BinaryDecoder.ReadBoolean(buffer, index);
            (index, includeTopicAuthorizedOperationsField) = BinaryDecoder.ReadBoolean(buffer, index);
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
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV12(byte[] buffer, int index, MetadataRequest message)
        {
            index = BinaryEncoder.WriteCompactArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV12);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, MetadataRequest Value) ReadV12(byte[] buffer, int index)
        {
            var topicsField = default(ImmutableArray<MetadataRequestTopic>?);
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, topicsField) = BinaryDecoder.ReadCompactArray<MetadataRequestTopic>(buffer, index, MetadataRequestTopicSerde.ReadV12);
            (index, allowAutoTopicCreationField) = BinaryDecoder.ReadBoolean(buffer, index);
            (index, includeTopicAuthorizedOperationsField) = BinaryDecoder.ReadBoolean(buffer, index);
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
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class MetadataRequestTopicSerde
        {
            public static int WriteV0(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, MetadataRequestTopic Value) ReadV0(byte[] buffer, int index)
            {
                var topicIdField = default(Guid);
                var nameField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                return (index, new(
                    topicIdField,
                    nameField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, MetadataRequestTopic Value) ReadV1(byte[] buffer, int index)
            {
                var topicIdField = default(Guid);
                var nameField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                return (index, new(
                    topicIdField,
                    nameField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, MetadataRequestTopic Value) ReadV2(byte[] buffer, int index)
            {
                var topicIdField = default(Guid);
                var nameField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                return (index, new(
                    topicIdField,
                    nameField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, MetadataRequestTopic Value) ReadV3(byte[] buffer, int index)
            {
                var topicIdField = default(Guid);
                var nameField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                return (index, new(
                    topicIdField,
                    nameField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, MetadataRequestTopic Value) ReadV4(byte[] buffer, int index)
            {
                var topicIdField = default(Guid);
                var nameField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                return (index, new(
                    topicIdField,
                    nameField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, MetadataRequestTopic Value) ReadV5(byte[] buffer, int index)
            {
                var topicIdField = default(Guid);
                var nameField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                return (index, new(
                    topicIdField,
                    nameField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, MetadataRequestTopic Value) ReadV6(byte[] buffer, int index)
            {
                var topicIdField = default(Guid);
                var nameField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                return (index, new(
                    topicIdField,
                    nameField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, MetadataRequestTopic Value) ReadV7(byte[] buffer, int index)
            {
                var topicIdField = default(Guid);
                var nameField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                return (index, new(
                    topicIdField,
                    nameField,
                    taggedFields
                ));
            }
            public static int WriteV8(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, MetadataRequestTopic Value) ReadV8(byte[] buffer, int index)
            {
                var topicIdField = default(Guid);
                var nameField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                return (index, new(
                    topicIdField,
                    nameField,
                    taggedFields
                ));
            }
            public static int WriteV9(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, MetadataRequestTopic Value) ReadV9(byte[] buffer, int index)
            {
                var topicIdField = default(Guid);
                var nameField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
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
                    topicIdField,
                    nameField,
                    taggedFields
                ));
            }
            public static int WriteV10(byte[] buffer, int index, MetadataRequestTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.NameField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, MetadataRequestTopic Value) ReadV10(byte[] buffer, int index)
            {
                var topicIdField = default(Guid);
                var nameField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, nameField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    topicIdField,
                    nameField,
                    taggedFields
                ));
            }
            public static int WriteV11(byte[] buffer, int index, MetadataRequestTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.NameField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, MetadataRequestTopic Value) ReadV11(byte[] buffer, int index)
            {
                var topicIdField = default(Guid);
                var nameField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, nameField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    topicIdField,
                    nameField,
                    taggedFields
                ));
            }
            public static int WriteV12(byte[] buffer, int index, MetadataRequestTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.NameField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, MetadataRequestTopic Value) ReadV12(byte[] buffer, int index)
            {
                var topicIdField = default(Guid);
                var nameField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, nameField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    topicIdField,
                    nameField,
                    taggedFields
                ));
            }
        }
    }
}