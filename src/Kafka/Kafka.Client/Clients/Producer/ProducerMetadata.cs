namespace Kafka.Client.Clients.Producer
{
    public sealed record ProducerMetadata(
        string ClusterId
    ) :
        ClusterMetadata(
            ClusterId
        )
    {
        public static ProducerMetadata Emtpy { get; } =
            new(
                ""
            )
        ;
    }
}