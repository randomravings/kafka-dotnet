using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterPartitionReassignmentsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string ErrorMessageField,
        AlterPartitionReassignmentsResponse.ReassignableTopicResponse[] ResponsesField
    )
    {
        public sealed record ReassignableTopicResponse (
            string NameField,
            AlterPartitionReassignmentsResponse.ReassignableTopicResponse.ReassignablePartitionResponse[] PartitionsField
        )
        {
            public sealed record ReassignablePartitionResponse (
                int PartitionIndexField,
                short ErrorCodeField,
                string ErrorMessageField
            );
        };
    };
}
