namespace Kafka.Client.Clients.Producer
{
    internal class DefaultPartitioner :
        IPartitioner
    {
        private DefaultPartitioner() { }
        public static DefaultPartitioner Instance { get; } = new();
        public async ValueTask<int> Select(ICluster<ProducerMetadata> cluster, string topic, byte[]? keyBytes) =>
            await new ValueTask<int>(-1);
        public void Close() { }
    }
}
