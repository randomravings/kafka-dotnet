using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreatePartitionsRequest (
        CreatePartitionsRequest.CreatePartitionsTopic[] TopicsField,
        int TimeoutMsField,
        bool ValidateOnlyField
    )
    {
        public sealed record CreatePartitionsTopic (
            string NameField,
            int CountField,
            CreatePartitionsRequest.CreatePartitionsTopic.CreatePartitionsAssignment[] AssignmentsField
        )
        {
            public sealed record CreatePartitionsAssignment (
                int[] BrokerIdsField
            );
        };
    };
}
