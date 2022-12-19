using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="ErrorMessageField">The top-level error message, or `null` if there was no top-level error.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record UnregisterBrokerResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string? ErrorMessageField
    ) : Response(64)
    {
        public static UnregisterBrokerResponse Empty { get; } = new(
            default(int),
            default(short),
            default(string?)
        );
        public static short FlexibleVersion { get; } = 0;
    };
}