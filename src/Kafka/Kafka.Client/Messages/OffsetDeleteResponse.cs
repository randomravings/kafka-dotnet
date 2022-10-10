using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetDeleteResponse (
        short ErrorCodeField,
        int ThrottleTimeMsField,
        OffsetDeleteResponse.OffsetDeleteResponseTopic[] TopicsField
    )
    {
        public sealed record OffsetDeleteResponseTopic (
            string NameField,
            OffsetDeleteResponse.OffsetDeleteResponseTopic.OffsetDeleteResponsePartition[] PartitionsField
        )
        {
            public sealed record OffsetDeleteResponsePartition (
                int PartitionIndexField,
                short ErrorCodeField
            );
        };
    };
}
