using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ListOffsetsResponse (
        int ThrottleTimeMsField,
        ListOffsetsResponse.ListOffsetsTopicResponse[] TopicsField
    )
    {
        public sealed record ListOffsetsTopicResponse (
            string NameField,
            ListOffsetsResponse.ListOffsetsTopicResponse.ListOffsetsPartitionResponse[] PartitionsField
        )
        {
            public sealed record ListOffsetsPartitionResponse (
                int PartitionIndexField,
                short ErrorCodeField,
                long[] OldStyleOffsetsField,
                long TimestampField,
                long OffsetField,
                int LeaderEpochField
            );
        };
    };
}
