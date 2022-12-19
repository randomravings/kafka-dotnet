namespace Kafka.Common.Encoding
{
    public delegate TItem DecodeDelegate<TItem>(
        byte[] buffer,
        ref int index
    );
}
