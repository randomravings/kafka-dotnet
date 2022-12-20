using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="BrokerIdField">The broker ID to unregister.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record UnregisterBrokerRequest (
        int BrokerIdField
    ) : Request(64,0,0,0)
    {
        public static UnregisterBrokerRequest Empty { get; } = new(
            default(int)
        );
    };
}