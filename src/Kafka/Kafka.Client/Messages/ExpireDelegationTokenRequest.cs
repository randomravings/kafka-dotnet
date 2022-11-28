using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="HmacField">The HMAC of the delegation token to be expired.</param>
    /// <param name="ExpiryTimePeriodMsField">The expiry time period in milliseconds.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ExpireDelegationTokenRequest (
        ImmutableArray<byte> HmacField,
        long ExpiryTimePeriodMsField
    ) : Request(40)
    {
        public static ExpireDelegationTokenRequest Empty { get; } = new(
            ImmutableArray<byte>.Empty,
            default(long)
        );
    };
}