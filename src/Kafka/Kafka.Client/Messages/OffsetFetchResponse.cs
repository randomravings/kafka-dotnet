using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetFetchResponse (
        int ThrottleTimeMsField,
        OffsetFetchResponse.OffsetFetchResponseTopic[] TopicsField,
        short ErrorCodeField,
        OffsetFetchResponse.OffsetFetchResponseGroup[] GroupsField
    )
    {
        public sealed record OffsetFetchResponseTopic (
            string NameField,
            OffsetFetchResponse.OffsetFetchResponseTopic.OffsetFetchResponsePartition[] PartitionsField
        )
        {
            public sealed record OffsetFetchResponsePartition (
                int PartitionIndexField,
                long CommittedOffsetField,
                int CommittedLeaderEpochField,
                string MetadataField,
                short ErrorCodeField
            );
        };
        public sealed record OffsetFetchResponseGroup (
            string groupIdField,
            OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics[] TopicsField,
            short ErrorCodeField
        )
        {
            public sealed record OffsetFetchResponseTopics (
                string NameField,
                OffsetFetchResponse.OffsetFetchResponseGroup.OffsetFetchResponseTopics.OffsetFetchResponsePartitions[] PartitionsField
            )
            {
                public sealed record OffsetFetchResponsePartitions (
                    int PartitionIndexField,
                    long CommittedOffsetField,
                    int CommittedLeaderEpochField,
                    string MetadataField,
                    short ErrorCodeField
                );
            };
        };
    };
}
