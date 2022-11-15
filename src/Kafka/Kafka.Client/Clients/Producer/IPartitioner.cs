using Kafka.Client.Server;

namespace Kafka.Client.Clients.Producer
{
    public interface IPartitioner
    {
        ValueTask<int> Select(Cluster cluster, string topic, byte[]? keyBytes);

        /**
         * This is called when partitioner is closed.
         */
        void Close();
    }
}
