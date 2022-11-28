using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using OngoingPartitionReassignment = Kafka.Client.Messages.ListPartitionReassignmentsResponse.OngoingTopicReassignment.OngoingPartitionReassignment;
using OngoingTopicReassignment = Kafka.Client.Messages.ListPartitionReassignmentsResponse.OngoingTopicReassignment;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The top-level error code, or 0 if there was no error</param>
    /// <param name="ErrorMessageField">The top-level error message, or null if there was no error.</param>
    /// <param name="TopicsField">The ongoing reassignments for each topic.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ListPartitionReassignmentsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string? ErrorMessageField,
        ImmutableArray<OngoingTopicReassignment> TopicsField
    ) : Response(46)
    {
        public static ListPartitionReassignmentsResponse Empty { get; } = new(
            default(int),
            default(short),
            default(string?),
            ImmutableArray<OngoingTopicReassignment>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">The ongoing reassignments for each partition.</param>
        /// </summary>
        public sealed record OngoingTopicReassignment (
            string NameField,
            ImmutableArray<OngoingPartitionReassignment> PartitionsField
        )
        {
            public static OngoingTopicReassignment Empty { get; } = new(
                "",
                ImmutableArray<OngoingPartitionReassignment>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The index of the partition.</param>
            /// <param name="ReplicasField">The current replica set.</param>
            /// <param name="AddingReplicasField">The set of replicas we are currently adding.</param>
            /// <param name="RemovingReplicasField">The set of replicas we are currently removing.</param>
            /// </summary>
            public sealed record OngoingPartitionReassignment (
                int PartitionIndexField,
                ImmutableArray<int> ReplicasField,
                ImmutableArray<int> AddingReplicasField,
                ImmutableArray<int> RemovingReplicasField
            )
            {
                public static OngoingPartitionReassignment Empty { get; } = new(
                    default(int),
                    ImmutableArray<int>.Empty,
                    ImmutableArray<int>.Empty,
                    ImmutableArray<int>.Empty
                );
            };
        };
    };
}