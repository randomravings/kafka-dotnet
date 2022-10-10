using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record TxnOffsetCommitRequest (
        string TransactionalIdField,
        string GroupIdField,
        long ProducerIdField,
        short ProducerEpochField,
        int GenerationIdField,
        string MemberIdField,
        string GroupInstanceIdField,
        TxnOffsetCommitRequest.TxnOffsetCommitRequestTopic[] TopicsField
    )
    {
        public sealed record TxnOffsetCommitRequestTopic (
            string NameField,
            TxnOffsetCommitRequest.TxnOffsetCommitRequestTopic.TxnOffsetCommitRequestPartition[] PartitionsField
        )
        {
            public sealed record TxnOffsetCommitRequestPartition (
                int PartitionIndexField,
                long CommittedOffsetField,
                int CommittedLeaderEpochField,
                string CommittedMetadataField
            );
        };
    };
}
