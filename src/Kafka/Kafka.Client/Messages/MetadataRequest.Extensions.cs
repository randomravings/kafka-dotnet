using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using MetadataRequestTopic = Kafka.Client.Messages.MetadataRequest.MetadataRequestTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class MetadataRequestSerde
    {
        private static readonly DecodeDelegate<MetadataRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV08(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV09(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV10(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV11(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV12(ref b),
        };
        private static readonly EncodeDelegate<MetadataRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
            (b, m) => WriteV08(b, m),
            (b, m) => WriteV09(b, m),
            (b, m) => WriteV10(b, m),
            (b, m) => WriteV11(b, m),
            (b, m) => WriteV12(b, m),
        };
        public static MetadataRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, MetadataRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static MetadataRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataRequestTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, MetadataRequest message)
        {
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            buffer = Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static MetadataRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataRequestTopicSerde.ReadV01(ref b));
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, MetadataRequest message)
        {
            buffer = Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV01(b, i));
            return buffer;
        }
        private static MetadataRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataRequestTopicSerde.ReadV02(ref b));
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, MetadataRequest message)
        {
            buffer = Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV02(b, i));
            return buffer;
        }
        private static MetadataRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataRequestTopicSerde.ReadV03(ref b));
            var allowAutoTopicCreationField = default(bool);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, MetadataRequest message)
        {
            buffer = Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV03(b, i));
            return buffer;
        }
        private static MetadataRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataRequestTopicSerde.ReadV04(ref b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(ref buffer);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, MetadataRequest message)
        {
            buffer = Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV04(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            return buffer;
        }
        private static MetadataRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataRequestTopicSerde.ReadV05(ref b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(ref buffer);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, MetadataRequest message)
        {
            buffer = Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV05(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            return buffer;
        }
        private static MetadataRequest ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataRequestTopicSerde.ReadV06(ref b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(ref buffer);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, MetadataRequest message)
        {
            buffer = Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV06(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            return buffer;
        }
        private static MetadataRequest ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataRequestTopicSerde.ReadV07(ref b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(ref buffer);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, MetadataRequest message)
        {
            buffer = Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV07(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            return buffer;
        }
        private static MetadataRequest ReadV08(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataRequestTopicSerde.ReadV08(ref b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(ref buffer);
            var includeClusterAuthorizedOperationsField = Decoder.ReadBoolean(ref buffer);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(ref buffer);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV08(Memory<byte> buffer, MetadataRequest message)
        {
            buffer = Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV08(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            buffer = Encoder.WriteBoolean(buffer, message.IncludeClusterAuthorizedOperationsField);
            buffer = Encoder.WriteBoolean(buffer, message.IncludeTopicAuthorizedOperationsField);
            return buffer;
        }
        private static MetadataRequest ReadV09(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<MetadataRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataRequestTopicSerde.ReadV09(ref b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(ref buffer);
            var includeClusterAuthorizedOperationsField = Decoder.ReadBoolean(ref buffer);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV09(Memory<byte> buffer, MetadataRequest message)
        {
            buffer = Encoder.WriteCompactArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV09(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            buffer = Encoder.WriteBoolean(buffer, message.IncludeClusterAuthorizedOperationsField);
            buffer = Encoder.WriteBoolean(buffer, message.IncludeTopicAuthorizedOperationsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static MetadataRequest ReadV10(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<MetadataRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataRequestTopicSerde.ReadV10(ref b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(ref buffer);
            var includeClusterAuthorizedOperationsField = Decoder.ReadBoolean(ref buffer);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV10(Memory<byte> buffer, MetadataRequest message)
        {
            buffer = Encoder.WriteCompactArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV10(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            buffer = Encoder.WriteBoolean(buffer, message.IncludeClusterAuthorizedOperationsField);
            buffer = Encoder.WriteBoolean(buffer, message.IncludeTopicAuthorizedOperationsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static MetadataRequest ReadV11(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<MetadataRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataRequestTopicSerde.ReadV11(ref b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(ref buffer);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV11(Memory<byte> buffer, MetadataRequest message)
        {
            buffer = Encoder.WriteCompactArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV11(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            buffer = Encoder.WriteBoolean(buffer, message.IncludeTopicAuthorizedOperationsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static MetadataRequest ReadV12(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<MetadataRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => MetadataRequestTopicSerde.ReadV12(ref b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(ref buffer);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static Memory<byte> WriteV12(Memory<byte> buffer, MetadataRequest message)
        {
            buffer = Encoder.WriteCompactArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV12(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            buffer = Encoder.WriteBoolean(buffer, message.IncludeTopicAuthorizedOperationsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class MetadataRequestTopicSerde
        {
            public static MetadataRequestTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(ref buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                return buffer;
            }
            public static MetadataRequestTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(ref buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                return buffer;
            }
            public static MetadataRequestTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(ref buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                return buffer;
            }
            public static MetadataRequestTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(ref buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                return buffer;
            }
            public static MetadataRequestTopic ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(ref buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                return buffer;
            }
            public static MetadataRequestTopic ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(ref buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                return buffer;
            }
            public static MetadataRequestTopic ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(ref buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                return buffer;
            }
            public static MetadataRequestTopic ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(ref buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                return buffer;
            }
            public static MetadataRequestTopic ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(ref buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteString(buffer, message.NameField);
                return buffer;
            }
            public static MetadataRequestTopic ReadV09(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadCompactString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static Memory<byte> WriteV09(Memory<byte> buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static MetadataRequestTopic ReadV10(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var nameField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static Memory<byte> WriteV10(Memory<byte> buffer, MetadataRequestTopic message)
            {
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.NameField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static MetadataRequestTopic ReadV11(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var nameField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static Memory<byte> WriteV11(Memory<byte> buffer, MetadataRequestTopic message)
            {
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.NameField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static MetadataRequestTopic ReadV12(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var nameField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static Memory<byte> WriteV12(Memory<byte> buffer, MetadataRequestTopic message)
            {
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.NameField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}