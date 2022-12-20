namespace Kafka.Client.Clients.Consumer
{
    public sealed record ClusterInfo(
        int? LeaderEpoch
    )
    {
        public static ClusterInfo Empty { get; } = new(-1);
    }
}
