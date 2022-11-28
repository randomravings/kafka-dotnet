using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="ErrorCodeField">The top-level error, or zero if there was no error.</param>
    /// <param name="PrincipalTypeField">The principal type of the token owner.</param>
    /// <param name="PrincipalNameField">The name of the token owner.</param>
    /// <param name="TokenRequesterPrincipalTypeField">The principal type of the requester of the token.</param>
    /// <param name="TokenRequesterPrincipalNameField">The principal type of the requester of the token.</param>
    /// <param name="IssueTimestampMsField">When this token was generated.</param>
    /// <param name="ExpiryTimestampMsField">When this token expires.</param>
    /// <param name="MaxTimestampMsField">The maximum lifetime of this token.</param>
    /// <param name="TokenIdField">The token UUID.</param>
    /// <param name="HmacField">HMAC of the delegation token.</param>
    /// <param name="ThrottleTimeMsField">The duration in milliseconds for which the request was throttled due to a quota violation, or zero if the request did not violate any quota.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreateDelegationTokenResponse (
        short ErrorCodeField,
        string PrincipalTypeField,
        string PrincipalNameField,
        string TokenRequesterPrincipalTypeField,
        string TokenRequesterPrincipalNameField,
        long IssueTimestampMsField,
        long ExpiryTimestampMsField,
        long MaxTimestampMsField,
        string TokenIdField,
        ImmutableArray<byte> HmacField,
        int ThrottleTimeMsField
    ) : Response(38)
    {
        public static CreateDelegationTokenResponse Empty { get; } = new(
            default(short),
            "",
            "",
            "",
            "",
            default(long),
            default(long),
            default(long),
            "",
            ImmutableArray<byte>.Empty,
            default(int)
        );
    };
}