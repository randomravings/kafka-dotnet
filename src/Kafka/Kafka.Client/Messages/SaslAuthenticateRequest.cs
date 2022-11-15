using System.CodeDom.Compiler;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="AuthBytesField">The SASL authentication bytes from the client, as defined by the SASL mechanism.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SaslAuthenticateRequest (
        byte[] AuthBytesField
    )
    {
        public static SaslAuthenticateRequest Empty { get; } = new(
            System.Array.Empty<byte>()
        );
    };
}