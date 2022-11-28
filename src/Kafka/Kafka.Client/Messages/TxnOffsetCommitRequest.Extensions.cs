using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TxnOffsetCommitRequestPartition = Kafka.Client.Messages.TxnOffsetCommitRequest.TxnOffsetCommitRequestTopic.TxnOffsetCommitRequestPartition;
using TxnOffsetCommitRequestTopic = Kafka.Client.Messages.TxnOffsetCommitRequest.TxnOffsetCommitRequestTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class TxnOffsetCommitRequestSerde
    {
        private static readonly DecodeDelegate<TxnOffsetCommitRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<TxnOffsetCommitRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static TxnOffsetCommitRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, TxnOffsetCommitRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static TxnOffsetCommitRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadString(ref buffer);
            var groupIdField = Decoder.ReadString(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitRequestTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                transactionalIdField,
                groupIdField,
                producerIdField,
                producerEpochField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, TxnOffsetCommitRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteArray<TxnOffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitRequestTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static TxnOffsetCommitRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadString(ref buffer);
            var groupIdField = Decoder.ReadString(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitRequestTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                transactionalIdField,
                groupIdField,
                producerIdField,
                producerEpochField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, TxnOffsetCommitRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteArray<TxnOffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitRequestTopicSerde.WriteV01(b, i));
            return buffer;
        }
        private static TxnOffsetCommitRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadString(ref buffer);
            var groupIdField = Decoder.ReadString(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitRequestTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                transactionalIdField,
                groupIdField,
                producerIdField,
                producerEpochField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                topicsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, TxnOffsetCommitRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteArray<TxnOffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitRequestTopicSerde.WriteV02(b, i));
            return buffer;
        }
        private static TxnOffsetCommitRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var transactionalIdField = Decoder.ReadCompactString(ref buffer);
            var groupIdField = Decoder.ReadCompactString(ref buffer);
            var producerIdField = Decoder.ReadInt64(ref buffer);
            var producerEpochField = Decoder.ReadInt16(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadCompactString(ref buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
            var topicsField = Decoder.ReadCompactArray<TxnOffsetCommitRequestTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitRequestTopicSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                transactionalIdField,
                groupIdField,
                producerIdField,
                producerEpochField,
                generationIdField,
                memberIdField,
                groupInstanceIdField,
                topicsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, TxnOffsetCommitRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.TransactionalIdField);
            buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
            buffer = Encoder.WriteInt16(buffer, message.ProducerEpochField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            buffer = Encoder.WriteCompactArray<TxnOffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitRequestTopicSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class TxnOffsetCommitRequestTopicSerde
        {
            public static TxnOffsetCommitRequestTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<TxnOffsetCommitRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitRequestPartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TxnOffsetCommitRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<TxnOffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitRequestPartitionSerde.WriteV00(b, i));
                return buffer;
            }
            public static TxnOffsetCommitRequestTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<TxnOffsetCommitRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitRequestPartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, TxnOffsetCommitRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<TxnOffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitRequestPartitionSerde.WriteV01(b, i));
                return buffer;
            }
            public static TxnOffsetCommitRequestTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<TxnOffsetCommitRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitRequestPartitionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, TxnOffsetCommitRequestTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<TxnOffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitRequestPartitionSerde.WriteV02(b, i));
                return buffer;
            }
            public static TxnOffsetCommitRequestTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<TxnOffsetCommitRequestPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => TxnOffsetCommitRequestPartitionSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, TxnOffsetCommitRequestTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<TxnOffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitRequestPartitionSerde.WriteV03(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class TxnOffsetCommitRequestPartitionSerde
            {
                public static TxnOffsetCommitRequestPartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = default(int);
                    var committedMetadataField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        committedMetadataField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, TxnOffsetCommitRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                    return buffer;
                }
                public static TxnOffsetCommitRequestPartition ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = default(int);
                    var committedMetadataField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        committedMetadataField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, TxnOffsetCommitRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                    return buffer;
                }
                public static TxnOffsetCommitRequestPartition ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var committedMetadataField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        committedMetadataField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, TxnOffsetCommitRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    buffer = Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                    return buffer;
                }
                public static TxnOffsetCommitRequestPartition ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var committedOffsetField = Decoder.ReadInt64(ref buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var committedMetadataField = Decoder.ReadCompactNullableString(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        committedMetadataField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, TxnOffsetCommitRequestPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.CommittedMetadataField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}