using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetCommitResponse (
        int ThrottleTimeMsField,
        OffsetCommitResponse.OffsetCommitResponseTopic[] TopicsField
    )
    {
        public sealed record OffsetCommitResponseTopic (
            string NameField,
            OffsetCommitResponse.OffsetCommitResponseTopic.OffsetCommitResponsePartition[] PartitionsField
        )
        {
            public sealed record OffsetCommitResponsePartition (
                int PartitionIndexField,
                short ErrorCodeField
            );
        };
    };
}
