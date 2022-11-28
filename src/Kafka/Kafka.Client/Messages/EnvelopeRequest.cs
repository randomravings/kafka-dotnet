using System.CodeDom.Compiler;
using System.Collections.Immutable;
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
        ImmutableArray<byte> RequestDataField,
        ImmutableArray<byte>? RequestPrincipalField,
        ImmutableArray<byte> ClientHostAddressField
    ) : Request(58)
    {
        public static EnvelopeRequest Empty { get; } = new(
            ImmutableArray<byte>.Empty,
            default(ImmutableArray<byte>?),
            ImmutableArray<byte>.Empty
        );
    };
}