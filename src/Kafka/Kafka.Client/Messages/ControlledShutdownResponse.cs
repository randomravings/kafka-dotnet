using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ControlledShutdownResponse (
        short ErrorCodeField,
        ControlledShutdownResponse.RemainingPartition[] RemainingPartitionsField
    )
    {
        public sealed record RemainingPartition (
            string TopicNameField,
            int PartitionIndexField
        );
    };
}
