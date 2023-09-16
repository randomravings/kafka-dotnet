using System.Collections.Immutable;

namespace Kafka.Common.Model
{
    public abstract record ResponseHeader(
        int CorrelationId,
        ImmutableArray<TaggedField> TaggedFields
    );
}
