namespace Kafka.Client
{
    public sealed record ClusterNode(
        int Id,
        string IdString,
        string Host,
        int Port,
        string Rack
    );
}