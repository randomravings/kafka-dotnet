using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="ExpiryTimestampMsField">The timestamp in milliseconds at which this token expires.</param>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ExpireDelegationTokenResponse (
        short ErrorCodeField,
        long ExpiryTimestampMsField,
        int ThrottleTimeMsField
    ) : Response(40)
    {
        public static ExpireDelegationTokenResponse Empty { get; } = new(
            default(short),
            default(long),
            default(int)
        );
    };
}