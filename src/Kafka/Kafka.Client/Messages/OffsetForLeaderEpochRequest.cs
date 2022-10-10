using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetForLeaderEpochRequest (
        int ReplicaIdField,
        OffsetForLeaderEpochRequest.OffsetForLeaderTopic[] TopicsField
    )
    {
        public sealed record OffsetForLeaderTopic (
            string TopicField,
            OffsetForLeaderEpochRequest.OffsetForLeaderTopic.OffsetForLeaderPartition[] PartitionsField
        )
        {
            public sealed record OffsetForLeaderPartition (
                int PartitionField,
                int CurrentLeaderEpochField,
                int LeaderEpochField
            );
        };
    };
}
