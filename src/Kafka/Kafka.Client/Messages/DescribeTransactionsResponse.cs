using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using TopicData = Kafka.Client.Messages.DescribeTransactionsResponse.TransactionState.TopicData;
using TransactionState = Kafka.Client.Messages.DescribeTransactionsResponse.TransactionState;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="TransactionStatesField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeTransactionsResponse (
        int ThrottleTimeMsField,
        ImmutableArray<TransactionState> TransactionStatesField
    ) : Response(65)
    {
        public static DescribeTransactionsResponse Empty { get; } = new(
            default(int),
            ImmutableArray<TransactionState>.Empty
        );
        public static short FlexibleVersion { get; } = 0;
        /// <summary>
        /// <param name="ErrorCodeField"></param>
        /// <param name="TransactionalIdField"></param>
        /// <param name="TransactionStateField"></param>
        /// <param name="TransactionTimeoutMsField"></param>
        /// <param name="TransactionStartTimeMsField"></param>
        /// <param name="ProducerIdField"></param>
        /// <param name="ProducerEpochField"></param>
        /// <param name="TopicsField">The set of partitions included in the current transaction (if active). When a transaction is preparing to commit or abort, this will include only partitions which do not have markers.</param>
        /// </summary>
        public sealed record TransactionState (
            short ErrorCodeField,
            string TransactionalIdField,
            string TransactionStateField,
            int TransactionTimeoutMsField,
            long TransactionStartTimeMsField,
            long ProducerIdField,
            short ProducerEpochField,
            ImmutableArray<TopicData> TopicsField
        )
        {
            public static TransactionState Empty { get; } = new(
                default(short),
                "",
                "",
                default(int),
                default(long),
                default(long),
                default(short),
                ImmutableArray<TopicData>.Empty
            );
            /// <summary>
            /// <param name="TopicField"></param>
            /// <param name="PartitionsField"></param>
            /// </summary>
            public sealed record TopicData (
                string TopicField,
                ImmutableArray<int> PartitionsField
            )
            {
                public static TopicData Empty { get; } = new(
                    "",
                    ImmutableArray<int>.Empty
                );
            };
        };
    };
}