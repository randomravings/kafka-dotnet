using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreateDelegationTokenRequest (
        string OwnerPrincipalTypeField,
        string OwnerPrincipalNameField,
        CreateDelegationTokenRequest.CreatableRenewers[] RenewersField,
        long MaxLifetimeMsField
    )
    {
        public sealed record CreatableRenewers (
            string PrincipalTypeField,
            string PrincipalNameField
        );
    };
}
