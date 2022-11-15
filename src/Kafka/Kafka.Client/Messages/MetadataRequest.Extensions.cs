using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using MetadataRequestTopic = Kafka.Client.Messages.MetadataRequest.MetadataRequestTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class MetadataRequestSerde
    {
        private static readonly Func<Stream, MetadataRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
            b => ReadV08(b),
            b => ReadV09(b),
            b => ReadV10(b),
            b => ReadV11(b),
            b => ReadV12(b),
        };
        private static readonly Action<Stream, MetadataRequest>[] WRITE_VERSIONS = {
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
        public static MetadataRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, MetadataRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static MetadataRequest ReadV00(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, b => MetadataRequestTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static void WriteV00(Stream buffer, MetadataRequest message)
        {
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV00(b, i));
        }
        private static MetadataRequest ReadV01(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, b => MetadataRequestTopicSerde.ReadV01(b));
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
        private static void WriteV01(Stream buffer, MetadataRequest message)
        {
            Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV01(b, i));
        }
        private static MetadataRequest ReadV02(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, b => MetadataRequestTopicSerde.ReadV02(b));
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
        private static void WriteV02(Stream buffer, MetadataRequest message)
        {
            Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV02(b, i));
        }
        private static MetadataRequest ReadV03(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, b => MetadataRequestTopicSerde.ReadV03(b));
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
        private static void WriteV03(Stream buffer, MetadataRequest message)
        {
            Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV03(b, i));
        }
        private static MetadataRequest ReadV04(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, b => MetadataRequestTopicSerde.ReadV04(b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static void WriteV04(Stream buffer, MetadataRequest message)
        {
            Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV04(b, i));
            Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
        }
        private static MetadataRequest ReadV05(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, b => MetadataRequestTopicSerde.ReadV05(b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static void WriteV05(Stream buffer, MetadataRequest message)
        {
            Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV05(b, i));
            Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
        }
        private static MetadataRequest ReadV06(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, b => MetadataRequestTopicSerde.ReadV06(b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static void WriteV06(Stream buffer, MetadataRequest message)
        {
            Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV06(b, i));
            Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
        }
        private static MetadataRequest ReadV07(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, b => MetadataRequestTopicSerde.ReadV07(b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static void WriteV07(Stream buffer, MetadataRequest message)
        {
            Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV07(b, i));
            Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
        }
        private static MetadataRequest ReadV08(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, b => MetadataRequestTopicSerde.ReadV08(b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer);
            var includeClusterAuthorizedOperationsField = Decoder.ReadBoolean(buffer);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(buffer);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static void WriteV08(Stream buffer, MetadataRequest message)
        {
            Encoder.WriteArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV08(b, i));
            Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            Encoder.WriteBoolean(buffer, message.IncludeClusterAuthorizedOperationsField);
            Encoder.WriteBoolean(buffer, message.IncludeTopicAuthorizedOperationsField);
        }
        private static MetadataRequest ReadV09(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<MetadataRequestTopic>(buffer, b => MetadataRequestTopicSerde.ReadV09(b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer);
            var includeClusterAuthorizedOperationsField = Decoder.ReadBoolean(buffer);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static void WriteV09(Stream buffer, MetadataRequest message)
        {
            Encoder.WriteCompactArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV09(b, i));
            Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            Encoder.WriteBoolean(buffer, message.IncludeClusterAuthorizedOperationsField);
            Encoder.WriteBoolean(buffer, message.IncludeTopicAuthorizedOperationsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static MetadataRequest ReadV10(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<MetadataRequestTopic>(buffer, b => MetadataRequestTopicSerde.ReadV10(b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer);
            var includeClusterAuthorizedOperationsField = Decoder.ReadBoolean(buffer);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static void WriteV10(Stream buffer, MetadataRequest message)
        {
            Encoder.WriteCompactArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV10(b, i));
            Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            Encoder.WriteBoolean(buffer, message.IncludeClusterAuthorizedOperationsField);
            Encoder.WriteBoolean(buffer, message.IncludeTopicAuthorizedOperationsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static MetadataRequest ReadV11(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<MetadataRequestTopic>(buffer, b => MetadataRequestTopicSerde.ReadV11(b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static void WriteV11(Stream buffer, MetadataRequest message)
        {
            Encoder.WriteCompactArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV11(b, i));
            Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            Encoder.WriteBoolean(buffer, message.IncludeTopicAuthorizedOperationsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static MetadataRequest ReadV12(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<MetadataRequestTopic>(buffer, b => MetadataRequestTopicSerde.ReadV12(b));
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static void WriteV12(Stream buffer, MetadataRequest message)
        {
            Encoder.WriteCompactArray<MetadataRequestTopic>(buffer, message.TopicsField, (b, i) => MetadataRequestTopicSerde.WriteV12(b, i));
            Encoder.WriteBoolean(buffer, message.AllowAutoTopicCreationField);
            Encoder.WriteBoolean(buffer, message.IncludeTopicAuthorizedOperationsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class MetadataRequestTopicSerde
        {
            public static MetadataRequestTopic ReadV00(Stream buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static void WriteV00(Stream buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
            }
            public static MetadataRequestTopic ReadV01(Stream buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static void WriteV01(Stream buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
            }
            public static MetadataRequestTopic ReadV02(Stream buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static void WriteV02(Stream buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
            }
            public static MetadataRequestTopic ReadV03(Stream buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static void WriteV03(Stream buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
            }
            public static MetadataRequestTopic ReadV04(Stream buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static void WriteV04(Stream buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
            }
            public static MetadataRequestTopic ReadV05(Stream buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static void WriteV05(Stream buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
            }
            public static MetadataRequestTopic ReadV06(Stream buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static void WriteV06(Stream buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
            }
            public static MetadataRequestTopic ReadV07(Stream buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static void WriteV07(Stream buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
            }
            public static MetadataRequestTopic ReadV08(Stream buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadString(buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static void WriteV08(Stream buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteString(buffer, message.NameField);
            }
            public static MetadataRequestTopic ReadV09(Stream buffer)
            {
                var topicIdField = default(Guid);
                var nameField = Decoder.ReadCompactString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static void WriteV09(Stream buffer, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static MetadataRequestTopic ReadV10(Stream buffer)
            {
                var topicIdField = Decoder.ReadUuid(buffer);
                var nameField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static void WriteV10(Stream buffer, MetadataRequestTopic message)
            {
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteCompactNullableString(buffer, message.NameField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static MetadataRequestTopic ReadV11(Stream buffer)
            {
                var topicIdField = Decoder.ReadUuid(buffer);
                var nameField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static void WriteV11(Stream buffer, MetadataRequestTopic message)
            {
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteCompactNullableString(buffer, message.NameField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static MetadataRequestTopic ReadV12(Stream buffer)
            {
                var topicIdField = Decoder.ReadUuid(buffer);
                var nameField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicIdField,
                    nameField
                );
            }
            public static void WriteV12(Stream buffer, MetadataRequestTopic message)
            {
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteCompactNullableString(buffer, message.NameField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}