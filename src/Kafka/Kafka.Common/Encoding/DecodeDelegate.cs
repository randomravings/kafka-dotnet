namespace Kafka.Common.Encoding
{
    public delegate (int Offset, TItem Value) DecodeDelegate<TItem>(
        byte[] buffer,
        int index
    );
}
