using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;
using UserName = Kafka.Client.Messages.DescribeUserScramCredentialsRequest.UserName;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="UsersField">The users to describe, or null/empty to describe all users.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeUserScramCredentialsRequest (
        ImmutableArray<UserName>? UsersField
    ) : Request(50,0,0,0)
    {
        public static DescribeUserScramCredentialsRequest Empty { get; } = new(
            default(ImmutableArray<UserName>?)
        );
        /// <summary>
        /// <param name="NameField">The user name.</param>
        /// </summary>
        public sealed record UserName (
            string NameField
        )
        {
            public static UserName Empty { get; } = new(
                ""
            );
        };
    };
}