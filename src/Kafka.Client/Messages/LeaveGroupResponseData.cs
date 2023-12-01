using Kafka.Common.Model;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using MemberResponse = Kafka.Client.Messages.LeaveGroupResponseData.MemberResponse;

namespace Kafka.Client.Messages {
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="MembersField">List of leaving member responses.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    internal sealed record LeaveGroupResponseData (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        ImmutableArray<MemberResponse> MembersField,
        ImmutableArray<TaggedField> TaggedFields
    ) : ResponseMessage (TaggedFields)
    {
        internal static LeaveGroupResponseData Empty { get; } = new(
            default(int),
            default(short),
            ImmutableArray<MemberResponse>.Empty,
            ImmutableArray<TaggedField>.Empty
        );
        /// <summary>
        /// <param name="MemberIdField">The member ID to remove from the group.</param>
        /// <param name="GroupInstanceIdField">The group instance ID to remove from the group.</param>
        /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
        /// </summary>
        [GeneratedCode("kgen", "1.0.0.0")]
        internal sealed record MemberResponse (
            string MemberIdField,
            string? GroupInstanceIdField,
            short ErrorCodeField,
            ImmutableArray<TaggedField> TaggedFields
        )
        {
            internal static MemberResponse Empty { get; } = new(
                "",
                default(string?),
                default(short),
                ImmutableArray<TaggedField>.Empty
            );
        };
    };
}
