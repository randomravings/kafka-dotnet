using System.CodeDom.Compiler;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="GroupIdField">The group id.</param>
    /// <param name="GenerationIdField">The generation of the group.</param>
    /// <param name="MemberIdField">The member ID.</param>
    /// <param name="GroupInstanceIdField">The unique identifier of the consumer instance provided by end user.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record HeartbeatRequest (
        string GroupIdField,
        int GenerationIdField,
        string MemberIdField,
        string? GroupInstanceIdField
    ) : Request(12)
    {
        public static HeartbeatRequest Empty { get; } = new(
            "",
            default(int),
            "",
            default(string?)
        );
    };
}