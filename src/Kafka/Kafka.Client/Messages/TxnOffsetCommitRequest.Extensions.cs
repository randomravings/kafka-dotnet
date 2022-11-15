using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TxnOffsetCommitRequestTopic = Kafka.Client.Messages.TxnOffsetCommitRequest.TxnOffsetCommitRequestTopic;
using TxnOffsetCommitRequestPartition = Kafka.Client.Messages.TxnOffsetCommitRequest.TxnOffsetCommitRequestTopic.TxnOffsetCommitRequestPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class TxnOffsetCommitRequestSerde
    {
        private static readonly Func<Stream, TxnOffsetCommitRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, TxnOffsetCommitRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static TxnOffsetCommitRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, TxnOffsetCommitRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static TxnOffsetCommitRequest ReadV00(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadString(buffer);
            var groupIdField = Decoder.ReadString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitRequestTopic>(buffer, b => TxnOffsetCommitRequestTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static void WriteV00(Stream buffer, TxnOffsetCommitRequest message)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteArray<TxnOffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitRequestTopicSerde.WriteV00(b, i));
        }
        private static TxnOffsetCommitRequest ReadV01(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadString(buffer);
            var groupIdField = Decoder.ReadString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitRequestTopic>(buffer, b => TxnOffsetCommitRequestTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static void WriteV01(Stream buffer, TxnOffsetCommitRequest message)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteArray<TxnOffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitRequestTopicSerde.WriteV01(b, i));
        }
        private static TxnOffsetCommitRequest ReadV02(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadString(buffer);
            var groupIdField = Decoder.ReadString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitRequestTopic>(buffer, b => TxnOffsetCommitRequestTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static void WriteV02(Stream buffer, TxnOffsetCommitRequest message)
        {
            Encoder.WriteString(buffer, message.TransactionalIdField);
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteArray<TxnOffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitRequestTopicSerde.WriteV02(b, i));
        }
        private static TxnOffsetCommitRequest ReadV03(Stream buffer)
        {
            var transactionalIdField = Decoder.ReadCompactString(buffer);
            var groupIdField = Decoder.ReadCompactString(buffer);
            var producerIdField = Decoder.ReadInt64(buffer);
            var producerEpochField = Decoder.ReadInt16(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadCompactString(buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
            var topicsField = Decoder.ReadCompactArray<TxnOffsetCommitRequestTopic>(buffer, b => TxnOffsetCommitRequestTopicSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV03(Stream buffer, TxnOffsetCommitRequest message)
        {
            Encoder.WriteCompactString(buffer, message.TransactionalIdField);
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteInt64(buffer, message.ProducerIdField);
            Encoder.WriteInt16(buffer, message.ProducerEpochField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteCompactString(buffer, message.MemberIdField);
            Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            Encoder.WriteCompactArray<TxnOffsetCommitRequestTopic>(buffer, message.TopicsField, (b, i) => TxnOffsetCommitRequestTopicSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TxnOffsetCommitRequestTopicSerde
        {
            public static TxnOffsetCommitRequestTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<TxnOffsetCommitRequestPartition>(buffer, b => TxnOffsetCommitRequestPartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, TxnOffsetCommitRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<TxnOffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitRequestPartitionSerde.WriteV00(b, i));
            }
            public static TxnOffsetCommitRequestTopic ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<TxnOffsetCommitRequestPartition>(buffer, b => TxnOffsetCommitRequestPartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, TxnOffsetCommitRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<TxnOffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitRequestPartitionSerde.WriteV01(b, i));
            }
            public static TxnOffsetCommitRequestTopic ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<TxnOffsetCommitRequestPartition>(buffer, b => TxnOffsetCommitRequestPartitionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, TxnOffsetCommitRequestTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<TxnOffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitRequestPartitionSerde.WriteV02(b, i));
            }
            public static TxnOffsetCommitRequestTopic ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<TxnOffsetCommitRequestPartition>(buffer, b => TxnOffsetCommitRequestPartitionSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV03(Stream buffer, TxnOffsetCommitRequestTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<TxnOffsetCommitRequestPartition>(buffer, message.PartitionsField, (b, i) => TxnOffsetCommitRequestPartitionSerde.WriteV03(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class TxnOffsetCommitRequestPartitionSerde
            {
                public static TxnOffsetCommitRequestPartition ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = default(int);
                    var committedMetadataField = Decoder.ReadNullableString(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        committedMetadataField
                    );
                }
                public static void WriteV00(Stream buffer, TxnOffsetCommitRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                }
                public static TxnOffsetCommitRequestPartition ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = default(int);
                    var committedMetadataField = Decoder.ReadNullableString(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        committedMetadataField
                    );
                }
                public static void WriteV01(Stream buffer, TxnOffsetCommitRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                }
                public static TxnOffsetCommitRequestPartition ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(buffer);
                    var committedMetadataField = Decoder.ReadNullableString(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        committedMetadataField
                    );
                }
                public static void WriteV02(Stream buffer, TxnOffsetCommitRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    Encoder.WriteNullableString(buffer, message.CommittedMetadataField);
                }
                public static TxnOffsetCommitRequestPartition ReadV03(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var committedOffsetField = Decoder.ReadInt64(buffer);
                    var committedLeaderEpochField = Decoder.ReadInt32(buffer);
                    var committedMetadataField = Decoder.ReadCompactNullableString(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        committedMetadataField
                    );
                }
                public static void WriteV03(Stream buffer, TxnOffsetCommitRequestPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.CommittedOffsetField);
                    Encoder.WriteInt32(buffer, message.CommittedLeaderEpochField);
                    Encoder.WriteCompactNullableString(buffer, message.CommittedMetadataField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}