using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ResponseDataField">The embedded response header and data.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record EnvelopeResponse (
        ReadOnlyMemory<byte>? ResponseDataField,
        short ErrorCodeField
    ) : Response(58)
    {
        public static EnvelopeResponse Empty { get; } = new(
            default(ReadOnlyMemory<byte>?),
            default(short)
        );
    };
}