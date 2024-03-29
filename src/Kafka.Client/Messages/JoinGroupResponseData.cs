using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using JoinGroupResponseMember = Kafka.Client.Messages.JoinGroupResponseData.JoinGroupResponseMember;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="GenerationIdField">The generation ID of the group.</param>
    /// <param name="ProtocolTypeField">The group protocol name.</param>
    /// <param name="ProtocolNameField">The group protocol selected by the coordinator.</param>
    /// <param name="LeaderField">The leader of the group.</param>
    /// <param name="SkipAssignmentField">True if the leader must skip running the assignment.</param>
    /// <param name="MemberIdField">The member ID assigned by the group coordinator.</param>
    /// <param name="MembersField"></param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record JoinGroupResponseData (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        int GenerationIdField,
        string? ProtocolTypeField,
        string? ProtocolNameField,
        string LeaderField,
        bool SkipAssignmentField,
        string MemberIdField,
        ImmutableArray<JoinGroupResponseMember> MembersField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static JoinGroupResponseData Empty { get; } = new(
            default(int),
            default(short),
            default(int),
            default(string?),
            default(string?),
            "",
            default(bool),
            "",
            ImmutableArray<JoinGroupResponseMember>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="MemberIdField">The group member ID.</param>
        /// <param name="GroupInstanceIdField">The unique identifier of the consumer instance provided by end user.</param>
        /// <param name="MetadataField">The group member metadata.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record JoinGroupResponseMember (
            string MemberIdField,
            string? GroupInstanceIdField,
            byte[] MetadataField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static JoinGroupResponseMember Empty { get; } = new(
                "",
                default(string?),
                Array.Empty<byte>(),
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
