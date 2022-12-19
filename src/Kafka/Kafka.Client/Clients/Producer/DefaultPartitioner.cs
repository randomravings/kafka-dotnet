using Kafka.Client.Server;
using Kafka.Common.Types;

namespace Kafka.Client.Clients.Producer
{
    internal class DefaultPartitioner :
        IPartitioner
    {
        private DefaultPartitioner() { }
        public static DefaultPartitioner Instance { get; } = new();
        public async ValueTask<int> Select(Cluster cluster, TopicName topic, byte[]? keyBytes) =>
            await new ValueTask<int>(0);
        public void Close() { }
    }
}
