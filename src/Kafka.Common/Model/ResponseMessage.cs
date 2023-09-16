using System.Collections.Immutable;

namespace Kafka.Common.Model
{
    public abstract record ResponseMessage(
        ImmutableArray<TaggedField> TaggedFields
    );
}
