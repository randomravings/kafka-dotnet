using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using CreatePartitionsAssignment = Kafka.Client.Messages.CreatePartitionsRequest.CreatePartitionsTopic.CreatePartitionsAssignment;
using CreatePartitionsTopic = Kafka.Client.Messages.CreatePartitionsRequest.CreatePartitionsTopic;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TopicsField">Each topic that we want to create new partitions inside.</param>
    /// <param name="TimeoutMsField">The time in ms to wait for the partitions to be created.</param>
    /// <param name="ValidateOnlyField">If true, then validate the request, but don't actually increase the number of partitions.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreatePartitionsRequest (
        ImmutableArray<CreatePartitionsTopic> TopicsField,
        int TimeoutMsField,
        bool ValidateOnlyField
    ) : Request(37,0,3,2)
    {
        public static CreatePartitionsRequest Empty { get; } = new(
            ImmutableArray<CreatePartitionsTopic>.Empty,
            default(int),
            default(bool)
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="CountField">The new partition count.</param>
        /// <param name="AssignmentsField">The new partition assignments.</param>
        /// </summary>
        public sealed record CreatePartitionsTopic (
            string NameField,
            int CountField,
            ImmutableArray<CreatePartitionsAssignment>? AssignmentsField
        )
        {
            public static CreatePartitionsTopic Empty { get; } = new(
                "",
                default(int),
                default(ImmutableArray<CreatePartitionsAssignment>?)
            );
            /// <summary>
            /// <param name="BrokerIdsField">The assigned broker IDs.</param>
            /// </summary>
            public sealed record CreatePartitionsAssignment (
                ImmutableArray<int> BrokerIdsField
            )
            {
                public static CreatePartitionsAssignment Empty { get; } = new(
                    ImmutableArray<int>.Empty
                );
            };
        };
    };
}