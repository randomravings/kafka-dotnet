namespace Kafka.Client.Server
{
    public readonly record struct ClusterNodeId(
        int Value
    )
    {
        public static readonly ClusterNodeId Empty = new(-1);
        public static implicit operator ClusterNodeId(int value) => new(value);
        public static implicit operator int(ClusterNodeId value) => value.Value;
        public static bool operator <=(ClusterNodeId a, ClusterNodeId b) => a.Value <= b.Value;
        public static bool operator >=(ClusterNodeId a, ClusterNodeId b) => a.Value >= b.Value;
        public static bool operator <(ClusterNodeId a, ClusterNodeId b) => a.Value < b.Value;
        public static bool operator >(ClusterNodeId a, ClusterNodeId b) => a.Value > b.Value;
    }
}
