using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DeleteRecordsPartition = Kafka.Client.Messages.DeleteRecordsRequest.DeleteRecordsTopic.DeleteRecordsPartition;
using DeleteRecordsTopic = Kafka.Client.Messages.DeleteRecordsRequest.DeleteRecordsTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteRecordsRequestSerde
    {
        private static readonly DecodeDelegate<DeleteRecordsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<DeleteRecordsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static DeleteRecordsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DeleteRecordsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DeleteRecordsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<DeleteRecordsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteRecordsTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            return new(
                topicsField,
                timeoutMsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DeleteRecordsRequest message)
        {
            buffer = Encoder.WriteArray<DeleteRecordsTopic>(buffer, message.TopicsField, (b, i) => DeleteRecordsTopicSerde.WriteV00(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            return buffer;
        }
        private static DeleteRecordsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadArray<DeleteRecordsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteRecordsTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            return new(
                topicsField,
                timeoutMsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DeleteRecordsRequest message)
        {
            buffer = Encoder.WriteArray<DeleteRecordsTopic>(buffer, message.TopicsField, (b, i) => DeleteRecordsTopicSerde.WriteV01(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            return buffer;
        }
        private static DeleteRecordsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var topicsField = Decoder.ReadCompactArray<DeleteRecordsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteRecordsTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var timeoutMsField = Decoder.ReadInt32(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                topicsField,
                timeoutMsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DeleteRecordsRequest message)
        {
            buffer = Encoder.WriteCompactArray<DeleteRecordsTopic>(buffer, message.TopicsField, (b, i) => DeleteRecordsTopicSerde.WriteV02(b, i));
            buffer = Encoder.WriteInt32(buffer, message.TimeoutMsField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DeleteRecordsTopicSerde
        {
            public static DeleteRecordsTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<DeleteRecordsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteRecordsPartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DeleteRecordsTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<DeleteRecordsPartition>(buffer, message.PartitionsField, (b, i) => DeleteRecordsPartitionSerde.WriteV00(b, i));
                return buffer;
            }
            public static DeleteRecordsTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<DeleteRecordsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteRecordsPartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, DeleteRecordsTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<DeleteRecordsPartition>(buffer, message.PartitionsField, (b, i) => DeleteRecordsPartitionSerde.WriteV01(b, i));
                return buffer;
            }
            public static DeleteRecordsTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<DeleteRecordsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeleteRecordsPartitionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, DeleteRecordsTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<DeleteRecordsPartition>(buffer, message.PartitionsField, (b, i) => DeleteRecordsPartitionSerde.WriteV02(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class DeleteRecordsPartitionSerde
            {
                public static DeleteRecordsPartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var offsetField = Decoder.ReadInt64(ref buffer);
                    return new(
                        partitionIndexField,
                        offsetField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, DeleteRecordsPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.OffsetField);
                    return buffer;
                }
                public static DeleteRecordsPartition ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var offsetField = Decoder.ReadInt64(ref buffer);
                    return new(
                        partitionIndexField,
                        offsetField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, DeleteRecordsPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.OffsetField);
                    return buffer;
                }
                public static DeleteRecordsPartition ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var offsetField = Decoder.ReadInt64(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        offsetField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, DeleteRecordsPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.OffsetField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}