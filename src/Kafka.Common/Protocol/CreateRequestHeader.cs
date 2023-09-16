using Kafka.Common.Model;
using System.Collections.Immutable;

namespace Kafka.Common.Protocol
{
    public delegate THeader CreateRequestHeader<THeader>(
        int correllationId,
        string clientId,
        ImmutableArray<TaggedField> taggedFields
    ) where THeader : notnull, RequestHeader;
}
