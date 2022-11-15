using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="MechanismsField">The mechanisms enabled in the server.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SaslHandshakeResponse (
        short ErrorCodeField,
        ImmutableArray<string> MechanismsField
    )
    {
        public static SaslHandshakeResponse Empty { get; } = new(
            default(short),
            ImmutableArray<string>.Empty
        );
    };
}