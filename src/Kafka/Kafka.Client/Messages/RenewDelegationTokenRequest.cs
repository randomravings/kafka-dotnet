using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record RenewDelegationTokenRequest (
        byte[] HmacField,
        long RenewPeriodMsField
    );
}
