using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="TransactionalIdsField">Array of transactionalIds to include in describe results. If empty, then no results will be returned.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeTransactionsRequest (
        ImmutableArray<string> TransactionalIdsField
    ) : Request(65)
    {
        public static DescribeTransactionsRequest Empty { get; } = new(
            ImmutableArray<string>.Empty
        );
    };
}