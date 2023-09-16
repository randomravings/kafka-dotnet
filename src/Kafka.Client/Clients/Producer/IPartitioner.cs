using Kafka.Common.Model;

namespace Kafka.Client.Clients.Producer
{
    public interface IPartitioner
    {
        ValueTask<Partition> SelectPartition(TopicName topic, int partitionCount, ReadOnlyMemory<byte>? keyBytes, CancellationToken cancellationToken);
    }
}
