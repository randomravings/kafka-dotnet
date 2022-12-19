using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

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
        public static short FlexibleVersion { get; } = 1;
    };
}