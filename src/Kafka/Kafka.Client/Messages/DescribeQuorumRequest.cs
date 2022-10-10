using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeQuorumRequest (
        DescribeQuorumRequest.TopicData[] TopicsField
    )
    {
        public sealed record TopicData (
            string TopicNameField,
            DescribeQuorumRequest.TopicData.PartitionData[] PartitionsField
        )
        {
            public sealed record PartitionData (
                int PartitionIndexField
            );
        };
    };
}
