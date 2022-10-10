using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AddPartitionsToTxnRequest (
        string TransactionalIdField,
        long ProducerIdField,
        short ProducerEpochField,
        AddPartitionsToTxnRequest.AddPartitionsToTxnTopic[] TopicsField
    )
    {
        public sealed record AddPartitionsToTxnTopic (
            string NameField,
            int[] PartitionsField
        );
    };
}
