using Kafka.Common.Records;
using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record FetchResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        int SessionIdField,
        FetchResponse.FetchableTopicResponse[] ResponsesField
    )
    {
        public sealed record FetchableTopicResponse (
            string TopicField,
            Guid TopicIdField,
            FetchResponse.FetchableTopicResponse.PartitionData[] PartitionsField
        )
        {
            public sealed record PartitionData (
                int PartitionIndexField,
                short ErrorCodeField,
                long HighWatermarkField,
                long LastStableOffsetField,
                long LogStartOffsetField,
                FetchResponse.FetchableTopicResponse.PartitionData.EpochEndOffset DivergingEpochField,
                FetchResponse.FetchableTopicResponse.PartitionData.LeaderIdAndEpoch CurrentLeaderField,
                FetchResponse.FetchableTopicResponse.PartitionData.SnapshotId SnapshotIdField,
                FetchResponse.FetchableTopicResponse.PartitionData.AbortedTransaction[] AbortedTransactionsField,
                int PreferredReadReplicaField,
                IRecords RecordsField
            )
            {
                public sealed record EpochEndOffset (
                    int EpochField,
                    long EndOffsetField
                );
                public sealed record SnapshotId (
                    long EndOffsetField,
                    int EpochField
                );
                public sealed record LeaderIdAndEpoch (
                    int LeaderIdField,
                    int LeaderEpochField
                );
                public sealed record AbortedTransaction (
                    long ProducerIdField,
                    long FirstOffsetField
                );
            };
        };
    };
}
