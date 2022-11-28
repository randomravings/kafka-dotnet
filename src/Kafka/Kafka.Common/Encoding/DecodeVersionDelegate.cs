namespace Kafka.Common.Encoding
{
    public delegate TItem DecodeVersionDelegate<TItem>(ref ReadOnlyMemory<byte> buffer, short version);
}
