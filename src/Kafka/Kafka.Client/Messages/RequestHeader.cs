using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record RequestHeader (
        short RequestApiKeyField,
        short RequestApiVersionField,
        int CorrelationIdField,
        string ClientIdField
    );
}
