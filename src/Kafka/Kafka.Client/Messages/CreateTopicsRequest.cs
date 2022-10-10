using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreateTopicsRequest (
        CreateTopicsRequest.CreatableTopic[] TopicsField,
        int timeoutMsField,
        bool validateOnlyField
    )
    {
        public sealed record CreatableTopic (
            string NameField,
            int NumPartitionsField,
            short ReplicationFactorField,
            CreateTopicsRequest.CreatableTopic.CreatableReplicaAssignment[] AssignmentsField,
            CreateTopicsRequest.CreatableTopic.CreateableTopicConfig[] ConfigsField
        )
        {
            public sealed record CreatableReplicaAssignment (
                int PartitionIndexField,
                int[] BrokerIdsField
            );
            public sealed record CreateableTopicConfig (
                string NameField,
                string ValueField
            );
        };
    };
}
