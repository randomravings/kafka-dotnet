using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreateDelegationTokenResponse (
        short ErrorCodeField,
        string PrincipalTypeField,
        string PrincipalNameField,
        string TokenRequesterPrincipalTypeField,
        string TokenRequesterPrincipalNameField,
        long IssueTimestampMsField,
        long ExpiryTimestampMsField,
        long MaxTimestampMsField,
        string TokenIdField,
        byte[] HmacField,
        int ThrottleTimeMsField
    );
}
