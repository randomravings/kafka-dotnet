using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="RequestApiKeyField">The API key of this request.</param>
    /// <param name="RequestApiVersionField">The API version of this request.</param>
    /// <param name="CorrelationIdField">The correlation ID of this request.</param>
    /// <param name="ClientIdField">The client ID string.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record RequestHeader (
        short RequestApiKeyField,
        short RequestApiVersionField,
        int CorrelationIdField,
        string? ClientIdField
    )
    {
        public static RequestHeader Empty { get; } = new(
            default(short),
            default(short),
            default(int),
            default(string?)
        );
    };
}