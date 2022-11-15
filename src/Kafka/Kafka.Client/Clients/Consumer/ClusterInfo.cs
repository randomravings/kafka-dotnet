namespace Kafka.Client.Clients.Consumer
{
    public sealed record ClusterInfo(
        int? LeaderEpoch
    );
}
