using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using CreatableTopicResult = Kafka.Client.Messages.CreateTopicsResponseData.CreatableTopicResult;
using CreatableTopicConfigs = Kafka.Client.Messages.CreateTopicsResponseData.CreatableTopicResult.CreatableTopicConfigs;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class CreateTopicsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, CreateTopicsResponseData>
    {
        internal CreateTopicsResponseDecoder() :
            base(
                ApiKey.CreateTopics,
                new(0, 7),
                new(5, 32767),
                ResponseHeaderDecoder.ReadV0,
                ReadV0
            )
        { }
        protected override DecodeValue<ResponseHeaderData> GetHeaderDecoder(short apiVersion)
        {
            if (FlexibleVersions.Includes(apiVersion))
                return ResponseHeaderDecoder.ReadV1;
            else
                return ResponseHeaderDecoder.ReadV0;
        }
        protected override DecodeValue<CreateTopicsResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<CreateTopicsResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, i, CreatableTopicResultDecoder.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, i, CreatableTopicResultDecoder.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, i, CreatableTopicResultDecoder.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, i, CreatableTopicResultDecoder.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<CreatableTopicResult>(buffer, i, CreatableTopicResultDecoder.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV5([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadCompactArray<CreatableTopicResult>(buffer, i, CreatableTopicResultDecoder.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                    (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV6([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadCompactArray<CreatableTopicResult>(buffer, i, CreatableTopicResultDecoder.ReadV6);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                    (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<CreateTopicsResponseData> ReadV7([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<CreatableTopicResult>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadCompactArray<CreatableTopicResult>(buffer, i, CreatableTopicResultDecoder.ReadV7);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                    (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class CreatableTopicResultDecoder
        {
            public static DecodeResult<CreatableTopicResult> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, configsField) = BinaryDecoder.ReadCompactArray<CreatableTopicConfigs>(buffer, i, CreatableTopicConfigsDecoder.ReadV5);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        switch (tag)
                        {
                            case 0:
                                (i, topicConfigErrorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                                break;
                            default:
                                (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                                taggedFieldsBuilder.Add(new(tag, bytes));
                                break;
                        }
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV6([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, configsField) = BinaryDecoder.ReadCompactArray<CreatableTopicConfigs>(buffer, i, CreatableTopicConfigsDecoder.ReadV6);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        switch (tag)
                        {
                            case 0:
                                (i, topicConfigErrorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                                break;
                            default:
                                (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                                taggedFieldsBuilder.Add(new(tag, bytes));
                                break;
                        }
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
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
            public static DecodeResult<CreatableTopicResult> ReadV7([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var topicIdField = default(Guid);
                var errorCodeField = default(short);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = default(ImmutableArray<CreatableTopicConfigs>?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, topicIdField) = BinaryDecoder.ReadUuid(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, numPartitionsField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, replicationFactorField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, configsField) = BinaryDecoder.ReadCompactArray<CreatableTopicConfigs>(buffer, i, CreatableTopicConfigsDecoder.ReadV7);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        switch (tag)
                        {
                            case 0:
                                (i, topicConfigErrorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                                break;
                            default:
                                (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                                taggedFieldsBuilder.Add(new(tag, bytes));
                                break;
                        }
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
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
                public static DecodeResult<CreatableTopicConfigs> ReadV0([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(i, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV1([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(i, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV2([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(i, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV3([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(i, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV4([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(i, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV5([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, valueField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                    (i, readOnlyField) = BinaryDecoder.ReadBoolean(buffer, i);
                    (i, configSourceField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, isSensitiveField) = BinaryDecoder.ReadBoolean(buffer, i);
                    (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                            (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            taggedFieldsCount--;
                        }
                    }
                    return new(i, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV6([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, valueField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                    (i, readOnlyField) = BinaryDecoder.ReadBoolean(buffer, i);
                    (i, configSourceField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, isSensitiveField) = BinaryDecoder.ReadBoolean(buffer, i);
                    (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                            (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            taggedFieldsCount--;
                        }
                    }
                    return new(i, new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField,
                        taggedFields
                    ));
                }
                public static DecodeResult<CreatableTopicConfigs> ReadV7([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var valueField = default(string?);
                    var readOnlyField = default(bool);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = default(bool);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, valueField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                    (i, readOnlyField) = BinaryDecoder.ReadBoolean(buffer, i);
                    (i, configSourceField) = BinaryDecoder.ReadInt8(buffer, i);
                    (i, isSensitiveField) = BinaryDecoder.ReadBoolean(buffer, i);
                    (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                            (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            taggedFieldsCount--;
                        }
                    }
                    return new(i, new(
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
