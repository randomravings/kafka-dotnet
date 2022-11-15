using System.CodeDom.Compiler;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="MechanismField">The SASL mechanism chosen by the client.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SaslHandshakeRequest (
        string MechanismField
    )
    {
        public static SaslHandshakeRequest Empty { get; } = new(
            ""
        );
    };
}