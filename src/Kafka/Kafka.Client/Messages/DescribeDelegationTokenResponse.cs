using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using DescribedDelegationTokenRenewer = Kafka.Client.Messages.DescribeDelegationTokenResponse.DescribedDelegationToken.DescribedDelegationTokenRenewer;
using DescribedDelegationToken = Kafka.Client.Messages.DescribeDelegationTokenResponse.DescribedDelegationToken;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ErrorCodeField">The error code, or 0 if there was no error.</param>
    /// <param name="TokensField">The tokens.</param>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeDelegationTokenResponse (
        short ErrorCodeField,
        ImmutableArray<DescribedDelegationToken> TokensField,
        int ThrottleTimeMsField
    ) : Response(41)
    {
        public static DescribeDelegationTokenResponse Empty { get; } = new(
            default(short),
            ImmutableArray<DescribedDelegationToken>.Empty,
            default(int)
        );
        /// <summary>
        /// <param name="PrincipalTypeField">The token principal type.</param>
        /// <param name="PrincipalNameField">The token principal name.</param>
        /// <param name="TokenRequesterPrincipalTypeField">The principal type of the requester of the token.</param>
        /// <param name="TokenRequesterPrincipalNameField">The principal type of the requester of the token.</param>
        /// <param name="IssueTimestampField">The token issue timestamp in milliseconds.</param>
        /// <param name="ExpiryTimestampField">The token expiry timestamp in milliseconds.</param>
        /// <param name="MaxTimestampField">The token maximum timestamp length in milliseconds.</param>
        /// <param name="TokenIdField">The token ID.</param>
        /// <param name="HmacField">The token HMAC.</param>
        /// <param name="RenewersField">Those who are able to renew this token before it expires.</param>
        /// </summary>
        public sealed record DescribedDelegationToken (
            string PrincipalTypeField,
            string PrincipalNameField,
            string TokenRequesterPrincipalTypeField,
            string TokenRequesterPrincipalNameField,
            long IssueTimestampField,
            long ExpiryTimestampField,
            long MaxTimestampField,
            string TokenIdField,
            ReadOnlyMemory<byte> HmacField,
            ImmutableArray<DescribedDelegationTokenRenewer> RenewersField
        )
        {
            public static DescribedDelegationToken Empty { get; } = new(
                "",
                "",
                "",
                "",
                default(long),
                default(long),
                default(long),
                "",
                ReadOnlyMemory<byte>.Empty,
                ImmutableArray<DescribedDelegationTokenRenewer>.Empty
            );
            /// <summary>
            /// <param name="PrincipalTypeField">The renewer principal type</param>
            /// <param name="PrincipalNameField">The renewer principal name</param>
            /// </summary>
            public sealed record DescribedDelegationTokenRenewer (
                string PrincipalTypeField,
                string PrincipalNameField
            )
            {
                public static DescribedDelegationTokenRenewer Empty { get; } = new(
                    "",
                    ""
                );
            };
        };
    };
}