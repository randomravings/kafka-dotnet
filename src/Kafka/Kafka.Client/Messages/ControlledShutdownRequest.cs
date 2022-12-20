using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="BrokerIdField">The id of the broker for which controlled shutdown has been requested.</param>
    /// <param name="BrokerEpochField">The broker epoch.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ControlledShutdownRequest (
        int BrokerIdField,
        long BrokerEpochField
    ) : Request(7,0,3,3)
    {
        public static ControlledShutdownRequest Empty { get; } = new(
            default(int),
            default(long)
        );
    };
}