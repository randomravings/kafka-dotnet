using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="HmacField">The HMAC of the delegation token to be expired.</param>
    /// <param name="ExpiryTimePeriodMsField">The expiry time period in milliseconds.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ExpireDelegationTokenRequest (
        ReadOnlyMemory<byte> HmacField,
        long ExpiryTimePeriodMsField
    ) : Request(40)
    {
        public static ExpireDelegationTokenRequest Empty { get; } = new(
            Array.Empty<byte>(),
            default(long)
        );
        public static short FlexibleVersion { get; } = 2;
    };
}