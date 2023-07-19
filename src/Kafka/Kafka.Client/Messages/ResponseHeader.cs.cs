using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="CorrelationIdField">The correlation ID of this response.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ResponseHeader (
        int CorrelationIdField,
        ImmutableArray<TaggedField> TaggedFields
    ) : IResponseHeader
    {
        public static ResponseHeader Empty { get; } = new(
            default(int),
            ImmutableArray<TaggedField>.Empty

        );
    };
}