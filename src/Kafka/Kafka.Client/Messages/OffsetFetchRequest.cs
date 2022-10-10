using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record OffsetFetchRequest (
        string GroupIdField,
        OffsetFetchRequest.OffsetFetchRequestTopic[] TopicsField,
        OffsetFetchRequest.OffsetFetchRequestGroup[] GroupsField,
        bool RequireStableField
    )
    {
        public sealed record OffsetFetchRequestTopic (
            string NameField,
            int[] PartitionIndexesField
        );
        public sealed record OffsetFetchRequestGroup (
            string groupIdField,
            OffsetFetchRequest.OffsetFetchRequestGroup.OffsetFetchRequestTopics[] TopicsField
        )
        {
            public sealed record OffsetFetchRequestTopics (
                string NameField,
                int[] PartitionIndexesField
            );
        };
    };
}
