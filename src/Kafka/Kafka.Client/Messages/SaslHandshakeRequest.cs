using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="MechanismField">The SASL mechanism chosen by the client.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SaslHandshakeRequest (
        string MechanismField
    ) : Request(17)
    {
        public static SaslHandshakeRequest Empty { get; } = new(
            ""
        );
    };
}