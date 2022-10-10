using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record FetchSnapshotRequest (
        string ClusterIdField,
        int ReplicaIdField,
        int MaxBytesField,
        FetchSnapshotRequest.TopicSnapshot[] TopicsField
    )
    {
        public sealed record TopicSnapshot (
            string NameField,
            FetchSnapshotRequest.TopicSnapshot.PartitionSnapshot[] PartitionsField
        )
        {
            public sealed record PartitionSnapshot (
                int PartitionField,
                int CurrentLeaderEpochField,
                FetchSnapshotRequest.TopicSnapshot.PartitionSnapshot.SnapshotId SnapshotIdField,
                long PositionField
            )
            {
                public sealed record SnapshotId (
                    long EndOffsetField,
                    int EpochField
                );
            };
        };
    };
}
