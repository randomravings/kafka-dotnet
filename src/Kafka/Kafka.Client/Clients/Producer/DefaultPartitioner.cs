using Kafka.Client.Server;

namespace Kafka.Client.Clients.Producer
{
    internal class DefaultPartitioner :
        IPartitioner
    {
        private DefaultPartitioner() { }
        public static DefaultPartitioner Instance { get; } = new();
        public async ValueTask<int> Select(Cluster cluster, string topic, byte[]? keyBytes) =>
            await new ValueTask<int>(-1);
        public void Close() { }
    }
}
