using Kafka.Client.Model;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Admin.Model
{
    public sealed record CreateTopicsOptions(
        int TimeoutMs,
        bool ValidateOnly,
        bool RetryOnQuotaViolation,
        ImmutableArray<CreateTopicOptions> Topics
    ) : ClientOptions(TimeoutMs)
    {
        public static CreateTopicsOptions Empty { get; } = new(
            -1,
            false,
            false,
            ImmutableArray<CreateTopicOptions>.Empty
        );
    };
}
