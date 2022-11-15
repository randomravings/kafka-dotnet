using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ListOffsetsTopic = Kafka.Client.Messages.ListOffsetsRequest.ListOffsetsTopic;
using ListOffsetsPartition = Kafka.Client.Messages.ListOffsetsRequest.ListOffsetsTopic.ListOffsetsPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListOffsetsRequestSerde
    {
        private static readonly Func<Stream, ListOffsetsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
        };
        private static readonly Action<Stream, ListOffsetsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
        };
        public static ListOffsetsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ListOffsetsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ListOffsetsRequest ReadV00(Stream buffer)
        {
            var replicaIdField = Decoder.ReadInt32(buffer);
            var isolationLevelField = default(sbyte);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(buffer, b => ListOffsetsTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, ListOffsetsRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV00(b, i));
        }
        private static ListOffsetsRequest ReadV01(Stream buffer)
        {
            var replicaIdField = Decoder.ReadInt32(buffer);
            var isolationLevelField = default(sbyte);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(buffer, b => ListOffsetsTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static void WriteV01(Stream buffer, ListOffsetsRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV01(b, i));
        }
        private static ListOffsetsRequest ReadV02(Stream buffer)
        {
            var replicaIdField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(buffer, b => ListOffsetsTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static void WriteV02(Stream buffer, ListOffsetsRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV02(b, i));
        }
        private static ListOffsetsRequest ReadV03(Stream buffer)
        {
            var replicaIdField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(buffer, b => ListOffsetsTopicSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static void WriteV03(Stream buffer, ListOffsetsRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV03(b, i));
        }
        private static ListOffsetsRequest ReadV04(Stream buffer)
        {
            var replicaIdField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(buffer, b => ListOffsetsTopicSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static void WriteV04(Stream buffer, ListOffsetsRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV04(b, i));
        }
        private static ListOffsetsRequest ReadV05(Stream buffer)
        {
            var replicaIdField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(buffer, b => ListOffsetsTopicSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static void WriteV05(Stream buffer, ListOffsetsRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV05(b, i));
        }
        private static ListOffsetsRequest ReadV06(Stream buffer)
        {
            var replicaIdField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var topicsField = Decoder.ReadCompactArray<ListOffsetsTopic>(buffer, b => ListOffsetsTopicSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static void WriteV06(Stream buffer, ListOffsetsRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteCompactArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV06(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static ListOffsetsRequest ReadV07(Stream buffer)
        {
            var replicaIdField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var topicsField = Decoder.ReadCompactArray<ListOffsetsTopic>(buffer, b => ListOffsetsTopicSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static void WriteV07(Stream buffer, ListOffsetsRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteCompactArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV07(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class ListOffsetsTopicSerde
        {
            public static ListOffsetsTopic ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartition>(buffer, b => ListOffsetsPartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, ListOffsetsTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV00(b, i));
            }
            public static ListOffsetsTopic ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartition>(buffer, b => ListOffsetsPartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, ListOffsetsTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV01(b, i));
            }
            public static ListOffsetsTopic ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartition>(buffer, b => ListOffsetsPartitionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, ListOffsetsTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV02(b, i));
            }
            public static ListOffsetsTopic ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartition>(buffer, b => ListOffsetsPartitionSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV03(Stream buffer, ListOffsetsTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV03(b, i));
            }
            public static ListOffsetsTopic ReadV04(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartition>(buffer, b => ListOffsetsPartitionSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV04(Stream buffer, ListOffsetsTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV04(b, i));
            }
            public static ListOffsetsTopic ReadV05(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartition>(buffer, b => ListOffsetsPartitionSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV05(Stream buffer, ListOffsetsTopic message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV05(b, i));
            }
            public static ListOffsetsTopic ReadV06(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<ListOffsetsPartition>(buffer, b => ListOffsetsPartitionSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV06(Stream buffer, ListOffsetsTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV06(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static ListOffsetsTopic ReadV07(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<ListOffsetsPartition>(buffer, b => ListOffsetsPartitionSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV07(Stream buffer, ListOffsetsTopic message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV07(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class ListOffsetsPartitionSerde
            {
                public static ListOffsetsPartition ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var timestampField = Decoder.ReadInt64(buffer);
                    var maxNumOffsetsField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static void WriteV00(Stream buffer, ListOffsetsPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                    Encoder.WriteInt32(buffer, message.MaxNumOffsetsField);
                }
                public static ListOffsetsPartition ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var timestampField = Decoder.ReadInt64(buffer);
                    var maxNumOffsetsField = default(int);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static void WriteV01(Stream buffer, ListOffsetsPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                }
                public static ListOffsetsPartition ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var timestampField = Decoder.ReadInt64(buffer);
                    var maxNumOffsetsField = default(int);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static void WriteV02(Stream buffer, ListOffsetsPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                }
                public static ListOffsetsPartition ReadV03(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var timestampField = Decoder.ReadInt64(buffer);
                    var maxNumOffsetsField = default(int);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static void WriteV03(Stream buffer, ListOffsetsPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                }
                public static ListOffsetsPartition ReadV04(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer);
                    var timestampField = Decoder.ReadInt64(buffer);
                    var maxNumOffsetsField = default(int);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static void WriteV04(Stream buffer, ListOffsetsPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                }
                public static ListOffsetsPartition ReadV05(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer);
                    var timestampField = Decoder.ReadInt64(buffer);
                    var maxNumOffsetsField = default(int);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static void WriteV05(Stream buffer, ListOffsetsPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                }
                public static ListOffsetsPartition ReadV06(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer);
                    var timestampField = Decoder.ReadInt64(buffer);
                    var maxNumOffsetsField = default(int);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static void WriteV06(Stream buffer, ListOffsetsPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static ListOffsetsPartition ReadV07(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer);
                    var timestampField = Decoder.ReadInt64(buffer);
                    var maxNumOffsetsField = default(int);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static void WriteV07(Stream buffer, ListOffsetsPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    Encoder.WriteInt64(buffer, message.TimestampField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}