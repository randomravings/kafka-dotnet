using System.Collections.Immutable;

namespace Kafka.Common.Model
{
    public interface IRequestHeader
    {
        ImmutableArray<TaggedField> TaggedFields { get; }
    }
}
