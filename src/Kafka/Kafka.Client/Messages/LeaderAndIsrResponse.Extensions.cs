using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using LeaderAndIsrPartitionError = Kafka.Client.Messages.LeaderAndIsrResponse.LeaderAndIsrPartitionError;
using LeaderAndIsrTopicError = Kafka.Client.Messages.LeaderAndIsrResponse.LeaderAndIsrTopicError;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaderAndIsrResponseSerde
    {
        private static readonly DecodeDelegate<LeaderAndIsrResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
        };
        private static readonly EncodeDelegate<LeaderAndIsrResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
        };
        public static LeaderAndIsrResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, LeaderAndIsrResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static LeaderAndIsrResponse ReadV00(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var partitionErrorsField = Decoder.ReadArray<LeaderAndIsrPartitionError>(buffer, ref index, LeaderAndIsrPartitionErrorSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, LeaderAndIsrResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV00);
            return index;
        }
        private static LeaderAndIsrResponse ReadV01(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var partitionErrorsField = Decoder.ReadArray<LeaderAndIsrPartitionError>(buffer, ref index, LeaderAndIsrPartitionErrorSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, LeaderAndIsrResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV01);
            return index;
        }
        private static LeaderAndIsrResponse ReadV02(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var partitionErrorsField = Decoder.ReadArray<LeaderAndIsrPartitionError>(buffer, ref index, LeaderAndIsrPartitionErrorSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, LeaderAndIsrResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV02);
            return index;
        }
        private static LeaderAndIsrResponse ReadV03(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var partitionErrorsField = Decoder.ReadArray<LeaderAndIsrPartitionError>(buffer, ref index, LeaderAndIsrPartitionErrorSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, LeaderAndIsrResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV03);
            return index;
        }
        private static LeaderAndIsrResponse ReadV04(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var partitionErrorsField = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(buffer, ref index, LeaderAndIsrPartitionErrorSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, LeaderAndIsrResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static LeaderAndIsrResponse ReadV05(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
            var topicsField = Decoder.ReadCompactArray<LeaderAndIsrTopicError>(buffer, ref index, LeaderAndIsrTopicErrorSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static int WriteV05(byte[] buffer, int index, LeaderAndIsrResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<LeaderAndIsrTopicError>(buffer, index, message.TopicsField, LeaderAndIsrTopicErrorSerde.WriteV05);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static LeaderAndIsrResponse ReadV06(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
            var topicsField = Decoder.ReadCompactArray<LeaderAndIsrTopicError>(buffer, ref index, LeaderAndIsrTopicErrorSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static int WriteV06(byte[] buffer, int index, LeaderAndIsrResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<LeaderAndIsrTopicError>(buffer, index, message.TopicsField, LeaderAndIsrTopicErrorSerde.WriteV06);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static LeaderAndIsrResponse ReadV07(byte[] buffer, ref int index)
        {
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
            var topicsField = Decoder.ReadCompactArray<LeaderAndIsrTopicError>(buffer, ref index, LeaderAndIsrTopicErrorSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static int WriteV07(byte[] buffer, int index, LeaderAndIsrResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<LeaderAndIsrTopicError>(buffer, index, message.TopicsField, LeaderAndIsrTopicErrorSerde.WriteV07);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class LeaderAndIsrPartitionErrorSerde
        {
            public static LeaderAndIsrPartitionError ReadV00(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static int WriteV00(byte[] buffer, int index, LeaderAndIsrPartitionError message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static LeaderAndIsrPartitionError ReadV01(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static int WriteV01(byte[] buffer, int index, LeaderAndIsrPartitionError message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static LeaderAndIsrPartitionError ReadV02(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static int WriteV02(byte[] buffer, int index, LeaderAndIsrPartitionError message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static LeaderAndIsrPartitionError ReadV03(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static int WriteV03(byte[] buffer, int index, LeaderAndIsrPartitionError message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static LeaderAndIsrPartitionError ReadV04(byte[] buffer, ref int index)
            {
                var topicNameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static int WriteV04(byte[] buffer, int index, LeaderAndIsrPartitionError message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrPartitionError ReadV05(byte[] buffer, ref int index)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static int WriteV05(byte[] buffer, int index, LeaderAndIsrPartitionError message)
            {
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrPartitionError ReadV06(byte[] buffer, ref int index)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static int WriteV06(byte[] buffer, int index, LeaderAndIsrPartitionError message)
            {
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrPartitionError ReadV07(byte[] buffer, ref int index)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static int WriteV07(byte[] buffer, int index, LeaderAndIsrPartitionError message)
            {
                index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
        private static class LeaderAndIsrTopicErrorSerde
        {
            public static LeaderAndIsrTopicError ReadV05(byte[] buffer, ref int index)
            {
                var topicIdField = Decoder.ReadUuid(buffer, ref index);
                var partitionErrorsField = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(buffer, ref index, LeaderAndIsrPartitionErrorSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicIdField,
                    partitionErrorsField
                );
            }
            public static int WriteV05(byte[] buffer, int index, LeaderAndIsrTopicError message)
            {
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV05);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrTopicError ReadV06(byte[] buffer, ref int index)
            {
                var topicIdField = Decoder.ReadUuid(buffer, ref index);
                var partitionErrorsField = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(buffer, ref index, LeaderAndIsrPartitionErrorSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicIdField,
                    partitionErrorsField
                );
            }
            public static int WriteV06(byte[] buffer, int index, LeaderAndIsrTopicError message)
            {
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV06);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static LeaderAndIsrTopicError ReadV07(byte[] buffer, ref int index)
            {
                var topicIdField = Decoder.ReadUuid(buffer, ref index);
                var partitionErrorsField = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(buffer, ref index, LeaderAndIsrPartitionErrorSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicIdField,
                    partitionErrorsField
                );
            }
            public static int WriteV07(byte[] buffer, int index, LeaderAndIsrTopicError message)
            {
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, index, message.PartitionErrorsField, LeaderAndIsrPartitionErrorSerde.WriteV07);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}