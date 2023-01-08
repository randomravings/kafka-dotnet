using Kafka.Client.Server;
using Kafka.Common.Types;

namespace Kafka.Client.Clients.Producer
{
    public interface IPartitioner
    {
        ValueTask<Partition> Select(TopicName topic, int partitionCount, ReadOnlyMemory<byte>? keyBytes, CancellationToken cancellationToken);

        /**
         * This is called when partitioner is closed.
         */
        void Close();
    }
}
