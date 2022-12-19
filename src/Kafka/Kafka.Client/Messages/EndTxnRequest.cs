using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TransactionalIdField">The ID of the transaction to end.</param>
    /// <param name="ProducerIdField">The producer ID.</param>
    /// <param name="ProducerEpochField">The current epoch associated with the producer.</param>
    /// <param name="CommittedField">True if the transaction was committed, false if it was aborted.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record EndTxnRequest (
        string TransactionalIdField,
        long ProducerIdField,
        short ProducerEpochField,
        bool CommittedField
    ) : Request(26)
    {
        public static EndTxnRequest Empty { get; } = new(
            "",
            default(long),
            default(short),
            default(bool)
        );
        public static short FlexibleVersion { get; } = 3;
    };
}