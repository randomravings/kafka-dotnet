using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ListPartitionReassignmentsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string ErrorMessageField,
        ListPartitionReassignmentsResponse.OngoingTopicReassignment[] TopicsField
    )
    {
        public sealed record OngoingTopicReassignment (
            string NameField,
            ListPartitionReassignmentsResponse.OngoingTopicReassignment.OngoingPartitionReassignment[] PartitionsField
        )
        {
            public sealed record OngoingPartitionReassignment (
                int PartitionIndexField,
                int[] ReplicasField,
                int[] AddingReplicasField,
                int[] RemovingReplicasField
            );
        };
    };
}
