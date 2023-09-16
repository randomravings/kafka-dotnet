namespace Kafka.Common.Model
{
    public readonly record struct DecodeResult<TValue>(
        int Offset,
        TValue Value
    );
}
