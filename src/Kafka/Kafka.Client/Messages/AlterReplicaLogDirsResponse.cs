using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterReplicaLogDirsResponse (
        int ThrottleTimeMsField,
        AlterReplicaLogDirsResponse.AlterReplicaLogDirTopicResult[] ResultsField
    )
    {
        public sealed record AlterReplicaLogDirTopicResult (
            string TopicNameField,
            AlterReplicaLogDirsResponse.AlterReplicaLogDirTopicResult.AlterReplicaLogDirPartitionResult[] PartitionsField
        )
        {
            public sealed record AlterReplicaLogDirPartitionResult (
                int PartitionIndexField,
                short ErrorCodeField
            );
        };
    };
}
