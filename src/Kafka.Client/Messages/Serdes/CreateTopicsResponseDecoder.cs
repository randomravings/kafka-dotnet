using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using CreatableTopicConfigs = Kafka.Client.Messages.CreateTopicsResponseData.CreatableTopicResult.CreatableTopicConfigs;
using CreatableTopicResult = Kafka.Client.Messages.CreateTopicsResponseData.CreatableTopicResult;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class CreateTopicsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, CreateTopicsResponseData>
    {
        public CreateTopicsResponseDecoder() :
            base(
                ApiKey.CreateTopics,
                new(0, 7),
                new(5, 32767),
                ResponseHeaderDecoder.ReadV0,
                ReadV0
            )
        { }
        protected override DecodeDelegate<ResponseHeaderData> GetHeaderDecoder(short apiVersion)
        {
            if (_flexibleVersions.Includes(apiVersion))
                return ResponseHeaderDecoder.ReadV1;
            else
                return ResponseHeaderDecoder.ReadV0;
        }
        protected override DecodeDelegate<CreateTopicsResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                4 => ReadV4,
                5 => ReadV5,
                6 => ReadV6,
                7 => ReadV7,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<CreateTopicsResponseData> ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultDecoder.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultDecoder.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultDecoder.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultDecoder.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, index, CreatableTopicResultDecoder.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<CreatableTopicResult>(buffer, index, CreatableTopicResultDecoder.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if (taggedFieldsCount > 0)
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
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV6(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<CreatableTopicResult>(buffer, index, CreatableTopicResultDecoder.ReadV6);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if (taggedFieldsCount > 0)
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
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV7(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<CreatableTopicResult>(buffer, index, CreatableTopicResultDecoder.ReadV7);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if (taggedFieldsCount > 0)
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
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class CreatableTopicResultDecoder
        {
            public static DecodeResult<CreatableTopicResult> ReadV0(byte[] buffer, int index)
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
                return new(index, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV1(byte[] buffer, int index)
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
                return new(index, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV2(byte[] buffer, int index)
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
                return new(index, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV3(byte[] buffer, int index)
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
                return new(index, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV4(byte[] buffer, int index)
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
                return new(index, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV5(byte[] buffer, int index)
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
                (index, configsField) = BinaryDecoder.ReadCompactArray<CreatableTopicConfigs>(buffer, index, CreatableTopicConfigsDecoder.ReadV5);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if (taggedFieldsCount > 0)
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
                return new(index, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV6(byte[] buffer, int index)
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
                (index, configsField) = BinaryDecoder.ReadCompactArray<CreatableTopicConfigs>(buffer, index, CreatableTopicConfigsDecoder.ReadV6);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if (taggedFieldsCount > 0)
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
                return new(index, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV7(byte[] buffer, int index)
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
                (index, configsField) = BinaryDecoder.ReadCompactArray<CreatableTopicConfigs>(buffer, index, CreatableTopicConfigsDecoder.ReadV7);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if (taggedFieldsCount > 0)
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
                return new(index, new(
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
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class CreatableTopicConfigsDecoder
            {
                public static DecodeResult<CreatableTopicConfigs> ReadV0(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(index, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV1(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(index, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV2(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(index, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV3(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(index, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV4(byte[] buffer, int index)
                {
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(index, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV5(byte[] buffer, int index)
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
                    if (taggedFieldsCount > 0)
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
                    return new(index, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV6(byte[] buffer, int index)
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
                    if (taggedFieldsCount > 0)
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
                    return new(index, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV7(byte[] buffer, int index)
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
                    if (taggedFieldsCount > 0)
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
                    return new(index, new(
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
