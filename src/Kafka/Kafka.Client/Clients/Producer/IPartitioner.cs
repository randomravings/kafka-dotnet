using Kafka.Client.Server;
using Kafka.Common.Model;

namespace Kafka.Client.Clients.Producer
{
    public interface IPartitioner
    {
        ValueTask<Partition> Select(TopicName topic, int partitionCount, ReadOnlyMemory<byte>? keyBytes, CancellationToken cancellationToken);
    }
}
