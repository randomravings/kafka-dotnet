using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteTopicsResponse (
        int ThrottleTimeMsField,
        DeleteTopicsResponse.DeletableTopicResult[] ResponsesField
    )
    {
        public sealed record DeletableTopicResult (
            string NameField,
            Guid TopicIdField,
            short ErrorCodeField,
            string ErrorMessageField
        );
    };
}
