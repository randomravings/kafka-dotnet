using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeProducersRequest (
        DescribeProducersRequest.TopicRequest[] TopicsField
    )
    {
        public sealed record TopicRequest (
            string NameField,
            int[] PartitionIndexesField
        );
    };
}
