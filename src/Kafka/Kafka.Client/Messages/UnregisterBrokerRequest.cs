using System.CodeDom.Compiler;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="BrokerIdField">The broker ID to unregister.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record UnregisterBrokerRequest (
        int BrokerIdField
    )
    {
        public static UnregisterBrokerRequest Empty { get; } = new(
            default(int)
        );
    };
}