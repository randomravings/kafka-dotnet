namespace Kafka.Client.Collections.Internal
{
    public delegate int KeyCompare<TKey>(in TKey left, in TKey right);
    public delegate int KeyCompare<TItem, TKey>(in TItem left, in TKey right);
}
