using Kafka.Common.Model;
using MemberResponse = Kafka.Client.Messages.LeaveGroupResponse.MemberResponse;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="MembersField">List of leaving member responses.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record LeaveGroupResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        ImmutableArray<MemberResponse> MembersField,
        ImmutableArray<TaggedField> TaggedFields
    ) : IResponse
    {
        public static LeaveGroupResponse Empty { get; } = new(
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
        public sealed record MemberResponse (
            string MemberIdField,
            string? GroupInstanceIdField,
            short ErrorCodeField,
            ImmutableArray<TaggedField> TaggedFields
        ) : IResponse
        {
            public static MemberResponse Empty { get; } = new(
                "",
                default(string?),
                default(short),
                ImmutableArray<TaggedField>.Empty

            );
        };
    };
}