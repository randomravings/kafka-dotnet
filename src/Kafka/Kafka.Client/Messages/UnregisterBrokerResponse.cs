using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record UnregisterBrokerResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string ErrorMessageField
    );
}
