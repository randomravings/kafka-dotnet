using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="StateFiltersField">The transaction states to filter by: if empty, all transactions are returned; if non-empty, then only transactions matching one of the filtered states will be returned</param>
    /// <param name="ProducerIdFiltersField">The producerIds to filter by: if empty, all transactions will be returned; if non-empty, only transactions which match one of the filtered producerIds will be returned</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ListTransactionsRequest (
        ImmutableArray<string> StateFiltersField,
        ImmutableArray<long> ProducerIdFiltersField
    ) : Request(66)
    {
        public static ListTransactionsRequest Empty { get; } = new(
            ImmutableArray<string>.Empty,
            ImmutableArray<long>.Empty
        );
    };
}