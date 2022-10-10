using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreateTopicsResponse (
        int ThrottleTimeMsField,
        CreateTopicsResponse.CreatableTopicResult[] TopicsField
    )
    {
        public sealed record CreatableTopicResult (
            string NameField,
            Guid TopicIdField,
            short ErrorCodeField,
            string ErrorMessageField,
            short TopicConfigErrorCodeField,
            int NumPartitionsField,
            short ReplicationFactorField,
            CreateTopicsResponse.CreatableTopicResult.CreatableTopicConfigs[] ConfigsField
        )
        {
            public sealed record CreatableTopicConfigs (
                string NameField,
                string ValueField,
                bool ReadOnlyField,
                sbyte ConfigSourceField,
                bool IsSensitiveField
            );
        };
    };
}
