using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record InitProducerIdRequest (
        string TransactionalIdField,
        int TransactionTimeoutMsField,
        long ProducerIdField,
        short ProducerEpochField
    );
}
