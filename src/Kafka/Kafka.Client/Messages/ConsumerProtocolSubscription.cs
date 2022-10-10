using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ConsumerProtocolSubscription (
        string[] TopicsField,
        byte[] UserDataField,
        ConsumerProtocolSubscription.TopicPartition[] OwnedPartitionsField
    )
    {
        public sealed record TopicPartition (
            string TopicField,
            int[] PartitionsField
        );
    };
}
