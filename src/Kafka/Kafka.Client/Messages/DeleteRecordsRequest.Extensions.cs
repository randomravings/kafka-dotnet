using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DeleteRecordsTopic = Kafka.Client.Messages.DeleteRecordsRequest.DeleteRecordsTopic;
using DeleteRecordsPartition = Kafka.Client.Messages.DeleteRecordsRequest.DeleteRecordsTopic.DeleteRecordsPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteRecordsRequestSerde
    {
        private static readonly Func<Stream, DeleteRecordsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, DeleteRecordsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static DeleteRecordsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DeleteRecordsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DeleteRecordsRequest ReadV00(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<DeleteRecordsTopic>(buffer, b => DeleteRecordsTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            return new(
                topicsField,
                timeoutMsField
            );
        }
        private static void WriteV00(Stream buffer, DeleteRecordsRequest message)
        {
            Encoder.WriteArray<DeleteRecordsTopic>(buffer, message.TopicsField, (b, i) => DeleteRecordsTopicSerde.WriteV00(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
        }
        private static DeleteRecordsRequest ReadV01(Stream buffer)
        {
            var topicsField = Decoder.ReadArray<DeleteRecordsTopic>(buffer, b => DeleteRecordsTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            return new(
                topicsField,
                timeoutMsField
            );
        }
        private static void WriteV01(Stream buffer, DeleteRecordsRequest message)
        {
            Encoder.WriteArray<DeleteRecordsTopic>(buffer, message.TopicsField, (b, i) => DeleteRecordsTopicSerde.WriteV01(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
        }
        private static DeleteRecordsRequest ReadV02(Stream buffer)
        {
            var topicsField = Decoder.ReadCompactArray<DeleteRecordsTopic>(buffer, b => DeleteRecordsTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                topicsField,
                timeoutMsField
            );
        }
        private static void WriteV02(Stream buffer, DeleteRecordsRequest message)
        {
            Encoder.WriteCompactArray<DeleteRecordsTopic>(buffer, message.TopicsField, (b, i) => DeleteRecordsTopicSerde.WriteV02(b, i));
            Encoder.WriteInt32(buffer, message.TimeoutMsField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DeleteRecordsTopicSerde
        {
            public static DeleteRecordsTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<DeleteRecordsPartition>(buffer, b => DeleteRecordsPartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, DeleteRecordsTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<DeleteRecordsPartition>(buffer, message.PartitionsField, (b, i) => DeleteRecordsPartitionSerde.WriteV00(b, i));
            }
            public static DeleteRecordsTopic ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<DeleteRecordsPartition>(buffer, b => DeleteRecordsPartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, DeleteRecordsTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<DeleteRecordsPartition>(buffer, message.PartitionsField, (b, i) => DeleteRecordsPartitionSerde.WriteV01(b, i));
            }
            public static DeleteRecordsTopic ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<DeleteRecordsPartition>(buffer, b => DeleteRecordsPartitionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, DeleteRecordsTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<DeleteRecordsPartition>(buffer, message.PartitionsField, (b, i) => DeleteRecordsPartitionSerde.WriteV02(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class DeleteRecordsPartitionSerde
            {
                public static DeleteRecordsPartition ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var offsetField = Decoder.ReadInt64(buffer);
                    return new(
                        partitionIndexField,
                        offsetField
                    );
                }
                public static void WriteV00(Stream buffer, DeleteRecordsPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.OffsetField);
                }
                public static DeleteRecordsPartition ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var offsetField = Decoder.ReadInt64(buffer);
                    return new(
                        partitionIndexField,
                        offsetField
                    );
                }
                public static void WriteV01(Stream buffer, DeleteRecordsPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.OffsetField);
                }
                public static DeleteRecordsPartition ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var offsetField = Decoder.ReadInt64(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        offsetField
                    );
                }
                public static void WriteV02(Stream buffer, DeleteRecordsPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.OffsetField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}