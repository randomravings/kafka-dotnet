namespace Kafka.Client.Clients.Producer
{
    public interface IPartitioner
    {
        ValueTask<int> Select(ICluster<ProducerMetadata> cluster, string topic, byte[]? keyBytes);

        /**
         * This is called when partitioner is closed.
         */
        void Close();
    }
}
