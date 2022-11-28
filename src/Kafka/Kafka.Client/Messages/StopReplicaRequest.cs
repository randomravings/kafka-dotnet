using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using StopReplicaPartitionState = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicState.StopReplicaPartitionState;
using StopReplicaPartitionV0 = Kafka.Client.Messages.StopReplicaRequest.StopReplicaPartitionV0;
using StopReplicaTopicV1 = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicV1;
using StopReplicaTopicState = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicState;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ControllerIdField">The controller id.</param>
    /// <param name="ControllerEpochField">The controller epoch.</param>
    /// <param name="BrokerEpochField">The broker epoch.</param>
    /// <param name="DeletePartitionsField">Whether these partitions should be deleted.</param>
    /// <param name="UngroupedPartitionsField">The partitions to stop.</param>
    /// <param name="TopicsField">The topics to stop.</param>
    /// <param name="TopicStatesField">Each topic.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record StopReplicaRequest (
        int ControllerIdField,
        int ControllerEpochField,
        long BrokerEpochField,
        bool DeletePartitionsField,
        ImmutableArray<StopReplicaPartitionV0> UngroupedPartitionsField,
        ImmutableArray<StopReplicaTopicV1> TopicsField,
        ImmutableArray<StopReplicaTopicState> TopicStatesField
    ) : Request(5)
    {
        public static StopReplicaRequest Empty { get; } = new(
            default(int),
            default(int),
            default(long),
            default(bool),
            ImmutableArray<StopReplicaPartitionV0>.Empty,
            ImmutableArray<StopReplicaTopicV1>.Empty,
            ImmutableArray<StopReplicaTopicState>.Empty
        );
        /// <summary>
        /// <param name="TopicNameField">The topic name.</param>
        /// <param name="PartitionIndexField">The partition index.</param>
        /// </summary>
        public sealed record StopReplicaPartitionV0 (
            string TopicNameField,
            int PartitionIndexField
        )
        {
            public static StopReplicaPartitionV0 Empty { get; } = new(
                "",
                default(int)
            );
        };
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionIndexesField">The partition indexes.</param>
        /// </summary>
        public sealed record StopReplicaTopicV1 (
            string NameField,
            ImmutableArray<int> PartitionIndexesField
        )
        {
            public static StopReplicaTopicV1 Empty { get; } = new(
                "",
                ImmutableArray<int>.Empty
            );
        };
        /// <summary>
        /// <param name="TopicNameField">The topic name.</param>
        /// <param name="PartitionStatesField">The state of each partition</param>
        /// </summary>
        public sealed record StopReplicaTopicState (
            string TopicNameField,
            ImmutableArray<StopReplicaPartitionState> PartitionStatesField
        )
        {
            public static StopReplicaTopicState Empty { get; } = new(
                "",
                ImmutableArray<StopReplicaPartitionState>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="LeaderEpochField">The leader epoch.</param>
            /// <param name="DeletePartitionField">Whether this partition should be deleted.</param>
            /// </summary>
            public sealed record StopReplicaPartitionState (
                int PartitionIndexField,
                int LeaderEpochField,
                bool DeletePartitionField
            )
            {
                public static StopReplicaPartitionState Empty { get; } = new(
                    default(int),
                    default(int),
                    default(bool)
                );
            };
        };
    };
}