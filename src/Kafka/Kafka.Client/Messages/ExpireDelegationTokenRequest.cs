using System.CodeDom.Compiler;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="HmacField">The HMAC of the delegation token to be expired.</param>
    /// <param name="ExpiryTimePeriodMsField">The expiry time period in milliseconds.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ExpireDelegationTokenRequest (
        byte[] HmacField,
        long ExpiryTimePeriodMsField
    )
    {
        public static ExpireDelegationTokenRequest Empty { get; } = new(
            System.Array.Empty<byte>(),
            default(long)
        );
    };
}