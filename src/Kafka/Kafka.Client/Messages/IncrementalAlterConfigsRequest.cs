using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record IncrementalAlterConfigsRequest (
        IncrementalAlterConfigsRequest.AlterConfigsResource[] ResourcesField,
        bool ValidateOnlyField
    )
    {
        public sealed record AlterConfigsResource (
            sbyte ResourceTypeField,
            string ResourceNameField,
            IncrementalAlterConfigsRequest.AlterConfigsResource.AlterableConfig[] ConfigsField
        )
        {
            public sealed record AlterableConfig (
                string NameField,
                sbyte ConfigOperationField,
                string ValueField
            );
        };
    };
}
