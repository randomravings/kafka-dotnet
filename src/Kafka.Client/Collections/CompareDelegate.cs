namespace Kafka.Client.Collections
{
    public delegate int CompareKey<TKey>(in TKey left, in TKey right);
    public delegate int CompareKey<TItem, TKey>(in TItem left, in TKey right);
}
