using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeTransactionsResponse (
        int ThrottleTimeMsField,
        DescribeTransactionsResponse.TransactionState[] TransactionStatesField
    )
    {
        public sealed record TransactionState (
            short ErrorCodeField,
            string TransactionalIdField,
            string TransactionStateField,
            int TransactionTimeoutMsField,
            long TransactionStartTimeMsField,
            long ProducerIdField,
            short ProducerEpochField,
            DescribeTransactionsResponse.TransactionState.TopicData[] TopicsField
        )
        {
            public sealed record TopicData (
                string TopicField,
                int[] PartitionsField
            );
        };
    };
}
