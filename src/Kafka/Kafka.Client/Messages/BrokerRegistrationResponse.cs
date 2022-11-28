using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="BrokerEpochField">The broker's assigned epoch, or -1 if none was assigned.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record BrokerRegistrationResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        long BrokerEpochField
    ) : Response(62)
    {
        public static BrokerRegistrationResponse Empty { get; } = new(
            default(int),
            default(short),
            default(long)
        );
    };
}