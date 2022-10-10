using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeDelegationTokenRequest (
        DescribeDelegationTokenRequest.DescribeDelegationTokenOwner[] OwnersField
    )
    {
        public sealed record DescribeDelegationTokenOwner (
            string PrincipalTypeField,
            string PrincipalNameField
        );
    };
}
