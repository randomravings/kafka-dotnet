using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="HmacField">The HMAC of the delegation token to be renewed.</param>
    /// <param name="RenewPeriodMsField">The renewal time period in milliseconds.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record RenewDelegationTokenRequest (
        ImmutableArray<byte> HmacField,
        long RenewPeriodMsField
    ) : Request(39)
    {
        public static RenewDelegationTokenRequest Empty { get; } = new(
            ImmutableArray<byte>.Empty,
            default(long)
        );
    };
}