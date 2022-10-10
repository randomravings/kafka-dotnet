using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeConfigsRequest (
        DescribeConfigsRequest.DescribeConfigsResource[] ResourcesField,
        bool IncludeSynonymsField,
        bool IncludeDocumentationField
    )
    {
        public sealed record DescribeConfigsResource (
            sbyte ResourceTypeField,
            string ResourceNameField,
            string[] ConfigurationKeysField
        );
    };
}
