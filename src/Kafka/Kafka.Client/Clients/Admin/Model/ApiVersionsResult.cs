using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record ApiVersionsResult(
        ImmutableSortedDictionary<Api, ApiVersion> ApiVersions
    )
    {
        public static ApiVersionsResult Empty { get; } = new(
            ImmutableSortedDictionary<Api, ApiVersion>.Empty
        );
    };
}
