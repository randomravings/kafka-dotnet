namespace Kafka.Common.Encoding
{
    public delegate TItem DecodeDelegate<TItem>(ref ReadOnlyMemory<byte> buffer);
}
