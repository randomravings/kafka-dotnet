using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteGroupsResponse (
        int ThrottleTimeMsField,
        DeleteGroupsResponse.DeletableGroupResult[] ResultsField
    )
    {
        public sealed record DeletableGroupResult (
            string GroupIdField,
            short ErrorCodeField
        );
    };
}
