using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using JoinGroupRequestProtocol = Kafka.Client.Messages.JoinGroupRequest.JoinGroupRequestProtocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="GroupIdField">The group identifier.</param>
    /// <param name="SessionTimeoutMsField">The coordinator considers the consumer dead if it receives no heartbeat after this timeout in milliseconds.</param>
    /// <param name="RebalanceTimeoutMsField">The maximum time in milliseconds that the coordinator will wait for each member to rejoin when rebalancing the group.</param>
    /// <param name="MemberIdField">The member id assigned by the group coordinator.</param>
    /// <param name="GroupInstanceIdField">The unique identifier of the consumer instance provided by end user.</param>
    /// <param name="ProtocolTypeField">The unique name the for class of protocols implemented by the group we want to join.</param>
    /// <param name="ProtocolsField">The list of protocols that the member supports.</param>
    /// <param name="ReasonField">The reason why the member (re-)joins the group.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record JoinGroupRequest (
        string GroupIdField,
        int SessionTimeoutMsField,
        int RebalanceTimeoutMsField,
        string MemberIdField,
        string? GroupInstanceIdField,
        string ProtocolTypeField,
        ImmutableArray<JoinGroupRequestProtocol> ProtocolsField,
        string? ReasonField
    ) : Request(11)
    {
        public static JoinGroupRequest Empty { get; } = new(
            "",
            default(int),
            default(int),
            "",
            default(string?),
            "",
            ImmutableArray<JoinGroupRequestProtocol>.Empty,
            default(string?)
        );
        /// <summary>
        /// <param name="NameField">The protocol name.</param>
        /// <param name="MetadataField">The protocol metadata.</param>
        /// </summary>
        public sealed record JoinGroupRequestProtocol (
            string NameField,
            ImmutableArray<byte> MetadataField
        )
        {
            public static JoinGroupRequestProtocol Empty { get; } = new(
                "",
                ImmutableArray<byte>.Empty
            );
        };
    };
}