using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteTopicsRequest (
        DeleteTopicsRequest.DeleteTopicState[] TopicsField,
        string[] TopicNamesField,
        int TimeoutMsField
    )
    {
        public sealed record DeleteTopicState (
            string NameField,
            Guid TopicIdField
        );
    };
}
