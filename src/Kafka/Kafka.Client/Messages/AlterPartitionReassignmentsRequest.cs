using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterPartitionReassignmentsRequest (
        int TimeoutMsField,
        AlterPartitionReassignmentsRequest.ReassignableTopic[] TopicsField
    )
    {
        public sealed record ReassignableTopic (
            string NameField,
            AlterPartitionReassignmentsRequest.ReassignableTopic.ReassignablePartition[] PartitionsField
        )
        {
            public sealed record ReassignablePartition (
                int PartitionIndexField,
                int[] ReplicasField
            );
        };
    };
}
