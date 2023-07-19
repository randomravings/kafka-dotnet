using DeletableTopicResult = Kafka.Client.Messages.DeleteTopicsResponse.DeletableTopicResult;
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
    public static class DeleteTopicsResponseSerde
    {
        private static readonly ApiKey API_KEY = new(20);
        private static readonly VersionRange API_VERSIONS = new(0, 6);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (4, 32767);
        public static IEncoder<ResponseHeader, DeleteTopicsResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 6 ? apiVersion : new Version(6);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, DeleteTopicsResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 6 ? apiVersion : new Version(6);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<ResponseHeader, DeleteTopicsResponse>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = BinaryEncoder.WriteArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV0);
            return index;
        }
        private static (int Offset, DeleteTopicsResponse Value) ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV0);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV1);
            return index;
        }
        private static (int Offset, DeleteTopicsResponse Value) ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV1);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV2);
            return index;
        }
        private static (int Offset, DeleteTopicsResponse Value) ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV2);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV3);
            return index;
        }
        private static (int Offset, DeleteTopicsResponse Value) ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV3);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return (index, new(
                throttleTimeMsField,
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV4);
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
        private static (int Offset, DeleteTopicsResponse Value) ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadCompactArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV4);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
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
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV5);
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
        private static (int Offset, DeleteTopicsResponse Value) ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadCompactArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV5);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
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
                responsesField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, DeleteTopicsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV6);
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
        private static (int Offset, DeleteTopicsResponse Value) ReadV6(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var responsesField = ImmutableArray<DeletableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadCompactArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV6);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
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
                responsesField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class DeletableTopicResultSerde
        {
            public static int WriteV0(byte[] buffer, int index, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
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
            public static (int Offset, DeletableTopicResult Value) ReadV0(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                return (index, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
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
            public static (int Offset, DeletableTopicResult Value) ReadV1(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                return (index, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
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
            public static (int Offset, DeletableTopicResult Value) ReadV2(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                return (index, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
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
            public static (int Offset, DeletableTopicResult Value) ReadV3(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                return (index, new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
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
            public static (int Offset, DeletableTopicResult Value) ReadV4(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
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
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, DeletableTopicResult message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
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
            public static (int Offset, DeletableTopicResult Value) ReadV5(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, DeletableTopicResult message)
            {
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
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
            public static (int Offset, DeletableTopicResult Value) ReadV6(byte[] buffer, int index)
            {
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    errorCodeField,
                    errorMessageField,
                    taggedFields
                ));
            }
        }
    }
}