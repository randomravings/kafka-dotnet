using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="RequestDataField">The embedded request header and data.</param>
    /// <param name="RequestPrincipalField">Value of the initial client principal when the request is redirected by a broker.</param>
    /// <param name="ClientHostAddressField">The original client's address in bytes.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record EnvelopeRequest (
        ReadOnlyMemory<byte> RequestDataField,
        ReadOnlyMemory<byte>? RequestPrincipalField,
        ReadOnlyMemory<byte> ClientHostAddressField
    ) : Request(58,0,0,0)
    {
        public static EnvelopeRequest Empty { get; } = new(
            ReadOnlyMemory<byte>.Empty,
            default(ReadOnlyMemory<byte>?),
            ReadOnlyMemory<byte>.Empty
        );
    };
}