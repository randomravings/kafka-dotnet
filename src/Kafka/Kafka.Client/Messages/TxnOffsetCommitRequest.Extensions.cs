using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TxnOffsetCommitRequestTopic = Kafka.Client.Messages.TxnOffsetCommitRequest.TxnOffsetCommitRequestTopic;
using TxnOffsetCommitRequestPartition = Kafka.Client.Messages.TxnOffsetCommitRequest.TxnOffsetCommitRequestTopic.TxnOffsetCommitRequestPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class TxnOffsetCommitRequestSerde
    {
        private static readonly DecodeDelegate<TxnOffsetCommitRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<TxnOffsetCommitRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static TxnOffsetCommitRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, TxnOffsetCommitRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static TxnOffsetCommitRequest ReadV00(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadString(buffer, ref index);
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitRequestTopic>(buffer, ref index, TxnOffsetCommitRequestTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static int WriteV00(byte[] buffer, int index, TxnOffsetCommitRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteArray<TxnOffsetCommitRequestTopic>(buffer, index, message.TopicsField, TxnOffsetCommitRequestTopicSerde.WriteV00);
            return index;
        }
        private static TxnOffsetCommitRequest ReadV01(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadString(buffer, ref index);
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitRequestTopic>(buffer, ref index, TxnOffsetCommitRequestTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static int WriteV01(byte[] buffer, int index, TxnOffsetCommitRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteArray<TxnOffsetCommitRequestTopic>(buffer, index, message.TopicsField, TxnOffsetCommitRequestTopicSerde.WriteV01);
            return index;
        }
        private static TxnOffsetCommitRequest ReadV02(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadString(buffer, ref index);
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = default(int);
            var memberIdField = "";
            var groupInstanceIdField = default(string?);
            var topicsField = Decoder.ReadArray<TxnOffsetCommitRequestTopic>(buffer, ref index, TxnOffsetCommitRequestTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static int WriteV02(byte[] buffer, int index, TxnOffsetCommitRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteArray<TxnOffsetCommitRequestTopic>(buffer, index, message.TopicsField, TxnOffsetCommitRequestTopicSerde.WriteV02);
            return index;
        }
        private static TxnOffsetCommitRequest ReadV03(byte[] buffer, ref int index)
        {
            var transactionalIdField = Decoder.ReadCompactString(buffer, ref index);
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            var producerIdField = Decoder.ReadInt64(buffer, ref index);
            var producerEpochField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadCompactString(buffer, ref index);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<TxnOffsetCommitRequestTopic>(buffer, ref index, TxnOffsetCommitRequestTopicSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
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
        private static int WriteV03(byte[] buffer, int index, TxnOffsetCommitRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.TransactionalIdField);
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
            index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = Encoder.WriteCompactArray<TxnOffsetCommitRequestTopic>(buffer, index, message.TopicsField, TxnOffsetCommitRequestTopicSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class TxnOffsetCommitRequestTopicSerde
        {
            public static TxnOffsetCommitRequestTopic ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<TxnOffsetCommitRequestPartition>(buffer, ref index, TxnOffsetCommitRequestPartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TxnOffsetCommitRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<TxnOffsetCommitRequestPartition>(buffer, index, message.PartitionsField, TxnOffsetCommitRequestPartitionSerde.WriteV00);
                return index;
            }
            public static TxnOffsetCommitRequestTopic ReadV01(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<TxnOffsetCommitRequestPartition>(buffer, ref index, TxnOffsetCommitRequestPartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, TxnOffsetCommitRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<TxnOffsetCommitRequestPartition>(buffer, index, message.PartitionsField, TxnOffsetCommitRequestPartitionSerde.WriteV01);
                return index;
            }
            public static TxnOffsetCommitRequestTopic ReadV02(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<TxnOffsetCommitRequestPartition>(buffer, ref index, TxnOffsetCommitRequestPartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, TxnOffsetCommitRequestTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<TxnOffsetCommitRequestPartition>(buffer, index, message.PartitionsField, TxnOffsetCommitRequestPartitionSerde.WriteV02);
                return index;
            }
            public static TxnOffsetCommitRequestTopic ReadV03(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<TxnOffsetCommitRequestPartition>(buffer, ref index, TxnOffsetCommitRequestPartitionSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, TxnOffsetCommitRequestTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<TxnOffsetCommitRequestPartition>(buffer, index, message.PartitionsField, TxnOffsetCommitRequestPartitionSerde.WriteV03);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class TxnOffsetCommitRequestPartitionSerde
            {
                public static TxnOffsetCommitRequestPartition ReadV00(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = default(int);
                    var CommittedMetadataField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        CommittedMetadataField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, TxnOffsetCommitRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static TxnOffsetCommitRequestPartition ReadV01(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = default(int);
                    var CommittedMetadataField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        CommittedMetadataField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, TxnOffsetCommitRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static TxnOffsetCommitRequestPartition ReadV02(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedMetadataField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        CommittedMetadataField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, TxnOffsetCommitRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = Encoder.WriteNullableString(buffer, index, message.CommittedMetadataField);
                    return index;
                }
                public static TxnOffsetCommitRequestPartition ReadV03(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var CommittedLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var CommittedMetadataField = Decoder.ReadCompactNullableString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CommittedOffsetField,
                        CommittedLeaderEpochField,
                        CommittedMetadataField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, TxnOffsetCommitRequestPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.CommittedOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.CommittedLeaderEpochField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.CommittedMetadataField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}