using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using LeaderAndIsrTopicError = Kafka.Client.Messages.LeaderAndIsrResponse.LeaderAndIsrTopicError;
using LeaderAndIsrPartitionError = Kafka.Client.Messages.LeaderAndIsrResponse.LeaderAndIsrPartitionError;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaderAndIsrResponseSerde
    {
        private static readonly Func<Stream, LeaderAndIsrResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
        };
        private static readonly Action<Stream, LeaderAndIsrResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
        };
        public static LeaderAndIsrResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, LeaderAndIsrResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static LeaderAndIsrResponse ReadV00(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var partitionErrorsField = Decoder.ReadArray<LeaderAndIsrPartitionError>(buffer, b => LeaderAndIsrPartitionErrorSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, LeaderAndIsrResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV00(b, i));
        }
        private static LeaderAndIsrResponse ReadV01(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var partitionErrorsField = Decoder.ReadArray<LeaderAndIsrPartitionError>(buffer, b => LeaderAndIsrPartitionErrorSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, LeaderAndIsrResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV01(b, i));
        }
        private static LeaderAndIsrResponse ReadV02(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var partitionErrorsField = Decoder.ReadArray<LeaderAndIsrPartitionError>(buffer, b => LeaderAndIsrPartitionErrorSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, LeaderAndIsrResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV02(b, i));
        }
        private static LeaderAndIsrResponse ReadV03(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var partitionErrorsField = Decoder.ReadArray<LeaderAndIsrPartitionError>(buffer, b => LeaderAndIsrPartitionErrorSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static void WriteV03(Stream buffer, LeaderAndIsrResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV03(b, i));
        }
        private static LeaderAndIsrResponse ReadV04(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var partitionErrorsField = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(buffer, b => LeaderAndIsrPartitionErrorSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static void WriteV04(Stream buffer, LeaderAndIsrResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV04(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static LeaderAndIsrResponse ReadV05(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
            var topicsField = Decoder.ReadCompactArray<LeaderAndIsrTopicError>(buffer, b => LeaderAndIsrTopicErrorSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static void WriteV05(Stream buffer, LeaderAndIsrResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<LeaderAndIsrTopicError>(buffer, message.TopicsField, (b, i) => LeaderAndIsrTopicErrorSerde.WriteV05(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static LeaderAndIsrResponse ReadV06(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
            var topicsField = Decoder.ReadCompactArray<LeaderAndIsrTopicError>(buffer, b => LeaderAndIsrTopicErrorSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static void WriteV06(Stream buffer, LeaderAndIsrResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<LeaderAndIsrTopicError>(buffer, message.TopicsField, (b, i) => LeaderAndIsrTopicErrorSerde.WriteV06(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class LeaderAndIsrTopicErrorSerde
        {
            public static LeaderAndIsrTopicError ReadV05(Stream buffer)
            {
                var topicIdField = Decoder.ReadUuid(buffer);
                var partitionErrorsField = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(buffer, b => LeaderAndIsrPartitionErrorSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicIdField,
                    partitionErrorsField
                );
            }
            public static void WriteV05(Stream buffer, LeaderAndIsrTopicError message)
            {
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV05(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static LeaderAndIsrTopicError ReadV06(Stream buffer)
            {
                var topicIdField = Decoder.ReadUuid(buffer);
                var partitionErrorsField = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(buffer, b => LeaderAndIsrPartitionErrorSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicIdField,
                    partitionErrorsField
                );
            }
            public static void WriteV06(Stream buffer, LeaderAndIsrTopicError message)
            {
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV06(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
        private static class LeaderAndIsrPartitionErrorSerde
        {
            public static LeaderAndIsrPartitionError ReadV00(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static void WriteV00(Stream buffer, LeaderAndIsrPartitionError message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static LeaderAndIsrPartitionError ReadV01(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static void WriteV01(Stream buffer, LeaderAndIsrPartitionError message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static LeaderAndIsrPartitionError ReadV02(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static void WriteV02(Stream buffer, LeaderAndIsrPartitionError message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static LeaderAndIsrPartitionError ReadV03(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static void WriteV03(Stream buffer, LeaderAndIsrPartitionError message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static LeaderAndIsrPartitionError ReadV04(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static void WriteV04(Stream buffer, LeaderAndIsrPartitionError message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static LeaderAndIsrPartitionError ReadV05(Stream buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static void WriteV05(Stream buffer, LeaderAndIsrPartitionError message)
            {
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static LeaderAndIsrPartitionError ReadV06(Stream buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static void WriteV06(Stream buffer, LeaderAndIsrPartitionError message)
            {
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}