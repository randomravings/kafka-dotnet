using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="StatesFilterField">The states of the groups we want to list. If empty all groups are returned with their state.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record ListGroupsRequest (
        ImmutableArray<string> StatesFilterField
    ) : Request(16)
    {
        public static ListGroupsRequest Empty { get; } = new(
            ImmutableArray<string>.Empty
        );
        public static short FlexibleVersion { get; } = 3;
    };
}