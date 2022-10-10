using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ListOffsetsRequest (
        int ReplicaIdField,
        sbyte IsolationLevelField,
        ListOffsetsRequest.ListOffsetsTopic[] TopicsField
    )
    {
        public sealed record ListOffsetsTopic (
            string NameField,
            ListOffsetsRequest.ListOffsetsTopic.ListOffsetsPartition[] PartitionsField
        )
        {
            public sealed record ListOffsetsPartition (
                int PartitionIndexField,
                int CurrentLeaderEpochField,
                long TimestampField,
                int MaxNumOffsetsField
            );
        };
    };
}
