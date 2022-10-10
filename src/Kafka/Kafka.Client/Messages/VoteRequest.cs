using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record VoteRequest (
        string ClusterIdField,
        VoteRequest.TopicData[] TopicsField
    )
    {
        public sealed record TopicData (
            string TopicNameField,
            VoteRequest.TopicData.PartitionData[] PartitionsField
        )
        {
            public sealed record PartitionData (
                int PartitionIndexField,
                int CandidateEpochField,
                int CandidateIdField,
                int LastOffsetEpochField,
                long LastOffsetField
            );
        };
    };
}
