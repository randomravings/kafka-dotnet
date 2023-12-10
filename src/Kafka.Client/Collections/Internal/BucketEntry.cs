namespace Kafka.Client.Collections.Internal
{
    internal sealed class BucketEntry<TKey, TValue>
    {
        public BucketEntry()
        {
            Bucket = default;
            KeyValue = default;
            Next = default;
        }
        public BucketEntry(
            Bucket<TKey, TValue> bucket,
            TKey key,
            TValue value,
            BucketEntry<TKey, TValue>? next
        )
        {
            Bucket = bucket;
            KeyValue = new(key, value);
            Next = next;
        }
        public Bucket<TKey, TValue> Bucket { get; set; }
        public BucketEntry<TKey, TValue>? Next { get; set; }
        public KeyValuePair<TKey, TValue> KeyValue { get; set; }
    }
}
