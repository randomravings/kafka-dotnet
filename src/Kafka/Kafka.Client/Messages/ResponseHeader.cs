using System.CodeDom.Compiler;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="CorrelationIdField">The correlation ID of this response.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ResponseHeader (
        int CorrelationIdField
    )
    {
        public static ResponseHeader Empty { get; } = new(
            default(int)
        );
    };
}