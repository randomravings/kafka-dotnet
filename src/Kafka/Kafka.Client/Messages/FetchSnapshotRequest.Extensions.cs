using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicSnapshot = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot;
using SnapshotId = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot.PartitionSnapshot.SnapshotId;
using PartitionSnapshot = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot.PartitionSnapshot;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchSnapshotRequestSerde
    {
        private static readonly Func<Stream, FetchSnapshotRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, FetchSnapshotRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static FetchSnapshotRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, FetchSnapshotRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static FetchSnapshotRequest ReadV00(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxBytesField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<TopicSnapshot>(buffer, b => TopicSnapshotSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                clusterIdField,
                replicaIdField,
                maxBytesField,
                topicsField
            );
        }
        private static void WriteV00(Stream buffer, FetchSnapshotRequest message)
        {
            Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteCompactArray<TopicSnapshot>(buffer, message.TopicsField, (b, i) => TopicSnapshotSerde.WriteV00(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class TopicSnapshotSerde
        {
            public static TopicSnapshot ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionSnapshot>(buffer, b => PartitionSnapshotSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, TopicSnapshot message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<PartitionSnapshot>(buffer, message.PartitionsField, (b, i) => PartitionSnapshotSerde.WriteV00(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class PartitionSnapshotSerde
            {
                public static PartitionSnapshot ReadV00(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer);
                    var snapshotIdField = SnapshotIdSerde.ReadV00(buffer);
                    var positionField = Decoder.ReadInt64(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        snapshotIdField,
                        positionField
                    );
                }
                public static void WriteV00(Stream buffer, PartitionSnapshot message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    SnapshotIdSerde.WriteV00(buffer, message.SnapshotIdField);
                    Encoder.WriteInt64(buffer, message.PositionField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                private static class SnapshotIdSerde
                {
                    public static SnapshotId ReadV00(Stream buffer)
                    {
                        var endOffsetField = Decoder.ReadInt64(buffer);
                        var epochField = Decoder.ReadInt32(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            endOffsetField,
                            epochField
                        );
                    }
                    public static void WriteV00(Stream buffer, SnapshotId message)
                    {
                        Encoder.WriteInt64(buffer, message.EndOffsetField);
                        Encoder.WriteInt32(buffer, message.EpochField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                }
            }
        }
    }
}