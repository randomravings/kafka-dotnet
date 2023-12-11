using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="AuthBytesField">The SASL authentication bytes from the client, as defined by the SASL mechanism.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record SaslAuthenticateRequestData (
        byte[] AuthBytesField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        internal static SaslAuthenticateRequestData Empty { get; } = new(
            Array.Empty<byte>(),
            ImmutableArray<TaggedField>.Empty
        );
    };
}
