namespace Kafka.Common.Encoding
{
    public delegate (int Offset, TItem Value) DecodeVersionDelegate<TItem>(
        byte[] buffer,
        int index,
        short version
    );
}
