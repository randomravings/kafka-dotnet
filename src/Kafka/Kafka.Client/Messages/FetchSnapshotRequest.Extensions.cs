using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using SnapshotId = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot.PartitionSnapshot.SnapshotId;
using PartitionSnapshot = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot.PartitionSnapshot;
using TopicSnapshot = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchSnapshotRequestSerde
    {
        private static readonly DecodeDelegate<FetchSnapshotRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<FetchSnapshotRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static FetchSnapshotRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, FetchSnapshotRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static FetchSnapshotRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<TopicSnapshot>(ref buffer, (ref ReadOnlyMemory<byte> b) => TopicSnapshotSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                clusterIdField,
                replicaIdField,
                maxBytesField,
                topicsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, FetchSnapshotRequest message)
        {
            buffer = Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxBytesField);
            buffer = Encoder.WriteCompactArray<TopicSnapshot>(buffer, message.TopicsField, (b, i) => TopicSnapshotSerde.WriteV00(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class TopicSnapshotSerde
        {
            public static TopicSnapshot ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionSnapshot>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionSnapshotSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, TopicSnapshot message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<PartitionSnapshot>(buffer, message.PartitionsField, (b, i) => PartitionSnapshotSerde.WriteV00(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class PartitionSnapshotSerde
            {
                public static PartitionSnapshot ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var snapshotIdField = SnapshotIdSerde.ReadV00(ref buffer);
                    var positionField = Decoder.ReadInt64(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        snapshotIdField,
                        positionField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, PartitionSnapshot message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    buffer = SnapshotIdSerde.WriteV00(buffer, message.SnapshotIdField);
                    buffer = Encoder.WriteInt64(buffer, message.PositionField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                private static class SnapshotIdSerde
                {
                    public static SnapshotId ReadV00(ref ReadOnlyMemory<byte> buffer)
                    {
                        var endOffsetField = Decoder.ReadInt64(ref buffer);
                        var epochField = Decoder.ReadInt32(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            endOffsetField,
                            epochField
                        );
                    }
                    public static Memory<byte> WriteV00(Memory<byte> buffer, SnapshotId message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.EndOffsetField);
                        buffer = Encoder.WriteInt32(buffer, message.EpochField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                }
            }
        }
    }
}