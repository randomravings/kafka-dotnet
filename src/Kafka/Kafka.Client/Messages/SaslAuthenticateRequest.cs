using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="AuthBytesField">The SASL authentication bytes from the client, as defined by the SASL mechanism.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SaslAuthenticateRequest (
        ReadOnlyMemory<byte> AuthBytesField
    ) : Request(36)
    {
        public static SaslAuthenticateRequest Empty { get; } = new(
            Array.Empty<byte>()
        );
        public static short FlexibleVersion { get; } = 2;
    };
}