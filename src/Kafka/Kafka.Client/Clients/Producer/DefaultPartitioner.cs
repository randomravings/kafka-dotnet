using Kafka.Client.Server;
using Kafka.Common.Types;

namespace Kafka.Client.Clients.Producer
{
    public class DefaultPartitioner :
        IPartitioner
    {
        private DefaultPartitioner() { }
        public static DefaultPartitioner Instance { get; } = new();
        public async ValueTask<int> Select(Cluster cluster, TopicName topic, ReadOnlyMemory<byte>? keyBytes, CancellationToken cancellationToken) =>
            await new ValueTask<int>(0);
        public void Close() { }
    }
}
