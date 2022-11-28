using Kafka.Common.Types;

namespace Kafka.Client.Server
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
            int.MinValue,
            "",
            "",
            0,
            ""
        );
    }
}