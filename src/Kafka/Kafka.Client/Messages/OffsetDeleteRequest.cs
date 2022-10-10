using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetDeleteRequest (
        string GroupIdField,
        OffsetDeleteRequest.OffsetDeleteRequestTopic[] TopicsField
    )
    {
        public sealed record OffsetDeleteRequestTopic (
            string NameField,
            OffsetDeleteRequest.OffsetDeleteRequestTopic.OffsetDeleteRequestPartition[] PartitionsField
        )
        {
            public sealed record OffsetDeleteRequestPartition (
                int PartitionIndexField
            );
        };
    };
}
