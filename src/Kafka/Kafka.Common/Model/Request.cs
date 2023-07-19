using System.Collections.Immutable;

namespace Kafka.Common.Model
{
    public interface IRequest
    {
        ImmutableArray<TaggedField> TaggedFields { get; }
    }
}
