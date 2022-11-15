using System.CodeDom.Compiler;
using System.Collections.Immutable;
using AlterUserScramCredentialsResult = Kafka.Client.Messages.AlterUserScramCredentialsResponse.AlterUserScramCredentialsResult;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ResultsField">The results for deletions and alterations, one per affected user.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record AlterUserScramCredentialsResponse (
        int ThrottleTimeMsField,
        ImmutableArray<AlterUserScramCredentialsResult> ResultsField
    )
    {
        public static AlterUserScramCredentialsResponse Empty { get; } = new(
            default(int),
            ImmutableArray<AlterUserScramCredentialsResult>.Empty
        );
        /// <summary>
        /// <param name="UserField">The user name.</param>
        /// <param name="ErrorCodeField">The error code.</param>
        /// <param name="ErrorMessageField">The error message, if any.</param>
        /// </summary>
        public sealed record AlterUserScramCredentialsResult (
            string UserField,
            short ErrorCodeField,
            string? ErrorMessageField
        )
        {
            public static AlterUserScramCredentialsResult Empty { get; } = new(
                "",
                default(short),
                default(string?)
            );
        };
    };
}