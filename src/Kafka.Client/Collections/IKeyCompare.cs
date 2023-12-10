namespace Kafka.Client.Collections
{
    public interface IKeyCompare<TKey>
    {
        bool IsValid(in TKey key);
        bool IsValid<TValue>(in TValue value, in Func<TValue, TKey> key);
        int Compare(in TKey left, in TKey right);
        int Compare<TValue>(in TValue left, in TKey right, in Func<TValue, TKey> key);
        bool Equals(in TKey left, in TKey right);
        bool Equals<TValue>(in TValue left, in TKey right, in Func<TValue, TKey> key);
        int GetHashCode(in TKey key);
        int GetHashCode<TValue>(in TValue value, in Func<TValue, TKey> key);
    }
}
