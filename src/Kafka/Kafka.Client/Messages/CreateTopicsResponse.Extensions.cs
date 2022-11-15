using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using CreatableTopicResult = Kafka.Client.Messages.CreateTopicsResponse.CreatableTopicResult;
using CreatableTopicConfigs = Kafka.Client.Messages.CreateTopicsResponse.CreatableTopicResult.CreatableTopicConfigs;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class CreateTopicsResponseSerde
    {
        private static readonly Func<Stream, CreateTopicsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
        };
        private static readonly Action<Stream, CreateTopicsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
        };
        public static CreateTopicsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, CreateTopicsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static CreateTopicsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(buffer, b => CreatableTopicResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, CreateTopicsResponse message)
        {
            Encoder.WriteArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV00(b, i));
        }
        private static CreateTopicsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(buffer, b => CreatableTopicResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, CreateTopicsResponse message)
        {
            Encoder.WriteArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV01(b, i));
        }
        private static CreateTopicsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(buffer, b => CreatableTopicResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, CreateTopicsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV02(b, i));
        }
        private static CreateTopicsResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(buffer, b => CreatableTopicResultSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV03(Stream buffer, CreateTopicsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV03(b, i));
        }
        private static CreateTopicsResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(buffer, b => CreatableTopicResultSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV04(Stream buffer, CreateTopicsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV04(b, i));
        }
        private static CreateTopicsResponse ReadV05(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<CreatableTopicResult>(buffer, b => CreatableTopicResultSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV05(Stream buffer, CreateTopicsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV05(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static CreateTopicsResponse ReadV06(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<CreatableTopicResult>(buffer, b => CreatableTopicResultSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV06(Stream buffer, CreateTopicsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV06(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static CreateTopicsResponse ReadV07(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<CreatableTopicResult>(buffer, b => CreatableTopicResultSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV07(Stream buffer, CreateTopicsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV07(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class CreatableTopicResultSerde
        {
            public static CreatableTopicResult ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer);
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
            public static void WriteV00(Stream buffer, CreatableTopicResult message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static CreatableTopicResult ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
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
            public static void WriteV01(Stream buffer, CreatableTopicResult message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            }
            public static CreatableTopicResult ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
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
            public static void WriteV02(Stream buffer, CreatableTopicResult message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            }
            public static CreatableTopicResult ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
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
            public static void WriteV03(Stream buffer, CreatableTopicResult message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            }
            public static CreatableTopicResult ReadV04(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
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
            public static void WriteV04(Stream buffer, CreatableTopicResult message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            }
            public static CreatableTopicResult ReadV05(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = Decoder.ReadInt32(buffer);
                var replicationFactorField = Decoder.ReadInt16(buffer);
                var configsField = Decoder.ReadCompactArray<CreatableTopicConfigs>(buffer, b => CreatableTopicConfigsSerde.ReadV05(b));
                _ = Decoder.ReadVarUInt32(buffer);
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
            public static void WriteV05(Stream buffer, CreatableTopicResult message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteInt16(buffer, message.TopicConfigErrorCodeField);
                Encoder.WriteInt32(buffer, message.NumPartitionsField);
                Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                Encoder.WriteCompactArray<CreatableTopicConfigs>(buffer, message.ConfigsField, (b, i) => CreatableTopicConfigsSerde.WriteV05(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static CreatableTopicResult ReadV06(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = Decoder.ReadInt32(buffer);
                var replicationFactorField = Decoder.ReadInt16(buffer);
                var configsField = Decoder.ReadCompactArray<CreatableTopicConfigs>(buffer, b => CreatableTopicConfigsSerde.ReadV06(b));
                _ = Decoder.ReadVarUInt32(buffer);
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
            public static void WriteV06(Stream buffer, CreatableTopicResult message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteInt16(buffer, message.TopicConfigErrorCodeField);
                Encoder.WriteInt32(buffer, message.NumPartitionsField);
                Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                Encoder.WriteCompactArray<CreatableTopicConfigs>(buffer, message.ConfigsField, (b, i) => CreatableTopicConfigsSerde.WriteV06(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static CreatableTopicResult ReadV07(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var topicIdField = Decoder.ReadUuid(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = Decoder.ReadInt32(buffer);
                var replicationFactorField = Decoder.ReadInt16(buffer);
                var configsField = Decoder.ReadCompactArray<CreatableTopicConfigs>(buffer, b => CreatableTopicConfigsSerde.ReadV07(b));
                _ = Decoder.ReadVarUInt32(buffer);
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
            public static void WriteV07(Stream buffer, CreatableTopicResult message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteInt16(buffer, message.TopicConfigErrorCodeField);
                Encoder.WriteInt32(buffer, message.NumPartitionsField);
                Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                Encoder.WriteCompactArray<CreatableTopicConfigs>(buffer, message.ConfigsField, (b, i) => CreatableTopicConfigsSerde.WriteV07(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class CreatableTopicConfigsSerde
            {
                public static CreatableTopicConfigs ReadV05(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var valueField = Decoder.ReadCompactNullableString(buffer);
                    var readOnlyField = Decoder.ReadBoolean(buffer);
                    var configSourceField = Decoder.ReadInt8(buffer);
                    var isSensitiveField = Decoder.ReadBoolean(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField
                    );
                }
                public static void WriteV05(Stream buffer, CreatableTopicConfigs message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static CreatableTopicConfigs ReadV06(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var valueField = Decoder.ReadCompactNullableString(buffer);
                    var readOnlyField = Decoder.ReadBoolean(buffer);
                    var configSourceField = Decoder.ReadInt8(buffer);
                    var isSensitiveField = Decoder.ReadBoolean(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField
                    );
                }
                public static void WriteV06(Stream buffer, CreatableTopicConfigs message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static CreatableTopicConfigs ReadV07(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var valueField = Decoder.ReadCompactNullableString(buffer);
                    var readOnlyField = Decoder.ReadBoolean(buffer);
                    var configSourceField = Decoder.ReadInt8(buffer);
                    var isSensitiveField = Decoder.ReadBoolean(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField
                    );
                }
                public static void WriteV07(Stream buffer, CreatableTopicConfigs message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}