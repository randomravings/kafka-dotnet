using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ElectLeadersRequest (
        sbyte ElectionTypeField,
        ElectLeadersRequest.TopicPartitions[] TopicPartitionsField,
        int TimeoutMsField
    )
    {
        public sealed record TopicPartitions (
            string TopicField,
            int[] PartitionsField
        );
    };
}
