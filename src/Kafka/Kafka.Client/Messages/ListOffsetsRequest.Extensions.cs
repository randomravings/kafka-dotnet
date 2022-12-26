using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ListOffsetsTopic = Kafka.Client.Messages.ListOffsetsRequest.ListOffsetsTopic;
using ListOffsetsPartition = Kafka.Client.Messages.ListOffsetsRequest.ListOffsetsTopic.ListOffsetsPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListOffsetsRequestSerde
    {
        private static readonly DecodeDelegate<ListOffsetsRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
        };
        private static readonly EncodeDelegate<ListOffsetsRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
        };
        public static ListOffsetsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ListOffsetsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ListOffsetsRequest ReadV00(byte[] buffer, ref int index)
        {
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = default(sbyte);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(buffer, ref index, ListOffsetsTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV00);
            return index;
        }
        private static ListOffsetsRequest ReadV01(byte[] buffer, ref int index)
        {
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = default(sbyte);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(buffer, ref index, ListOffsetsTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV01);
            return index;
        }
        private static ListOffsetsRequest ReadV02(byte[] buffer, ref int index)
        {
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(buffer, ref index, ListOffsetsTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV02);
            return index;
        }
        private static ListOffsetsRequest ReadV03(byte[] buffer, ref int index)
        {
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(buffer, ref index, ListOffsetsTopicSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV03);
            return index;
        }
        private static ListOffsetsRequest ReadV04(byte[] buffer, ref int index)
        {
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(buffer, ref index, ListOffsetsTopicSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV04);
            return index;
        }
        private static ListOffsetsRequest ReadV05(byte[] buffer, ref int index)
        {
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(buffer, ref index, ListOffsetsTopicSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static int WriteV05(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV05);
            return index;
        }
        private static ListOffsetsRequest ReadV06(byte[] buffer, ref int index)
        {
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<ListOffsetsTopic>(buffer, ref index, ListOffsetsTopicSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static int WriteV06(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteCompactArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV06);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static ListOffsetsRequest ReadV07(byte[] buffer, ref int index)
        {
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<ListOffsetsTopic>(buffer, ref index, ListOffsetsTopicSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static int WriteV07(byte[] buffer, int index, ListOffsetsRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteCompactArray<ListOffsetsTopic>(buffer, index, message.TopicsField, ListOffsetsTopicSerde.WriteV07);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class ListOffsetsTopicSerde
        {
            public static ListOffsetsTopic ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<ListOffsetsPartition>(buffer, ref index, ListOffsetsPartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV00);
                return index;
            }
            public static ListOffsetsTopic ReadV01(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<ListOffsetsPartition>(buffer, ref index, ListOffsetsPartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV01);
                return index;
            }
            public static ListOffsetsTopic ReadV02(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<ListOffsetsPartition>(buffer, ref index, ListOffsetsPartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV02);
                return index;
            }
            public static ListOffsetsTopic ReadV03(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<ListOffsetsPartition>(buffer, ref index, ListOffsetsPartitionSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV03);
                return index;
            }
            public static ListOffsetsTopic ReadV04(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<ListOffsetsPartition>(buffer, ref index, ListOffsetsPartitionSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV04);
                return index;
            }
            public static ListOffsetsTopic ReadV05(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var PartitionsField = Decoder.ReadArray<ListOffsetsPartition>(buffer, ref index, ListOffsetsPartitionSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV05(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV05);
                return index;
            }
            public static ListOffsetsTopic ReadV06(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<ListOffsetsPartition>(buffer, ref index, ListOffsetsPartitionSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV06(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV06);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static ListOffsetsTopic ReadV07(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<ListOffsetsPartition>(buffer, ref index, ListOffsetsPartitionSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    PartitionsField
                );
            }
            public static int WriteV07(byte[] buffer, int index, ListOffsetsTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<ListOffsetsPartition>(buffer, index, message.PartitionsField, ListOffsetsPartitionSerde.WriteV07);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class ListOffsetsPartitionSerde
            {
                public static ListOffsetsPartition ReadV00(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CurrentLeaderEpochField = default(int);
                    var TimestampField = Decoder.ReadInt64(buffer, ref index);
                    var MaxNumOffsetsField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CurrentLeaderEpochField,
                        TimestampField,
                        MaxNumOffsetsField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    index = Encoder.WriteInt32(buffer, index, message.MaxNumOffsetsField);
                    return index;
                }
                public static ListOffsetsPartition ReadV01(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CurrentLeaderEpochField = default(int);
                    var TimestampField = Decoder.ReadInt64(buffer, ref index);
                    var MaxNumOffsetsField = default(int);
                    return new(
                        PartitionIndexField,
                        CurrentLeaderEpochField,
                        TimestampField,
                        MaxNumOffsetsField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    return index;
                }
                public static ListOffsetsPartition ReadV02(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CurrentLeaderEpochField = default(int);
                    var TimestampField = Decoder.ReadInt64(buffer, ref index);
                    var MaxNumOffsetsField = default(int);
                    return new(
                        PartitionIndexField,
                        CurrentLeaderEpochField,
                        TimestampField,
                        MaxNumOffsetsField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    return index;
                }
                public static ListOffsetsPartition ReadV03(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CurrentLeaderEpochField = default(int);
                    var TimestampField = Decoder.ReadInt64(buffer, ref index);
                    var MaxNumOffsetsField = default(int);
                    return new(
                        PartitionIndexField,
                        CurrentLeaderEpochField,
                        TimestampField,
                        MaxNumOffsetsField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    return index;
                }
                public static ListOffsetsPartition ReadV04(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CurrentLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var TimestampField = Decoder.ReadInt64(buffer, ref index);
                    var MaxNumOffsetsField = default(int);
                    return new(
                        PartitionIndexField,
                        CurrentLeaderEpochField,
                        TimestampField,
                        MaxNumOffsetsField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    return index;
                }
                public static ListOffsetsPartition ReadV05(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CurrentLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var TimestampField = Decoder.ReadInt64(buffer, ref index);
                    var MaxNumOffsetsField = default(int);
                    return new(
                        PartitionIndexField,
                        CurrentLeaderEpochField,
                        TimestampField,
                        MaxNumOffsetsField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    return index;
                }
                public static ListOffsetsPartition ReadV06(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CurrentLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var TimestampField = Decoder.ReadInt64(buffer, ref index);
                    var MaxNumOffsetsField = default(int);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CurrentLeaderEpochField,
                        TimestampField,
                        MaxNumOffsetsField
                    );
                }
                public static int WriteV06(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static ListOffsetsPartition ReadV07(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var CurrentLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var TimestampField = Decoder.ReadInt64(buffer, ref index);
                    var MaxNumOffsetsField = default(int);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        CurrentLeaderEpochField,
                        TimestampField,
                        MaxNumOffsetsField
                    );
                }
                public static int WriteV07(byte[] buffer, int index, ListOffsetsPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.TimestampField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}