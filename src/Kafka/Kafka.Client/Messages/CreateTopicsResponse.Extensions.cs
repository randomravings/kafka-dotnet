using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using CreatableTopicConfigs = Kafka.Client.Messages.CreateTopicsResponse.CreatableTopicResult.CreatableTopicConfigs;
using CreatableTopicResult = Kafka.Client.Messages.CreateTopicsResponse.CreatableTopicResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateTopicsResponseSerde
    {
        private static readonly DecodeDelegate<CreateTopicsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
        };
        private static readonly EncodeDelegate<CreateTopicsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
        };
        public static CreateTopicsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, CreateTopicsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static CreateTopicsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(buffer, ref index, CreatableTopicResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = Encoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV00);
            return index;
        }
        private static CreateTopicsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(buffer, ref index, CreatableTopicResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = Encoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV01);
            return index;
        }
        private static CreateTopicsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(buffer, ref index, CreatableTopicResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV02);
            return index;
        }
        private static CreateTopicsResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(buffer, ref index, CreatableTopicResultSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV03);
            return index;
        }
        private static CreateTopicsResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(buffer, ref index, CreatableTopicResultSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV04);
            return index;
        }
        private static CreateTopicsResponse ReadV05(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<CreatableTopicResult>(buffer, ref index, CreatableTopicResultSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV05(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV05);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static CreateTopicsResponse ReadV06(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<CreatableTopicResult>(buffer, ref index, CreatableTopicResultSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV06(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV06);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static CreateTopicsResponse ReadV07(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<CreatableTopicResult>(buffer, ref index, CreatableTopicResultSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static int WriteV07(byte[] buffer, int index, CreateTopicsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<CreatableTopicResult>(buffer, index, message.TopicsField, CreatableTopicResultSerde.WriteV07);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class CreatableTopicResultSerde
        {
            public static CreatableTopicResult ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = default(string?);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = ImmutableArray<CreatableTopicConfigs>.Empty;
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static CreatableTopicResult ReadV01(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = ImmutableArray<CreatableTopicConfigs>.Empty;
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                return index;
            }
            public static CreatableTopicResult ReadV02(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = ImmutableArray<CreatableTopicConfigs>.Empty;
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                return index;
            }
            public static CreatableTopicResult ReadV03(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = ImmutableArray<CreatableTopicConfigs>.Empty;
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                return index;
            }
            public static CreatableTopicResult ReadV04(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = default(int);
                var replicationFactorField = default(short);
                var configsField = ImmutableArray<CreatableTopicConfigs>.Empty;
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                return index;
            }
            public static CreatableTopicResult ReadV05(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = Decoder.ReadInt32(buffer, ref index);
                var replicationFactorField = Decoder.ReadInt16(buffer, ref index);
                var configsField = Decoder.ReadCompactArray<CreatableTopicConfigs>(buffer, ref index, CreatableTopicConfigsSerde.ReadV05);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField
                );
            }
            public static int WriteV05(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteInt16(buffer, index, message.TopicConfigErrorCodeField);
                index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = Encoder.WriteCompactArray<CreatableTopicConfigs>(buffer, index, message.ConfigsField, CreatableTopicConfigsSerde.WriteV05);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static CreatableTopicResult ReadV06(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = Decoder.ReadInt32(buffer, ref index);
                var replicationFactorField = Decoder.ReadInt16(buffer, ref index);
                var configsField = Decoder.ReadCompactArray<CreatableTopicConfigs>(buffer, ref index, CreatableTopicConfigsSerde.ReadV06);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField
                );
            }
            public static int WriteV06(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteInt16(buffer, index, message.TopicConfigErrorCodeField);
                index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = Encoder.WriteCompactArray<CreatableTopicConfigs>(buffer, index, message.ConfigsField, CreatableTopicConfigsSerde.WriteV06);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static CreatableTopicResult ReadV07(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var topicIdField = Decoder.ReadUuid(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = Decoder.ReadInt32(buffer, ref index);
                var replicationFactorField = Decoder.ReadInt16(buffer, ref index);
                var configsField = Decoder.ReadCompactArray<CreatableTopicConfigs>(buffer, ref index, CreatableTopicConfigsSerde.ReadV07);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    topicIdField,
                    errorCodeField,
                    errorMessageField,
                    topicConfigErrorCodeField,
                    numPartitionsField,
                    replicationFactorField,
                    configsField
                );
            }
            public static int WriteV07(byte[] buffer, int index, CreatableTopicResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteInt16(buffer, index, message.TopicConfigErrorCodeField);
                index = Encoder.WriteInt32(buffer, index, message.NumPartitionsField);
                index = Encoder.WriteInt16(buffer, index, message.ReplicationFactorField);
                index = Encoder.WriteCompactArray<CreatableTopicConfigs>(buffer, index, message.ConfigsField, CreatableTopicConfigsSerde.WriteV07);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class CreatableTopicConfigsSerde
            {
                public static CreatableTopicConfigs ReadV05(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadCompactString(buffer, ref index);
                    var valueField = Decoder.ReadCompactNullableString(buffer, ref index);
                    var readOnlyField = Decoder.ReadBoolean(buffer, ref index);
                    var configSourceField = Decoder.ReadInt8(buffer, ref index);
                    var isSensitiveField = Decoder.ReadBoolean(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, CreatableTopicConfigs message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                    index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                    index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                    index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static CreatableTopicConfigs ReadV06(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadCompactString(buffer, ref index);
                    var valueField = Decoder.ReadCompactNullableString(buffer, ref index);
                    var readOnlyField = Decoder.ReadBoolean(buffer, ref index);
                    var configSourceField = Decoder.ReadInt8(buffer, ref index);
                    var isSensitiveField = Decoder.ReadBoolean(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField
                    );
                }
                public static int WriteV06(byte[] buffer, int index, CreatableTopicConfigs message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                    index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                    index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                    index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static CreatableTopicConfigs ReadV07(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadCompactString(buffer, ref index);
                    var valueField = Decoder.ReadCompactNullableString(buffer, ref index);
                    var readOnlyField = Decoder.ReadBoolean(buffer, ref index);
                    var configSourceField = Decoder.ReadInt8(buffer, ref index);
                    var isSensitiveField = Decoder.ReadBoolean(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField
                    );
                }
                public static int WriteV07(byte[] buffer, int index, CreatableTopicConfigs message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                    index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                    index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                    index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}