using Kafka.Client.Messages;
using Kafka.Common.Model;

namespace Kafka.Client.Clients.Consumer.Models
{
    internal readonly record struct FetchCallback(
        FetchResponse FetchResponse,
        TaskCompletionSource<IReadOnlyDictionary<TopicPartition, Offset>> TaskCompletionSource
    );
}
