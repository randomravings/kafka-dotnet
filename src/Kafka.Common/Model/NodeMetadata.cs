namespace Kafka.Common.Model
{
    public sealed record NodeMetadata(
        NodeId Id,
        string IdString,
        string Host,
        int Port,
        string Rack
    )
    {
        public static NodeMetadata Empty { get; } = new(
            NodeId.Empty,
            "",
            "",
            0,
            ""
        );
    }
}