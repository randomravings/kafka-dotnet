using System.CodeDom.Compiler;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="RequestDataField">The embedded request header and data.</param>
    /// <param name="RequestPrincipalField">Value of the initial client principal when the request is redirected by a broker.</param>
    /// <param name="ClientHostAddressField">The original client's address in bytes.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record EnvelopeRequest (
        byte[] RequestDataField,
        byte[]? RequestPrincipalField,
        byte[] ClientHostAddressField
    )
    {
        public static EnvelopeRequest Empty { get; } = new(
            System.Array.Empty<byte>(),
            default(byte[]?),
            System.Array.Empty<byte>()
        );
    };
}