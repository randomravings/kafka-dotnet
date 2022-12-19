using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TopicSnapshot = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot;
using SnapshotId = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot.PartitionSnapshot.SnapshotId;
using PartitionSnapshot = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot.PartitionSnapshot;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchSnapshotRequestSerde
    {
        private static readonly DecodeDelegate<FetchSnapshotRequest>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<FetchSnapshotRequest>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static FetchSnapshotRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, FetchSnapshotRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static FetchSnapshotRequest ReadV00(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<TopicSnapshot>(buffer, ref index, TopicSnapshotSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                clusterIdField,
                replicaIdField,
                maxBytesField,
                topicsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, FetchSnapshotRequest message)
        {
            index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = Encoder.WriteCompactArray<TopicSnapshot>(buffer, index, message.TopicsField, TopicSnapshotSerde.WriteV00);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class TopicSnapshotSerde
        {
            public static TopicSnapshot ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<PartitionSnapshot>(buffer, ref index, PartitionSnapshotSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, TopicSnapshot message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<PartitionSnapshot>(buffer, index, message.PartitionsField, PartitionSnapshotSerde.WriteV00);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class PartitionSnapshotSerde
            {
                public static PartitionSnapshot ReadV00(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var snapshotIdField = SnapshotIdSerde.ReadV00(buffer, ref index);
                    var positionField = Decoder.ReadInt64(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        snapshotIdField,
                        positionField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, PartitionSnapshot message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = SnapshotIdSerde.WriteV00(buffer, index, message.SnapshotIdField);
                    index = Encoder.WriteInt64(buffer, index, message.PositionField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                private static class SnapshotIdSerde
                {
                    public static SnapshotId ReadV00(byte[] buffer, ref int index)
                    {
                        var endOffsetField = Decoder.ReadInt64(buffer, ref index);
                        var epochField = Decoder.ReadInt32(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            endOffsetField,
                            epochField
                        );
                    }
                    public static int WriteV00(byte[] buffer, int index, SnapshotId message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = Encoder.WriteInt32(buffer, index, message.EpochField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                }
            }
        }
    }
}