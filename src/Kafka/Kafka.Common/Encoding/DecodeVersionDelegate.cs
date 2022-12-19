namespace Kafka.Common.Encoding
{
    public delegate TItem DecodeVersionDelegate<TItem>(
        byte[] buffer,
        ref int index,
        short version
    );
}
