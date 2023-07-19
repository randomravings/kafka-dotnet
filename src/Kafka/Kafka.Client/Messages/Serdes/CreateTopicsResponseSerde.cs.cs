using CreatableTopicConfigs = Kafka.Client.Messages.CreateTopicsResponse.CreatableTopicResult.CreatableTopicConfigs;
using CreatableTopicResult = Kafka.Client.Messages.CreateTopicsResponse.CreatableTopicResult;
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
    public static class CreateTopicsResponseSerde
    {
        private static readonly ApiKey API_KEY = new(19);
        private static readonly VersionRange API_VERSIONS = new(0, 7);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (5, 32767);
        public static IEncoder<ResponseHeader, CreateTopicsResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 7 ? apiVersion : new Version(7);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, CreateTopicsResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 7 ? apiVersion : new Version(7);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<ResponseHeader, CreateTopicsResponse>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = BinaryEncoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV0);
            return index;
        }
        private static (int Offset, CreateTopicsResponse Value) ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV0);
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
        private static int WriteV1(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = BinaryEncoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV1);
            return index;
        }
        private static (int Offset, CreateTopicsResponse Value) ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV1);
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
        private static int WriteV2(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV2);
            return index;
        }
        private static (int Offset, CreateTopicsResponse Value) ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV2);
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
        private static int WriteV3(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV3);
            return index;
        }
        private static (int Offset, CreateTopicsResponse Value) ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV3);
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
        private static int WriteV4(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV4);
            return index;
        }
        private static (int Offset, CreateTopicsResponse Value) ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV4);
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
        private static int WriteV5(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV5);
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
        private static (int Offset, CreateTopicsResponse Value) ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV5);
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
        private static int WriteV6(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV6);
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
        private static (int Offset, CreateTopicsResponse Value) ReadV6(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV6);
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
        private static int WriteV7(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV7);
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
        private static (int Offset, CreateTopicsResponse Value) ReadV7(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<CreatableTopicResult>(buffer, index, CreatableTopicResultSerde.ReadV7);
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
        private static class CreatableTopicResultSerde
        {
            public static int WriteV0(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
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
            public static (int Offset, CreatableTopicResult Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                return (index, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
            public static (int Offset, CreatableTopicResult Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, index);
                return (index, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
            public static (int Offset, CreatableTopicResult Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, index);
                return (index, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
            public static (int Offset, CreatableTopicResult Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, index);
                return (index, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
            public static (int Offset, CreatableTopicResult Value) ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, index);
                return (index, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteCompactArray<CreatableTopicConfigs>(buffer, index, message.ConfigsField, CreatableTopicConfigsSerde.WriteV5);
                var taggedFieldsCount = 1u;
                var previousTagged = 0;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                {
                    index = BinaryEncoder.WriteVarInt32(buffer, index, 0);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.TopicConfigErrorCodeField);
                }
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 0");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, CreatableTopicResult Value) ReadV5(byte[] buffer, int index)
            {
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, configsField) = BinaryDecoder.ReadCompactArray<CreatableTopicConfigs>(buffer, index, CreatableTopicConfigsSerde.ReadV5);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                        switch (tag)
                        {
                            case 0:
                                (index, topicConfigErrorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                                break;
                            default:
                                (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                                taggedFieldsBuilder.Add(new(tag, bytes));
                            break;
                        }
                        taggedFieldsCount--;
                    }
                }
                return (index, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteCompactArray<CreatableTopicConfigs>(buffer, index, message.ConfigsField, CreatableTopicConfigsSerde.WriteV6);
                var taggedFieldsCount = 1u;
                var previousTagged = 0;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                {
                    index = BinaryEncoder.WriteVarInt32(buffer, index, 0);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.TopicConfigErrorCodeField);
                }
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 0");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, CreatableTopicResult Value) ReadV6(byte[] buffer, int index)
            {
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, configsField) = BinaryDecoder.ReadCompactArray<CreatableTopicConfigs>(buffer, index, CreatableTopicConfigsSerde.ReadV6);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                        switch (tag)
                        {
                            case 0:
                                (index, topicConfigErrorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                                break;
                            default:
                                (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                                taggedFieldsBuilder.Add(new(tag, bytes));
                            break;
                        }
                        taggedFieldsCount--;
                    }
                }
                return (index, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = BinaryEncoder.WriteCompactArray<CreatableTopicConfigs>(buffer, index, message.ConfigsField, CreatableTopicConfigsSerde.WriteV7);
                var taggedFieldsCount = 1u;
                var previousTagged = 0;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                {
                    index = BinaryEncoder.WriteVarInt32(buffer, index, 0);
                    index = BinaryEncoder.WriteInt16(buffer, index, message.TopicConfigErrorCodeField);
                }
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 0");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, CreatableTopicResult Value) ReadV7(byte[] buffer, int index)
            {
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, configsField) = BinaryDecoder.ReadCompactArray<CreatableTopicConfigs>(buffer, index, CreatableTopicConfigsSerde.ReadV7);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                        switch (tag)
                        {
                            case 0:
                                (index, topicConfigErrorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                                break;
                            default:
                                (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                                taggedFieldsBuilder.Add(new(tag, bytes));
                            break;
                        }
                        taggedFieldsCount--;
                    }
                }
                return (index, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField,
                    taggedFields
                ));
            }
            [GeneratedCode("kgen", "1.0.0.0")]
            private static class CreatableTopicConfigsSerde
            {
                public static int WriteV0(byte[] buffer, int index, CreatableTopicConfigs message)
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
                public static (int Offset, CreatableTopicConfigs Value) ReadV0(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, CreatableTopicConfigs message)
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
                public static (int Offset, CreatableTopicConfigs Value) ReadV1(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, CreatableTopicConfigs message)
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
                public static (int Offset, CreatableTopicConfigs Value) ReadV2(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, CreatableTopicConfigs message)
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
                public static (int Offset, CreatableTopicConfigs Value) ReadV3(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static int WriteV4(byte[] buffer, int index, CreatableTopicConfigs message)
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
                public static (int Offset, CreatableTopicConfigs Value) ReadV4(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return (index, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static int WriteV5(byte[] buffer, int index, CreatableTopicConfigs message)
                {
                    index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ValueField);
                    index = BinaryEncoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                    index = BinaryEncoder.WriteInt8(buffer, index, message.ConfigSourceField);
                    index = BinaryEncoder.WriteBoolean(buffer, index, message.IsSensitiveField);
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
                public static (int Offset, CreatableTopicConfigs Value) ReadV5(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                    (index, valueField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                    (index, readOnlyField) = BinaryDecoder.ReadBoolean(buffer, index);
                    (index, configSourceField) = BinaryDecoder.ReadInt8(buffer, index);
                    (index, isSensitiveField) = BinaryDecoder.ReadBoolean(buffer, index);
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
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static int WriteV6(byte[] buffer, int index, CreatableTopicConfigs message)
                {
                    index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ValueField);
                    index = BinaryEncoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                    index = BinaryEncoder.WriteInt8(buffer, index, message.ConfigSourceField);
                    index = BinaryEncoder.WriteBoolean(buffer, index, message.IsSensitiveField);
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
                public static (int Offset, CreatableTopicConfigs Value) ReadV6(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                    (index, valueField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                    (index, readOnlyField) = BinaryDecoder.ReadBoolean(buffer, index);
                    (index, configSourceField) = BinaryDecoder.ReadInt8(buffer, index);
                    (index, isSensitiveField) = BinaryDecoder.ReadBoolean(buffer, index);
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
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static int WriteV7(byte[] buffer, int index, CreatableTopicConfigs message)
                {
                    index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                    index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ValueField);
                    index = BinaryEncoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                    index = BinaryEncoder.WriteInt8(buffer, index, message.ConfigSourceField);
                    index = BinaryEncoder.WriteBoolean(buffer, index, message.IsSensitiveField);
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
                public static (int Offset, CreatableTopicConfigs Value) ReadV7(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                    (index, valueField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                    (index, readOnlyField) = BinaryDecoder.ReadBoolean(buffer, index);
                    (index, configSourceField) = BinaryDecoder.ReadInt8(buffer, index);
                    (index, isSensitiveField) = BinaryDecoder.ReadBoolean(buffer, index);
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
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
            }
        }
    }
}