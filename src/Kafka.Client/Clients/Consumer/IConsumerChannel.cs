using Kafka.Common.Model;
using System.Collections.Concurrent;

namespace Kafka.Client.Clients.Consumer
{
    internal interface IConsumerChannel
    {
        Task FetchLoop { get; }
        Task Start(
            IReadOnlyDictionary<TopicPartition, Offset> topicPartitionOffsets,
            ConcurrentQueue<FetchResultEnumerator> fetchCallbacks,
            ManualResetEventSlim resetEvent,
            CancellationToken cancellationToken
        );
    }
}
