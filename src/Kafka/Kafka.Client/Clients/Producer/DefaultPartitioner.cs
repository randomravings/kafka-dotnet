using Kafka.Client.Server;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Producer
{
    internal class DefaultPartitioner :
        IPartitioner
    {
        private DefaultPartitioner() { }
        public static DefaultPartitioner Instance { get; } = new();
        public async ValueTask<int> Select(Cluster cluster, string topic, ImmutableArray<byte>? keyBytes) =>
            await new ValueTask<int>(-1);
        public void Close() { }
    }
}
