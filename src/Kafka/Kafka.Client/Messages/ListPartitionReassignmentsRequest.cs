using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ListPartitionReassignmentsRequest (
        int TimeoutMsField,
        ListPartitionReassignmentsRequest.ListPartitionReassignmentsTopics[] TopicsField
    )
    {
        public sealed record ListPartitionReassignmentsTopics (
            string NameField,
            int[] PartitionIndexesField
        );
    };
}
