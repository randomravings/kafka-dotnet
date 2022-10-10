using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ConsumerProtocolAssignment (
        ConsumerProtocolAssignment.TopicPartition[] AssignedPartitionsField,
        byte[] UserDataField
    )
    {
        public sealed record TopicPartition (
            string TopicField,
            int[] PartitionsField
        );
    };
}
