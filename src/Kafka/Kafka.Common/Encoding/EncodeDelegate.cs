namespace Kafka.Common.Encoding
{
    public delegate Memory<byte> EncodeDelegate<TItem>(Memory<byte> buffer, TItem item);
}
