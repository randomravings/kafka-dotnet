namespace Kafka.Common.Model
{
    public readonly record struct NodeId(
        int Value
    )
    {
        public static readonly NodeId Empty = new(-1);
        public static implicit operator NodeId(int value) => new(value);
        public static implicit operator int(NodeId value) => value.Value;
        public static bool operator <=(NodeId a, NodeId b) => a.Value <= b.Value;
        public static bool operator >=(NodeId a, NodeId b) => a.Value >= b.Value;
        public static bool operator <(NodeId a, NodeId b) => a.Value < b.Value;
        public static bool operator >(NodeId a, NodeId b) => a.Value > b.Value;
    }
}
