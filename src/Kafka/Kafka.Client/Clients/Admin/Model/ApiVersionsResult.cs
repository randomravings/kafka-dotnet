using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record ApiVersionsResult(
        ImmutableSortedDictionary<ApiKey, ApiVersion> ApiVersions
    )
    {
        public static ApiVersionsResult Empty { get; } = new(
            ImmutableSortedDictionary<ApiKey, ApiVersion>.Empty
        );
    };
}
