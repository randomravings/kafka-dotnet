using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ListGroupsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        ListGroupsResponse.ListedGroup[] GroupsField
    )
    {
        public sealed record ListedGroup (
            string GroupIdField,
            string ProtocolTypeField,
            string GroupStateField
        );
    };
}
