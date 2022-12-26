using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using OffsetForLeaderPartition = Kafka.Client.Messages.OffsetForLeaderEpochRequest.OffsetForLeaderTopic.OffsetForLeaderPartition;
using OffsetForLeaderTopic = Kafka.Client.Messages.OffsetForLeaderEpochRequest.OffsetForLeaderTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class OffsetForLeaderEpochRequestSerde
    {
        private static readonly DecodeDelegate<OffsetForLeaderEpochRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<OffsetForLeaderEpochRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static OffsetForLeaderEpochRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, OffsetForLeaderEpochRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static OffsetForLeaderEpochRequest ReadV00(byte[] buffer, ref int index)
        {
            var replicaIdField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopic>(buffer, ref index, OffsetForLeaderTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, OffsetForLeaderEpochRequest message)
        {
            index = Encoder.WriteArray<OffsetForLeaderTopic>(buffer, index, message.TopicsField, OffsetForLeaderTopicSerde.WriteV00);
            return index;
        }
        private static OffsetForLeaderEpochRequest ReadV01(byte[] buffer, ref int index)
        {
            var replicaIdField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopic>(buffer, ref index, OffsetForLeaderTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, OffsetForLeaderEpochRequest message)
        {
            index = Encoder.WriteArray<OffsetForLeaderTopic>(buffer, index, message.TopicsField, OffsetForLeaderTopicSerde.WriteV01);
            return index;
        }
        private static OffsetForLeaderEpochRequest ReadV02(byte[] buffer, ref int index)
        {
            var replicaIdField = default(int);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopic>(buffer, ref index, OffsetForLeaderTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, OffsetForLeaderEpochRequest message)
        {
            index = Encoder.WriteArray<OffsetForLeaderTopic>(buffer, index, message.TopicsField, OffsetForLeaderTopicSerde.WriteV02);
            return index;
        }
        private static OffsetForLeaderEpochRequest ReadV03(byte[] buffer, ref int index)
        {
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<OffsetForLeaderTopic>(buffer, ref index, OffsetForLeaderTopicSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, OffsetForLeaderEpochRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteArray<OffsetForLeaderTopic>(buffer, index, message.TopicsField, OffsetForLeaderTopicSerde.WriteV03);
            return index;
        }
        private static OffsetForLeaderEpochRequest ReadV04(byte[] buffer, ref int index)
        {
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<OffsetForLeaderTopic>(buffer, ref index, OffsetForLeaderTopicSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                replicaIdField,
                topicsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, OffsetForLeaderEpochRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteCompactArray<OffsetForLeaderTopic>(buffer, index, message.TopicsField, OffsetForLeaderTopicSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class OffsetForLeaderTopicSerde
        {
            public static OffsetForLeaderTopic ReadV00(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetForLeaderPartition>(buffer, ref index, OffsetForLeaderPartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, OffsetForLeaderTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<OffsetForLeaderPartition>(buffer, index, message.PartitionsField, OffsetForLeaderPartitionSerde.WriteV00);
                return index;
            }
            public static OffsetForLeaderTopic ReadV01(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetForLeaderPartition>(buffer, ref index, OffsetForLeaderPartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    PartitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, OffsetForLeaderTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<OffsetForLeaderPartition>(buffer, index, message.PartitionsField, OffsetForLeaderPartitionSerde.WriteV01);
                return index;
            }
            public static OffsetForLeaderTopic ReadV02(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetForLeaderPartition>(buffer, ref index, OffsetForLeaderPartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    PartitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, OffsetForLeaderTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<OffsetForLeaderPartition>(buffer, index, message.PartitionsField, OffsetForLeaderPartitionSerde.WriteV02);
                return index;
            }
            public static OffsetForLeaderTopic ReadV03(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<OffsetForLeaderPartition>(buffer, ref index, OffsetForLeaderPartitionSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    PartitionsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, OffsetForLeaderTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<OffsetForLeaderPartition>(buffer, index, message.PartitionsField, OffsetForLeaderPartitionSerde.WriteV03);
                return index;
            }
            public static OffsetForLeaderTopic ReadV04(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<OffsetForLeaderPartition>(buffer, ref index, OffsetForLeaderPartitionSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicField,
                    PartitionsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, OffsetForLeaderTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicField);
                index = Encoder.WriteCompactArray<OffsetForLeaderPartition>(buffer, index, message.PartitionsField, OffsetForLeaderPartitionSerde.WriteV04);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class OffsetForLeaderPartitionSerde
            {
                public static OffsetForLeaderPartition ReadV00(byte[] buffer, ref int index)
                {
                    var PartitionField = Decoder.ReadInt32(buffer, ref index);
                    var CurrentLeaderEpochField = default(int);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        PartitionField,
                        CurrentLeaderEpochField,
                        LeaderEpochField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, OffsetForLeaderPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    return index;
                }
                public static OffsetForLeaderPartition ReadV01(byte[] buffer, ref int index)
                {
                    var PartitionField = Decoder.ReadInt32(buffer, ref index);
                    var CurrentLeaderEpochField = default(int);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        PartitionField,
                        CurrentLeaderEpochField,
                        LeaderEpochField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, OffsetForLeaderPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    return index;
                }
                public static OffsetForLeaderPartition ReadV02(byte[] buffer, ref int index)
                {
                    var PartitionField = Decoder.ReadInt32(buffer, ref index);
                    var CurrentLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        PartitionField,
                        CurrentLeaderEpochField,
                        LeaderEpochField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, OffsetForLeaderPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    return index;
                }
                public static OffsetForLeaderPartition ReadV03(byte[] buffer, ref int index)
                {
                    var PartitionField = Decoder.ReadInt32(buffer, ref index);
                    var CurrentLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        PartitionField,
                        CurrentLeaderEpochField,
                        LeaderEpochField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, OffsetForLeaderPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    return index;
                }
                public static OffsetForLeaderPartition ReadV04(byte[] buffer, ref int index)
                {
                    var PartitionField = Decoder.ReadInt32(buffer, ref index);
                    var CurrentLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionField,
                        CurrentLeaderEpochField,
                        LeaderEpochField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, OffsetForLeaderPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}