using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record MetadataRequest (
        MetadataRequest.MetadataRequestTopic[] TopicsField,
        bool AllowAutoTopicCreationField,
        bool IncludeClusterAuthorizedOperationsField,
        bool IncludeTopicAuthorizedOperationsField
    )
    {
        public sealed record MetadataRequestTopic (
            Guid TopicIdField,
            string NameField
        );
    };
}
