using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TransactionalIdField">The transactional id corresponding to the transaction.</param>
    /// <param name="ProducerIdField">Current producer id in use by the transactional id.</param>
    /// <param name="ProducerEpochField">Current epoch associated with the producer id.</param>
    /// <param name="GroupIdField">The unique group identifier.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AddOffsetsToTxnRequest (
        string TransactionalIdField,
        long ProducerIdField,
        short ProducerEpochField,
        string GroupIdField
    ) : Request(25)
    {
        public static AddOffsetsToTxnRequest Empty { get; } = new(
            "",
            default(long),
            default(short),
            ""
        );
    };
}