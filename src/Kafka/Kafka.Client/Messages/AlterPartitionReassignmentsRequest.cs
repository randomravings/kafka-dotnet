using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using ReassignableTopic = Kafka.Client.Messages.AlterPartitionReassignmentsRequest.ReassignableTopic;
using ReassignablePartition = Kafka.Client.Messages.AlterPartitionReassignmentsRequest.ReassignableTopic.ReassignablePartition;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TimeoutMsField">The time in ms to wait for the request to complete.</param>
    /// <param name="TopicsField">The topics to reassign.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterPartitionReassignmentsRequest (
        int TimeoutMsField,
        ImmutableArray<ReassignableTopic> TopicsField
    ) : Request(45,0,0,0)
    {
        public static AlterPartitionReassignmentsRequest Empty { get; } = new(
            default(int),
            ImmutableArray<ReassignableTopic>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">The partitions to reassign.</param>
        /// </summary>
        public sealed record ReassignableTopic (
            string NameField,
            ImmutableArray<ReassignablePartition> PartitionsField
        )
        {
            public static ReassignableTopic Empty { get; } = new(
                "",
                ImmutableArray<ReassignablePartition>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="ReplicasField">The replicas to place the partitions on, or null to cancel a pending reassignment for this partition.</param>
            /// </summary>
            public sealed record ReassignablePartition (
                int PartitionIndexField,
                ImmutableArray<int>? ReplicasField
            )
            {
                public static ReassignablePartition Empty { get; } = new(
                    default(int),
                    default(ImmutableArray<int>?)
                );
            };
        };
    };
}