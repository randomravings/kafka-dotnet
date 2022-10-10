using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record LeaderAndIsrRequest (
        int ControllerIdField,
        int ControllerEpochField,
        long BrokerEpochField,
        sbyte TypeField,
        LeaderAndIsrRequest.LeaderAndIsrPartitionState[] UngroupedPartitionStatesField,
        LeaderAndIsrRequest.LeaderAndIsrTopicState[] TopicStatesField,
        LeaderAndIsrRequest.LeaderAndIsrLiveLeader[] LiveLeadersField
    )
    {
        public sealed record LeaderAndIsrTopicState (
            string TopicNameField,
            Guid TopicIdField,
            LeaderAndIsrRequest.LeaderAndIsrPartitionState[] PartitionStatesField
        );
        public sealed record LeaderAndIsrPartitionState (
            string TopicNameField,
            int PartitionIndexField,
            int ControllerEpochField,
            int LeaderField,
            int LeaderEpochField,
            int[] IsrField,
            int PartitionEpochField,
            int[] ReplicasField,
            int[] AddingReplicasField,
            int[] RemovingReplicasField,
            bool IsNewField,
            sbyte LeaderRecoveryStateField
        );
        public sealed record LeaderAndIsrLiveLeader (
            int BrokerIdField,
            string HostNameField,
            int PortField
        );
    };
}
