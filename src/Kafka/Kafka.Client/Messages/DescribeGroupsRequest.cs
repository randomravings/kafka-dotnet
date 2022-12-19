using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="GroupsField">The names of the groups to describe</param>
    /// <param name="IncludeAuthorizedOperationsField">Whether to include authorized operations.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DescribeGroupsRequest (
        ImmutableArray<string> GroupsField,
        bool IncludeAuthorizedOperationsField
    ) : Request(15)
    {
        public static DescribeGroupsRequest Empty { get; } = new(
            ImmutableArray<string>.Empty,
            default(bool)
        );
        public static short FlexibleVersion { get; } = 5;
    };
}