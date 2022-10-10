using Kafka.Common.Records;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record FetchSnapshotResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        FetchSnapshotResponse.TopicSnapshot[] TopicsField
    )
    {
        public sealed record TopicSnapshot (
            string NameField,
            FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot[] PartitionsField
        )
        {
            public sealed record PartitionSnapshot (
                int IndexField,
                short ErrorCodeField,
                FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot.SnapshotId SnapshotIdField,
                FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot.LeaderIdAndEpoch CurrentLeaderField,
                long SizeField,
                long PositionField,
                IRecords UnalignedRecordsField
            )
            {
                public sealed record SnapshotId (
                    long EndOffsetField,
                    int EpochField
                );
                public sealed record LeaderIdAndEpoch (
                    int LeaderIdField,
                    int LeaderEpochField
                );
            };
        };
    };
}
