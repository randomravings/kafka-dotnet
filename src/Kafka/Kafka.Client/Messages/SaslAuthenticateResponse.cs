using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SaslAuthenticateResponse (
        short ErrorCodeField,
        string ErrorMessageField,
        byte[] AuthBytesField,
        long SessionLifetimeMsField
    );
}
