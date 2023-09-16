using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using MemberIdentity = Kafka.Client.Messages.LeaveGroupRequestData.MemberIdentity;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="GroupIdField">The ID of the group to leave.</param>
    /// <param name="MemberIdField">The member ID to remove from the group.</param>
    /// <param name="MembersField">List of leaving member identities.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record LeaveGroupRequestData (
        string GroupIdField,
        string MemberIdField,
        ImmutableArray<MemberIdentity> MembersField,
        ImmutableArray<TaggedField> TaggedFields
    ) : RequestMessage (TaggedFields)
    {
        public static LeaveGroupRequestData Empty { get; } = new(
            "",
            "",
            ImmutableArray<MemberIdentity>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="MemberIdField">The member ID to remove from the group.</param>
        /// <param name="GroupInstanceIdField">The group instance ID to remove from the group.</param>
        /// <param name="ReasonField">The reason why the member left the group.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        public sealed record MemberIdentity (
            string MemberIdField,
            string? GroupInstanceIdField,
            string? ReasonField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            public static MemberIdentity Empty { get; } = new(
                "",
                default(string?),
                default(string?),
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
