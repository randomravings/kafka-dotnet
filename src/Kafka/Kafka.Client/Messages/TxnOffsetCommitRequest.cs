using System.CodeDom.Compiler;
using System.Collections.Immutable;
using TxnOffsetCommitRequestTopic = Kafka.Client.Messages.TxnOffsetCommitRequest.TxnOffsetCommitRequestTopic;
using TxnOffsetCommitRequestPartition = Kafka.Client.Messages.TxnOffsetCommitRequest.TxnOffsetCommitRequestTopic.TxnOffsetCommitRequestPartition;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TransactionalIdField">The ID of the transaction.</param>
    /// <param name="GroupIdField">The ID of the group.</param>
    /// <param name="ProducerIdField">The current producer ID in use by the transactional ID.</param>
    /// <param name="ProducerEpochField">The current epoch associated with the producer ID.</param>
    /// <param name="GenerationIdField">The generation of the consumer.</param>
    /// <param name="MemberIdField">The member ID assigned by the group coordinator.</param>
    /// <param name="GroupInstanceIdField">The unique identifier of the consumer instance provided by end user.</param>
    /// <param name="TopicsField">Each topic that we want to commit offsets for.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record TxnOffsetCommitRequest (
        string TransactionalIdField,
        string GroupIdField,
        long ProducerIdField,
        short ProducerEpochField,
        int GenerationIdField,
        string MemberIdField,
        string? GroupInstanceIdField,
        ImmutableArray<TxnOffsetCommitRequestTopic> TopicsField
    )
    {
        public static TxnOffsetCommitRequest Empty { get; } = new(
            "",
            "",
            default(long),
            default(short),
            default(int),
            "",
            default(string?),
            ImmutableArray<TxnOffsetCommitRequestTopic>.Empty
        );
        /// <summary>
        /// <param name="NameField">The topic name.</param>
        /// <param name="PartitionsField">The partitions inside the topic that we want to committ offsets for.</param>
        /// </summary>
        public sealed record TxnOffsetCommitRequestTopic (
            string NameField,
            ImmutableArray<TxnOffsetCommitRequestPartition> PartitionsField
        )
        {
            public static TxnOffsetCommitRequestTopic Empty { get; } = new(
                "",
                ImmutableArray<TxnOffsetCommitRequestPartition>.Empty
            );
            /// <summary>
            /// <param name="PartitionIndexField">The index of the partition within the topic.</param>
            /// <param name="CommittedOffsetField">The message offset to be committed.</param>
            /// <param name="CommittedLeaderEpochField">The leader epoch of the last consumed record.</param>
            /// <param name="CommittedMetadataField">Any associated metadata the client wants to keep.</param>
            /// </summary>
            public sealed record TxnOffsetCommitRequestPartition (
                int PartitionIndexField,
                long CommittedOffsetField,
                int CommittedLeaderEpochField,
                string? CommittedMetadataField
            )
            {
                public static TxnOffsetCommitRequestPartition Empty { get; } = new(
                    default(int),
                    default(long),
                    default(int),
                    default(string?)
                );
            };
        };
    };
}