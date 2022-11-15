using System.CodeDom.Compiler;
using System.Collections.Immutable;
using UpdateMetadataBroker = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataBroker;
using UpdateMetadataEndpoint = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataBroker.UpdateMetadataEndpoint;
using UpdateMetadataTopicState = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataTopicState;
using UpdateMetadataPartitionState = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataPartitionState;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ControllerIdField">The controller id.</param>
    /// <param name="ControllerEpochField">The controller epoch.</param>
    /// <param name="BrokerEpochField">The broker epoch.</param>
    /// <param name="UngroupedPartitionStatesField">In older versions of this RPC, each partition that we would like to update.</param>
    /// <param name="TopicStatesField">In newer versions of this RPC, each topic that we would like to update.</param>
    /// <param name="LiveBrokersField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record UpdateMetadataRequest (
        int ControllerIdField,
        int ControllerEpochField,
        long BrokerEpochField,
        ImmutableArray<UpdateMetadataPartitionState> UngroupedPartitionStatesField,
        ImmutableArray<UpdateMetadataTopicState> TopicStatesField,
        ImmutableArray<UpdateMetadataBroker> LiveBrokersField
    )
    {
        public static UpdateMetadataRequest Empty { get; } = new(
            default(int),
            default(int),
            default(long),
            ImmutableArray<UpdateMetadataPartitionState>.Empty,
            ImmutableArray<UpdateMetadataTopicState>.Empty,
            ImmutableArray<UpdateMetadataBroker>.Empty
        );
        /// <summary>
        /// <param name="IdField">The broker id.</param>
        /// <param name="V0HostField">The broker hostname.</param>
        /// <param name="V0PortField">The broker port.</param>
        /// <param name="EndpointsField">The broker endpoints.</param>
        /// <param name="RackField">The rack which this broker belongs to.</param>
        /// </summary>
        public sealed record UpdateMetadataBroker (
            int IdField,
            string V0HostField,
            int V0PortField,
            ImmutableArray<UpdateMetadataEndpoint> EndpointsField,
            string? RackField
        )
        {
            public static UpdateMetadataBroker Empty { get; } = new(
                default(int),
                "",
                default(int),
                ImmutableArray<UpdateMetadataEndpoint>.Empty,
                default(string?)
            );
            /// <summary>
            /// <param name="PortField">The port of this endpoint</param>
            /// <param name="HostField">The hostname of this endpoint</param>
            /// <param name="ListenerField">The listener name.</param>
            /// <param name="SecurityProtocolField">The security protocol type.</param>
            /// </summary>
            public sealed record UpdateMetadataEndpoint (
                int PortField,
                string HostField,
                string ListenerField,
                short SecurityProtocolField
            )
            {
                public static UpdateMetadataEndpoint Empty { get; } = new(
                    default(int),
                    "",
                    "",
                    default(short)
                );
            };
        };
        /// <summary>
        /// <param name="TopicNameField">The topic name.</param>
        /// <param name="TopicIdField">The topic id.</param>
        /// <param name="PartitionStatesField">The partition that we would like to update.</param>
        /// </summary>
        public sealed record UpdateMetadataTopicState (
            string TopicNameField,
            Guid TopicIdField,
            ImmutableArray<UpdateMetadataPartitionState> PartitionStatesField
        )
        {
            public static UpdateMetadataTopicState Empty { get; } = new(
                "",
                default(Guid),
                ImmutableArray<UpdateMetadataPartitionState>.Empty
            );
        };
        /// <summary>
        /// <param name="TopicNameField">In older versions of this RPC, the topic name.</param>
        /// <param name="PartitionIndexField">The partition index.</param>
        /// <param name="ControllerEpochField">The controller epoch.</param>
        /// <param name="LeaderField">The ID of the broker which is the current partition leader.</param>
        /// <param name="LeaderEpochField">The leader epoch of this partition.</param>
        /// <param name="IsrField">The brokers which are in the ISR for this partition.</param>
        /// <param name="ZkVersionField">The Zookeeper version.</param>
        /// <param name="ReplicasField">All the replicas of this partition.</param>
        /// <param name="OfflineReplicasField">The replicas of this partition which are offline.</param>
        /// </summary>
        public sealed record UpdateMetadataPartitionState (
            string TopicNameField,
            int PartitionIndexField,
            int ControllerEpochField,
            int LeaderField,
            int LeaderEpochField,
            ImmutableArray<int> IsrField,
            int ZkVersionField,
            ImmutableArray<int> ReplicasField,
            ImmutableArray<int> OfflineReplicasField
        )
        {
            public static UpdateMetadataPartitionState Empty { get; } = new(
                "",
                default(int),
                default(int),
                default(int),
                default(int),
                ImmutableArray<int>.Empty,
                default(int),
                ImmutableArray<int>.Empty,
                ImmutableArray<int>.Empty
            );
        };
    };
}