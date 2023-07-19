using System.Collections.Immutable;

namespace Kafka.Common.Model
{
    public interface IResponse
    {
        ImmutableArray<TaggedField> TaggedFields { get; }
    }
}
