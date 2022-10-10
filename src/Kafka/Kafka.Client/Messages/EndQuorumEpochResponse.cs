using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record EndQuorumEpochResponse (
        short ErrorCodeField,
        EndQuorumEpochResponse.TopicData[] TopicsField
    )
    {
        public sealed record TopicData (
            string TopicNameField,
            EndQuorumEpochResponse.TopicData.PartitionData[] PartitionsField
        )
        {
            public sealed record PartitionData (
                int PartitionIndexField,
                short ErrorCodeField,
                int LeaderIdField,
                int LeaderEpochField
            );
        };
    };
}
