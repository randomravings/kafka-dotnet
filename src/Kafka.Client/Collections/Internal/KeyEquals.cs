namespace Kafka.Client.Collections.Internal
{
    public delegate bool KeyEquals<TKey>(in TKey left, in TKey right);
    public delegate bool KeyEquals<TItem, TKey>(in TItem left, in TKey right);
}
