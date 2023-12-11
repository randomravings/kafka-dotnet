using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="MechanismField">The SASL mechanism chosen by the client.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record SaslHandshakeRequestData (
        string MechanismField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static SaslHandshakeRequestData Empty { get; } = new(
            "",
            ImmutableArray<TaggedField>.Empty
        );
    };
}
