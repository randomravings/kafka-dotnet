using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AddPartitionsToTxnResponse (
        int ThrottleTimeMsField,
        AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult[] ResultsField
    )
    {
        public sealed record AddPartitionsToTxnTopicResult (
            string NameField,
            AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult.AddPartitionsToTxnPartitionResult[] ResultsField
        )
        {
            public sealed record AddPartitionsToTxnPartitionResult (
                int PartitionIndexField,
                short ErrorCodeField
            );
        };
    };
}
