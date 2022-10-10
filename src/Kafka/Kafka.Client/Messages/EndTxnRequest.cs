using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record EndTxnRequest (
        string TransactionalIdField,
        long ProducerIdField,
        short ProducerEpochField,
        bool CommittedField
    );
}
