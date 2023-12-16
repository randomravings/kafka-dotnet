using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DescribedGroup = Kafka.Client.Messages.DescribeGroupsResponseData.DescribedGroup;
using DescribedGroupMember = Kafka.Client.Messages.DescribeGroupsResponseData.DescribedGroup.DescribedGroupMember;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="GroupsField">Each described group.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record DescribeGroupsResponseData (
        int ThrottleTimeMsField,
        ImmutableArray<DescribedGroup> GroupsField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static DescribeGroupsResponseData Empty { get; } = new(
            default(int),
            ImmutableArray<DescribedGroup>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="ErrorCodeField">The describe error, or 0 if there was no error.</param>
        /// <param name="GroupIdField">The group ID string.</param>
        /// <param name="GroupStateField">The group state string, or the empty string.</param>
        /// <param name="ProtocolTypeField">The group protocol type, or the empty string.</param>
        /// <param name="ProtocolDataField">The group protocol data, or the empty string.</param>
        /// <param name="MembersField">The group members.</param>
        /// <param name="AuthorizedOperationsField">32-bit bitfield to represent authorized operations for this group.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record DescribedGroup (
            short ErrorCodeField,
            string GroupIdField,
            string GroupStateField,
            string ProtocolTypeField,
            string ProtocolDataField,
            ImmutableArray<DescribedGroupMember> MembersField,
            int AuthorizedOperationsField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static DescribedGroup Empty { get; } = new(
                default(short),
                "",
                "",
                "",
                "",
                ImmutableArray<DescribedGroupMember>.Empty,
                default(int),
                ImmutableArray<TaggedField>.Empty
            );
            /// <summary>
            /// <param name="MemberIdField">The member ID assigned by the group coordinator.</param>
            /// <param name="GroupInstanceIdField">The unique identifier of the consumer instance provided by end user.</param>
            /// <param name="ClientIdField">The client ID used in the member's latest join group request.</param>
            /// <param name="ClientHostField">The client host.</param>
            /// <param name="MemberMetadataField">The metadata corresponding to the current group protocol in use.</param>
            /// <param name="MemberAssignmentField">The current assignment provided by the group leader.</param>
            /// </summary>
            [GeneratedCode("kgen", "1.0.0.0")]
            internal sealed record DescribedGroupMember (
                string MemberIdField,
                string? GroupInstanceIdField,
                string ClientIdField,
                string ClientHostField,
                byte[] MemberMetadataField,
                byte[] MemberAssignmentField,
                ImmutableArray<TaggedField> TaggedFields
            )
            {
                internal static DescribedGroupMember Empty { get; } = new(
                    "",
                    default(string?),
                    "",
                    "",
                    Array.Empty<byte>(),
                    Array.Empty<byte>(),
                    ImmutableArray<TaggedField>.Empty
                );
            };
        };
    };
}
