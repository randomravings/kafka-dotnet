using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterPartitionResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        AlterPartitionResponse.TopicData[] TopicsField
    )
    {
        public sealed record TopicData (
            string TopicNameField,
            Guid TopicIdField,
            AlterPartitionResponse.TopicData.PartitionData[] PartitionsField
        )
        {
            public sealed record PartitionData (
                int PartitionIndexField,
                short ErrorCodeField,
                int LeaderIdField,
                int LeaderEpochField,
                int[] IsrField,
                sbyte LeaderRecoveryStateField,
                int PartitionEpochField
            );
        };
    };
}
