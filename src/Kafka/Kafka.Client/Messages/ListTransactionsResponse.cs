using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using TransactionState = Kafka.Client.Messages.ListTransactionsResponse.TransactionState;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField"></param>
    /// <param name="UnknownStateFiltersField">Set of state filters provided in the request which were unknown to the transaction coordinator</param>
    /// <param name="TransactionStatesField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ListTransactionsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        ImmutableArray<string> UnknownStateFiltersField,
        ImmutableArray<TransactionState> TransactionStatesField
    ) : Response(66)
    {
        public static ListTransactionsResponse Empty { get; } = new(
            default(int),
            default(short),
            ImmutableArray<string>.Empty,
            ImmutableArray<TransactionState>.Empty
        );
        /// <summary>
        /// <param name="TransactionalIdField"></param>
        /// <param name="ProducerIdField"></param>
        /// <param name="TransactionStateField">The current transaction state of the producer</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record TransactionState (
            string TransactionalIdField,
            long ProducerIdField,
            string TransactionStateField
        )
        {
            public static TransactionState Empty { get; } = new(
                "",
                default(long),
                ""
            );
        };
    };
}