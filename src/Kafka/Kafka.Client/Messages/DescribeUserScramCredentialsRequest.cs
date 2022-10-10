using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeUserScramCredentialsRequest (
        DescribeUserScramCredentialsRequest.UserName[] UsersField
    )
    {
        public sealed record UserName (
            string NameField
        );
    };
}
