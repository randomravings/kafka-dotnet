using Kafka.Common.Model;

namespace Kafka.Client.Clients.Consumer
{
    internal interface IConsumerChannel :
        IDisposable
    {
        ClusterNodeId NodeId { get; }
        IReadOnlyList<TopicPartition> Assignments { get; }
        Task Start(IReadOnlyDictionary<TopicPartition, Offset> topicPartition, CancellationToken cancellationToken);
        Task Stop(CancellationToken cancellationToken);
    }
}
