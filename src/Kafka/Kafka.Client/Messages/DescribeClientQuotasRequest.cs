using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeClientQuotasRequest (
        DescribeClientQuotasRequest.ComponentData[] ComponentsField,
        bool StrictField
    )
    {
        public sealed record ComponentData (
            string EntityTypeField,
            sbyte MatchTypeField,
            string MatchField
        );
    };
}
