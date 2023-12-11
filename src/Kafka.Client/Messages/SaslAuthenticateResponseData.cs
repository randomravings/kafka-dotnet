using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="ErrorMessageField">The error message, or null if there was no error.</param>
    /// <param name="AuthBytesField">The SASL authentication bytes from the server, as defined by the SASL mechanism.</param>
    /// <param name="SessionLifetimeMsField">Number of milliseconds after which only re-authentication over the existing connection to create a new session can occur.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record SaslAuthenticateResponseData (
        short ErrorCodeField,
        string? ErrorMessageField,
        byte[] AuthBytesField,
        long SessionLifetimeMsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static SaslAuthenticateResponseData Empty { get; } = new(
            default(short),
            default(string?),
            Array.Empty<byte>(),
            default(long),
            ImmutableArray<TaggedField>.Empty
        );
    };
}
