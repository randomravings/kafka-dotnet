namespace Kafka.Common.Encoding
{
    public delegate int EncodeVersionDelegate<TItem>(
        byte[] buffer,
        int offset,
        TItem item,
        short version
    );
}
