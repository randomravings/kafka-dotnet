using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterConfigsResponse (
        int ThrottleTimeMsField,
        AlterConfigsResponse.AlterConfigsResourceResponse[] ResponsesField
    )
    {
        public sealed record AlterConfigsResourceResponse (
            short ErrorCodeField,
            string ErrorMessageField,
            sbyte ResourceTypeField,
            string ResourceNameField
        );
    };
}
