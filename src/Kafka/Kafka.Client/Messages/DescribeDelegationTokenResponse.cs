using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeDelegationTokenResponse (
        short ErrorCodeField,
        DescribeDelegationTokenResponse.DescribedDelegationToken[] TokensField,
        int ThrottleTimeMsField
    )
    {
        public sealed record DescribedDelegationToken (
            string PrincipalTypeField,
            string PrincipalNameField,
            string TokenRequesterPrincipalTypeField,
            string TokenRequesterPrincipalNameField,
            long IssueTimestampField,
            long ExpiryTimestampField,
            long MaxTimestampField,
            string TokenIdField,
            byte[] HmacField,
            DescribeDelegationTokenResponse.DescribedDelegationToken.DescribedDelegationTokenRenewer[] RenewersField
        )
        {
            public sealed record DescribedDelegationTokenRenewer (
                string PrincipalTypeField,
                string PrincipalNameField
            );
        };
    };
}
