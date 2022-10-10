using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record MetadataResponse (
        int ThrottleTimeMsField,
        MetadataResponse.MetadataResponseBroker[] BrokersField,
        string ClusterIdField,
        int ControllerIdField,
        MetadataResponse.MetadataResponseTopic[] TopicsField,
        int ClusterAuthorizedOperationsField
    )
    {
        public sealed record MetadataResponseBroker (
            int NodeIdField,
            string HostField,
            int PortField,
            string RackField
        );
        public sealed record MetadataResponseTopic (
            short ErrorCodeField,
            string NameField,
            Guid TopicIdField,
            bool IsInternalField,
            MetadataResponse.MetadataResponseTopic.MetadataResponsePartition[] PartitionsField,
            int TopicAuthorizedOperationsField
        )
        {
            public sealed record MetadataResponsePartition (
                short ErrorCodeField,
                int PartitionIndexField,
                int LeaderIdField,
                int LeaderEpochField,
                int[] ReplicaNodesField,
                int[] IsrNodesField,
                int[] OfflineReplicasField
            );
        };
    };
}
