using System.CodeDom.Compiler;
namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record JoinGroupRequest (
        string GroupIdField,
        int SessionTimeoutMsField,
        int RebalanceTimeoutMsField,
        string MemberIdField,
        string GroupInstanceIdField,
        string ProtocolTypeField,
        JoinGroupRequest.JoinGroupRequestProtocol[] ProtocolsField,
        string ReasonField
    )
    {
        public sealed record JoinGroupRequestProtocol (
            string NameField,
            byte[] MetadataField
        );
    };
}
