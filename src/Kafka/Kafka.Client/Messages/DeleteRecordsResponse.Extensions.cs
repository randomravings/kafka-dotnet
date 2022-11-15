using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DeleteRecordsPartitionResult = Kafka.Client.Messages.DeleteRecordsResponse.DeleteRecordsTopicResult.DeleteRecordsPartitionResult;
using DeleteRecordsTopicResult = Kafka.Client.Messages.DeleteRecordsResponse.DeleteRecordsTopicResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteRecordsResponseSerde
    {
        private static readonly Func<Stream, DeleteRecordsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, DeleteRecordsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static DeleteRecordsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DeleteRecordsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DeleteRecordsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<DeleteRecordsTopicResult>(buffer, b => DeleteRecordsTopicResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, DeleteRecordsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DeleteRecordsTopicResult>(buffer, message.TopicsField, (b, i) => DeleteRecordsTopicResultSerde.WriteV00(b, i));
        }
        private static DeleteRecordsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<DeleteRecordsTopicResult>(buffer, b => DeleteRecordsTopicResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, DeleteRecordsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DeleteRecordsTopicResult>(buffer, message.TopicsField, (b, i) => DeleteRecordsTopicResultSerde.WriteV01(b, i));
        }
        private static DeleteRecordsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<DeleteRecordsTopicResult>(buffer, b => DeleteRecordsTopicResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, DeleteRecordsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<DeleteRecordsTopicResult>(buffer, message.TopicsField, (b, i) => DeleteRecordsTopicResultSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DeleteRecordsTopicResultSerde
        {
            public static DeleteRecordsTopicResult ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<DeleteRecordsPartitionResult>(buffer, b => DeleteRecordsPartitionResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, DeleteRecordsTopicResult message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<DeleteRecordsPartitionResult>(buffer, message.PartitionsField, (b, i) => DeleteRecordsPartitionResultSerde.WriteV00(b, i));
            }
            public static DeleteRecordsTopicResult ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<DeleteRecordsPartitionResult>(buffer, b => DeleteRecordsPartitionResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, DeleteRecordsTopicResult message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<DeleteRecordsPartitionResult>(buffer, message.PartitionsField, (b, i) => DeleteRecordsPartitionResultSerde.WriteV01(b, i));
            }
            public static DeleteRecordsTopicResult ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<DeleteRecordsPartitionResult>(buffer, b => DeleteRecordsPartitionResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, DeleteRecordsTopicResult message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<DeleteRecordsPartitionResult>(buffer, message.PartitionsField, (b, i) => DeleteRecordsPartitionResultSerde.WriteV02(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class DeleteRecordsPartitionResultSerde
            {
                public static DeleteRecordsPartitionResult ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var lowWatermarkField = Decoder.ReadInt64(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        lowWatermarkField,
                        errorCodeField
                    );
                }
                public static void WriteV00(Stream buffer, DeleteRecordsPartitionResult message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.LowWatermarkField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static DeleteRecordsPartitionResult ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var lowWatermarkField = Decoder.ReadInt64(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        lowWatermarkField,
                        errorCodeField
                    );
                }
                public static void WriteV01(Stream buffer, DeleteRecordsPartitionResult message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.LowWatermarkField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static DeleteRecordsPartitionResult ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var lowWatermarkField = Decoder.ReadInt64(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        lowWatermarkField,
                        errorCodeField
                    );
                }
                public static void WriteV02(Stream buffer, DeleteRecordsPartitionResult message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.LowWatermarkField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}