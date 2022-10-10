namespace Kafka.Client.Clients.Producer
{
    public sealed class ProducerCluster
        : ICluster<ProducerMetadata>
    {
        public ProducerCluster(
            ProducerConfig producerConfig
        )
        { }
        async ValueTask<ProducerMetadata> ICluster<ProducerMetadata>.GetMetadata(
            CancellationToken token
        ) =>
            await new ValueTask<ProducerMetadata>(ProducerMetadata.Emtpy)
        ;
    }
}
