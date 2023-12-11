using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="MechanismsField">The mechanisms enabled in the server.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record SaslHandshakeResponseData (
        short ErrorCodeField,
        ImmutableArray<string> MechanismsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static SaslHandshakeResponseData Empty { get; } = new(
            default(short),
            ImmutableArray<string>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
    };
}
