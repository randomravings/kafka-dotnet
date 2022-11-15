using System.CodeDom.Compiler;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="ErrorMessageField">The error message, or null if there was no error.</param>
    /// <param name="AuthBytesField">The SASL authentication bytes from the server, as defined by the SASL mechanism.</param>
    /// <param name="SessionLifetimeMsField">The SASL authentication bytes from the server, as defined by the SASL mechanism.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SaslAuthenticateResponse (
        short ErrorCodeField,
        string? ErrorMessageField,
        byte[] AuthBytesField,
        long SessionLifetimeMsField
    )
    {
        public static SaslAuthenticateResponse Empty { get; } = new(
            default(short),
            default(string?),
            System.Array.Empty<byte>(),
            default(long)
        );
    };
}