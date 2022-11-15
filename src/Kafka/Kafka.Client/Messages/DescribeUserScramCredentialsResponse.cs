using System.CodeDom.Compiler;
using System.Collections.Immutable;
using DescribeUserScramCredentialsResult = Kafka.Client.Messages.DescribeUserScramCredentialsResponse.DescribeUserScramCredentialsResult;
using CredentialInfo = Kafka.Client.Messages.DescribeUserScramCredentialsResponse.DescribeUserScramCredentialsResult.CredentialInfo;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// <param name="ErrorCodeField">The message-level error code, 0 except for user authorization or infrastructure issues.</param>
    /// <param name="ErrorMessageField">The message-level error message, if any.</param>
    /// <param name="ResultsField">The results for descriptions, one per user.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeUserScramCredentialsResponse (
        int ThrottleTimeMsField,
        short ErrorCodeField,
        string? ErrorMessageField,
        ImmutableArray<DescribeUserScramCredentialsResult> ResultsField
    )
    {
        public static DescribeUserScramCredentialsResponse Empty { get; } = new(
            default(int),
            default(short),
            default(string?),
            ImmutableArray<DescribeUserScramCredentialsResult>.Empty
        );
        /// <summary>
        /// <param name="UserField">The user name.</param>
        /// <param name="ErrorCodeField">The user-level error code.</param>
        /// <param name="ErrorMessageField">The user-level error message, if any.</param>
        /// <param name="CredentialInfosField">The mechanism and related information associated with the user's SCRAM credentials.</param>
        /// </summary>
        public sealed record DescribeUserScramCredentialsResult (
            string UserField,
            short ErrorCodeField,
            string? ErrorMessageField,
            ImmutableArray<CredentialInfo> CredentialInfosField
        )
        {
            public static DescribeUserScramCredentialsResult Empty { get; } = new(
                "",
                default(short),
                default(string?),
                ImmutableArray<CredentialInfo>.Empty
            );
            /// <summary>
            /// <param name="MechanismField">The SCRAM mechanism.</param>
            /// <param name="IterationsField">The number of iterations used in the SCRAM credential.</param>
            /// </summary>
            public sealed record CredentialInfo (
                sbyte MechanismField,
                int IterationsField
            )
            {
                public static CredentialInfo Empty { get; } = new(
                    default(sbyte),
                    default(int)
                );
            };
        };
    };
}