using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record FetchRequest (
        string ClusterIdField,
        int ReplicaIdField,
        int MaxWaitMsField,
        int MinBytesField,
        int MaxBytesField,
        sbyte IsolationLevelField,
        int SessionIdField,
        int SessionEpochField,
        FetchRequest.FetchTopic[] TopicsField,
        FetchRequest.ForgottenTopic[] ForgottenTopicsDataField,
        string RackIdField
    )
    {
        public sealed record ForgottenTopic (
            string TopicField,
            Guid TopicIdField,
            int[] PartitionsField
        );
        public sealed record FetchTopic (
            string TopicField,
            Guid TopicIdField,
            FetchRequest.FetchTopic.FetchPartition[] PartitionsField
        )
        {
            public sealed record FetchPartition (
                int PartitionField,
                int CurrentLeaderEpochField,
                long FetchOffsetField,
                int LastFetchedEpochField,
                long LogStartOffsetField,
                int PartitionMaxBytesField
            );
        };
    };
}
