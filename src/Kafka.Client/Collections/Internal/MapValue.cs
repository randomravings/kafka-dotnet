namespace Kafka.Client.Collections.Internal
{
    internal sealed class MapValue<TKey, TValue>(
        TKey key,
        TValue value
    )
    {
        public TKey Key { get; init; } = key;
        public TValue Value { get; set; } = value;
    }
}
