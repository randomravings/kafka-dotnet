using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">Duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="IsCaughtUpField">True if the broker has approximately caught up with the latest metadata.</param>
    /// <param name="IsFencedField">True if the broker is fenced.</param>
    /// <param name="ShouldShutDownField">True if the broker should proceed with its shutdown.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record BrokerHeartbeatResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        bool IsCaughtUpField,
        bool IsFencedField,
        bool ShouldShutDownField
    ) : Response(63)
    {
        public static BrokerHeartbeatResponse Empty { get; } = new(
            default(int),
            default(short),
            default(bool),
            default(bool),
            default(bool)
        );
    };
}