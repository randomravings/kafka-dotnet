namespace KafkaGraphQL.Model
{
    public sealed class Record
    {
        public Guid TopicId { get; set; }
        public string TopicName { get; set; } = "";
        public int Partition { get; set; }
        public long Offset { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}
