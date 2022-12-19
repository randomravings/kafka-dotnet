using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using Voter = Kafka.Client.Messages.LeaderChangeMessage.Voter;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="VersionField">The version of the leader change message</param>
    /// <param name="LeaderIdField">The ID of the newly elected leader</param>
    /// <param name="VotersField">The set of voters in the quorum for this epoch</param>
    /// <param name="GrantingVotersField">The voters who voted for the leader at the time of election</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record LeaderChangeMessage (
        short VersionField,
        int LeaderIdField,
        ImmutableArray<Voter> VotersField,
        ImmutableArray<Voter> GrantingVotersField
    )
    {
        public static LeaderChangeMessage Empty { get; } = new(
            default(short),
            default(int),
            ImmutableArray<Voter>.Empty,
            ImmutableArray<Voter>.Empty
        );
        public static short FlexibleVersion { get; } = 0;
        /// <summary>
        /// <param name="VoterIdField"></param>
        /// </summary>
        public sealed record Voter (
            int VoterIdField
        )
        {
            public static Voter Empty { get; } = new(
                default(int)
            );
        };
    };
}