using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using ListPartitionReassignmentsTopics = Kafka.Client.Messages.ListPartitionReassignmentsRequest.ListPartitionReassignmentsTopics;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TimeoutMsField">The time in ms to wait for the request to complete.</param>
    /// <param name="TopicsField">The topics to list partition reassignments for, or null to list everything.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ListPartitionReassignmentsRequest (
        int TimeoutMsField,
        ImmutableArray<ListPartitionReassignmentsTopics>? TopicsField
    ) : Request(46,0,0,0)
    {
        public static ListPartitionReassignmentsRequest Empty { get; } = new(
            default(int),
            default(ImmutableArray<ListPartitionReassignmentsTopics>?)
        );
        /// <summary>
        /// <param name="NameField">The topic name</param>
        /// <param name="PartitionIndexesField">The partitions to list partition reassignments for.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record ListPartitionReassignmentsTopics (
            string NameField,
            ImmutableArray<int> PartitionIndexesField
        )
        {
            public static ListPartitionReassignmentsTopics Empty { get; } = new(
                "",
                ImmutableArray<int>.Empty
            );
        };
    };
}