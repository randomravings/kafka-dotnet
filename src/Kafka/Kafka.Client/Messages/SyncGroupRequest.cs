using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using SyncGroupRequestAssignment = Kafka.Client.Messages.SyncGroupRequest.SyncGroupRequestAssignment;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="GroupIdField">The unique group identifier.</param>
    /// <param name="GenerationIdField">The generation of the group.</param>
    /// <param name="MemberIdField">The member ID assigned by the group.</param>
    /// <param name="GroupInstanceIdField">The unique identifier of the consumer instance provided by end user.</param>
    /// <param name="ProtocolTypeField">The group protocol type.</param>
    /// <param name="ProtocolNameField">The group protocol name.</param>
    /// <param name="AssignmentsField">Each assignment.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record SyncGroupRequest (
        string GroupIdField,
        int GenerationIdField,
        string MemberIdField,
        string? GroupInstanceIdField,
        string? ProtocolTypeField,
        string? ProtocolNameField,
        ImmutableArray<SyncGroupRequestAssignment> AssignmentsField
    ) : Request(14,0,5,4)
    {
        public static SyncGroupRequest Empty { get; } = new(
            "",
            default(int),
            "",
            default(string?),
            default(string?),
            default(string?),
            ImmutableArray<SyncGroupRequestAssignment>.Empty
        );
        /// <summary>
        /// <param name="MemberIdField">The ID of the member to assign.</param>
        /// <param name="AssignmentField">The member assignment.</param>
        /// </summary>
        public sealed record SyncGroupRequestAssignment (
            string MemberIdField,
            ReadOnlyMemory<byte> AssignmentField
        )
        {
            public static SyncGroupRequestAssignment Empty { get; } = new(
                "",
                Array.Empty<byte>()
            );
        };
    };
}