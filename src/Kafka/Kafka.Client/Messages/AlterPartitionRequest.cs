using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterPartitionRequest (
        int BrokerIdField,
        long BrokerEpochField,
        AlterPartitionRequest.TopicData[] TopicsField
    )
    {
        public sealed record TopicData (
            string TopicNameField,
            Guid TopicIdField,
            AlterPartitionRequest.TopicData.PartitionData[] PartitionsField
        )
        {
            public sealed record PartitionData (
                int PartitionIndexField,
                int LeaderEpochField,
                int[] NewIsrField,
                sbyte LeaderRecoveryStateField,
                int PartitionEpochField
            );
        };
    };
}
