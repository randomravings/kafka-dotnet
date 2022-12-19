using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record ListTopicsResult(
        ImmutableArray<Topic> Topics
    )
    {
        public static ListTopicsResult Empty { get; } = new(
            ImmutableArray<Topic>.Empty
        );
    };
}
