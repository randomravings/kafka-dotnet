using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record LeaderAndIsrResponse (
        short ErrorCodeField,
        LeaderAndIsrResponse.LeaderAndIsrPartitionError[] PartitionErrorsField,
        LeaderAndIsrResponse.LeaderAndIsrTopicError[] TopicsField
    )
    {
        public sealed record LeaderAndIsrTopicError (
            Guid TopicIdField,
            LeaderAndIsrResponse.LeaderAndIsrPartitionError[] PartitionErrorsField
        );
        public sealed record LeaderAndIsrPartitionError (
            string TopicNameField,
            int PartitionIndexField,
            short ErrorCodeField
        );
    };
}
