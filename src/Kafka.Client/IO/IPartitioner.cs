using Kafka.Common.Model;

namespace Kafka.Client.IO
{
    public interface IPartitioner
    {
        ValueTask<Partition> SelectPartition(TopicName topic, int partitionCount, ReadOnlyMemory<byte>? keyBytes, CancellationToken cancellationToken);
    }
}
