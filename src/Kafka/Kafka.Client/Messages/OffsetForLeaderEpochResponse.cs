using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetForLeaderEpochResponse (
        int ThrottleTimeMsField,
        OffsetForLeaderEpochResponse.OffsetForLeaderTopicResult[] TopicsField
    )
    {
        public sealed record OffsetForLeaderTopicResult (
            string TopicField,
            OffsetForLeaderEpochResponse.OffsetForLeaderTopicResult.EpochEndOffset[] PartitionsField
        )
        {
            public sealed record EpochEndOffset (
                short ErrorCodeField,
                int PartitionField,
                int LeaderEpochField,
                long EndOffsetField
            );
        };
    };
}
