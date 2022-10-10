using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record BeginQuorumEpochRequest (
        string ClusterIdField,
        BeginQuorumEpochRequest.TopicData[] TopicsField
    )
    {
        public sealed record TopicData (
            string TopicNameField,
            BeginQuorumEpochRequest.TopicData.PartitionData[] PartitionsField
        )
        {
            public sealed record PartitionData (
                int PartitionIndexField,
                int LeaderIdField,
                int LeaderEpochField
            );
        };
    };
}
