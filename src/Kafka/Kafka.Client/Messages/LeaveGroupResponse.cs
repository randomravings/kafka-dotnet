using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using MemberResponse = Kafka.Client.Messages.LeaveGroupResponse.MemberResponse;

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
        ImmutableArray<MemberResponse> MembersField
    ) : Response(13)
    {
        public static LeaveGroupResponse Empty { get; } = new(
            default(int),
            default(short),
            ImmutableArray<MemberResponse>.Empty
        );
        public static short FlexibleVersion { get; } = 4;
        /// <summary>
        /// <param name="MemberIdField">The member ID to remove from the group.</param>
        /// <param name="GroupInstanceIdField">The group instance ID to remove from the group.</param>
        /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
        /// </summary>
        public sealed record MemberResponse (
            string MemberIdField,
            string? GroupInstanceIdField,
            short ErrorCodeField
        )
        {
            public static MemberResponse Empty { get; } = new(
                "",
                default(string?),
                default(short)
            );
        };
    };
}