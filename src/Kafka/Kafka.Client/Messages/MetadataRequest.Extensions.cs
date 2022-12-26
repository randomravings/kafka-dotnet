using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using MetadataRequestTopic = Kafka.Client.Messages.MetadataRequest.MetadataRequestTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class MetadataRequestSerde
    {
        private static readonly DecodeDelegate<MetadataRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
            ReadV08,
            ReadV09,
            ReadV10,
            ReadV11,
            ReadV12,
        };
        private static readonly EncodeDelegate<MetadataRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
            WriteV08,
            WriteV09,
            WriteV10,
            WriteV11,
            WriteV12,
        };
        public static MetadataRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, MetadataRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static MetadataRequest ReadV00(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, ref index, MetadataRequestTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static int WriteV00(byte[] buffer, int index, MetadataRequest message)
        {
            if (message.TopicsField == null)
                throw new ArgumentNullException(nameof(message.TopicsField));
            index = Encoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV00);
            return index;
        }
        private static MetadataRequest ReadV01(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, ref index, MetadataRequestTopicSerde.ReadV01);
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
        private static int WriteV01(byte[] buffer, int index, MetadataRequest message)
        {
            index = Encoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV01);
            return index;
        }
        private static MetadataRequest ReadV02(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, ref index, MetadataRequestTopicSerde.ReadV02);
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
        private static int WriteV02(byte[] buffer, int index, MetadataRequest message)
        {
            index = Encoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV02);
            return index;
        }
        private static MetadataRequest ReadV03(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, ref index, MetadataRequestTopicSerde.ReadV03);
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
        private static int WriteV03(byte[] buffer, int index, MetadataRequest message)
        {
            index = Encoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV03);
            return index;
        }
        private static MetadataRequest ReadV04(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, ref index, MetadataRequestTopicSerde.ReadV04);
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer, ref index);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, MetadataRequest message)
        {
            index = Encoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV04);
            index = Encoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            return index;
        }
        private static MetadataRequest ReadV05(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, ref index, MetadataRequestTopicSerde.ReadV05);
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer, ref index);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static int WriteV05(byte[] buffer, int index, MetadataRequest message)
        {
            index = Encoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV05);
            index = Encoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            return index;
        }
        private static MetadataRequest ReadV06(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, ref index, MetadataRequestTopicSerde.ReadV06);
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer, ref index);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static int WriteV06(byte[] buffer, int index, MetadataRequest message)
        {
            index = Encoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV06);
            index = Encoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            return index;
        }
        private static MetadataRequest ReadV07(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, ref index, MetadataRequestTopicSerde.ReadV07);
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer, ref index);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = default(bool);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static int WriteV07(byte[] buffer, int index, MetadataRequest message)
        {
            index = Encoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV07);
            index = Encoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            return index;
        }
        private static MetadataRequest ReadV08(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadArray<MetadataRequestTopic>(buffer, ref index, MetadataRequestTopicSerde.ReadV08);
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer, ref index);
            var includeClusterAuthorizedOperationsField = Decoder.ReadBoolean(buffer, ref index);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(buffer, ref index);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static int WriteV08(byte[] buffer, int index, MetadataRequest message)
        {
            index = Encoder.WriteArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV08);
            index = Encoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeClusterAuthorizedOperationsField);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
            return index;
        }
        private static MetadataRequest ReadV09(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<MetadataRequestTopic>(buffer, ref index, MetadataRequestTopicSerde.ReadV09);
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer, ref index);
            var includeClusterAuthorizedOperationsField = Decoder.ReadBoolean(buffer, ref index);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static int WriteV09(byte[] buffer, int index, MetadataRequest message)
        {
            index = Encoder.WriteCompactArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV09);
            index = Encoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeClusterAuthorizedOperationsField);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static MetadataRequest ReadV10(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<MetadataRequestTopic>(buffer, ref index, MetadataRequestTopicSerde.ReadV10);
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer, ref index);
            var includeClusterAuthorizedOperationsField = Decoder.ReadBoolean(buffer, ref index);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static int WriteV10(byte[] buffer, int index, MetadataRequest message)
        {
            index = Encoder.WriteCompactArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV10);
            index = Encoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeClusterAuthorizedOperationsField);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static MetadataRequest ReadV11(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<MetadataRequestTopic>(buffer, ref index, MetadataRequestTopicSerde.ReadV11);
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer, ref index);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static int WriteV11(byte[] buffer, int index, MetadataRequest message)
        {
            index = Encoder.WriteCompactArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV11);
            index = Encoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static MetadataRequest ReadV12(byte[] buffer, ref int index)
        {
            var topicsField = Decoder.ReadCompactArray<MetadataRequestTopic>(buffer, ref index, MetadataRequestTopicSerde.ReadV12);
            var allowAutoTopicCreationField = Decoder.ReadBoolean(buffer, ref index);
            var includeClusterAuthorizedOperationsField = default(bool);
            var includeTopicAuthorizedOperationsField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                topicsField,
                allowAutoTopicCreationField,
                includeClusterAuthorizedOperationsField,
                includeTopicAuthorizedOperationsField
            );
        }
        private static int WriteV12(byte[] buffer, int index, MetadataRequest message)
        {
            index = Encoder.WriteCompactArray<MetadataRequestTopic>(buffer, index, message.TopicsField, MetadataRequestTopicSerde.WriteV12);
            index = Encoder.WriteBoolean(buffer, index, message.AllowAutoTopicCreationField);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeTopicAuthorizedOperationsField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class MetadataRequestTopicSerde
        {
            public static MetadataRequestTopic ReadV00(byte[] buffer, ref int index)
            {
                var TopicIdField = default(Guid);
                var NameField = Decoder.ReadString(buffer, ref index);
                return new(
                    TopicIdField,
                    NameField
                );
            }
            public static int WriteV00(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static MetadataRequestTopic ReadV01(byte[] buffer, ref int index)
            {
                var TopicIdField = default(Guid);
                var NameField = Decoder.ReadString(buffer, ref index);
                return new(
                    TopicIdField,
                    NameField
                );
            }
            public static int WriteV01(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static MetadataRequestTopic ReadV02(byte[] buffer, ref int index)
            {
                var TopicIdField = default(Guid);
                var NameField = Decoder.ReadString(buffer, ref index);
                return new(
                    TopicIdField,
                    NameField
                );
            }
            public static int WriteV02(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static MetadataRequestTopic ReadV03(byte[] buffer, ref int index)
            {
                var TopicIdField = default(Guid);
                var NameField = Decoder.ReadString(buffer, ref index);
                return new(
                    TopicIdField,
                    NameField
                );
            }
            public static int WriteV03(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static MetadataRequestTopic ReadV04(byte[] buffer, ref int index)
            {
                var TopicIdField = default(Guid);
                var NameField = Decoder.ReadString(buffer, ref index);
                return new(
                    TopicIdField,
                    NameField
                );
            }
            public static int WriteV04(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static MetadataRequestTopic ReadV05(byte[] buffer, ref int index)
            {
                var TopicIdField = default(Guid);
                var NameField = Decoder.ReadString(buffer, ref index);
                return new(
                    TopicIdField,
                    NameField
                );
            }
            public static int WriteV05(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static MetadataRequestTopic ReadV06(byte[] buffer, ref int index)
            {
                var TopicIdField = default(Guid);
                var NameField = Decoder.ReadString(buffer, ref index);
                return new(
                    TopicIdField,
                    NameField
                );
            }
            public static int WriteV06(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static MetadataRequestTopic ReadV07(byte[] buffer, ref int index)
            {
                var TopicIdField = default(Guid);
                var NameField = Decoder.ReadString(buffer, ref index);
                return new(
                    TopicIdField,
                    NameField
                );
            }
            public static int WriteV07(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static MetadataRequestTopic ReadV08(byte[] buffer, ref int index)
            {
                var TopicIdField = default(Guid);
                var NameField = Decoder.ReadString(buffer, ref index);
                return new(
                    TopicIdField,
                    NameField
                );
            }
            public static int WriteV08(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteString(buffer, index, message.NameField);
                return index;
            }
            public static MetadataRequestTopic ReadV09(byte[] buffer, ref int index)
            {
                var TopicIdField = default(Guid);
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicIdField,
                    NameField
                );
            }
            public static int WriteV09(byte[] buffer, int index, MetadataRequestTopic message)
            {
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static MetadataRequestTopic ReadV10(byte[] buffer, ref int index)
            {
                var TopicIdField = Decoder.ReadUuid(buffer, ref index);
                var NameField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicIdField,
                    NameField
                );
            }
            public static int WriteV10(byte[] buffer, int index, MetadataRequestTopic message)
            {
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.NameField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static MetadataRequestTopic ReadV11(byte[] buffer, ref int index)
            {
                var TopicIdField = Decoder.ReadUuid(buffer, ref index);
                var NameField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicIdField,
                    NameField
                );
            }
            public static int WriteV11(byte[] buffer, int index, MetadataRequestTopic message)
            {
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.NameField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static MetadataRequestTopic ReadV12(byte[] buffer, ref int index)
            {
                var TopicIdField = Decoder.ReadUuid(buffer, ref index);
                var NameField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicIdField,
                    NameField
                );
            }
            public static int WriteV12(byte[] buffer, int index, MetadataRequestTopic message)
            {
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.NameField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}