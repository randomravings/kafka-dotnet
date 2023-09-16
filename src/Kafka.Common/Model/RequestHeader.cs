using System.Collections.Immutable;

namespace Kafka.Common.Model
{
    public abstract record RequestHeader(
        int CorrelationId,
        ImmutableArray<TaggedField> TaggedFields
    );
}
