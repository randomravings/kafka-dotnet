using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreateAclsResponse (
        int ThrottleTimeMsField,
        CreateAclsResponse.AclCreationResult[] ResultsField
    )
    {
        public sealed record AclCreationResult (
            short ErrorCodeField,
            string ErrorMessageField
        );
    };
}
