namespace Kafka.Common.Encoding
{
    public delegate Memory<byte> EncodeVersionDelegate<TItem>(Memory<byte> buffer, short version, TItem item);
}
