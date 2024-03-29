using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="TransactionalIdField">The ID of the transaction to end.</param>
    /// <param name="ProducerIdField">The producer ID.</param>
    /// <param name="ProducerEpochField">The current epoch associated with the producer.</param>
    /// <param name="CommittedField">True if the transaction was committed, false if it was aborted.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record EndTxnRequestData (
        string TransactionalIdField,
        long ProducerIdField,
        short ProducerEpochField,
        bool CommittedField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static EndTxnRequestData Empty { get; } = new(
            "",
            default(long),
            default(short),
            default(bool),
            ImmutableArray<TaggedField>.Empty
        );
    };
}
