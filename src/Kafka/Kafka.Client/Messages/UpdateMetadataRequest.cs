using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record UpdateMetadataRequest (
        int ControllerIdField,
        int ControllerEpochField,
        long BrokerEpochField,
        UpdateMetadataRequest.UpdateMetadataPartitionState[] UngroupedPartitionStatesField,
        UpdateMetadataRequest.UpdateMetadataTopicState[] TopicStatesField,
        UpdateMetadataRequest.UpdateMetadataBroker[] LiveBrokersField
    )
    {
        public sealed record UpdateMetadataPartitionState (
            string TopicNameField,
            int PartitionIndexField,
            int ControllerEpochField,
            int LeaderField,
            int LeaderEpochField,
            int[] IsrField,
            int ZkVersionField,
            int[] ReplicasField,
            int[] OfflineReplicasField
        );
        public sealed record UpdateMetadataBroker (
            int IdField,
            string V0HostField,
            int V0PortField,
            UpdateMetadataRequest.UpdateMetadataBroker.UpdateMetadataEndpoint[] EndpointsField,
            string RackField
        )
        {
            public sealed record UpdateMetadataEndpoint (
                int PortField,
                string HostField,
                string ListenerField,
                short SecurityProtocolField
            );
        };
        public sealed record UpdateMetadataTopicState (
            string TopicNameField,
            Guid TopicIdField,
            UpdateMetadataRequest.UpdateMetadataPartitionState[] PartitionStatesField
        );
    };
}
