using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using AddPartitionsToTxnTopic = Kafka.Client.Messages.AddPartitionsToTxnRequestData.AddPartitionsToTxnTopic;
using AddPartitionsToTxnTransaction = Kafka.Client.Messages.AddPartitionsToTxnRequestData.AddPartitionsToTxnTransaction;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="TransactionsField">List of transactions to add partitions to.</param>
    /// <param name="V3AndBelowTransactionalIdField">The transactional id corresponding to the transaction.</param>
    /// <param name="V3AndBelowProducerIdField">Current producer id in use by the transactional id.</param>
    /// <param name="V3AndBelowProducerEpochField">Current epoch associated with the producer id.</param>
    /// <param name="V3AndBelowTopicsField">The partitions to add to the transaction.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AddPartitionsToTxnRequestData (
        ImmutableArray<AddPartitionsToTxnTransaction> TransactionsField,
        string V3AndBelowTransactionalIdField,
        long V3AndBelowProducerIdField,
        short V3AndBelowProducerEpochField,
        ImmutableArray<AddPartitionsToTxnTopic> V3AndBelowTopicsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        public static AddPartitionsToTxnRequestData Empty { get; } = new(
            ImmutableArray<AddPartitionsToTxnTransaction>.Empty,
            "",
            default(long),
            default(short),
            ImmutableArray<AddPartitionsToTxnTopic>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="NameField">The name of the topic.</param>
        /// <param name="PartitionsField">The partition indexes to add to the transaction</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record AddPartitionsToTxnTopic (
            string NameField,
            ImmutableArray<int> PartitionsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static AddPartitionsToTxnTopic Empty { get; } = new(
                "",
                ImmutableArray<int>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
        };
        /// <summary>
        /// <param name="TransactionalIdField">The transactional id corresponding to the transaction.</param>
        /// <param name="ProducerIdField">Current producer id in use by the transactional id.</param>
        /// <param name="ProducerEpochField">Current epoch associated with the producer id.</param>
        /// <param name="VerifyOnlyField">Boolean to signify if we want to check if the partition is in the transaction rather than add it.</param>
        /// <param name="TopicsField">The partitions to add to the transaction.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record AddPartitionsToTxnTransaction (
            string TransactionalIdField,
            long ProducerIdField,
            short ProducerEpochField,
            bool VerifyOnlyField,
            ImmutableArray<AddPartitionsToTxnTopic> TopicsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static AddPartitionsToTxnTransaction Empty { get; } = new(
                "",
                default(long),
                default(short),
                default(bool),
                ImmutableArray<AddPartitionsToTxnTopic>.Empty,
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
