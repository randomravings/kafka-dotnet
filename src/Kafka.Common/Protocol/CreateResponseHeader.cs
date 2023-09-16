using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Common.Protocol
{
    public delegate THeader CreateResponseHeader<THeader>(
        int correllationId,
        ImmutableArray<TaggedField> taggedFields
    ) where THeader : notnull, ResponseHeader;
}
