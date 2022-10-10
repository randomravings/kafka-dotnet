using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeLogDirsRequest (
        DescribeLogDirsRequest.DescribableLogDirTopic[] TopicsField
    )
    {
        public sealed record DescribableLogDirTopic (
            string TopicField,
            int[] PartitionsField
        );
    };
}
