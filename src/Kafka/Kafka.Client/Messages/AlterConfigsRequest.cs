using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterConfigsRequest (
        AlterConfigsRequest.AlterConfigsResource[] ResourcesField,
        bool ValidateOnlyField
    )
    {
        public sealed record AlterConfigsResource (
            sbyte ResourceTypeField,
            string ResourceNameField,
            AlterConfigsRequest.AlterConfigsResource.AlterableConfig[] ConfigsField
        )
        {
            public sealed record AlterableConfig (
                string NameField,
                string ValueField
            );
        };
    };
}
