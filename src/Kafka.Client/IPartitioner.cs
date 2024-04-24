using Kafka.Common.Model;

namespace Kafka.Client
{
    public interface IPartitioner
    {
        Partition SelectPartition(
            in int partitionCount,
            in ReadOnlyMemory<byte>? keyBytes
        );
    }
}
