namespace Kafka.Common.Encoding
{
    public delegate int EncodeDelegate<TItem>(
        byte[] buffer,
        int offset,
        TItem item
    );
}
