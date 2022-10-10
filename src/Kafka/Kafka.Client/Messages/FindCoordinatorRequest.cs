using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record FindCoordinatorRequest (
        string KeyField,
        sbyte KeyTypeField,
        string[] CoordinatorKeysField
    );
}
