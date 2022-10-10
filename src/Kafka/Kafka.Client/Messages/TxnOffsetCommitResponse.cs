using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record TxnOffsetCommitResponse (
        int ThrottleTimeMsField,
        TxnOffsetCommitResponse.TxnOffsetCommitResponseTopic[] TopicsField
    )
    {
        public sealed record TxnOffsetCommitResponseTopic (
            string NameField,
            TxnOffsetCommitResponse.TxnOffsetCommitResponseTopic.TxnOffsetCommitResponsePartition[] PartitionsField
        )
        {
            public sealed record TxnOffsetCommitResponsePartition (
                int PartitionIndexField,
                short ErrorCodeField
            );
        };
    };
}
