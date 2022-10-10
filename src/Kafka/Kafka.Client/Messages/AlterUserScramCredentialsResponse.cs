using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterUserScramCredentialsResponse (
        int ThrottleTimeMsField,
        AlterUserScramCredentialsResponse.AlterUserScramCredentialsResult[] ResultsField
    )
    {
        public sealed record AlterUserScramCredentialsResult (
            string UserField,
            short ErrorCodeField,
            string ErrorMessageField
        );
    };
}
