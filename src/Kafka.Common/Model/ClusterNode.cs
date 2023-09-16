namespace Kafka.Common.Model
{
    public sealed record ClusterNode(
        ClusterNodeId Id,
        string IdString,
        string Host,
        int Port,
        string Rack
    )
    {
        public static ClusterNode Empty { get; } = new(
            ClusterNodeId.Empty,
            "",
            "",
            0,
            ""
        );
    }
}