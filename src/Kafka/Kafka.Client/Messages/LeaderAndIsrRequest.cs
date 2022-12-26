using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using LeaderAndIsrTopicState = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrTopicState;
using LeaderAndIsrLiveLeader = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrLiveLeader;
using LeaderAndIsrPartitionState = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrPartitionState;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ControllerIdField">The current controller ID.</param>
    /// <param name="KRaftControllerIdField">The KRaft controller id, used during migration. See KIP-866</param>
    /// <param name="ControllerEpochField">The current controller epoch.</param>
    /// <param name="BrokerEpochField">The current broker epoch.</param>
    /// <param name="TypeField">The type that indicates whether all topics are included in the request</param>
    /// <param name="UngroupedPartitionStatesField">The state of each partition, in a v0 or v1 message.</param>
    /// <param name="TopicStatesField">Each topic.</param>
    /// <param name="LiveLeadersField">The current live leaders.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record LeaderAndIsrRequest (
        int ControllerIdField,
        int KRaftControllerIdField,
        int ControllerEpochField,
        long BrokerEpochField,
        sbyte TypeField,
        ImmutableArray<LeaderAndIsrPartitionState> UngroupedPartitionStatesField,
        ImmutableArray<LeaderAndIsrTopicState> TopicStatesField,
        ImmutableArray<LeaderAndIsrLiveLeader> LiveLeadersField
    ) : Request(4,0,7,4)
    {
        public static LeaderAndIsrRequest Empty { get; } = new(
            default(int),
            default(int),
            default(int),
            default(long),
            default(sbyte),
            ImmutableArray<LeaderAndIsrPartitionState>.Empty,
            ImmutableArray<LeaderAndIsrTopicState>.Empty,
            ImmutableArray<LeaderAndIsrLiveLeader>.Empty
        );
        /// <summary>
        /// <param name="TopicNameField">The topic name.</param>
        /// <param name="TopicIdField">The unique topic ID.</param>
        /// <param name="PartitionStatesField">The state of each partition</param>
        /// </summary>
        public sealed record LeaderAndIsrTopicState (
            string TopicNameField,
            Guid TopicIdField,
            ImmutableArray<LeaderAndIsrPartitionState> PartitionStatesField
        )
        {
            public static LeaderAndIsrTopicState Empty { get; } = new(
                "",
                default(Guid),
                ImmutableArray<LeaderAndIsrPartitionState>.Empty
            );
        };
        /// <summary>
        /// <param name="BrokerIdField">The leader's broker ID.</param>
        /// <param name="HostNameField">The leader's hostname.</param>
        /// <param name="PortField">The leader's port.</param>
        /// </summary>
        public sealed record LeaderAndIsrLiveLeader (
            int BrokerIdField,
            string HostNameField,
            int PortField
        )
        {
            public static LeaderAndIsrLiveLeader Empty { get; } = new(
                default(int),
                "",
                default(int)
            );
        };
        /// <summary>
        /// <param name="TopicNameField">The topic name.  This is only present in v0 or v1.</param>
        /// <param name="PartitionIndexField">The partition index.</param>
        /// <param name="ControllerEpochField">The controller epoch.</param>
        /// <param name="LeaderField">The broker ID of the leader.</param>
        /// <param name="LeaderEpochField">The leader epoch.</param>
        /// <param name="IsrField">The in-sync replica IDs.</param>
        /// <param name="PartitionEpochField">The current epoch for the partition. The epoch is a monotonically increasing value which is incremented after every partition change. (Since the LeaderAndIsr request is only used by the legacy controller, this corresponds to the zkVersion)</param>
        /// <param name="ReplicasField">The replica IDs.</param>
        /// <param name="AddingReplicasField">The replica IDs that we are adding this partition to, or null if no replicas are being added.</param>
        /// <param name="RemovingReplicasField">The replica IDs that we are removing this partition from, or null if no replicas are being removed.</param>
        /// <param name="IsNewField">Whether the replica should have existed on the broker or not.</param>
        /// <param name="LeaderRecoveryStateField">1 if the partition is recovering from an unclean leader election; 0 otherwise.</param>
        /// </summary>
        public sealed record LeaderAndIsrPartitionState (
            string TopicNameField,
            int PartitionIndexField,
            int ControllerEpochField,
            int LeaderField,
            int LeaderEpochField,
            ImmutableArray<int> IsrField,
            int PartitionEpochField,
            ImmutableArray<int> ReplicasField,
            ImmutableArray<int> AddingReplicasField,
            ImmutableArray<int> RemovingReplicasField,
            bool IsNewField,
            sbyte LeaderRecoveryStateField
        )
        {
            public static LeaderAndIsrPartitionState Empty { get; } = new(
                "",
                default(int),
                default(int),
                default(int),
                default(int),
                ImmutableArray<int>.Empty,
                default(int),
                ImmutableArray<int>.Empty,
                ImmutableArray<int>.Empty,
                ImmutableArray<int>.Empty,
                default(bool),
                default(sbyte)
            );
        };
    };
}