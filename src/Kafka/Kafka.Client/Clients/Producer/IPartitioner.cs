using Kafka.Client.Server;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    public interface IPartitioner
    {
        ValueTask<int> Select(Cluster cluster, string topic, ImmutableArray<byte>? keyBytes);

        /**
         * This is called when partitioner is closed.
         */
        void Close();
    }
}
