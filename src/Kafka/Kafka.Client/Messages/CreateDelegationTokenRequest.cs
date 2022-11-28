using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using CreatableRenewers = Kafka.Client.Messages.CreateDelegationTokenRequest.CreatableRenewers;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="OwnerPrincipalTypeField">The principal type of the owner of the token. If it's null it defaults to the token request principal.</param>
    /// <param name="OwnerPrincipalNameField">The principal name of the owner of the token. If it's null it defaults to the token request principal.</param>
    /// <param name="RenewersField">A list of those who are allowed to renew this token before it expires.</param>
    /// <param name="MaxLifetimeMsField">The maximum lifetime of the token in milliseconds, or -1 to use the server side default.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record CreateDelegationTokenRequest (
        string? OwnerPrincipalTypeField,
        string? OwnerPrincipalNameField,
        ImmutableArray<CreatableRenewers> RenewersField,
        long MaxLifetimeMsField
    ) : Request(38)
    {
        public static CreateDelegationTokenRequest Empty { get; } = new(
            default(string?),
            default(string?),
            ImmutableArray<CreatableRenewers>.Empty,
            default(long)
        );
        /// <summary>
        /// <param name="PrincipalTypeField">The type of the Kafka principal.</param>
        /// <param name="PrincipalNameField">The name of the Kafka principal.</param>
        /// </summary>
        public sealed record CreatableRenewers (
            string PrincipalTypeField,
            string PrincipalNameField
        )
        {
            public static CreatableRenewers Empty { get; } = new(
                "",
                ""
            );
        };
    };
}