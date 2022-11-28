using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="AuthBytesField">The SASL authentication bytes from the client, as defined by the SASL mechanism.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SaslAuthenticateRequest (
        ImmutableArray<byte> AuthBytesField
    ) : Request(36)
    {
        public static SaslAuthenticateRequest Empty { get; } = new(
            ImmutableArray<byte>.Empty
        );
    };
}