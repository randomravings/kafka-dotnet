using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using DescribeDelegationTokenOwner = Kafka.Client.Messages.DescribeDelegationTokenRequest.DescribeDelegationTokenOwner;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="OwnersField">Each owner that we want to describe delegation tokens for, or null to describe all tokens.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeDelegationTokenRequest (
        ImmutableArray<DescribeDelegationTokenOwner>? OwnersField
    ) : Request(41)
    {
        public static DescribeDelegationTokenRequest Empty { get; } = new(
            default(ImmutableArray<DescribeDelegationTokenOwner>?)
        );
        /// <summary>
        /// <param name="PrincipalTypeField">The owner principal type.</param>
        /// <param name="PrincipalNameField">The owner principal name.</param>
        /// </summary>
        public sealed record DescribeDelegationTokenOwner (
            string PrincipalTypeField,
            string PrincipalNameField
        )
        {
            public static DescribeDelegationTokenOwner Empty { get; } = new(
                "",
                ""
            );
        };
    };
}