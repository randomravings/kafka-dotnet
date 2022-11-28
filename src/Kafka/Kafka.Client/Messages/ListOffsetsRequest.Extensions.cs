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
        private static readonly DecodeDelegate<ListOffsetsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
        };
        private static readonly EncodeDelegate<ListOffsetsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
        };
        public static ListOffsetsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ListOffsetsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ListOffsetsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = default(sbyte);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ListOffsetsRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static ListOffsetsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = default(sbyte);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ListOffsetsRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV01(b, i));
            return buffer;
        }
        private static ListOffsetsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, ListOffsetsRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV02(b, i));
            return buffer;
        }
        private static ListOffsetsRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, ListOffsetsRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV03(b, i));
            return buffer;
        }
        private static ListOffsetsRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, ListOffsetsRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV04(b, i));
            return buffer;
        }
        private static ListOffsetsRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var topicsField = Decoder.ReadArray<ListOffsetsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, ListOffsetsRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV05(b, i));
            return buffer;
        }
        private static ListOffsetsRequest ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var topicsField = Decoder.ReadCompactArray<ListOffsetsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, ListOffsetsRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteCompactArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV06(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static ListOffsetsRequest ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var topicsField = Decoder.ReadCompactArray<ListOffsetsTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsTopicSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                replicaIdField,
                isolationLevelField,
                topicsField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, ListOffsetsRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteCompactArray<ListOffsetsTopic>(buffer, message.TopicsField, (b, i) => ListOffsetsTopicSerde.WriteV07(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class ListOffsetsTopicSerde
        {
            public static ListOffsetsTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, ListOffsetsTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV00(b, i));
                return buffer;
            }
            public static ListOffsetsTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, ListOffsetsTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV01(b, i));
                return buffer;
            }
            public static ListOffsetsTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, ListOffsetsTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV02(b, i));
                return buffer;
            }
            public static ListOffsetsTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, ListOffsetsTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV03(b, i));
                return buffer;
            }
            public static ListOffsetsTopic ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, ListOffsetsTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV04(b, i));
                return buffer;
            }
            public static ListOffsetsTopic ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var partitionsField = Decoder.ReadArray<ListOffsetsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, ListOffsetsTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV05(b, i));
                return buffer;
            }
            public static ListOffsetsTopic ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<ListOffsetsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, ListOffsetsTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV06(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static ListOffsetsTopic ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<ListOffsetsPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListOffsetsPartitionSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, ListOffsetsTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<ListOffsetsPartition>(buffer, message.PartitionsField, (b, i) => ListOffsetsPartitionSerde.WriteV07(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class ListOffsetsPartitionSerde
            {
                public static ListOffsetsPartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var maxNumOffsetsField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, ListOffsetsPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    buffer = Encoder.WriteInt32(buffer, message.MaxNumOffsetsField);
                    return buffer;
                }
                public static ListOffsetsPartition ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var maxNumOffsetsField = default(int);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, ListOffsetsPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    return buffer;
                }
                public static ListOffsetsPartition ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var maxNumOffsetsField = default(int);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, ListOffsetsPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    return buffer;
                }
                public static ListOffsetsPartition ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var maxNumOffsetsField = default(int);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, ListOffsetsPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    return buffer;
                }
                public static ListOffsetsPartition ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var maxNumOffsetsField = default(int);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, ListOffsetsPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    return buffer;
                }
                public static ListOffsetsPartition ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var maxNumOffsetsField = default(int);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static Memory<byte> WriteV05(Memory<byte> buffer, ListOffsetsPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    return buffer;
                }
                public static ListOffsetsPartition ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var maxNumOffsetsField = default(int);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static Memory<byte> WriteV06(Memory<byte> buffer, ListOffsetsPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static ListOffsetsPartition ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var timestampField = Decoder.ReadInt64(ref buffer);
                    var maxNumOffsetsField = default(int);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        currentLeaderEpochField,
                        timestampField,
                        maxNumOffsetsField
                    );
                }
                public static Memory<byte> WriteV07(Memory<byte> buffer, ListOffsetsPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.TimestampField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}