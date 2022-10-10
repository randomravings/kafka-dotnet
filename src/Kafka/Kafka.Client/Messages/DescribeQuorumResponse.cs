using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeQuorumResponse (
        short ErrorCodeField,
        DescribeQuorumResponse.TopicData[] TopicsField
    )
    {
        public sealed record TopicData (
            string TopicNameField,
            DescribeQuorumResponse.TopicData.PartitionData[] PartitionsField
        )
        {
            public sealed record PartitionData (
                int PartitionIndexField,
                short ErrorCodeField,
                int LeaderIdField,
                int LeaderEpochField,
                long HighWatermarkField,
                DescribeQuorumResponse.ReplicaState[] CurrentVotersField,
                DescribeQuorumResponse.ReplicaState[] ObserversField
            );
        };
        public sealed record ReplicaState (
            int ReplicaIdField,
            long LogEndOffsetField,
            long LastFetchTimestampField,
            long LastCaughtUpTimestampField
        );
    };
}
