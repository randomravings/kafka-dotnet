namespace Kafka.Client.Collections
{
    public delegate int CompareDelegate<TType, TKey>(in TKey left, in TType right);
}
