using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Kafka.Common.Protocol;

namespace Kafka.Client.Messages
{
    /// <summary>
    /// <param name="GroupsNamesField">The group names to delete.</param>
    /// </summary>
    [GeneratedCode("kgen", "1.0.0.0")]
    public sealed record DeleteGroupsRequest (
        ImmutableArray<string> GroupsNamesField
    ) : Request(42)
    {
        public static DeleteGroupsRequest Empty { get; } = new(
            ImmutableArray<string>.Empty
        );
    };
}