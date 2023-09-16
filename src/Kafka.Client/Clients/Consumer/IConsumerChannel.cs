using Kafka.Common.Model;

namespace Kafka.Client.Clients.Consumer
{
    internal interface IConsumerChannel
    {
        Task Seek(TopicPartition topicPartition, DateTimeOffset timestamp);
        Task Seek(TopicPartition topicPartition, Offset offset);
        Task Start(CancellationToken cancellationToken);
        Task Stop(CancellationToken cancellationToken);
    }
}
