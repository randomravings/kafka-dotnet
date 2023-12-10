namespace Kafka.Client.Collections.Internal
{
    public delegate int KeyHash<TKey>(in TKey key);
}
