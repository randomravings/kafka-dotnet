using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record StopReplicaResponse (
        short ErrorCodeField,
        StopReplicaResponse.StopReplicaPartitionError[] PartitionErrorsField
    )
    {
        public sealed record StopReplicaPartitionError (
            string TopicNameField,
            int PartitionIndexField,
            short ErrorCodeField
        );
    };
}
