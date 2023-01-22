using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using CreatableTopic = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic;
using CreateableTopicConfig = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic.CreateableTopicConfig;
using CreatableReplicaAssignment = Kafka.Client.Messages.CreateTopicsRequest.CreatableTopic.CreatableReplicaAssignment;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TopicsField">The topics to create.</param>
    /// <param name="TimeoutMsField">How long to wait in milliseconds before timing out the request.</param>
    /// <param name="ValidateOnlyField">If true, check that the topics can be created as specified, but don't create anything.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreateTopicsRequest (
        ImmutableArray<CreatableTopic> TopicsField,
        int TimeoutMsField,
        bool ValidateOnlyField
    ) : Request(19,0,7,5)
    {
        public static CreateTopicsRequest Empty { get; } = new(
            ImmutableArray<CreatableTopic>.Empty,
            default(int),
            default(bool)
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="NumPartitionsField">The number of partitions to create in the topic, or -1 if we are either specifying a manual partition assignment or using the default partitions.</param>
        /// <param name="ReplicationFactorField">The number of replicas to create for each partition in the topic, or -1 if we are either specifying a manual partition assignment or using the default replication factor.</param>
        /// <param name="AssignmentsField">The manual partition assignment, or the empty array if we are using automatic assignment.</param>
        /// <param name="ConfigsField">The custom topic configurations to set.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record CreatableTopic (
            string NameField,
            int NumPartitionsField,
            short ReplicationFactorField,
            ImmutableArray<CreatableReplicaAssignment> AssignmentsField,
            ImmutableArray<CreateableTopicConfig> ConfigsField
        )
        {
            public static CreatableTopic Empty { get; } = new(
                "",
                default(int),
                default(short),
                ImmutableArray<CreatableReplicaAssignment>.Empty,
                ImmutableArray<CreateableTopicConfig>.Empty
            );
            /// <summary>
            /// <param name="NameField">The configuration name.</param>
            /// <param name="ValueField">The configuration value.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            public sealed record CreateableTopicConfig (
                string NameField,
                string? ValueField
            )
            {
                public static CreateableTopicConfig Empty { get; } = new(
                    "",
                    default(string?)
                );
            };
            /// <summary>
            /// <param name="PartitionIndexField">The partition index.</param>
            /// <param name="BrokerIdsField">The brokers to place the partition on.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            public sealed record CreatableReplicaAssignment (
                int PartitionIndexField,
                ImmutableArray<int> BrokerIdsField
            )
            {
                public static CreatableReplicaAssignment Empty { get; } = new(
                    default(int),
                    ImmutableArray<int>.Empty
                );
            };
        };
    };
}