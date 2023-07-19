using System.Collections.Immutable;

namespace Kafka.Common.Model
{
    public interface IResponseHeader
    {
        ImmutableArray<TaggedField> TaggedFields { get; }
    }
}
