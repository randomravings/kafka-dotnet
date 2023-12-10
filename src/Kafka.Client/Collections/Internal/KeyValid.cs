namespace Kafka.Client.Collections.Internal
{
    public delegate bool KeyValid<TKey>(in TKey key);
}
