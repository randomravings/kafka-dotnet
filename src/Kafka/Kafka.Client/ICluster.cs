namespace Kafka.Client
{
    public interface ICluster<TMetadata>
        where TMetadata : ClusterMetadata
    {
        public ValueTask<TMetadata> GetMetadata(
            CancellationToken token = default
        );
    }
}