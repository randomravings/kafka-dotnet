namespace Kafka.Common.Encoding
{
    public delegate int EncodeVersionDelegate<TItem>(
        byte[] buffer,
        int offset,
        short version,
        TItem item
    );
}
