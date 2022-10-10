using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record StopReplicaRequest (
        int ControllerIdField,
        int ControllerEpochField,
        long BrokerEpochField,
        bool DeletePartitionsField,
        StopReplicaRequest.StopReplicaPartitionV0[] UngroupedPartitionsField,
        StopReplicaRequest.StopReplicaTopicV1[] TopicsField,
        StopReplicaRequest.StopReplicaTopicState[] TopicStatesField
    )
    {
        public sealed record StopReplicaPartitionV0 (
            string TopicNameField,
            int PartitionIndexField
        );
        public sealed record StopReplicaTopicState (
            string TopicNameField,
            StopReplicaRequest.StopReplicaTopicState.StopReplicaPartitionState[] PartitionStatesField
        )
        {
            public sealed record StopReplicaPartitionState (
                int PartitionIndexField,
                int LeaderEpochField,
                bool DeletePartitionField
            );
        };
        public sealed record StopReplicaTopicV1 (
            string NameField,
            int[] PartitionIndexesField
        );
    };
}
