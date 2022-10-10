using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeUserScramCredentialsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string ErrorMessageField,
        DescribeUserScramCredentialsResponse.DescribeUserScramCredentialsResult[] ResultsField
    )
    {
        public sealed record DescribeUserScramCredentialsResult (
            string UserField,
            short ErrorCodeField,
            string ErrorMessageField,
            DescribeUserScramCredentialsResponse.DescribeUserScramCredentialsResult.CredentialInfo[] CredentialInfosField
        )
        {
            public sealed record CredentialInfo (
                sbyte MechanismField,
                int IterationsField
            );
        };
    };
}
