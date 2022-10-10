using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetCommitRequest (
        string GroupIdField,
        int GenerationIdField,
        string MemberIdField,
        string GroupInstanceIdField,
        long RetentionTimeMsField,
        OffsetCommitRequest.OffsetCommitRequestTopic[] TopicsField
    )
    {
        public sealed record OffsetCommitRequestTopic (
            string NameField,
            OffsetCommitRequest.OffsetCommitRequestTopic.OffsetCommitRequestPartition[] PartitionsField
        )
        {
            public sealed record OffsetCommitRequestPartition (
                int PartitionIndexField,
                long CommittedOffsetField,
                int CommittedLeaderEpochField,
                long CommitTimestampField,
                string CommittedMetadataField
            );
        };
    };
}
