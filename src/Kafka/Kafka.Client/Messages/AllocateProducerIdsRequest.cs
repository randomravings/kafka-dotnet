using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="BrokerIdField">The ID of the requesting broker</param>
    /// <param name="BrokerEpochField">The epoch of the requesting broker</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AllocateProducerIdsRequest (
        int BrokerIdField,
        long BrokerEpochField
    ) : Request(67)
    {
        public static AllocateProducerIdsRequest Empty { get; } = new(
            default(int),
            default(long)
        );
    };
}