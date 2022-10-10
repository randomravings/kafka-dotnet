using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ListTransactionsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string[] UnknownStateFiltersField,
        ListTransactionsResponse.TransactionState[] TransactionStatesField
    )
    {
        public sealed record TransactionState (
            string TransactionalIdField,
            long ProducerIdField,
            string TransactionStateField
        );
    };
}
