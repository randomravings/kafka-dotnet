using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="BrokerIdField">The broker ID.</param>
    /// <param name="BrokerEpochField">The broker epoch.</param>
    /// <param name="CurrentMetadataOffsetField">The highest metadata offset which the broker has reached.</param>
    /// <param name="WantFenceField">True if the broker wants to be fenced, false otherwise.</param>
    /// <param name="WantShutDownField">True if the broker wants to be shut down, false otherwise.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record BrokerHeartbeatRequest (
        int BrokerIdField,
        long BrokerEpochField,
        long CurrentMetadataOffsetField,
        bool WantFenceField,
        bool WantShutDownField
    ) : Request(63)
    {
        public static BrokerHeartbeatRequest Empty { get; } = new(
            default(int),
            default(long),
            default(long),
            default(bool),
            default(bool)
        );
        public static short FlexibleVersion { get; } = 0;
    };
}