using System.CodeDom.Compiler;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="HmacField">The HMAC of the delegation token to be renewed.</param>
    /// <param name="RenewPeriodMsField">The renewal time period in milliseconds.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record RenewDelegationTokenRequest (
        byte[] HmacField,
        long RenewPeriodMsField
    )
    {
        public static RenewDelegationTokenRequest Empty { get; } = new(
            System.Array.Empty<byte>(),
            default(long)
        );
    };
}