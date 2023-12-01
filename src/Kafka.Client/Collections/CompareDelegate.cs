namespace Kafka.Client.Collections
{
    public delegate int CompareDelegate<TKey>(in TKey left, in TKey right);
    public delegate int CompareDelegate<TItem, TKey>(in TItem left, in TKey right);
}
