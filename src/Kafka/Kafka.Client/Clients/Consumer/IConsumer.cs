using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    public interface IConsumer<TKey, TValue> :
        IClient
    {
        ValueTask<ImmutableSortedDictionary<TopicName, ImmutableArray<PartitionWatermark>>> QueryWatermarks(TopicList topics, CancellationToken cancellationToken = default);
        IAsyncEnumerable<ConsumeResult<TKey, TValue>> Read(TopicList topics, CancellationToken cancellationToken = default);
    }
}
