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
        private static readonly DecodeDelegate<LeaderAndIsrResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
        };
        private static readonly EncodeDelegate<LeaderAndIsrResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
        };
        public static LeaderAndIsrResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, LeaderAndIsrResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static LeaderAndIsrResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var partitionErrorsField = Decoder.ReadArray<LeaderAndIsrPartitionError>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionErrorSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, LeaderAndIsrResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV00(b, i));
            return buffer;
        }
        private static LeaderAndIsrResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var partitionErrorsField = Decoder.ReadArray<LeaderAndIsrPartitionError>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionErrorSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, LeaderAndIsrResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV01(b, i));
            return buffer;
        }
        private static LeaderAndIsrResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var partitionErrorsField = Decoder.ReadArray<LeaderAndIsrPartitionError>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionErrorSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, LeaderAndIsrResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV02(b, i));
            return buffer;
        }
        private static LeaderAndIsrResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var partitionErrorsField = Decoder.ReadArray<LeaderAndIsrPartitionError>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionErrorSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, LeaderAndIsrResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV03(b, i));
            return buffer;
        }
        private static LeaderAndIsrResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var partitionErrorsField = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionErrorSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
            var topicsField = ImmutableArray<LeaderAndIsrTopicError>.Empty;
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, LeaderAndIsrResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV04(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static LeaderAndIsrResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
            var topicsField = Decoder.ReadCompactArray<LeaderAndIsrTopicError>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrTopicErrorSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, LeaderAndIsrResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<LeaderAndIsrTopicError>(buffer, message.TopicsField, (b, i) => LeaderAndIsrTopicErrorSerde.WriteV05(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static LeaderAndIsrResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var partitionErrorsField = ImmutableArray<LeaderAndIsrPartitionError>.Empty;
            var topicsField = Decoder.ReadCompactArray<LeaderAndIsrTopicError>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrTopicErrorSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                partitionErrorsField,
                topicsField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, LeaderAndIsrResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<LeaderAndIsrTopicError>(buffer, message.TopicsField, (b, i) => LeaderAndIsrTopicErrorSerde.WriteV06(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class LeaderAndIsrTopicErrorSerde
        {
            public static LeaderAndIsrTopicError ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var partitionErrorsField = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionErrorSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicIdField,
                    partitionErrorsField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, LeaderAndIsrTopicError message)
            {
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV05(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static LeaderAndIsrTopicError ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var partitionErrorsField = Decoder.ReadCompactArray<LeaderAndIsrPartitionError>(ref buffer, (ref ReadOnlyMemory<byte> b) => LeaderAndIsrPartitionErrorSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicIdField,
                    partitionErrorsField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, LeaderAndIsrTopicError message)
            {
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteCompactArray<LeaderAndIsrPartitionError>(buffer, message.PartitionErrorsField, (b, i) => LeaderAndIsrPartitionErrorSerde.WriteV06(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
        private static class LeaderAndIsrPartitionErrorSerde
        {
            public static LeaderAndIsrPartitionError ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, LeaderAndIsrPartitionError message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static LeaderAndIsrPartitionError ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, LeaderAndIsrPartitionError message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static LeaderAndIsrPartitionError ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, LeaderAndIsrPartitionError message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static LeaderAndIsrPartitionError ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, LeaderAndIsrPartitionError message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static LeaderAndIsrPartitionError ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, LeaderAndIsrPartitionError message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static LeaderAndIsrPartitionError ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, LeaderAndIsrPartitionError message)
            {
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static LeaderAndIsrPartitionError ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = "";
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, LeaderAndIsrPartitionError message)
            {
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}