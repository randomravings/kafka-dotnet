using Kafka.Common.Model;
using MetadataResponseBroker = Kafka.Client.Messages.MetadataResponse.MetadataResponseBroker;
using MetadataResponsePartition = Kafka.Client.Messages.MetadataResponse.MetadataResponseTopic.MetadataResponsePartition;
using MetadataResponseTopic = Kafka.Client.Messages.MetadataResponse.MetadataResponseTopic;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="BrokersField">Each broker in the response.</param>
    /// <param name="ClusterIdField">The cluster ID that responding broker belongs to.</param>
    /// <param name="ControllerIdField">The ID of the controller broker.</param>
    /// <param name="TopicsField">Each topic in the response.</param>
    /// <param name="ClusterAuthorizedOperationsField">32-bit bitfield to represent authorized operations for this cluster.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record MetadataResponse (
        int ThrottleTimeMsField,
        ImmutableArray<MetadataResponseBroker> BrokersField,
        string? ClusterIdField,
        int ControllerIdField,
        ImmutableArray<MetadataResponseTopic> TopicsField,
        int ClusterAuthorizedOperationsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : IResponse
    {
        public static MetadataResponse Empty { get; } = new(
            default(int),
            ImmutableArray<MetadataResponseBroker>.Empty,
            default(string?),
            default(int),
            ImmutableArray<MetadataResponseTopic>.Empty,
            default(int),
            ImmutableArray<TaggedField>.Empty

        );
        /// <summary>
        /// <param name="NodeIdField">The broker ID.</param>
        /// <param name="HostField">The broker hostname.</param>
        /// <param name="PortField">The broker port.</param>
        /// <param name="RackField">The rack of the broker, or null if it has not been assigned to a rack.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record MetadataResponseBroker (
            int NodeIdField,
            string HostField,
            int PortField,
            string? RackField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static MetadataResponseBroker Empty { get; } = new(
                default(int),
                "",
                default(int),
                default(string?),
                ImmutableArray<TaggedField>.Empty

            );
        };
        /// <summary>
        /// <param name="ErrorCodeField">The topic error, or 0 if there was no error.</param>
        /// <param name="NameField">The topic name.</param>
        /// <param name="TopicIdField">The topic id.</param>
        /// <param name="IsInternalField">True if the topic is internal.</param>
        /// <param name="PartitionsField">Each partition in the topic.</param>
        /// <param name="TopicAuthorizedOperationsField">32-bit bitfield to represent authorized operations for this topic.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record MetadataResponseTopic (
            short ErrorCodeField,
            string? NameField,
            Guid TopicIdField,
            bool IsInternalField,
            ImmutableArray<MetadataResponsePartition> PartitionsField,
            int TopicAuthorizedOperationsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static MetadataResponseTopic Empty { get; } = new(
                default(short),
                default(string?),
                default(Guid),
                default(bool),
                ImmutableArray<MetadataResponsePartition>.Empty,
                default(int),
                ImmutableArray<TaggedField>.Empty

            );
            /// <summary>
            /// <param name="ErrorCodeField">The partition error, or 0 if there was no error.</param>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="LeaderIdField">The ID of the leader broker.</param>
            /// <param name="LeaderEpochField">The leader epoch of this partition.</param>
            /// <param name="ReplicaNodesField">The set of all nodes that host this partition.</param>
            /// <param name="IsrNodesField">The set of nodes that are in sync with the leader for this partition.</param>
            /// <param name="OfflineReplicasField">The set of offline replicas of this partition.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            public sealed record MetadataResponsePartition (
                short ErrorCodeField,
                int PartitionIndexField,
                int LeaderIdField,
                int LeaderEpochField,
                ImmutableArray<int> ReplicaNodesField,
                ImmutableArray<int> IsrNodesField,
                ImmutableArray<int> OfflineReplicasField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                public static MetadataResponsePartition Empty { get; } = new(
                    default(short),
                    default(int),
                    default(int),
                    default(int),
                    ImmutableArray<int>.Empty,
                    ImmutableArray<int>.Empty,
                    ImmutableArray<int>.Empty,
                    ImmutableArray<TaggedField>.Empty

                );
            };
        };
    };
}