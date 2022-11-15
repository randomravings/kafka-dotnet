namespace Kafka.Common.Records
{
    public readonly struct RecordValue
    {
        public RecordValue()
        {
            HasValue = false;
            Bytes = ReadOnlyMemory<byte>.Empty;
        }
        public RecordValue(in ReadOnlyMemory<byte> bytes)
        {
            HasValue = true;
            Bytes = bytes;
        }
        public readonly bool HasValue { get; }
        public readonly ReadOnlyMemory<byte> Bytes { get; }
    }
}
