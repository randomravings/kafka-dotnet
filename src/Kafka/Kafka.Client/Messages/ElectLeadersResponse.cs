using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ElectLeadersResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        ElectLeadersResponse.ReplicaElectionResult[] ReplicaElectionResultsField
    )
    {
        public sealed record ReplicaElectionResult (
            string TopicField,
            ElectLeadersResponse.ReplicaElectionResult.PartitionResult[] PartitionResultField
        )
        {
            public sealed record PartitionResult (
                int PartitionIdField,
                short ErrorCodeField,
                string ErrorMessageField
            );
        };
    };
}
