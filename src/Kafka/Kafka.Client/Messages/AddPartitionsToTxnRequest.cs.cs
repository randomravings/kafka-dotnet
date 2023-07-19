using AddPartitionsToTxnTopic = Kafka.Client.Messages.AddPartitionsToTxnRequest.AddPartitionsToTxnTopic;
using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TransactionalIdField">The transactional id corresponding to the transaction.</param>
    /// <param name="ProducerIdField">Current producer id in use by the transactional id.</param>
    /// <param name="ProducerEpochField">Current epoch associated with the producer id.</param>
    /// <param name="TopicsField">The partitions to add to the transaction.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AddPartitionsToTxnRequest (
        string TransactionalIdField,
        long ProducerIdField,
        short ProducerEpochField,
        ImmutableArray<AddPartitionsToTxnTopic> TopicsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : IRequest
    {
        public static AddPartitionsToTxnRequest Empty { get; } = new(
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
    };
}