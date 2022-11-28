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
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
        };
        private static readonly EncodeDelegate<CreateTopicsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
        };
        public static CreateTopicsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, CreateTopicsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static CreateTopicsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, CreateTopicsResponse message)
        {
            buffer = Encoder.WriteArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV00(b, i));
            return buffer;
        }
        private static CreateTopicsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, CreateTopicsResponse message)
        {
            buffer = Encoder.WriteArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV01(b, i));
            return buffer;
        }
        private static CreateTopicsResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, CreateTopicsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV02(b, i));
            return buffer;
        }
        private static CreateTopicsResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicResultSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, CreateTopicsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV03(b, i));
            return buffer;
        }
        private static CreateTopicsResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<CreatableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicResultSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, CreateTopicsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV04(b, i));
            return buffer;
        }
        private static CreateTopicsResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<CreatableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicResultSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, CreateTopicsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV05(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static CreateTopicsResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<CreatableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicResultSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, CreateTopicsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV06(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static CreateTopicsResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<CreatableTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicResultSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, CreateTopicsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<CreatableTopicResult>(buffer, message.TopicsField, (b, i) => CreatableTopicResultSerde.WriteV07(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class CreatableTopicResultSerde
        {
            public static CreatableTopicResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
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
            public static Memory<byte> WriteV00(Memory<byte> buffer, CreatableTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static CreatableTopicResult ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
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
            public static Memory<byte> WriteV01(Memory<byte> buffer, CreatableTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                return buffer;
            }
            public static CreatableTopicResult ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
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
            public static Memory<byte> WriteV02(Memory<byte> buffer, CreatableTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                return buffer;
            }
            public static CreatableTopicResult ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
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
            public static Memory<byte> WriteV03(Memory<byte> buffer, CreatableTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                return buffer;
            }
            public static CreatableTopicResult ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
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
            public static Memory<byte> WriteV04(Memory<byte> buffer, CreatableTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                return buffer;
            }
            public static CreatableTopicResult ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = Decoder.ReadInt32(ref buffer);
                var replicationFactorField = Decoder.ReadInt16(ref buffer);
                var configsField = Decoder.ReadCompactArray<CreatableTopicConfigs>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicConfigsSerde.ReadV05(ref b));
                _ = Decoder.ReadVarUInt32(ref buffer);
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
            public static Memory<byte> WriteV05(Memory<byte> buffer, CreatableTopicResult message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteInt16(buffer, message.TopicConfigErrorCodeField);
                buffer = Encoder.WriteInt32(buffer, message.NumPartitionsField);
                buffer = Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                buffer = Encoder.WriteCompactArray<CreatableTopicConfigs>(buffer, message.ConfigsField, (b, i) => CreatableTopicConfigsSerde.WriteV05(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static CreatableTopicResult ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = default(Guid);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = Decoder.ReadInt32(ref buffer);
                var replicationFactorField = Decoder.ReadInt16(ref buffer);
                var configsField = Decoder.ReadCompactArray<CreatableTopicConfigs>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicConfigsSerde.ReadV06(ref b));
                _ = Decoder.ReadVarUInt32(ref buffer);
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
            public static Memory<byte> WriteV06(Memory<byte> buffer, CreatableTopicResult message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteInt16(buffer, message.TopicConfigErrorCodeField);
                buffer = Encoder.WriteInt32(buffer, message.NumPartitionsField);
                buffer = Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                buffer = Encoder.WriteCompactArray<CreatableTopicConfigs>(buffer, message.ConfigsField, (b, i) => CreatableTopicConfigsSerde.WriteV06(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static CreatableTopicResult ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                var topicConfigErrorCodeField = default(short);
                var numPartitionsField = Decoder.ReadInt32(ref buffer);
                var replicationFactorField = Decoder.ReadInt16(ref buffer);
                var configsField = Decoder.ReadCompactArray<CreatableTopicConfigs>(ref buffer, (ref ReadOnlyMemory<byte> b) => CreatableTopicConfigsSerde.ReadV07(ref b));
                _ = Decoder.ReadVarUInt32(ref buffer);
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
            public static Memory<byte> WriteV07(Memory<byte> buffer, CreatableTopicResult message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteInt16(buffer, message.TopicConfigErrorCodeField);
                buffer = Encoder.WriteInt32(buffer, message.NumPartitionsField);
                buffer = Encoder.WriteInt16(buffer, message.ReplicationFactorField);
                buffer = Encoder.WriteCompactArray<CreatableTopicConfigs>(buffer, message.ConfigsField, (b, i) => CreatableTopicConfigsSerde.WriteV07(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class CreatableTopicConfigsSerde
            {
                public static CreatableTopicConfigs ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var valueField = Decoder.ReadCompactNullableString(ref buffer);
                    var readOnlyField = Decoder.ReadBoolean(ref buffer);
                    var configSourceField = Decoder.ReadInt8(ref buffer);
                    var isSensitiveField = Decoder.ReadBoolean(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField
                    );
                }
                public static Memory<byte> WriteV05(Memory<byte> buffer, CreatableTopicConfigs message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    buffer = Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    buffer = Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    buffer = Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static CreatableTopicConfigs ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var valueField = Decoder.ReadCompactNullableString(ref buffer);
                    var readOnlyField = Decoder.ReadBoolean(ref buffer);
                    var configSourceField = Decoder.ReadInt8(ref buffer);
                    var isSensitiveField = Decoder.ReadBoolean(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField
                    );
                }
                public static Memory<byte> WriteV06(Memory<byte> buffer, CreatableTopicConfigs message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    buffer = Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    buffer = Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    buffer = Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static CreatableTopicConfigs ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var valueField = Decoder.ReadCompactNullableString(ref buffer);
                    var readOnlyField = Decoder.ReadBoolean(ref buffer);
                    var configSourceField = Decoder.ReadInt8(ref buffer);
                    var isSensitiveField = Decoder.ReadBoolean(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        configSourceField,
                        isSensitiveField
                    );
                }
                public static Memory<byte> WriteV07(Memory<byte> buffer, CreatableTopicConfigs message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    buffer = Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    buffer = Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    buffer = Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}