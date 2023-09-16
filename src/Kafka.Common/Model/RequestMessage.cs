using System.Collections.Immutable;

namespace Kafka.Common.Model
{
    public abstract record RequestMessage(
        ImmutableArray<TaggedField> TaggedFields
    );
}
